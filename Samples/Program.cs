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
            Sample6();
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
            myObject = new MyClass();//120
            myObject.MyProperty = 6;
            Console.WriteLine(myObject.MyProperty);
        }
        #endregion
    }
}
