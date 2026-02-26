using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace KMA.ProgrammingInChsarp.Samples
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    enum DogType
    {
        Shepard,
        Labrador = 200,
        Poodle,
        Labradoodle = 5,
    }
    internal class Dog
    {
        private int _age;
        private string _name;

        public int Age 
        {
            get
            {  
                return _age; 
            }
            set
            {
                _age = value;
            }
        }

        public string Name { get => _name; set => _name = value; }
        public string Identifier
        {
            get
            {
                return $"Name: {_name} Age: {_age}";
            }
        }

        private DogType _breed;

        public DogType Breed
        {
            get { return _breed; }  
            set { _breed = value; }
        }


#pragma warning disable CA1822 // Mark members as static
        private void Foo()
#pragma warning restore CA1822 // Mark members as static
        {

        }

#pragma warning disable CA1822 // Mark members as static
        internal void Bar()
#pragma warning restore CA1822 // Mark members as static
        {

        }

#pragma warning disable CA1822 // Mark members as static
        protected void Gas()
#pragma warning restore CA1822 // Mark members as static
        {

        }

#pragma warning disable CA1822 // Mark members as static
        public void Talk(string value)
#pragma warning restore CA1822 // Mark members as static
        {

        }

#pragma warning disable CA1822 // Mark members as static
        public void Talk(int times, string value = "woof", bool sit = false)
#pragma warning restore CA1822 // Mark members as static
        {

        }


        public void MyMethod()
        {
            
            int val1 = Age;
            Age = 5;

            switch (Breed)
            {
                case DogType.Shepard:
                    break;
                case DogType.Labrador:
                    break;
                case DogType.Poodle:
                case DogType.Labradoodle:
                    break;
            }

            Talk("bark");
            Talk(3);
            Talk(3, "bark");
            Talk(3, sit:true);
        }
    }
}
