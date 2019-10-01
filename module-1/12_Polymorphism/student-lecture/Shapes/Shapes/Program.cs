using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        /* *
         * First, Draw 2D Shapes.  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * 
         * Later, we are going to want to draw additional things, like Sprites and Labels and Lines.
         * 
         * TODO 05 Define an IDrawable interface, which contains one method: Draw
         * TODO 06 Update Shape2D to implement the IDrawable interface
         * 
         * TODO 08 Define a Sprite class which displays a unicode glyph, make it IDrawable
         * TODO 10 Define a Text class which displays text, make it IDrawable
         * TODO 12 Define a Line class which displays a line, vertical or horizontal, make it IDrawable

         * Are these things shapes?  Do they have Area and Perimeter?
         * So let's make an IDrawable and change our collection to a List of IDrawable.
         * */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

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
