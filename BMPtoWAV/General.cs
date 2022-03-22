// This file is part of Vinyl Draw.
//
// Vinyl Draw is free software: you can redistribute it and/or modify it under the
// terms of the GNU General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
//
// Vinyl Draw is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY,
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with Vinyl Draw.
// If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VinylDraw
{
    public static class Constants
    {
        public const int SampleRate = 44100;
        public const int dfltCarrier = 2;           // 500 hz
        public const int dfltLPcm = 10;             //  200 lpi
        public const int dfltSelectedIndex = 5;     // 45 rpm
        public const bool dfltsync = true;          // generate a sync
        
        
    }
    
    [Serializable]
    public struct bmpHeader
    {
        public short Id;
        public int FileLength;
        public int Unused;
        public int BmpOffset;
        public int DibHeaderLength;
        public int WidthPx;
        public int HeightPx;
        public short ColourPlanes;
        public short BitsPerPx;
        public int BytesPerRow;
        public int Compression;
        public int ImageSize;
        public int HorizRes;
        public int VertRes;
        public int ColoursInPalette;
        public int ImportantColours;
        public int ColourTableHeader;
        public bool RowsReversed;

        /// <summary>
        /// Populates the fields of the BMP header by name with data read from the file.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bmpHeader Populate(byte[] data)
        {
            var br = new BinaryReader(new MemoryStream(data));
            var bh = default(bmpHeader);
            int height;
            bh.Id = br.ReadInt16();
            bh.FileLength = br.ReadInt32();
            bh.Unused = br.ReadInt32();
            bh.BmpOffset = br.ReadInt32();
            bh.DibHeaderLength = br.ReadInt32();
            bh.WidthPx = br.ReadInt32();

            height = br.ReadInt32();
            if (height < 0)
            {
                bh.HeightPx = -height;
                bh.RowsReversed = true;
            }
            else
            {
                bh.HeightPx = height;
                bh.RowsReversed = false;
            }
            bh.ColourPlanes = br.ReadInt16();
            bh.BitsPerPx = br.ReadInt16();
            bh.BytesPerRow = (bh.BitsPerPx * bh.WidthPx + 31) / 32 * 4;
            bh.Compression = br.ReadInt32();
            bh.ImageSize = br.ReadInt32();
            bh.HorizRes = br.ReadInt32();
            bh.VertRes = br.ReadInt32();
            bh.ColoursInPalette = br.ReadInt32();
            bh.ImportantColours = br.ReadInt32();
            return bh;
        }

    }

    public static class BMPAdmin
    {
        public static bmpHeader BMPHdr;
        public static double [,]BMPImageDataGrey;
        public static Bitmap BMPPreview;
        public static Bitmap BMPClone;

        /// <summary>
        /// Open and read a BMP file into memory.
        /// </summary>
        /// <param name="iFileName"></param>
        public static void OpenBMPFile(string iFileName)
        {
            byte[] data = new byte[0x36];
            int bytesRead = 0;
            
            BMPHdr = new bmpHeader();
            using (FileStream fs = new FileStream(iFileName, FileMode.Open))
            {
                // Read the first 0x36 bytes and populate the BMP header struct
                bytesRead = fs.Read(data, 0, 0x36);
                BMPHdr = bmpHeader.Populate(data);
                // Check for errors in file
                if (BMPHdr.Id != 0x4D42) throw new Exception("Not recognised as a BMP file");
                if (BMPHdr.BitsPerPx != 24) throw new Exception("Vinyl Draw only supports 24 bit BMP's");
                if (BMPHdr.Compression != 0) throw new Exception("Compressed BMPs are not supported at present!");
                if (BMPHdr.HeightPx != BMPHdr.WidthPx) throw new Exception("BMP Must be square");
                // Define image array size now dimensions are known
                BMPImageDataGrey = new double[BMPHdr.HeightPx, BMPHdr.WidthPx];
                // Move to start of bitmap data
                fs.Position = BMPHdr.BmpOffset;
                // Process the bitmap data
                for (int iRow = 0; iRow < BMPHdr.HeightPx; iRow++)
                {
                    bytesRead = 0;
                    int iCol = 0;
                    while (bytesRead < BMPHdr.BytesPerRow)
                    {
                        // If we're at the RHS of the image, read any padding bytes
                        if (iCol > BMPHdr.WidthPx - 1)
                        {
                            bytesRead += fs.Read(data, 0, BMPHdr.BytesPerRow - bytesRead);
                            break;
                        }
                        bytesRead += fs.Read(data, 0, 3);
                        // Calculate the grey scale from the three bytes,
                        // reversing the order for B, G, R, and add this new data to the image.
                        BMPImageDataGrey[iRow, iCol++] = CalcGreyData(data[2], data[1], data[0]);
                    }
                }
                fs.Close();
                BMPPreview = LoadImageSafe(iFileName);  //create the preview bmp
                BMPClone = LoadImageSafe(iFileName);  //create a copy

            }

        }

        /// <summary>Loads an image without locking the underlying file.</summary>
        /// <param name="path">Path of the image to load</param>
        /// <returns>The image</returns>
        public static Bitmap LoadImageSafe(String path)
        {
            using (Bitmap sourceImage = new Bitmap(path))
            {
                Bitmap clone = (Bitmap)sourceImage.Clone();
                sourceImage.Dispose();
                return (clone);
            }
        }

        /// <summary>
        /// Calculates Grey level from RGB data
        /// The 'colours' are inverted first.
        /// </summary>
        /// <param name="iR"></param>
        /// <param name="iG"></param>
        /// <param name="iB"></param>
        /// <returns></returns>
        private static double CalcGreyData(byte iR, byte iG, byte iB)
        {
            // Convert bytes to doubles, flipping bit-values so that colours are inverted
            // (so 'black' becomes 'white' etc)
            double dR = (byte)~iR;
            double dG = (byte)~iG;
            double dB = (byte)~iB;
            double Grey;

            Grey = (byte)((0.299 * dR) + (0.587 * dG) + (0.114 * dB));
            if (Grey > 255.0d)  // limit to valid range
                Grey = 255.0d;
            return Grey;
        }

    }    

	public class WAVAdmin
    {
        public double dsOuterRadiusCm;
		public double dsInnerRadiusCm;
		public double dsLPcm;
		public double TTrpm;
		public int stepsPerRev;
		public double angStep;
		public double numLines;
		public int samplesPerRev;
		public int samplesPerStep;
		public int samplesTotal;
		public int sampleBytes;
		public int fileSize;
		public List<byte> sampleData;
        public int numSampPerCycle;
        public bool UseSync;
        public byte[] HeaderBytes = { 0x52, 0x49, 0x46, 0x46, 0x00, 0x00, 0x00, 0x00, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20,
									  0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x44, 0xAC, 0x00, 0x00, 0x88, 0x58, 0x01, 0x00,
									  0x02, 0x00, 0x10, 0x00, 0x64, 0x61, 0x74, 0x61, 0x00, 0x00, 0x00, 0x00};
		public EventHandler<ProgressEventArgs> ProgressChanged;
		public EventHandler<ProcessingEndedEventArgs> ProcessingEnded;


        /// <summary>
        /// Constructor for WAV file. Parameter values are lifted from the 
        /// settings specified by the user on the main panel.
        /// </summary>
        /// <param name="idsOuterRadiusCm"></param>
        /// <param name="idsInnerRadiusCm"></param>
        /// <param name="idsLPcm"></param>
        /// <param name="iTTrpm"></param>
        /// <param name="iCarrier"></param>
        /// <param name="iUseSync"></param>
        /// /// <param name="iDeadband"></param>
        public WAVAdmin(double idsOuterRadiusCm, double idsInnerRadiusCm, double idsLPcm, double iTTrpm, int iCarrier, bool iUseSync, double iDeadband)
        {
            try
            {
                UseSync = iUseSync;
                numSampPerCycle = (Constants.SampleRate / iCarrier);
                dsOuterRadiusCm = idsOuterRadiusCm;
                dsInnerRadiusCm = idsInnerRadiusCm;
                dsLPcm = idsLPcm;
                if (UseSync)
                    TTrpm = iTTrpm * iDeadband;  //Set speed a bit faster than desired to make sure we finish scan a bit early before sync from platter
                else
                    TTrpm = iTTrpm;
                numLines = (dsOuterRadiusCm - dsInnerRadiusCm) * dsLPcm;
                stepsPerRev = (int)(((double)Constants.SampleRate / (double)numSampPerCycle * 60.0) / TTrpm);
                angStep = (360.0d / stepsPerRev) * Math.PI / 180.0d;
                samplesPerRev = (int)((Constants.SampleRate * 60.0) / TTrpm);
                sampleData = new List<byte>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred wrtiting the WAV file.");
            }


        }
		
        /// <summary>
        /// Once the WAVAdmin object has been created, this method is called.
        /// It extracts an annular section of the input BMP, starting from halfway down the
        /// RHS of the image, moving anticlockwise and slowly spiralling inward at the
        /// specified groove pitch until the specified inner radius is reached.
        /// </summary>
		public void PrepareWAV()
        {
			double theta;
			int stepsMade;
            int imCentreX = BMPAdmin.BMPHdr.WidthPx / 2;
            int imCentreY = BMPAdmin.BMPHdr.HeightPx / 2;
            double maxRadiusCm = Form1.pixelRes * 50.0;
            double imStartRadius = imCentreX * (dsOuterRadiusCm/ maxRadiusCm) ;
			double imEndRadius = imCentreX * (dsInnerRadiusCm / maxRadiusCm);
			double imStep = (imStartRadius - imEndRadius) / numLines;
			int imRow, imCol;
            int pad;
            int i;

            // Traverse the image from edge towards the centre
            for (double r = imStartRadius; r > imEndRadius; r -= imStep)
            {
                if (UseSync)
                { 
                sampleData.Add((byte)0xff);             // add a sync pule each rev
                sampleData.Add((byte)0x7f);
                ++samplesTotal;
                }
                for (theta = 0, stepsMade = 0; stepsMade < stepsPerRev; theta += angStep, stepsMade++)
                {
                    // Calculate the row (y) of the BMP to use. As theta moves from
                    // 0 to 2*PI, the radius as calculated in the second term 
                    // gradually decreases by one imStep - effectively describing one
                    // revolution of a spiral.
                    imRow = (int)(Math.Sin(theta) * (r - (theta * imStep / (2 * Math.PI))));
                    // If the rows are *not* reversed, flip the sign of imRow - in a normal
                    // BMP with positive height, the rows appear in the file in reverse order.
                    // If the height is negative, the rows are in top-to-bottom order already.
                    if (!BMPAdmin.BMPHdr.RowsReversed)
                    {
                        imRow = imCentreY + imRow;
                    }
                    else
                    {
                        imRow = imCentreY - imRow;
                    }
                    // Calculate the column (x) of the BMP to use in a similar manner.
                    imCol = (int)(imCentreX + Math.Cos(theta) * (r - (theta * imStep / (2 * Math.PI))));
                    CreateTone(BMPAdmin.BMPImageDataGrey[imRow, imCol]);
                }
                
                if (!UseSync)
                {
                    // pad remaining samples
                    pad = samplesPerRev - (stepsMade * numSampPerCycle);
                    for (i = 0; i < pad; ++i)  
                    {
                        sampleData.Add((byte)0x00);
                        sampleData.Add((byte)0x00);
                        ++samplesTotal;
                    }
                }
                // Report progress back to the main form
                FireEventProgressChanged((int)(100 * (imStartRadius - r) / (imStartRadius - imEndRadius)));
            }
            // Store number of samples and file length
            sampleBytes = samplesTotal << 1;
			fileSize = sampleBytes + 36;
			HeaderBytes[40] = (byte)(sampleBytes & 0xFF);
			HeaderBytes[41] = (byte)((sampleBytes >> 8) & 0xFF);
			HeaderBytes[42] = (byte)((sampleBytes >> 16) & 0xFF);
			HeaderBytes[43] = (byte)((sampleBytes >> 24) & 0xFF);
			HeaderBytes[4] = (byte)(fileSize & 0xFF);
			HeaderBytes[5] = (byte)((fileSize >> 8) & 0xFF);
			HeaderBytes[6] = (byte)((fileSize >> 16) & 0xFF);
			HeaderBytes[7] = (byte)((fileSize >> 24) & 0xFF);
			FireEventProcessingEnded("The WAV data has been generated successfully.");
        }

        /// <summary>
        /// Generates a single "point" in the WAV file, taking as input RGB data 
        /// for that point.
        /// </summary>
        /// <param name="iData"></param>
		public void CreateTone(double iAmplMultiplier)
        {
            short ampl;
          
            // Create the right number of samples
            for (int iSamp=0;iSamp< numSampPerCycle; iSamp++)
            {
                // Create a sine wave, calculating the amplitude from the hue data held for the specified pixel.
                // The Sine function returns a value in -1...1, which is multiplied by the value held for the luminosity or saturation
                // (0 - 100) and then multiplied by 326 to give a value in the range -32600...32600
                ampl = (short)(Math.Sin(2.0d * Math.PI * iSamp / numSampPerCycle) * iAmplMultiplier * 127);
                // Add new data point to WAV data
                if (UseSync)
                    ampl = (short)(((float)ampl * 0.9) + 0.5);  // scale amplitude to keep peaks from sync pulse height
                sampleData.Add((byte)(ampl & 0xFF));
				sampleData.Add((byte)((ampl >> 8) & 0xFF));
				samplesTotal++;
            }
         }
		
        public void WriteWAVFile(string iFileName)
		{
			using (FileStream fs = new FileStream(iFileName, FileMode.Create))
			{
				// The 44 bytes of the header
				fs.Write(HeaderBytes, 0, 44);
				// The bytes of actual data (which will number twice the number of samples).
				fs.Write(sampleData.ToArray(), 0, sampleBytes);
				// End gracefully.
				fs.Close();
			}
		}

        /// <summary>
        /// Update main panel with progress information.
        /// </summary>
        /// <param name="iProgress"></param>
		public void FireEventProgressChanged(int iProgress)
        {
			ProgressChanged?.Invoke(this, new ProgressEventArgs(iProgress));
        }

        /// <summary>
        /// Update main panel when processing has finished.
        /// </summary>
        /// <param name="iMessage"></param>
		public void FireEventProcessingEnded(string iMessage)
		{
			ProcessingEnded?.Invoke(this, new ProcessingEndedEventArgs(iMessage));
		}
	}
	public class ProgressEventArgs : EventArgs
    {
		public int Progress { get; set; }
		public ProgressEventArgs(int iProgress)
        {
			Progress = iProgress;
        }
    }
	public class ProcessingEndedEventArgs : EventArgs
    {
		public string Message { get; set; }
		public ProcessingEndedEventArgs(string iMessage)
        {
			Message = iMessage;
        }
    }
}
