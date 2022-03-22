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
using System.Windows.Forms;


namespace VinylDraw
{
    
    public partial class Form1 : Form
    {
        public WAVAdmin wav;
        public int CarrierHz;
        public double StartRadiusCm;
        public double EndRadiusCm;
        public double StartRadiusIn;
        public double EndRadiusIn;
        public int LPCm;
        public int LPIn;
        public int StepsPerRev;
        public double TTSpeedRPM;
        public List<SpeedRPM> Speeds;
        public bool UseSync;
        public string bmpfileName;
        public static double pixelRes;
        public double Deadband;

        /// <summary>
        /// Draw form and controls.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            cmdCreateWAVData.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            lblProcessingEnded.Visible = false;
            prgCreate.Visible = false;
            Speeds = new List<SpeedRPM> {
                new SpeedRPM("8⅓", 50.0d / 6.0d),
                new SpeedRPM("16⅔", 100.0d/6.0d),
                new SpeedRPM("22½", 22.5d),
                new SpeedRPM("33⅓", 100.0d/3.0d),
                new SpeedRPM("39", 39.0d),
                new SpeedRPM("45", 45.0d),
                new SpeedRPM("78", 78.0d)};
            lbxSpeedRPM.DisplayMember = "Text";
            lbxSpeedRPM.DataSource = Speeds;
            lbxSpeedRPM.SelectedIndex = 5;
            trkLPcm.Value = Constants.dfltLPcm;
            trkStartRadiusCm.Value = trkStartRadiusCm.Maximum;
            trkEndRadiusCm.Value = trkEndRadiusCm.Maximum / 2;
            trkCarrier.Value = Constants.dfltCarrier;
            sync.Checked = Constants.dfltsync;
            CollectValues();
        }

        /// <summary>
        /// Copy values from panel controls to working storage.
        /// </summary>
        private void CollectValues()
        {
            TimeSpan t;
            double secs;
            double lines;

            CarrierHz = trkCarrier.Value * 250;
            // don't update before we have a valid bmp file
            if (BMPAdmin.BMPHdr.HorizRes != 0)  
            {

                pixelRes = (double)BMPAdmin.BMPHdr.WidthPx / (double)BMPAdmin.BMPHdr.HorizRes;
                StartRadiusIn = ((double)trkStartRadiusCm.Value / (double)trkStartRadiusCm.Maximum) * pixelRes * 19.685d;
                EndRadiusIn = ((double)trkEndRadiusCm.Value / (double)trkEndRadiusCm.Maximum) *  pixelRes * 19.685d;
            }
            // convert inches to cm
            EndRadiusCm = EndRadiusIn * 2.54d;
            StartRadiusCm = StartRadiusIn * 2.54d;
            lblCarrier.Text = CarrierHz.ToString() + " Hz";
            lblStartRadiusIn.Text = string.Format("{0:N2} in", StartRadiusIn);
            lblEndRadiusIn.Text = string.Format("{0:N2} in", EndRadiusIn);
            LPIn = 100 + (trkLPcm.Value * 10);
            lblLPcm.Text = LPIn.ToString();
            // convert inches to cm
            LPCm = (int)(((double)LPIn / 2.54d) + .5d);
            UseSync = (sync.Checked) ? true : false;
            if (UseSync)
            {
                deadbandSel.Visible = true;
                dbLbl.Visible = true;
             }
            else
            {
                deadbandSel.Visible = false;
                dbLbl.Visible = false;
            }
            if (UseSync)
                Deadband = Convert.ToDouble(deadbandSel.SelectedItem);
            else
                Deadband = 1.00;
            lines = (StartRadiusCm - EndRadiusCm) * LPCm;
            secs = (lines * 60) / (TTSpeedRPM * Deadband);
            t = TimeSpan.FromSeconds(secs);
            txtDuration.Text = t.ToString(@"mm\:ss");  // display calculated cutting time
            DrawBmp();  // force a draw of the bmp preview in case boundary markers have changed

        }

        /// <summary>
        /// Open a BMP file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "Select BMP file";
            ofd.CheckPathExists = true;
            ofd.DefaultExt = "bmp";
            ofd.Filter = "BMP files (*.bmp)|*.bmp";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = false;
            ofd.ShowDialog();
            OpenFileDialog open = new OpenFileDialog();
            if (ofd.FileName != "")
            {
                try
                {
                    bmpfileName = ofd.FileName;
                    BMPAdmin.OpenBMPFile(ofd.FileName);
                    cmdCreateWAVData.Enabled = true;
                    lblProcessingEnded.Visible = false;
                    CollectValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occurred while opening the BMP file.");
                }
            }


        }

        /// <summary>
        /// Process BMP file and produce WAV output in working storage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            lblProcessingEnded.Visible = false;
            prgCreate.Value = 0;
            prgCreate.Visible = true;
            CollectValues();
            if (EndRadiusCm >= StartRadiusCm)
            {
                MessageBox.Show("Start radius smaller than end radius", "Error");
                return;
            }
            wav = new WAVAdmin(StartRadiusCm, EndRadiusCm, LPCm, TTSpeedRPM, CarrierHz, UseSync, Deadband);
            wav.ProgressChanged += (o, ex) =>
            {
                prgCreate.Value = ex.Progress;
            };
            wav.ProcessingEnded += (o, ex) =>
            {
                prgCreate.Visible = false;
                lblProcessingEnded.Text = ex.Message;
                lblProcessingEnded.Visible = true;
            };
            wav.PrepareWAV();
            lblProcessingEnded.Visible = true;
            saveToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Write working storage copy of WAV data to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wav != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Application.StartupPath;
                sfd.Title = "Save WAV file";
                sfd.CheckPathExists = true;
                sfd.DefaultExt = "wav";
                sfd.Filter = "WAV files (*.wav)|*.wav";
                sfd.FilterIndex = 0;
                sfd.RestoreDirectory = false;
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    wav.WriteWAVFile(sfd.FileName);
                }
            }
        }
        /// <summary>
        /// Wrapper for event. Called from several controls on panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectValues(object sender, EventArgs e)
        {
            CollectValues();
        }


        private void lbxSpeedRPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTSpeedRPM = (lbxSpeedRPM.SelectedItem as SpeedRPM).Value;
            CollectValues();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Vinyl Draw - Help")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                Help helpForm = new Help();
                helpForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CollectValues();
        }

        private void lblStepsPerRev_Click(object sender, EventArgs e)
        {

        }

        

        private void lblH0_Click(object sender, EventArgs e)
        {

        }

        private void grpAmplChoice_Enter(object sender, EventArgs e)
        {

        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lblLPcm_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }

        public void DrawBmp()
        {
            int startDia;
            int endDia;
            int startCenter;
            int endCenter;
            
            // make sure a bitmap filename has been selected 
            if (bmpfileName != null)
            {
                // display the bitmap preview using a copy
                if (BMPAdmin.BMPClone != null)
                    BMPAdmin.BMPClone.Dispose();
                BMPAdmin.BMPClone = (Bitmap)BMPAdmin.BMPPreview.Clone();
                // draw circles that show start and end boundries
                startDia = (int)((double)(trkStartRadiusCm.Value * BMPAdmin.BMPHdr.WidthPx) / (double)trkStartRadiusCm.Maximum);
                startCenter = (BMPAdmin.BMPHdr.WidthPx / 2) - (startDia / 2);
                endDia = (int)((double)(trkEndRadiusCm.Value * BMPAdmin.BMPHdr.WidthPx) / (double)trkEndRadiusCm.Maximum);
                endCenter = (BMPAdmin.BMPHdr.WidthPx / 2) - (endDia / 2);
                using (Graphics gr = Graphics.FromImage(BMPAdmin.BMPClone))
                {
                    using (Pen thick_pen = new Pen(Color.Red, 10))
                        gr.DrawEllipse(thick_pen, startCenter, startCenter, startDia, startDia);
                     using (Pen thick_pen = new Pen(Color.Green, 10))
                        gr.DrawEllipse(thick_pen, endCenter, endCenter, endDia, endDia);
                    pictureBox1.Image = BMPAdmin.BMPClone;
                }
            }
         }

public class SpeedRPM
        {
            public SpeedRPM(string iText, double iValue)
            {
                Text = iText;
                Value = iValue;
            }
            public string Text { get; set; }
            public double Value { get; set; }
        }

        private void trkCarrier_Scroll(object sender, EventArgs e)
        {

        }

        private void lblFileName_Click(object sender, EventArgs e)
        {

        }

        private void deadbandSel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
