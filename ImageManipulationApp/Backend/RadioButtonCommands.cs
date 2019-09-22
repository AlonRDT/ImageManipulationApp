using System.Collections;
using System.Collections.Generic;

namespace Backend
{
    public class RadioButtonCommands : IEnumerable
    {
        private readonly List<ChangeImageFormatCommandInfo> m_Commands;

        public RadioButtonCommands()
        {
            m_Commands = new List<ChangeImageFormatCommandInfo>()
            {
                 new ChangeImageFormatCommandInfo() { RadioButtonName = "RGB",  ImageFormat = Convolver.ChangePixelFromRGBToRGB},
                 new ChangeImageFormatCommandInfo() { RadioButtonName = "BGR", ImageFormat = Convolver.ChangePixelFromRGBToBGR},
                 new ChangeImageFormatCommandInfo() { RadioButtonName = "Grayscale", ImageFormat = Convolver.ChangePixelFromRGBToGrayscale},
                 new ChangeImageFormatCommandInfo() { RadioButtonName = "HSV", ImageFormat = Convolver.ChangePixelFromRGBToHSV}
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < m_Commands.Count; i++)
            {
                yield return m_Commands[i];
            }
        }
    }
}
