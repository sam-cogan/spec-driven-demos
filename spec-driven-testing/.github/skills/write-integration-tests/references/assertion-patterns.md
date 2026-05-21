# Assertion patterns

Use these patterns consistently so failures are easy to diagnose.

## Status code

```csharp
response.StatusCode.Should().Be(HttpStatusCode.Created);
```

## Body equals expected DTO

```csharp
var body = await response.Content.ReadFromJsonAsync<Book>();
body.Should().BeEquivalentTo(expected, options => options.Excluding(b => b.Id));
```

## Collection contains item matching predicate

```csharp
var list = await response.Content.ReadFromJsonAsync<List<Book>>();
list.Should().Contain(b => b.Isbn == request.Isbn);
```

## Negative case — verify nothing was persisted

```csharp
// After a 400/409, the resource list should not contain the rejected item.
var afterList = await _client.GetFromJsonAsync<List<Book>>("/books");
afterList.Should().NotContain(b => b.Isbn == request.Isbn);
```

## Avoid

- `Assert.True(response.IsSuccessStatusCode)` — gives no useful diagnostic on failure.
- Asserting only the status code without inspecting the body shape — silent contract drift.
- Reading and ignoring the body before asserting (loses the failure context).
