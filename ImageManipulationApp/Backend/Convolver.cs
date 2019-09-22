using System;
using System.Drawing;

namespace Backend
{
    public class Convolver
    {
        public event Action<Bitmap> m_ChangeFrontEndImage;

        public Func<Color, Color> ChangeImageFormatStrategy { get; set; }

        private Bitmap ImageUnderProcessing { get; set; }

        private int KernelHeight { get; set; }

        private int KernelWidth { get; set; }

        private float[,] CurrentKernel { get; set; }

        public Convolver(Action<Bitmap> i_ChangeFrontEndImage, Bitmap i_StartImage)
        {
            m_ChangeFrontEndImage = i_ChangeFrontEndImage;
            ImageUnderProcessing = i_StartImage;
            ChangeImageFormatStrategy = (Color i_CurrentPixel) => i_CurrentPixel;
        }

        public static Color ChangePixelFromRGBToRGB(Color i_PixelColor)
        {
            return i_PixelColor;
        }

        public static Color ChangePixelFromRGBToHSV(Color i_PixelColor)
        {
            int pixelMax = Math.Max(i_PixelColor.R, Math.Max(i_PixelColor.B, i_PixelColor.G));
            Color newColor = Color.FromArgb((int)(i_PixelColor.GetHue() * 255 / 360), (int)(i_PixelColor.GetSaturation() * 255 / 100), pixelMax);
            return newColor;
        }

        public static Color ChangePixelFromRGBToBGR(Color i_PixelColor)
        {
            Color newColor = Color.FromArgb(i_PixelColor.B, i_PixelColor.G, i_PixelColor.R);
            return newColor;
        }

        public static Color ChangePixelFromRGBToGrayscale(Color i_PixelColor)
        {
            int pixelAVG = i_PixelColor.R + i_PixelColor.B + i_PixelColor.G;
            pixelAVG /= 3;
            Color newColor = Color.FromArgb(pixelAVG, pixelAVG, pixelAVG);
            return newColor;
        }

        public void Convolve(int i_KernelHeight, int i_KernelWidth, float[,] i_CurrentKernel, Bitmap i_ImageBeforeProcessing = null)
        {
            KernelHeight = i_KernelHeight;
            KernelWidth = i_KernelWidth;
            if (i_ImageBeforeProcessing != null)
            {
                ImageUnderProcessing = i_ImageBeforeProcessing;
            }

            CurrentKernel = i_CurrentKernel;
            ProcessImage();
        }

        public void ProcessImage()
        {
            float[,,] redGreenBlueColorsAccumulator = new float[(int)eGuidelines.NumberOfColorChannels,
                ImageUnderProcessing.Width, ImageUnderProcessing.Height];
            buildProcessedImageColorMatrices(redGreenBlueColorsAccumulator);
            featureScalingColorMatrices(
                redGreenBlueColorsAccumulator,
                ImageUnderProcessing.Width,
                ImageUnderProcessing.Height);
            Bitmap result = new Bitmap(ImageUnderProcessing.Width, ImageUnderProcessing.Height);
            for (int x = 0; x < ImageUnderProcessing.Width; x++)
            {
                for (int y = 0; y < ImageUnderProcessing.Height; y++)
                {
                    result.SetPixel(
                        x,
                        y,
                        Color.FromArgb(
                            (int)redGreenBlueColorsAccumulator[(int)eGuidelines.Red, x, y],
                            (int)redGreenBlueColorsAccumulator[(int)eGuidelines.Green, x, y],
                            (int)redGreenBlueColorsAccumulator[(int)eGuidelines.Blue, x, y]));
                }
            }

            ChangeImageFormatAndReturnImage(result);
        }

        public void buildProcessedImageColorMatrices(float[,,] i_RedGreenBlueColorsAccumulator)
        {
            Color currentPixel;
            for (int x = 0; x < ImageUnderProcessing.Width; x++)
            {
                for (int y = 0; y < ImageUnderProcessing.Height; y++)
                {
                    i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Red, x, y] = 0;
                    i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Green, x, y] = 0;
                    i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Blue, x, y] = 0;
                    for (int kernelX = 0; kernelX < KernelWidth; kernelX++)
                    {
                        for (int kernelY = 0; kernelY < KernelHeight; kernelY++)
                        {
                            if (!(x + kernelX >= ImageUnderProcessing.Width || y + kernelY >= ImageUnderProcessing.Height))
                            {
                                currentPixel = ImageUnderProcessing.GetPixel(x + kernelX, y + kernelY);
                            }
                            else
                            {
                                currentPixel = ImageUnderProcessing.GetPixel(x, y);
                            }

                            i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Red, x, y] += currentPixel.R * CurrentKernel[kernelX, kernelY];
                            i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Green, x, y] += currentPixel.G * CurrentKernel[kernelX, kernelY];
                            i_RedGreenBlueColorsAccumulator[(int)eGuidelines.Blue, x, y] += currentPixel.B * CurrentKernel[kernelX, kernelY];
                        }
                    }
                }
            }
        }

        private void featureScalingColorMatrices(float[,,] i_RedGreenBlueColorsAccumulator, int i_MatrixWidth, int i_MatrixHeight)
        {
            for (int color = 0; color < (int)eGuidelines.NumberOfColorChannels; color++)
            {
                float maxValueInMatrix = findMaxInColorMatrix(i_RedGreenBlueColorsAccumulator, color, i_MatrixWidth, i_MatrixHeight);
                float minValueInMatrix = findMinInColorMatrix(i_RedGreenBlueColorsAccumulator, color, i_MatrixWidth, i_MatrixHeight);
                for (int x = 0; x < i_MatrixWidth; x++)
                {
                    for (int y = 0; y < i_MatrixHeight; y++)
                    {
                        i_RedGreenBlueColorsAccumulator[color, x, y] -= minValueInMatrix;
                        i_RedGreenBlueColorsAccumulator[color, x, y] *= (int)eGuidelines.MaxRGBValue;
                        if (i_RedGreenBlueColorsAccumulator[color, x, y] != 0)
                        {
                            i_RedGreenBlueColorsAccumulator[color, x, y] /= maxValueInMatrix - minValueInMatrix;
                        }
                    }
                }
            }
        }

        private void ChangeImageFormatAndReturnImage(Bitmap i_ImageToChangeFormat)
        {
            int x, y;

            for (x = 0; x < i_ImageToChangeFormat.Width; x++)
            {
                for (y = 0; y < i_ImageToChangeFormat.Height; y++)
                {
                    Color pixelColor = i_ImageToChangeFormat.GetPixel(x, y);
                    Color newColor = ChangeImageFormatStrategy.Invoke(pixelColor);
                    i_ImageToChangeFormat.SetPixel(x, y, newColor);
                }
            }

            m_ChangeFrontEndImage(i_ImageToChangeFormat);
        }

        private float findMaxInColorMatrix(float[,,] i_RedGreenBlueColorsAccumulator, int i_ColorIndicator, int i_MatrixWidth, int i_MatrixHeight)
        {
            float maxValue = i_RedGreenBlueColorsAccumulator[i_ColorIndicator, 0, 0];
            for (int x = 0; x < i_MatrixWidth; x++)
            {
                for (int y = 0; y < i_MatrixHeight; y++)
                {
                    if (maxValue < i_RedGreenBlueColorsAccumulator[i_ColorIndicator, x, y])
                    {
                        maxValue = i_RedGreenBlueColorsAccumulator[i_ColorIndicator, x, y];
                    }
                }
            }

            return maxValue;
        }

        private float findMinInColorMatrix(float[,,] i_RedGreenBlueColorsAccumulator, int i_ColorIndicator, int i_MatrixWidth, int i_MatrixHeight)
        {
            float minValue = i_RedGreenBlueColorsAccumulator[i_ColorIndicator, 0, 0];
            for (int x = 0; x < i_MatrixWidth; x++)
            {
                for (int y = 0; y < i_MatrixHeight; y++)
                {
                    if (minValue > i_RedGreenBlueColorsAccumulator[i_ColorIndicator, x, y])
                    {
                        minValue = i_RedGreenBlueColorsAccumulator[i_ColorIndicator, x, y];
                    }
                }
            }

            return minValue;
        }
    }
}
