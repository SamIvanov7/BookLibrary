using System;

class Program
{
    static Library library = new Library();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSolar Engineering Book Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Take Book");
            Console.WriteLine("3. Search Books");
            Console.WriteLine("4. Rename Publisher");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddBookToLibrary();
                    break;
                case "2":
                    TakeBookFromLibrary();
                    break;
                case "3":
                    SearchBooks();
                    break;
                case "4":
                    RenamePublisher();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddBookToLibrary()
    {
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        Console.Write("Enter author name: ");
        var author = Console.ReadLine();
        Console.Write("Enter publisher name: ");
        var publisherName = Console.ReadLine();

        var publisher = new Publisher(publisherName);
        var book = new Book(title, author, publisher);
        library.AddBook(book);

        Console.WriteLine($"Book '{title}' by {author} added successfully.");
    }

    static void TakeBookFromLibrary()
    {
        Console.Write("Enter the title of the book which you want to take: ");
        var title = Console.ReadLine();
        var success = library.TakeBook(title);

        if (success)
            Console.WriteLine($"You have taken '{title}'. Please return it when you have finished the book.");
        else
            Console.WriteLine($"Book '{title}' is not available.");
    }

    static void SearchBooks()
    {
        Console.WriteLine("Search by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Author");
        Console.WriteLine("3. Publisher");
        Console.Write("Choose an option: ");
        var searchOption = Console.ReadLine();
        Console.Write("Enter search query: ");
        var query = Console.ReadLine();

        switch (searchOption)
        {
            case "1":
                foreach (var book in library.SearchByTitle(query))
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                break;
            case "2":
                foreach (var book in library.SearchByAuthor(query))
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                break;
            case "3":
                foreach (var book in library.SearchByPublisher(query))
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                break;
            default:
                Console.WriteLine("Invalid search option.");
                break;
        }
    }

    static void RenamePublisher()
    {
        Console.Write("Enter the old publisher name: ");
        var oldName = Console.ReadLine();
        Console.Write("Enter the new publisher name: ");
        var newName = Console.ReadLine();

        library.RenamePublisher(oldName, newName);
        Console.WriteLine($"Publisher '{oldName}' renamed to '{newName}'.");
    }
}
