using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Graphic : IDrawable
    {
        static private Dictionary<string, string> glyphSymbols = new Dictionary<string, string>()
        {
            {"Spades", "\u2660"},
            {"Diamonds", "\u2666"},
            {"Clubs", "\u2663"},
            {"Hearts", "\u2665"},
            {"Music", "♫" },
        };

        static public string[] GlyphNames
        {
            get
            {
                List<string> names = new List<string>(glyphSymbols.Keys);
                return names.ToArray();
            }
        }

        //// Create a list of possible graphics
        //static protected List<string> glyphs = new List<string>()
        //{
        //    "\u2660 Spades",
        //    "\u2666 Diamonds",
        //    "\u2663 Clubs",
        //    "\u2665 Hearts"
        //};

        private string glyphSymbol;
        public string Name { get; }
        public ConsoleColor Color { get; set; }

        public Graphic(string glyphName, ConsoleColor color)
        {
            Color = color;
            if (glyphSymbols.ContainsKey(glyphName))
            {
                Name = glyphName;
                this.glyphSymbol = glyphSymbols[glyphName];
            }
            else
            {
                throw new ArgumentException($"Invalid glyph name: {glyphName}");
            }
        }

        public void Draw()
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine(this.glyphSymbol);
            Console.ForegroundColor = savedColor;

        }

        public override string ToString()
        {
            return $"A {Color} Graphic of glyph '{Name}'";
        }
    }
}
