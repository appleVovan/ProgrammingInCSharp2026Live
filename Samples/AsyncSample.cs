using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.Samples
{
    internal class AsyncSample
    {
        private Task<int> RunLongOperationAsync()
        {
            Console.WriteLine($"4 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            var task = Task.Run(RunLongOperation);
            Thread.Sleep(1000);
            Console.WriteLine($"8 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            return task;
        }

        private int RunLongOperation()
        {
            int res = 0;
            Console.WriteLine($"5 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                //throw new Exception("Some exception");
                Console.WriteLine($"6.{i} Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                res += 1000;
            }
            Console.WriteLine($"7 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            return res;
        }

        public async void RunAsync()
        {
            Console.WriteLine($"3 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            var task = RunLongOperationAsync();
            Console.WriteLine($"9 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Result is {await task}");
            Console.WriteLine($"10 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
