using BlogApp.models;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<BlogPost> posts = new List<BlogPost>
{
    new BlogPost { Id = 1, Title = "Laptop", Content = "different ranges of laptops" },
    new BlogPost { Id = 2, Title = "Phone", Content = "different ranges of phone" },
    new BlogPost { Id = 3, Title = "Tablet", Content = "different ranges of Tablet" }
};
int nextId = 4;

app.MapGet("/posts", () => posts);

app.MapGet("/posts/{id:int}",  (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    return post is null ? Results.NotFound("Post not found") : Results.Ok(post);
});

app.MapPost("/posts",  (int id, BlogPost post) =>
{
    post.Id = nextId++;
    posts.Add(post);
    Results.Ok(post);
});

app.MapPut("/posts/{id:int}",  (int id, BlogPost updatedpost) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    post.Title = updatedpost.Title;
    post.Content = updatedpost.Content;
    Results.Ok(post);
});

app.MapPatch("/posts/{id:int}",  (int id, BlogPost updatedpost) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if(post==null) return Results.NotFound("Post not found");
    if (!string.IsNullOrEmpty(post.Title)) post.Title = updatedpost.Title;
    if (!string.IsNullOrEmpty(post.Content)) post.Content = updatedpost.Content;
    return Results.Ok(post);
});

app.MapDelete("posts/{id:int}",  (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post == null) return Results.NotFound("Post not found");
    posts.Remove(post);
    return Results.Ok(post);
});
app.Run();
