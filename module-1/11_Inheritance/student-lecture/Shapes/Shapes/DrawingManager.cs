using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class DrawingManager
    {
        #region Fields
        /// <summary>
        /// A private list of shapes
        /// </summary>
        /// 
        // TODO 10 Create the private list of shapes

        #endregion

        #region Methods

        /// <summary>
        /// Starts the drawing manager interacting with the user
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Write(@"
    1) Add a Circle
    2) Add a Rectangle
    3) Draw the Canvas
    4) List all Shapes
    5) Clear the Canvas
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
            // TODO 11 Clear the list of shapes

            Success("Canvas was cleared");
        }

        /// <summary>
        /// Show the user the list of shapes
        /// </summary>
        private void ListDrawingObjects()
        {
            Success("Shapes:");

            // TODO 12 Display the list of shapes

        }

        /// <summary>
        /// Prompt the user and create a new rectangle
        /// </summary>
        private void NewRectangle()
        {
            // TODO 13 Prompt the user for Width, Height, Color and Filled, then add a Rectangle


            Success("New Rectangle was added");

        }

        /// <summary>
        /// Prompt the user and create a new circle
        /// </summary>
        private void NewCircle()
        {
            // TODO 14 Prompt the user for Radius, Color and Filled, then create a Circle


            Success("New Circle was added");
        }

        /// <summary>
        /// Draw all the shapes onto the canvas (Console)
        /// </summary>
        public void DrawCanvas()
        {
            // TODO 15 Loop through the shapes and Draw each one.

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
        /// <param name="prompt">Prompt to display to the user</param>
        /// <returns>A ConsoleColor value</returns>
        private ConsoleColor GetColor(string prompt)
        {
            object colorObject = null;
            while (colorObject ==  null)
            {
                Console.Write(prompt);
                if (!Enum.TryParse(typeof(ConsoleColor), Console.ReadLine(), out colorObject))
                {
                    Error($"Please enter a color name like Blue, Red, Yellow, DarkCyan...");
                }
            }
            return (ConsoleColor)colorObject;
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
