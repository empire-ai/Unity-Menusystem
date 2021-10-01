// -----------------------------------------------------------------
// Author: Taavet Maask	Date: 3/16/2020
// Copyright: © Digital Sputnik OÜ
// -----------------------------------------------------------------

using System;

namespace MenuSystem.Colors
{
    [Serializable]
    public class Rgb
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public byte RByte
        {
            get => (byte)(R * 255);
            set => R = value / 255.0f;
        }

        public byte GByte
        {
            get => (byte)(G * 255);
            set => G = value / 255.0f;
        }

        public byte BByte
        {
            get => (byte)(B * 255);
            set => B = value / 255.0f;
        }

        public Rgb(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Rgb(byte r, byte g, byte b)
        {
            RByte = r;
            GByte = g;
            BByte = b;
        }

        public static bool operator ==(Rgb self, Rgb other)
        {
            return
                Math.Abs(self.R - other.R) < 0.001f &&
                Math.Abs(self.G - other.G) < 0.001f &&
                Math.Abs(self.B - other.B) < 0.001f;
        }

        public static bool operator !=(Rgb self, Rgb other)
        {
            return !(self == other);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() => $"[{R}, {G}, {B}]";
    }
}
