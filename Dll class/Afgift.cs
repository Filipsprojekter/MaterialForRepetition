using System;
using System.Collections.Generic;
using System.Text;

namespace Skat
{
    public class Afgift
    {
        public static double BilAfgift(int pris, string bilType)
        {
            return BeregneMetode(pris, bilType);
        }

        public static double ElBilAfgift(int pris, string bilType)
        {
            return BeregneMetode(pris, bilType);
        }

        private static double BeregneMetode(int pris, string bilType)
        {
            double bilAfgift = 0;

            if (pris <= 0 && pris >= double.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            bilAfgift = pris * 0.85;

            if (pris > 200000)
            {
                bilAfgift = pris * 1.5 - 130000;
            }

            if (bilType == "elbil" || bilType == "Elbil")
            {
                bilAfgift = bilAfgift * 0.20;
                return bilAfgift;
            }

            return bilAfgift;
        }
    }
}
