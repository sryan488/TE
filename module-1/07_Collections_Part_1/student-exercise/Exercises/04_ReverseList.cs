using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given a List of string, return a new list in reverse order of the original. One obvious solution is to
         simply loop through the original list in reverse order, but see if you can come up with an alternative
         solution. (Hint: Think LIFO (i.e. stack))
         ReverseList( ["purple", "green", "blue", "yellow", "green" ])  -> ["green", "yellow", "blue", "green", "purple" ]
         ReverseList( ["jingle", "bells", "jingle", "bells", "jingle", "all", "the", "way"} )
            -> ["way", "the", "all", "jingle", "bells", "jingle", "bells", "jingle"]
         */
        public List<string> ReverseList(List<string> objectList)
        {
            //List<string> newList = new List<string>();
            //for (int i = objectList.Count -1; i >= 0; i--)
            //{
            //    newList.Add(objectList[i]);
            //}
            //return newList;

            Stack<string> newStack = new Stack<string>();
            List<string> newList = new List<string>();
            foreach (string i in objectList)
            {
                newStack.Push(i);
            }
            while (newStack.Count > 0)
            {
                newList.Add(newStack.Pop());
            }
            return newList;
        }

    }
}
