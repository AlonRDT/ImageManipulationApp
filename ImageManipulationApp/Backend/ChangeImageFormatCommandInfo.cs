using System;
using System.Drawing;

namespace Backend
{
    public class ChangeImageFormatCommandInfo
    {
        public string RadioButtonName { get; set; }

        public Func<Color, Color> ImageFormat { get; set; }
    }
}
