using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        // TODO 01 Create a Shape class with the appropriate methods and properties
        //      Properties: Color, IsFilled, Area, Perimeter
        //      Methods: Draw, ToString
        // TODO 02 Create a subclass for Circle
        // TODO 03 Create a subclass for Rectangle


        /* *
         * First, Draw 2D Shapes.  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * 
         * Later, we are going to want to draw additional things, like Sprites and Labels.
         * Are these things shapes?  Do they have Area and Perimeter?
         * So let's make an IDrawable and change our collection to a List of IDrawable.
         * */
        static void Main(string[] args)
        {
            Console.WriteLine(@"#     #                                                               #####                                     ### ");
            Console.WriteLine(@"#  #  # ###### #       ####   ####  #    # ######    #####  ####     #     # #    #   ##   #####  ######  ####  ### ");
            Console.WriteLine(@"#  #  # #      #      #    # #    # ##  ## #           #   #    #    #       #    #  #  #  #    # #      #      ### ");
            Console.WriteLine(@"#  #  # #####  #      #      #    # # ## # #####       #   #    #     #####  ###### #    # #    # #####   ####   #  ");
            Console.WriteLine(@"#  #  # #      #      #      #    # #    # #           #   #    #          # #    # ###### #####  #           #     ");
            Console.WriteLine(@"#  #  # #      #      #    # #    # #    # #           #   #    #    #     # #    # #    # #      #      #    # ### ");
            Console.WriteLine(@" ## ##  ###### ######  ####   ####  #    # ######      #    ####      #####  #    # #    # #      ######  ####  ### ");


            DrawingManager manager = new DrawingManager();
            manager.Run();

            Console.WriteLine("Thanks for drawing with us!");
            Console.ReadKey();
        }
    }
}
