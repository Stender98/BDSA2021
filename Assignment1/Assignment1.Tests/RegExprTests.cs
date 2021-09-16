using Xunit;
using System.Collections.Generic;


namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_given_helloworld_return_hello_world()
        {
            var given = new List<string>() { "hello world" };
            var expected = new List<string>() { "hello", "world" };

            var actual = RegExpr.SplitLine(given);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolution_given_1920x1080_return_1920_1080()
        {
            var given = new List<string>() { "1920x1080", "1024x768, 800x600, 640x480", "320x200, 320x240, 800x600", "1280x960" };
            var expected = new List<(int width, int height)>() { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) };

            var actual = RegExpr.Resolution(given);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void InnerText_given_html_string_return_from_tag() //This test currently fails
        {
            var givenText = @"<div>
                        <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
                        </div>";
            var givenTag = "a";
            var expected = new List<string>() { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };

            var actual = RegExpr.InnerText(givenText, givenTag);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InnerText_given_nested_html_string_return_from_tag()
        {
            var givenText = @"<div>
                            <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
                            </div>";
            var givenTag = "p";
            var expected = new List<string>() { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };

            var actual = RegExpr.InnerText(givenText, givenTag);

            Assert.Equal(expected, actual);
        }
    }
}
