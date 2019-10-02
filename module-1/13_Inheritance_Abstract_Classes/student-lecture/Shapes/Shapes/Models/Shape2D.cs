using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /// <summary>
    /// A two-dimensional shape the can be drawn on the screen
    /// </summary>
    public class Shape2D : IDrawable
    {
        public bool IsFilled { get; set; }
        public ConsoleColor Color { get; set; }

        virtual public int Area
        {
            get
            {
                return 0;
            }
        }

        virtual public int Perimeter
        {
            get
            {
                return 0;
            }
        }

        virtual public void Draw()
        {

        }

        public override string ToString()
        {
            return $"A {Color} shape that is{(IsFilled ? "" : " not")} filled.";
        }

        #region Helper Methods
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;

        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion


    }
}
