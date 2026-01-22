using KMA.ProgrammingInChsarp2026.Samples.Original;
using KMA.ProgrammingInChsarp2026.Samples.Copy;

namespace KMA.ProgrammingInChsarp2026.Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sample1();
        }

        #region Initialization in C# Examples
        static void Sample1()
        {
            var mystudent1 = new Original.Student() { FirstName = "Steve", LastName = "Jobs" };

            Copy.Student mystudent2 = new Copy.Student();
            mystudent1.FirstName = "Bill";
            mystudent1.LastName = "Gates";
        }
        #endregion

        #region Variable Initialization Examples
        static void Sample2()
        {
            int i, j, k;

            i = j = k = 0;
        }
        #endregion
    }
}
