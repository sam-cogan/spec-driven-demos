using System.Net;
using System.Net.Http.Json;
using BookLibrary.Api.Books;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BookLibrary.Api.Tests.Books;

public class PostBooksTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PostBooksTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_WithValidBody_Returns201AndBookWithMatchingCopies()
    {
        // Arrange — covers AC #4
        var request = new CreateBookRequest("Refactoring", "Martin Fowler", "978-0134757599", 2);

        // Act
        var response = await _client.PostAsJsonAsync("/books", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Headers.Location.Should().NotBeNull();

        var book = await response.Content.ReadFromJsonAsync<Book>();
        book.Should().NotBeNull();
        book!.Title.Should().Be(request.Title);
        book.CopiesAvailable.Should().Be(book.CopiesTotal);
    }

    // Add one [Fact] per test case in the test plan ...
}
