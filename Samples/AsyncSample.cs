using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.Samples
{
    internal class AsyncSample
    {
        private Task<int> RunLongOperationAsync()
        {
            Console.WriteLine($"5 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            var task = Task.Run(RunLongOperation);
            //Thread.Sleep(1000);
            Console.WriteLine($"9 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            return task;
        }

        private int RunLongOperation()
        {
            int res = 0;
            Console.WriteLine($"6 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            //throw new Exception();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"7.{i} Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                res += 1000;
            }
            Console.WriteLine($"8 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            return res;
        }

        public async Task RunAsync()
        {
            Console.WriteLine($"3 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            var task = RunAsync2();
            Console.WriteLine($"12 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            await task;
            Console.WriteLine($"13 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task RunAsync2()
        {
            Console.WriteLine($"4 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            var task = RunLongOperationAsync();
            Console.WriteLine($"10 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Result is {await task}");
            Console.WriteLine($"11 Step. Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
