using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Area51Task;

namespace Area51Task
{
    internal class Agents
    {
        public string Agent { get; set; }
        public string Id { get; set; }

        public static Random rand = new Random();
        public Random rndFloor = new Random();
        Random rndCeiling = new Random();
        public string [] chooseFloors = new string [] 
        {
            "gFloor",
            "sFloor",
            "t1Floor",
            "t2Floor"
        };
        private bool Throw(int chance)
        {
            int dice = rand.Next(100);
            return dice < chance;
        }
        Area51 area;
        int seconds = DateTime.Now.AddSeconds(1).Second;
        public Agents(Area51 area)
        {
            this.area = area;
        }
        public void Access(object obj)
        {
            
            CancellationToken token = (CancellationToken)obj;
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    {
                        area.TryEnter(this);
                        if (Throw(30))
                        {
                            Console.WriteLine($"Agent {Id} has Confidential rank. He choose {chooseFloors.FirstOrDefault()}!");
                            area.Leave(this);
                            break;
                        }
                        else if (Throw(40))
                        {
                            for (int i = 0; i <= rndCeiling.Next(10); i++)
                            {
                                Thread.Sleep(seconds);
                                Console.WriteLine($"Agent {Id} has Secret rank. He choose {chooseFloors[rndFloor.Next(2)]}.");
                            }
                            area.Leave(this);
                            break;
                        }
                        else 
                        {
                            for (int i = 0; i <= rndCeiling.Next(10); i++)
                            {
                                Thread.Sleep(seconds);
                                Console.WriteLine($"Agent {Id} has Top-secret rank. He choose {chooseFloors[rndFloor.Next(chooseFloors.Length)]}.");
                            }
                            area.Leave(this);
                            break;
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}