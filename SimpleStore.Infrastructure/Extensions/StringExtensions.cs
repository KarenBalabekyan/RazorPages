using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleStore.DataAccess.Extensions
{
    public static class StringExtensions
    {
        public static string SizeAsHumanReadableString(this byte[] s)
        {
            // Larger or equal to 1KB but lesser than 1MB
            if (s.Length >= 1024 && s.Length < 1048576)
            {
                return string.Format("{0}KB", s.Length / 1024);
            }

            // Larger or equal to 1MB but lesser than 1GB
            if (s.Length >= 1048576 && s.Length < 1073741824)
            {
                return string.Format("{0}MB", s.Length / 1024 / 1024);
            }

            // Larger or equal to 1Gt but lesser than 1TB
            if (s.Length >= 1073741824)
            {
                return string.Format("{0}GB", s.Length / 1024 / 1024 / 1024);
            }

            return string.Format("{0}bytes", s.Length);
        }

        public static string AsHumanReadableString(this TimeSpan ts)
        {
            // Larger or equal to 1 second but lesser than 1 minute
            if (ts.TotalMilliseconds >= 1000 && ts.TotalMilliseconds < 60000)
            {
                return string.Format("{0}s", ts.TotalMilliseconds / 1000);
            }

            // Larger or equal to 1 minute but lesser than 1 hour
            if (ts.TotalMilliseconds >= 60000 && ts.TotalMilliseconds < 3600000)
            {
                return string.Format("{0}m", ts.TotalMilliseconds / 1000 / 60);
            }

            // Larger or equal to 1 hour but lesser than 1 day
            if (ts.TotalMilliseconds >= 3600000 && ts.TotalMilliseconds < 86400000)
            {
                return string.Format("{0}h", ts.TotalMilliseconds / 1000 / 60 / 60);
            }

            return string.Format("{0}ms", ts.TotalMilliseconds);
        }

        public static string StripHtml(this string input)
        {
            string[] patterns = { @"<(.|\n)*?>", @"<script.*?</script>" };
            string stripped = input;
            foreach (string pattern in patterns)
            {
                stripped = System.Text.RegularExpressions.Regex.Replace(stripped, pattern, string.Empty);
            }

            return stripped;
        }

        public static string CleanUpSqlQuery(this string sqlQuery)
        {
            return string.Join(" ", Regex.Split(sqlQuery, @"(?:\r\n|\n|\r|\t)"));
        }

        public static bool UrlValidate(this string input)
        {
            return Uri.IsWellFormedUriString(input, UriKind.RelativeOrAbsolute);
        }

        public static string XssProtect(this string input)
        {
            string returnVal = input ?? string.Empty;

            returnVal = Regex.Replace(returnVal, @"\<script(.*?)\>(.*?)\<\/script(.*?)\>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            returnVal = Regex.Replace(returnVal, @"\<style(.*?)\>(.*?)\<\/style(.*?)\>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            returnVal = Regex.Replace(returnVal, @"\< (.*?)\>(.*?)\<\/ (.*?)\>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            returnVal = Regex.Replace(returnVal, @"(<[\s\S]*?) on.*?\=(['""])[\s\S]*?\2([\s\S]*?>)",
                match => String.Concat(match.Groups[1].Value, match.Groups[3].Value), RegexOptions.Compiled | RegexOptions.IgnoreCase);


            while (Regex.IsMatch(returnVal, @"(<[\s\S]*?) on.*?\=(['""])[\s\S]*?\2([\s\S]*?>)", RegexOptions.Compiled | RegexOptions.IgnoreCase))
            {
                returnVal = Regex.Replace(returnVal, @"(<[\s\S]*?) on.*?\=(['""])[\s\S]*?\2([\s\S]*?>)",
                    match => String.Concat(match.Groups[1].Value, match.Groups[3].Value), RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }

            return returnVal;
        }

        public static string Reverse(this string input)
        {
            //return Microsoft.VisualBasic.Strings.StrReverse(input);

            //1. char[] charArray = input.ToCharArray();
            //Array.Reverse(charArray);
            //return new string(charArray);

            return new string(input.Reverse().ToCharArray());
        }

        public static long Reverse(this long number)
        {
            long reversedNumber = 0L;
            while (number != 0)
            {
                reversedNumber = reversedNumber * 10;
                reversedNumber = reversedNumber + number % 10;
                number = number / 10;
            }

            return reversedNumber;
        }

        public static ulong Reverse(this ulong value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }
    }
}
