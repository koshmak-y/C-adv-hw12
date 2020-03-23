using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Основной поток работает... id {Thread.CurrentThread.ManagedThreadId}. Символ потока - '_'");
            Action action = new Action(Method);
            AsyncCallback callback = new AsyncCallback(CallBack);
            action.BeginInvoke(callback, null);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(160);
                Console.Write($"_ ");
            }
            Console.WriteLine("\n\nОсновной поток завершился б, если б не ReadKey." +
                "\nВторичный работает до вызова Callback\n");
            Console.ReadKey();
        }

        static void Method()
        {
            Console.WriteLine($"Запустился вторичный поток - id {Thread.CurrentThread.ManagedThreadId}. Символ потока - '*'\n");
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(20);
                Console.Write($"* ");
            }
        }

        static void CallBack(IAsyncResult asyncResult)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"\n\nCallback отработал! Поток - id {Thread.CurrentThread.ManagedThreadId}. " +
                $"Это значит что поток завершен.");
        }
    }
}
