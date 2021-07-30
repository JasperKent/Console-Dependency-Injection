using ConsoleDI.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDI.Services
{
    public class BookReviewRepository : IBookReviewRepository
    {
        public Guid Id { get; } = Guid.NewGuid();

        private BookReview[] _fakeData = new[] 
        {
            new BookReview { Title = "Dr No", Rating = 1 },
            new BookReview { Title = "Dr No", Rating = 2 }, 
            new BookReview { Title = "Dr No", Rating = 4 }, 
            new BookReview { Title = "Goldfinger", Rating = 5 }, 
            new BookReview { Title = "Goldfinger", Rating = 4 }, 
            new BookReview { Title = "Goldfinger", Rating = 3 }, 
            new BookReview { Title = "Emma", Rating = 5 }, 
            new BookReview { Title = "Emma", Rating = 5 } 
        };
        
        public IEnumerable<BookReview> All => _fakeData;
        public IEnumerable<BookReview> ByTitle(string title) => _fakeData.Where(r => r.Title == title);
    }
}
