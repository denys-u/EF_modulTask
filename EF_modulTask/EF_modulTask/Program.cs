namespace EF_modulTask
{
    using EF_modulTask.Linq;
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Task1();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Task2();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Task3();
            }

            Console.ReadKey();
        }
    }
}
