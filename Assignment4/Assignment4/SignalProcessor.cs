using Assignment4.Image;
using System;
using System.Drawing;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            double filterLength = sigma * 6;
            if (filterLength % 2 < 1)
            {
                filterLength++;
            }

            int l = (int)filterLength;

            double[] filter = new double[l];

            int filterMedian = (l / 2);

            for (int i = 0; i < filter.Length; i++)
            {
                filter[i] = GaussianCal(sigma, filterMedian - i);
            }

            return filter;
        }
        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            double[] convolvedSignal = new double[signal.Length];

            for (int i = 0; i < signal.Length; i++)
            {
                int x = filter.Length / 2;
                for (int j = filter.Length - 1; j >= 0; j--)
                {
                    if (i - x >= 0 && i - x < signal.Length)
                    {
                        convolvedSignal[i] += signal[i - x] * filter[j];
                    }
                    x--;
                }
            }
            return convolvedSignal;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            double filterLength = sigma * 6;
            if (filterLength % 2 < 1)
            {
                filterLength++;
            }

            double[,] filter = new double[(int)filterLength, (int)filterLength];

            int filterMedian = (int)filterLength / 2;

            for (int i = 0; i < filter.GetLength(0); i++)
            {
                for (int j = 0; j < filter.GetLength(1); j++)
                {
                    filter[i, j] = GaussianCal(sigma, filterMedian - i, filterMedian - j);
                }
            }

            return filter;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            int height = bitmap.Height;
            int width = bitmap.Width;

            int filterWidthMedian = filter.GetLength(0) / 2;
            int filterHeightMedian = filter.GetLength(1) / 2;

            Bitmap convolvedImage = new Bitmap(width, height);

            var flipedFilter = FlipFilter(filter);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double r = 0;
                    double g = 0;
                    double b = 0;

                    for (int k = 0; k < flipedFilter.GetLength(0); k++)
                    {
                        for (int l = 0; l < flipedFilter.GetLength(1); l++)
                        {
                            if (i - filterHeightMedian + k >= 0 && j - filterWidthMedian + l >= 0 && i - filterHeightMedian + k < height && j - filterWidthMedian + l < width)
                            {
                                Assignment4.Image.Color pixel = bitmap.GetPixel(i - filterHeightMedian + k, j - filterWidthMedian + l);

                                r += (double)pixel.R * flipedFilter[k, l];
                                g += (double)pixel.G * flipedFilter[k, l];
                                b += (double)pixel.B * flipedFilter[k, l];
                            }
                        }
                    }

                    var convolvedPixel = new Assignment4.Image.Color((byte)r, (byte)g, (byte)b);

                    convolvedImage.SetPixel(i, j, convolvedPixel);
                }
            }
            
            return convolvedImage;
        }

        public static double GaussianCal(double sigma, int x)
        {
            if (x < 0)
            {
                x = -x;
            }
            double coefficient = 1.0 / (sigma * Math.Sqrt(2 * Math.PI));
            double exponent = -(x * x) / (2 * (sigma * sigma));

            return coefficient * Math.Exp(exponent);
        }

        public static double GaussianCal(double sigma, int x, int y)
        {
            if (x < 0)
            {
                x = -x;
            }
            if (y < 0)
            {
                y = -y;
            }

            double coefficient = 1.0 / (2 * Math.PI * sigma * sigma);
            double exponent = -((x * x) + (y * y)) / (2 * sigma * sigma);

            return coefficient * Math.Exp(exponent);
        }

        public static double[,] FlipFilter(double[,] filter)
        {
            var flipedFilter = new double[filter.GetLength(0), filter.GetLength(1)];

            for (int i = 0; i < filter.GetLength(0); i++)
            {
                for (int j = 0; j < filter.GetLength(1); j++)
                {
                    flipedFilter[i, j] = filter[filter.GetLength(1) - 1 - j, filter.GetLength(0) - 1 - i];
                }
            }

            return flipedFilter;
        }
    }
}