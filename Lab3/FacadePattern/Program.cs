using System;

namespace FacadePattern
{
    class Program
    {
        static void Main()
        {
            var a = new SubsystemA();
            var b = new SubsystemB();
            var facade = new Facade(a, b);

            Console.WriteLine(facade.PerformComplexOperation());
        }
    }
}
