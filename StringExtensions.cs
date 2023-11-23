using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConvertTypesUtil
{
    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(this string source)
        {
            if (source is null) throw new ArgumentNullException();
            if (decimal.TryParse(source, NumberStyles.Any, source.GetCulture(), out decimal result))
            {
                return result;
            }
            throw new ArgumentException();
        }

        private static string GetNotNumbers(this string source)
        {
            return new string(source.Where(c => !char.IsDigit(c)).Distinct().ToArray());
        }

        private static NumberFormatInfo GetCulture(this string source)
        {
            var seporators = source.GetNotNumbers();
            var nfi = new CultureInfo("ru-RU").NumberFormat;

            switch (seporators.Length)
            {
                case 0:
                    break;
                case 1:
                    nfi.NumberDecimalSeparator = seporators[0].ToString();
                    break;
                case 2:
                    nfi.NumberDecimalSeparator = seporators[1].ToString();
                    nfi.NumberGroupSeparator = seporators[0].ToString();
                    break;
                default: throw new ArgumentException();
            }
            return nfi;
        }
    }
}