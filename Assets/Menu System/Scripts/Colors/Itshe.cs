// -----------------------------------------------------------------
// Author: Taavet Maask	Date: 3/16/2020
// Copyright: © Digital Sputnik OÜ
// -----------------------------------------------------------------

using System;

namespace MenuSystem.Colors
{
    [Serializable]
    public class Itshe
    {
        public float I;
        public float T;
        public float S;
        public float H;
        public float E;

        public Itshe()
        {
            I = 1.0f;
            T = ColorUtils.DEFAULT_TEMPERATURE;
            S = 0.0f;
            H = 0.0f;
            E = 0.0f;
        }

        public Itshe(float i, float t, float s, float h, float e)
        {
            I = i;
            T = t;
            S = s;
            H = h;
            E = e;
        }

        public static bool operator ==(Itshe self, Itshe other)
        {
            return
                Math.Abs(self.I - other.I) < 0.001f &&
                Math.Abs(self.T - other.T) < 0.001f &&
                Math.Abs(self.S - other.S) < 0.001f &&
                Math.Abs(self.H - other.H) < 0.001f &&
                Math.Abs(self.E - other.E) < 0.001f;
        }

        public static bool operator !=(Itshe self, Itshe other)
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

        public Itshe Clone() => (Itshe) MemberwiseClone();

        public override string ToString() => $"[{I}, {T}, {S}, {H}, {E}]";
    }
}
