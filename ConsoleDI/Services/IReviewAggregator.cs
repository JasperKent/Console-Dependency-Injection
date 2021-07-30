using ConsoleDI.Data;
using System;
using System.Collections.Generic;

namespace ConsoleDI.Services
{
    public interface IReviewAggregator
    {
        Guid Id { get; }
        IBookReviewRepository Repository { get; }

        IEnumerable<BookReview> Summary { get; }
    }
}
