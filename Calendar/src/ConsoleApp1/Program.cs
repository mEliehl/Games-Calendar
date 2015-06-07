using IOC.Service.Calendar;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using Service.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        readonly IGameService gameService;

        public void Main(string[] args)
        {
            Console.WriteLine("hello");
            Console.Read();
        }
    }
}
