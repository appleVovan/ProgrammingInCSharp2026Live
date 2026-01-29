using KMA.ProgrammingInChsarp2026.Samples.Original;
using KMA.ProgrammingInChsarp2026.Samples.Copy;
using циферка = System.Int32;
using OriginalStudent = KMA.ProgrammingInChsarp2026.Samples.Original.Student;
using CopyStudent = KMA.ProgrammingInChsarp2026.Samples.Copy.Student;

namespace KMA.ProgrammingInChsarp2026.Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sample14();
        }

        #region Initialization in C# Examples
        static void Sample1()
        {
            var mystudent1 = new OriginalStudent() { FirstName = "Steve", LastName = "Jobs" };

            CopyStudent mystudent2 = new CopyStudent();
            mystudent1.FirstName = "Bill";
            mystudent1.LastName = "Gates";
        }
        #endregion

        #region Variable Initialization Examples
        static void Sample2()
        {
            циферка i, j, k;

            i = j = k = 0;
        }
        #endregion

        #region Type conversion Examples
        static void Sample3()
        {
            int x = 1000;

            byte y = checked((byte)x);

            Console.WriteLine(y);
        }
        #endregion

        #region New Line Examples
        static void Sample4()
        {
            string tempVar = "My name is Volodymyr." + Environment.NewLine + "My age is 30.";
        }
        #endregion

        #region Value & Reference Type Behaviour Examples
        static void Sample5()
        {
            int myInt;
            MyMethodInt(out myInt);
            Console.WriteLine(myInt);
        }

        static void MyMethodInt(out int myInt)
        {
            myInt = 6;
            Console.WriteLine(myInt);
        }
        #endregion

        #region Reference Type Behaviour Examples
        class MyClass
        {
            private MyClass myChild;

            public int MyProperty { get; set; }
            public MyClass MyChild { get => myChild; set => myChild = value; }
        }

        static void Sample6()
        {
            MyClass myObject = new MyClass();//100
            myObject.MyProperty = 5;//100
            myObject.MyChild = new MyClass();//110
            myObject.MyChild.MyProperty = 5;
            var myObjectMyChild = myObject.MyChild;//110
            MyMethodObject(ref myObjectMyChild);//120
            Console.WriteLine(myObject.MyChild.MyProperty);//110
        }

        static void MyMethodObject(ref MyClass myObject) //110
        {
            myObject = new MyClass
            {
                MyProperty = 6
            };//120
            Console.WriteLine(myObject.MyProperty);
        }
        #endregion

        #region Value Types comparison
        static void Sample7()
        {
            int val1 = 5;
            int val2 = 5;

            Console.WriteLine(val1 == val2); 
            Console.WriteLine(val1.Equals(val2)); 

        }
        #endregion
        #region Reference Types comparison
        static void Sample8()
        {
            var obj1 = new OriginalStudent("Volodymyr", "Yablonskyi");
            var obj2 = new OriginalStudent("Volodymyr", "Yablonskyi");

            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(obj1.Equals(obj2));
        }
        #endregion

        #region String comparison
        static void Sample9()
        {
            var str1 = "Volodymyr";
            var str2 = "Volodymyr";

            Console.WriteLine(str1 == str2);
            Console.WriteLine(str1.Equals(str2));
        }
        #endregion

        #region Inheritance
        abstract class Animal
        {
            public abstract void Speak();
        }

        class Dog : Animal
        {
            public sealed override void Speak()
            {
                Console.WriteLine("Dog barks");
            }
        }

        class Basenji : Dog
        {
            public void Speak()
            {
                Console.WriteLine("Basenji is silent");
            }
        }

        static void Sample10()
        {
            Sample11();
        }
        static void Sample11()
        {
            Animal animalBasenji = new Basenji();
            animalBasenji.Speak();
            ((Dog)animalBasenji).Speak();
            ((Basenji)animalBasenji).Speak();


            Dog dog = new Dog();
            Animal animalDog = dog;
            animalDog.Speak();
            dog.Speak();
        }
        #endregion

        #region | and || comparison
        static void Sample12()
        {
            if (SaveToServer() || SaveLocalCopy())
            {
            }

            if (SaveToServer() | SaveLocalCopy())
            {
            }
        }

        private static bool SaveLocalCopy()
        {
            return true;
        }

        private static bool SaveToServer()
        {
            return true;
        }

        void Sample13()
        {
            if (SaveToServer())
            {
            }
            else 
                if (SaveLocalCopy())
                {
                }
                else
                {
                }

        }
        #endregion

        #region Reference Types comparison
        static void Sample14()
        {
            OriginalStudent obj1 = null;
            OriginalStudent obj2 = new OriginalStudent("Volodymyr", "Yablonskyi");

            string firstName = obj1?.FirstName ?? obj2?.FirstName ?? "Default";



        }
        #endregion
    }
}
