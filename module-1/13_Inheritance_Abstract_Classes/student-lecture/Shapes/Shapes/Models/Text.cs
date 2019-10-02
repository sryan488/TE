using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    class Text : IDrawable
    {
        public string Label { get; set; }
        public ConsoleColor Color { get; set; }

        public Text(string label, ConsoleColor color)
        {
            Label = label;
            Color = color;
        }

        public void Draw()
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine(Label);
            Console.ForegroundColor = savedColor;

        }

        public override string ToString()
        {
            return $"A {Color} Text Label";
        }

    }
}
