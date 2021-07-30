using ConsoleDI.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDI.Services
{
    public class ReviewAggregator : IReviewAggregator
    {
        public Guid Id { get; } = Guid.NewGuid();

        public IBookReviewRepository Repository { get; }

        public ReviewAggregator(IBookReviewRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<BookReview> Summary
            => Repository.All.GroupBy(r => r.Title).Select(g =>
                new BookReview
                {
                    Title = g.Key,
                    Rating = Math.Round (g.Average(r => r.Rating),2)
                }
            );
    }
}
