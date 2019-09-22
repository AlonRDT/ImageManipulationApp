using System;
using System.Drawing;
using System.Windows.Forms;
using Backend;

namespace ImageManipulationApp
{
    internal class RadioButtonWIthCommand : RadioButton
    {
        private Func<Color, Color> ImageFormatStrategy { get; set; }

        private Facade facade { get; }

        public RadioButtonWIthCommand(ChangeImageFormatCommandInfo i_CreationInfo, Facade i_Facade)
        {
            facade = i_Facade;
            this.Text = i_CreationInfo.RadioButtonName;
            ImageFormatStrategy = i_CreationInfo.ImageFormat;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (this.Checked == true)
            {
                facade.ImageManipulationConvolver.ChangeImageFormatStrategy = ImageFormatStrategy;
                facade.ProcessImage();
            }

            base.OnCheckedChanged(e);
        }
    }
}
