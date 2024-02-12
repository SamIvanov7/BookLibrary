using System.Collections.Generic;
using System.Linq;

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public bool TakeBook(string title)
    {
        var book = books.FirstOrDefault(b => b.Title == title && b.IsAvailable);
        if (book != null)
        {
            book.IsAvailable = false;
            return true;
        }
        return false;
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        return books.Where(b => b.Title.Contains(title));
    }

    public IEnumerable<Book> SearchByAuthor(string author)
    {
        return books.Where(b => b.Author.Contains(author));
    }

    public IEnumerable<Book> SearchByPublisher(string publisherName)
    {
        return books.Where(b => b.Publisher.Name.Contains(publisherName));
    }

    public void RenamePublisher(string oldName, string newName)
    {
        foreach (var book in books.Where(b => b.Publisher.Name == oldName))
        {
            book.Publisher.Name = newName;
        }
    }
}
