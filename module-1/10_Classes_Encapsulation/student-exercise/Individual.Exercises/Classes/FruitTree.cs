using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree (string typeOfFruit, int startingPiecesOfFruit)
        {
            this.TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }
        public bool PickFruit(int numberOfPiecesToRemove)
        {
            
            if (PiecesOfFruitLeft >= numberOfPiecesToRemove)
            {
                PiecesOfFruitLeft = PiecesOfFruitLeft - numberOfPiecesToRemove;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
