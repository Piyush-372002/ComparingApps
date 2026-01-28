namespace Webapp.models
{
    public static class data
    {
        public static List<BlogPost> posts = new List<BlogPost>
        {
            new BlogPost { Id = 1, Title = "Sports", Content = "I love to play sports!!" },
            new BlogPost { Id = 2, Title = "Technology", Content = "Always try to learn new technologies" },
            new BlogPost { Id = 3, Title = "Travel", Content = "Traveling provides new experiences..try to explore new places" }
        };
        public static int nextId = 4;
    }
}
