using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51Task
{
    internal class Area51
    {
        const int max = 1;
        Semaphore sem;
        List<Agents> employees;
        public ManualResetEvent stop { get; private set; }
        public Area51()
        {
            sem = new Semaphore(max,max);
            stop = new ManualResetEvent(false);
            employees = new List<Agents>();
        }
        
        public bool TryEnter(Agents a)
        {
            if (sem.WaitOne())
            {
                lock (employees) employees.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Leave(Agents a)
        {
            lock(employees) employees.Remove(a);
            sem.Release();
        }
        
        public void Work()
        {
            Console.WriteLine("Elevetor is turn on!");
            Thread.Sleep(10000);
            Console.WriteLine("Elevetor was stopped!");
            stop.Set();
        }
    }
}
