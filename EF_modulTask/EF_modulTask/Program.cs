namespace EF_modulTask
{
    using EF_modulTask.Linq;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new SampleContextFactory().CreateDbContext(args);
            new LazyLoadingSamples(context).Task2();

            for (int i = 0; i < 1000000; i++) ;

            Console.ReadKey();
        }
    }
}
