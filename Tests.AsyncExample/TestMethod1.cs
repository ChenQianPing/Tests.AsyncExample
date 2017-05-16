using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.AsyncExample
{
    public class TestMethod1
    {
        public void MockTest()
        {
            Console.WriteLine("执行GetReturnResult方法前的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            // 启动Task执行方法
            var strRes = Task.Run<string>(() => GetReturnResult()); 
            Console.WriteLine("执行GetReturnResult方法后的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            // 得到方法的返回值
            Console.WriteLine("我是主线程，线程ID：" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(strRes.Result); 

            Console.WriteLine("得到结果后的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            Console.ReadLine();
        }

        private static string GetReturnResult()
        {
            Console.WriteLine("我是GetReturnResult里面的线程，线程ID：" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            return "我是返回值";
        }


    }
}


/*
 * # Tips1:
 * 从结果分析可知在执行
 * var strRes = Task.Run<string>(() => { return GetReturnResult(); })这一句后，
 * 主线程并没有阻塞去执行GetReturnResult()方法，
 * 而是开启了另一个线程去执行GetReturnResult()方法。
 * 直到执行strRes.Result这一句的时候主线程才会等待GetReturnResult()方法执行完毕。
 * 为什么说是开启了另一个线程，我们通过线程ID可以看得更清楚.
 * 
 * # Tips2:
 * 由此可以得知，Task.Run<string>(()=>{}).Reslut是阻塞主线程的，
 * 因为主线程要得到返回值，必须要等方法执行完成。
 */
