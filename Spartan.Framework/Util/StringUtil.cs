using System;

namespace Spartan.Framework.Util
{
    public static class StringUtil
    {
        public static int ToInt32(string str, int min = 0, int max = 0, int def = 0)
        {
            int num = 0;
            if (!Int32.TryParse(str, out num) && def > 0)
            {
                return def;
            }
            if (min > 0 && num < min)
            {
                return min;
            }
            if (max > 0 && num > max)
            {
                return max;
            }
            return num;
        }
    }
}
