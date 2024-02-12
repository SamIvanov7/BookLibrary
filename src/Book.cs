public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Publisher Publisher { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(string title, string author, Publisher publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }
}
