using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine(this.Name + " ест.");
        }

        public void Sleep()
        {
            Console.WriteLine(this.Name + " спит.");
        }
    }
}
