using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Graphic : IDrawable
    {
        private Dictionary<string, string> glyphs = new Dictionary<string, string>()
        {
            { "Spades", "\u2660"},
            { "Diamonds", "\u2666"},
            { "Clubs", "\u2663"},
            { "Hearts", "\u2665"},
        };

        public string[] GlyphNames
        {
            get
            {
                List<string> names = new List<string>(glyphs.Keys);
                return names.ToArray();
            }
        }

        public ConsoleColor Color { get; set; }
        public string GlyphName { get; set; }

        public Graphic(string glyphName, ConsoleColor color)
        {
            Color = color;
            GlyphName = glyphName;
        }

        public void Draw()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            // Write
            Console.WriteLine(glyphs[GlyphName]);
            Console.ForegroundColor = oldColor;
        }
    }
}
