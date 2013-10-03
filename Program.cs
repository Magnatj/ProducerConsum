using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static int tamano = 0;
        static Semaphore ocupados = new Semaphore(0, 5);
        static Semaphore libres = new Semaphore(5, 5);

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Producer);
            Thread t2 = new Thread(Consumer);
            t1.Start();
            t2.Start();
            //Producer();
            //Consumer();
        }

        static void Producer()
        {
            while(true)
            {
                tamano++;
                libres.WaitOne();
                Console.WriteLine("Producer produced item No. " + tamano);
                ocupados.Release();
                Thread.Sleep(1000);
            }

        }

        static void Consumer()
        {
            while(true)
            {
                ocupados.WaitOne();
                Console.WriteLine("Consumer consumed item No. " + tamano);
                libres.Release();
                tamano--;
                Thread.Sleep(1000);
            }
        }

    }
}
