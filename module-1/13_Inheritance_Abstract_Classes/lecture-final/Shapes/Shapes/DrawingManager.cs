using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class DrawingManager
    {
        // TODO 07 Update the shapes collection to hold IDrawable objects (we should rename it to)
        #region Fields
        /// <summary>
        /// A private list of shapes
        /// </summary>
        /// 
        private List<IDrawable> drawables = new List<IDrawable>();

        #endregion

        #region Methods

        /// <summary>
        /// Starts the drawing manager interacting with the user
        /// </summary>
        public void Run()
        {
           /***
           * TODO 09 Add "Add a Graphic" to the menu and handle the choice
           * TODO 11 Add "Add a Text object" to the menu and handle the choice
           * TODO 13 Add "Add a Line" to the menu and handle the choice
           ***/

            while (true)
            {
                Console.Write(@"
    1) Add a Circle
    2) Add a Rectangle
    3) Draw the Canvas
    4) List all Shapes
    5) Clear the Canvas
    6) Add a Graphic
    7) Add a Text Label
    Q) Quit

Please choose an option: ");

                String input = Console.ReadLine().ToLower();

                if (input.Length == 0)
                {
                    Console.Clear();
                    continue;
                }
                input = input.Substring(0, 1);

                if (input == "q")
                {
                    break;
                }
                else if (input == "1")
                {
                    NewCircle();
                }
                else if (input == "2")
                {
                    NewRectangle();
                }
                else if (input == "3")
                {
                    DrawCanvas();
                }
                else if (input == "4")
                {
                    ListDrawingObjects();
                }
                else if (input == "5")
                {
                    ClearCanvas();
                }
                else if (input == "6")
                {
                    NewGraphic();
                }
                else if (input == "7")
                {
                    NewText();
                }
                else
                {
                    Error($"'{input}' is an invalid entry. Press enter, then try again.");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        /// <summary>
        /// Clear all the shapes
        /// </summary>
        private void ClearCanvas()
        {
            drawables.Clear();
            Success("Canvas was cleared");
        }

        /// <summary>
        /// Show the user the list of shapes
        /// </summary>
        private void ListDrawingObjects()
        {
            Success("Shapes:");
            foreach (IDrawable drawableObject in drawables)
            {
                Console.WriteLine($"\t{drawableObject}");
            }
        }

        /// <summary>
        /// Prompt the user and create a new rectangle
        /// </summary>
        private void NewRectangle()
        {
            int width = GetPositiveInt("Width: ", 1, 30);
            int height = GetPositiveInt("Height: ", 1, 30);
            ConsoleColor color = GetColor();
            bool isFilled = GetBool("Do you want the shape filled? ");

            // TODO 03 Use the new constructor
            Rectangle rect = new Rectangle(width, height, color, isFilled);

            drawables.Add(rect);
            Success("New Rectangle was added");

        }

        /// <summary>
        /// Prompt the user and create a new circle
        /// </summary>
        private void NewCircle()
        {
            // Prompt the user for Radius, Color and Filled, then create a Circle
            int radius = GetPositiveInt("Radius: ", 1, 15);
            ConsoleColor color = GetColor();
            bool isFilled = GetBool("Do you want the shape filled? ");

            // TODO 04 Use the new constructor
            Circle circle = new Circle(radius, color, isFilled);

            drawables.Add(circle);

            Success("New Circle was added");
        }


        /// <summary>
        /// Prompt the user and create a new graphic
        /// </summary>
        private void NewGraphic()
        {
            // Prompt the user for Glyph and Color, then create a Graphic
            string glyphName = GetGlyphName();
            ConsoleColor color = GetColor();

            Graphic graphic = new Graphic(glyphName, color);

            drawables.Add(graphic);

            Success("New Graphic was added");
        }

        /// <summary>
        /// Prompt the user and create a new text label
        /// </summary>
        private void NewText()
        {
            // Prompt the user for label and Color, then create a Text
            Console.Write("Label: ");
            string label = Console.ReadLine();
            ConsoleColor color = GetColor();

            drawables.Add(new Text(label, color));

            Success("New Text Label was added");
        }

        /// <summary>
        /// Draw all the shapes onto the canvas (Console)
        /// </summary>
        public void DrawCanvas()
        {
            foreach (IDrawable drawableObject in drawables)
            {
                drawableObject.Draw();
            }

            Success("*** End of Display ***");
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Show a prompt and get a Y/N answer from the user.  Y & T == true, everything else == false.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>True or false</returns>
        private bool GetBool(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            return (input == "y" || input == "t");
        }

        /// <summary>
        /// Prompt the user for a color. Must match ConsoleColors, even in case.
        /// </summary>
        /// <returns>A ConsoleColor value</returns>
        private ConsoleColor GetColor()
        {
            Console.Clear();
            // List all the colors, allow the user to select the number
            string[] colorNames = Enum.GetNames(typeof(ConsoleColor));
            for (int i = 0; i < colorNames.Length; i++)
            {
                Console.WriteLine($"{i + 1} {colorNames[i]}");
            }
            int index = GetPositiveInt("Select a color number from the list above: ", 1, colorNames.Length);
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[index - 1]);
        }

        /// <summary>
        /// Prompt the user for a glyph
        /// </summary>
        /// <returns>A glyph name</returns>
        private string GetGlyphName()
        {
            Console.Clear();
            // List all the colors, allow the user to select the number
            string[] glyphNames = Graphic.GlyphNames;
            for (int i = 0; i < glyphNames.Length; i++)
            {
                Console.WriteLine($"{i + 1} {glyphNames[i]}");
            }
            int index = GetPositiveInt("Select a glyph number from the list above: ", 1, glyphNames.Length);
            return glyphNames[index - 1];
        }

        /// <summary>
        /// Prompt the user and get a positive integer
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <param name="min">User's value must be >= this.</param>
        /// <param name="max">User's value must be &lt;= this</param>
        /// <returns>An integer between min and max inclusive</returns>
        private int GetPositiveInt(string prompt, int min, int max)
        {
            int num = 0;
            while (num <= 0)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
                {
                    Error($"Please enter an integer from {min} to {max}.");
                    num = 0;
                }
            }
            return num;
        }

        /// <summary>
        /// Display a message in the success color
        /// </summary>
        /// <param name="msg">Message to display</param>
        private void Success(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Display a message in the error color
        /// </summary>
        /// <param name="msg">Message to display</param>
        private void Error(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }
        #endregion
    }
}
