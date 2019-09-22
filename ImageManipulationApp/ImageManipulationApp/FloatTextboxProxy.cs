using Backend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageManipulationApp
{
    internal class FloatTextboxProxy : TextBox
    {
        private string LastParsableFloatValue { get; set; }

        private Facade DataBindedDatabase { get; set; }

        private bool Convolve { get; set; }

        public FloatTextboxProxy(Facade i_DataBindedDatabase, int i_Width, int i_Height)
        {
            DataBindedDatabase = i_DataBindedDatabase;
            this.Enabled = false;
            this.Visible = false;
            this.TabIndex = i_Width + (i_Height * (int)eGuidelines.RowEncryptionKey);
            this.Size = new Size(40, 40);
            this.SetTextWithoutImageProcessing("0");

            // there will be no two boxes straight in any direction with the same color, color of text also adjusted
            this.BackColor = (i_Height + i_Width) % 2 == 0 ? Color.Black : Color.Orange;
            this.ForeColor = (i_Height + i_Width) % 2 == 0 ? Color.White : Color.Black;
            this.Location = new Point((i_Width * 45) + 10, (i_Height * 45) + 40);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            float textboxFloat;
            if (!float.TryParse(this.Text, out textboxFloat))
            {
                this.Text = LastParsableFloatValue;
            }
            else
            {
                DataBindedDatabase.UpdateCurrentKernel(textboxFloat, this.TabIndex);
                if (Convolve)
                {
                    DataBindedDatabase.ProcessImage();
                }
            }

            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            else
            {
                LastParsableFloatValue = this.Text;
            }
        }

        public void SetTextWithoutImageProcessing(string i_NewText)
        {
            Convolve = false;
            this.Text = i_NewText;
            Convolve = true;
        }
    }
}
