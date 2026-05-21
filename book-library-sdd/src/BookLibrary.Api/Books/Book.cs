namespace BookLibrary.Api.Books;

public record Book(Guid Id, string Title, string Author, string Isbn, int CopiesTotal)
{
    public int CopiesAvailable { get; init; } = CopiesTotal;
}

public record CreateBookRequest(string Title, string Author, string Isbn, int CopiesTotal);

public record UpdateBookRequest(string Title, string Author, string Isbn, int CopiesTotal);
