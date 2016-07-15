using System;

namespace Common
{
    internal static class SubstringExtensions
    {
        public static string Between(this string value, string a, string b)
        {
            var posA = value.IndexOf(a, StringComparison.Ordinal);
            var posB = value.LastIndexOf(b, StringComparison.Ordinal);

            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            var adjustedPosA = posA + a.Length;

            return adjustedPosA >= posB ? "" : value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}