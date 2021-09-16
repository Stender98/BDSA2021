using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            foreach (var sentence in lines)
            {
                foreach (var word in Regex.Split(sentence, "\\s+"))
                {
                    yield return word;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            var regex = new Regex(@"(?<width>[\d]*)[x](?<height>[\d]*)");
            foreach (var line in resolutions)
            {
                foreach (Match match in regex.Matches(line))
                {
                    yield return (Int32.Parse(match.Groups["width"].Value), Int32.Parse(match.Groups["height"].Value));
                }
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            var regex = new Regex(@"<(" + tag + ")>(?<text>.*)</(\\1)>");
            foreach (Match match in regex.Matches(html))
            {
                yield return Regex.Replace(match.Groups["text"].Value, @"</?\w+>", "");
            }
        }
    }
}
