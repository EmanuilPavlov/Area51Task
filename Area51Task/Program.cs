using System.Threading;
using Area51Task;

Area51 area = new Area51();
CancellationTokenSource cts = new CancellationTokenSource();
Console.Write("Enter the number of agents ");
var num = int.Parse(Console.ReadLine());

Thread areaThread = new Thread(area.Work);
areaThread.Start();
var agentThread = new List<Thread>();

for (int i =1 ; i <= num ; i++)
{
    Agents agent = new Agents(area)
    {
        Id = i.ToString()
    };
    Thread agents = new Thread(() => agent.Access(cts.Token));
    agents.Start();
    Thread.Sleep(1000);
}

area.stop.WaitOne();
foreach (var agents in agentThread) agents.Join();
cts.Dispose();