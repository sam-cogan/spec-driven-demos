namespace BookLibrary.Api.Books;

public interface IBookStore
{
    IReadOnlyCollection<Book> GetAll();
    Book? GetById(Guid id);
    Book Add(CreateBookRequest request);
    Book? Update(Guid id, UpdateBookRequest request);
    bool Delete(Guid id);
}
