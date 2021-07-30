using ConsoleDI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleDI
{
    class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        static void Config()
        {
            ServiceProvider = new ServiceCollection()
                .AddSingleton<IBookReviewRepository, BookReviewRepository>()
                .AddSingleton<IReviewAggregator, ReviewAggregator>()
                .BuildServiceProvider();
        }

        static void Shutdown()
        {
            ServiceProvider?.Dispose();
        }

        static void Use()
        {
            using var scope = ServiceProvider.CreateScope();

            var repos = scope.ServiceProvider.GetRequiredService<IBookReviewRepository>();
            var aggreg = scope.ServiceProvider.GetRequiredService<IReviewAggregator>();

            Console.WriteLine($"Repository:       {repos.Id}");
            Console.WriteLine($"Aggregator:       {aggreg.Id}");
            Console.WriteLine($"Inner repository: {aggreg.Repository.Id}");

            Console.WriteLine();

            foreach (var item in repos.All)
                Console.WriteLine($"{item.Title,-10} {item.Rating}");

            Console.WriteLine();

            foreach (var item in aggreg.Summary)
                Console.WriteLine($"{item.Title,-10} {item.Rating}");

        }

        static void Main()
        {
            Config();

            Use();
            Console.WriteLine();
            Use();

            Shutdown();
        }
    }
}
