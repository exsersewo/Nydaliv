using System;

namespace Exsersewo.Nydaliv.Utilities
{
    public static class NumberUtilities
    {
        public static ulong GetXPLevelRequirement(ulong level, double growthmod)
            => (ulong)Math.Round(Math.Pow(level, 2) * 50 * growthmod, MidpointRounding.AwayFromZero);

        public static ulong GetLevelFromTotalXP(ulong totalxp, double growthmod)
            => (ulong)(Math.Sqrt(totalxp / (50 * growthmod)));
    }
}
