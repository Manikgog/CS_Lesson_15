using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class Mammal : Animal, ISwim, IWalk
    {
        public Mammal(string name, int age) 
        {
            Name = name;
            Age = age;
        }
        public string FurColor { get; set; }

        public void Swim()
        {
            Console.WriteLine(this.Name + " плывёт.");
        }

        public void Walk()
        {
            Console.WriteLine(this.Name + " идёт.");
        }

    }
}
