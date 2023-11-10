using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class Bird : Animal, IWalk, ISwim
    {
        public Bird(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Fly()
        {
            Console.WriteLine(this.Name + " летит.");
        }

        public void BuildNest()
        {
            Console.WriteLine(this.Name + " строит гнездо.");
        }

        public void Walk()
        {
            Console.WriteLine(this.Name + " идёт.");
        }

        public void Swim()
        {
            Console.WriteLine(this.Name + " плывёт.");
        }


    }
}
