using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.AsyncExample
{
    public class TestMethod2
    {
        public void MockTest()
        {
            Console.WriteLine($"我是主线程，线程ID：{Thread.CurrentThread.ManagedThreadId}");
            TestAsync();
            Console.ReadLine();
        }

        public static async Task TestAsync()
        {
            Console.WriteLine(
                $"调用GetReturnResult()之前，线程ID：{Thread.CurrentThread.ManagedThreadId}。当前时间：{DateTime.Now:yyyy-MM-dd hh:MM:ss}");
            var name = GetReturnResult();
            Console.WriteLine(
                $"调用GetReturnResult()之后，线程ID：{Thread.CurrentThread.ManagedThreadId}。当前时间：{DateTime.Now:yyyy-MM-dd hh:MM:ss}");

            Console.WriteLine(
                $"得到GetReturnResult()方法的结果：{await name}。当前时间：{DateTime.Now:yyyy-MM-dd hh:MM:ss}");

            /**
            Console.WriteLine(
                $"得到GetReturnResult()方法的结果：{name.GetAwaiter().GetResult()}。当前时间：{DateTime.Now:yyyy-MM-dd hh:MM:ss}");
            */
        }

        private static async Task<string> GetReturnResult()
        {
            Console.WriteLine($"执行Task.Run之前, 线程ID：{Thread.CurrentThread.ManagedThreadId}");
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"GetReturnResult()方法里面线程ID: {Thread.CurrentThread.ManagedThreadId}");
                return "我是返回值";
            });
        }

    }
}
