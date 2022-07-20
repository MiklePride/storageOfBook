class program
{
    static void Main(string[] args)
    {
        var library = new Library();
        bool isWork = true;
        string userInput;

        Console.WriteLine("Добро пожаловать в библиотеку!");

        while (isWork)
        {
            Console.WriteLine("Выберите комманду:");
            Console.WriteLine("1. Добавить книгу.\n" +
                "2. Убрать книгу.\n" +
                "3. Показать все книги.\n" +
                "4. Показать книги по указаному параметру.\n" +
                "5. Выход.");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    library.AddBook();
                    break;
                case "2":
                    library.RemoveBook();
                    break;
                case "3":
                    library.ShowAllBook();
                    break;
                case "4":
                    library.ShowBooksBySelectedParameters();
                    break;
                case "5":
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Такой команды нет!");
                    break;
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

class Library
{
    private List<Book> _books = new List<Book>();

    public void AddBook()
    {
        Console.Clear();

        Console.WriteLine("Введите название книги:");
        string titleOfBook = Console.ReadLine();

        Console.WriteLine("Укажите автора книги:");
        string authorOfBook = Console.ReadLine();

        Console.WriteLine("Укажите жанр книги:");
        string genreOfBook = Console.ReadLine();

        Console.WriteLine("Укажите дату выпуска книги:");
        int bookRelease = GetNumber();

        _books.Add(new Book(titleOfBook, authorOfBook, genreOfBook, bookRelease));

        Console.WriteLine("Книга добавлена в библиотеку!");
    }

    public void RemoveBook()
    {
        Console.Clear();

        if (_books.Count > 0)
        {
            int numberBook = 0;

            foreach (Book book in _books)
            {
                numberBook++;
                Console.Write(numberBook);
                book.ShowInfo();
            }

            Console.Write("Введите номер книги, которую хотите удалить:");

            int userInput = GetNumber();

            _books.RemoveAt(userInput - 1);

            Console.WriteLine("Книга удалена!");
        }
        else
            ShowErrorMessage();
    }

    public void ShowAllBook()
    {
        Console.Clear();

        if (_books.Count > 0)
        {
            foreach (Book book in _books)
            {
                book.ShowInfo();
            }
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
        else
            ShowErrorMessage();
    }

    public void ShowBooksBySelectedParameters()
    {
        Console.Clear();

        if (_books.Count > 0)
        {
            bool isWork = true;

            Console.WriteLine("Выберите по какому параметру вывести книги:\n" +
                "1. Вывести книги по названию.\n" +
                "2. Вывести книги по автору.\n" +
                "3. Вывести книги жанру.\n" +
                "4. Вывести книги по году выпуска.\n");

            while (isWork)
            {
                int numberUser = GetNumber();

                switch (numberUser)
                {
                    case 1:
                        ShowBooksByTitle();
                        break;
                    case 2:
                        ShowBooksByAuthor();
                        break;
                    case 3:
                        ShowBooksByGenre();
                        break;
                    case 4:
                        ShowBooksByYearOfRelease();
                        break;
                    default:
                        ShowErrorMessage("Такого параметра нет!");
                        break;

                }
                isWork = false;
            }
        }
        else
            ShowErrorMessage();
    }

    private void ShowBooksByTitle()
    {
        Console.WriteLine("Введите название книги:");
        string userInput = Console.ReadLine();
        int countBooks = 0;

        foreach (Book book in _books)
        {
            if (book.Title.ToLower() == userInput.ToLower())
            {
                countBooks++;
                book.ShowInfo();
            }
        }

        if (countBooks == 0)
            ShowErrorMessage("Книг с таким названием не найдено!");

        Console.WriteLine("нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private void ShowBooksByAuthor()
    {
        Console.WriteLine("Введите имя автора:");
        string userInput = Console.ReadLine();
        int countBooks = 0;

        foreach (Book book in _books)
        {
            if (book.Author.ToLower() == userInput.ToLower())
            {
                countBooks++;
                book.ShowInfo();
            }
        }

        if (countBooks == 0)
            ShowErrorMessage("Книг с таким автором не найдено!");

        Console.WriteLine("нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private void ShowBooksByGenre()
    {
        Console.WriteLine("Введите название жанра:");
        string userInput = Console.ReadLine();
        int countBooks = 0;

        foreach (Book book in _books)
        {
            if (book.Genre.ToLower() == userInput.ToLower())
            {
                countBooks++;
                book.ShowInfo();
            }
        }

        if (countBooks == 0)
            ShowErrorMessage("Книг с таким жанром не найдено!");

        Console.WriteLine("нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private void ShowBooksByYearOfRelease()
    {
        Console.WriteLine("Введите год выпуска:");
        int userInput = GetNumber();
        int countBooks = 0;

        foreach (Book book in _books)
        {
            if (book.YearOfRelease == userInput)
            {
                countBooks++;
                book.ShowInfo();
            }
        }

        if (countBooks == 0)
            ShowErrorMessage("Книг с таким годом выпуска не найдено!");

        Console.WriteLine("нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private int GetNumber()
    {
        bool isNumberWork = true;
        int userNumber = 0;

        while (isNumberWork)
        {
            bool isNumber = true;
            string userInput = Console.ReadLine();

            if (isNumber = int.TryParse(userInput, out int number))
            {
                userNumber = number;
                isNumberWork = false;
            }
            else
            {
                Console.WriteLine($"Не правильный ввод данных!!!  Повторите попытку");
            }
        }
        return userNumber;
    }

    private void ShowErrorMessage(string message = "В библиотеке нет ни одной книги!")
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.WriteLine(message);
        Console.ForegroundColor = color;
    }
}

class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public int YearOfRelease { get; private set; }

    public Book(string title, string author, string genre, int yearOfRelease)
    {
        Title = title;
        Author = author;
        Genre = genre;
        YearOfRelease = yearOfRelease;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"|Название - {Title}|\n |Автор - {Author}|\n |Жанр - {Genre}|\n |Год выпуска - {YearOfRelease}|\n");
    }
}