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

using System.Reflection;
using System.Windows.Forms;

namespace VinylDraw
{
    public partial class Help : Form
    {
        public const string help1 = "This program takes as input a graphic file in BMP format and produces as output a sound file in WAV format. " +
            "If the sound file is inscribed on to a disc record using a lathe, an approximation of the original image should (if things are working " +
            "well) be presented as visible sound wave patterns in the inscribed surface. The portion of the original image that will be inscribed " +
            "is limited to a circular ring section whose outer and inner diameters are set using sliders as a portion of the imported image. " +
            "The thickness of the ring is determined by the disc cutting parameters listed below.  The generated WAV file is: Mono 16 bit 44.1Khz.";
        public const string help2 = "Disc Cutting parameters:\r\n\r\nStart Radius - On the blank disc, the radius " +
            "at which the inscription will start.\r\n\r\nEnd Radius - On the blank disc, the radius at which the inscription will end. This should be the end of " +
            "the recorded programme material, not the locked groove.\r\n\r\nLPI - The number of windings of the groove that will occupy each " +
            "linear inch of radius.\r\n\r\nTurntable RPM - The speed of the recording lathe platter.  The duration of the cut is displayed based on the parameters. ";
        public const string help3 = "BMP File Details:\r\n" +
            "This program only supports 24 bit BMP files with square dimensions.  Any color information is reduced to a greyscale internally. " +
            "A preview box is provided showing the start and end radii using a RED circle for the start and GREEN for the end of the image data.";
        public const string help4 = "Carrier Frequency:\r\n\r\n" +
            "The Carrier Frequecny slider along with the RPM sets the size of each pixel in the radial scan.  This, in effect, sets the radial resolution of the image. " +
            "For exmaple, if 500 hz and 45 RPM is selected, each radial pixel will be 88 samples (at 44.1Khz) and there will be 668 pixels per rev.\r\n\r\n" +
            "Sync - If checked, a sync pulse is generated in the WAV file for each revolution.  This can be used with external hardware to sync up the playback " +
            "using a optical sensor on the turntable to halt playback until the sensor is detected.  This will prevent the slow drift of the image due to small speed errors. " +
            "For this to work, there must be a small amount of deadband such that the image scan line completes a bit early.  To accomplish this, a deadband dropbox " +
            "is provided.  This forces the image to be played back slightly faster.  Selecting 1.001 increases the playback speed by 1 percent. " +
            "This will allow for speed errors to be comensated for.";
        public string help5 = "This version built " + BMPtoWAV.Properties.Resources.BuildDate + "Copyright © David Nelson Modified by Mark Robinson, 2022.";

        public Help()
        {
            InitializeComponent();
            txtHelp1.Text = help1;
            txtHelp2.Text = help2;
            txtHelp3.Text = help3;
            txtHelp4.Text = help4;
            txtHelp5.Text = help5;
         }


    }
}
