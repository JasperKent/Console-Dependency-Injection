using ConsoleDI.Data;
using System;
using System.Collections.Generic;

namespace ConsoleDI.Services
{
    public interface IBookReviewRepository
    {
        Guid Id { get; }

        IEnumerable<BookReview> All { get; }
        IEnumerable<BookReview> ByTitle(string title);
    }
}
