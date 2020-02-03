namespace Exsersewo.Nydaliv.Extensions
{
    public static class Extensions
    {
        public static float Remap(this float value, float min1, float max1, float min2, float max2)
            => min2 + (max2 - min2) * ((value - min1) / (max1 - min1));
    }
}
