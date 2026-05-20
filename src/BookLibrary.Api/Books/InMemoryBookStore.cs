using System.Collections.Concurrent;

namespace BookLibrary.Api.Books;

public class InMemoryBookStore : IBookStore
{
    private readonly ConcurrentDictionary<Guid, Book> _books = new();

    public InMemoryBookStore()
    {
        // Seed a few books for the demo.
        Add(new CreateBookRequest("The Pragmatic Programmer", "Andrew Hunt, David Thomas", "978-0135957059", 3));
        Add(new CreateBookRequest("Clean Code", "Robert C. Martin", "978-0132350884", 2));
        Add(new CreateBookRequest("Domain-Driven Design", "Eric Evans", "978-0321125217", 1));
    }

    public IReadOnlyCollection<Book> GetAll() => _books.Values.ToList();

    public Book? GetById(Guid id) => _books.TryGetValue(id, out var book) ? book : null;

    public Book Add(CreateBookRequest request)
    {
        var book = new Book(Guid.NewGuid(), request.Title, request.Author, request.Isbn, request.CopiesTotal);
        _books[book.Id] = book;
        return book;
    }

    public Book? Update(Guid id, UpdateBookRequest request)
    {
        if (!_books.TryGetValue(id, out var existing)) return null;
        var updated = existing with
        {
            Title = request.Title,
            Author = request.Author,
            Isbn = request.Isbn,
            CopiesTotal = request.CopiesTotal,
            CopiesAvailable = Math.Min(existing.CopiesAvailable, request.CopiesTotal)
        };
        _books[id] = updated;
        return updated;
    }

    public bool Delete(Guid id) => _books.TryRemove(id, out _);
}
