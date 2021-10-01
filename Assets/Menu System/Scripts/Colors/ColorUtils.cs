// -----------------------------------------------------------------
// Author: Taavet Maask	Date: 3/16/2020
// Copyright: © Digital Sputnik OÜ
// -----------------------------------------------------------------

using System;

namespace MenuSystem.Colors
{
    public static class ColorUtils
    {
        public const float DEFAULT_TEMPERATURE = 0.482352941176471f;

        public static Rgb ItsheToRgb(Itshe itshe)
        {
            double h = itshe.H * 360.0;
            double s = itshe.S;
            double v = itshe.I;

            double r;
            double g;
            double b;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                int i;
                double f, p, q, t;

                if (h == 360)
                    h = 0;
                else
                    h /= 60;

                i = (int)Math.Truncate(h);
                f = h - i;

                p = v * (1.0 - s);
                q = v * (1.0 - (s * f));
                t = v * (1.0 - (s * (1.0 - f)));

                switch (i)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;

                    default:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }

            }

            return new Rgb((float)r, (float)g, (float)b);
        }

        public static Rgb[]RgbToArray(Rgb rgb, int length)
        {
            var array = new Rgb[length];
            for (var i = 0; i < length; i++)
                array[i] = rgb;
            return array;
        }

        public static byte[] RgbArrayToBytes(Rgb[] rgbArray)
        {
            var data = new byte[rgbArray.Length * 3];

            for (var i = 0; i < rgbArray.Length; i++)
            {
                var index = i * 3;
                var rgb = rgbArray[i];
                data[index + 0] = rgb.RByte;
                data[index + 1] = rgb.GByte;
                data[index + 2] = rgb.BByte;
            }

            return data;
        }

        public static Rgb[] BytesToRgbArray(byte[] bytes)
        {
            var data = new Rgb[bytes.Length / 3];

            for (var i = 0; i < bytes.Length / 3; i++)
            {
                var index = i * 3;
                var r = bytes[index + 0];
                var g = bytes[index + 1];
                var b = bytes[index + 2];
                data[i] = new Rgb(r, g, b);
            }

            return data;
        }
    }
}
