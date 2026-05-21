namespace BookLibrary.Api.Books;

public static class BookEndpoints
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/books").WithTags("Books");

        group.MapGet("/", (IBookStore store) => Results.Ok(store.GetAll()));

        group.MapGet("/{id:guid}", (Guid id, IBookStore store) =>
            store.GetById(id) is { } book ? Results.Ok(book) : Results.NotFound());

        group.MapPost("/", (CreateBookRequest req, IBookStore store) =>
        {
            var book = store.Add(req);
            return Results.Created($"/books/{book.Id}", book);
        });

        group.MapPut("/{id:guid}", (Guid id, UpdateBookRequest req, IBookStore store) =>
            store.Update(id, req) is { } updated ? Results.Ok(updated) : Results.NotFound());

        group.MapDelete("/{id:guid}", (Guid id, IBookStore store) =>
            store.Delete(id) ? Results.NoContent() : Results.NotFound());

        return app;
    }
}
