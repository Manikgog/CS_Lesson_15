using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15
{
    internal class Zoo
    {
        public event Action<Animal> AddAminalEvent;

        public List<Animal> Animals;

        public Zoo()
        {
            Animals = new List<Animal>();
        }

        public void AnimalAdded(Animal animal)
        {
            Animals.Add(animal);
            AddAminalEvent?.Invoke(animal);
        }
    }
}
