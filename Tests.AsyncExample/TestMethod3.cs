﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests.AsyncExample
{
    public class TestMethod3
    {
        private static readonly Stopwatch Watch = new Stopwatch();

        public void MockTest()
        {
            Watch.Start();

            const string url1 = "https://github.com/";
            const string url2 = "https://github.com/ChenQianPing";

            // 两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）
            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);

            // 三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            Console.WriteLine($"{url1} 的字符个数：{result1}");
            Console.WriteLine($"{url2} 的字符个数：{result2}");

        }

        private static int CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = wc.DownloadString(address);
            Console.WriteLine($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

        private static void ExtraOperation(int id)
        {
            // 这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";
            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }
            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");
        }

    }
}
