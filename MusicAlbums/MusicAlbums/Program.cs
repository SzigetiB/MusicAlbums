using System;

class Program
{
    static void Main()
    {
        AlbumManager manager = new AlbumManager();
        bool running = true;

        while (running)
        {

            Console.WriteLine("\n1 Add Album: ");
            Console.WriteLine("2 List Albums: ");
            Console.WriteLine("3 Search: ");
            Console.WriteLine("4 Filter: ");
            Console.WriteLine("5 Save CSV: ");
            Console.WriteLine("6 Load CSV");
            Console.WriteLine("7 Export HTML: ");
            Console.WriteLine("0 Exit");
            Console.Write("Select a menu item: ");

            string input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    manager.AddAlbum();
                    break;
                case "2":
                    manager.ListAlbums();
                    break;

                case "3":
                    Console.WriteLine("Name:");
                    manager.SearchByName(Console.ReadLine()!);
                    break;

                case "4":
                    Console.WriteLine("Category:");
                    manager.FilterByCategory(Console.ReadLine()!);
                    break;

                case "5":
                    manager.SaveCsv("data/albums.csv");
                    break;

                case "6":
                    manager.LoadCsv("data/albums.csv");
                    break;

                case "7":
                    manager.ExportHtml();
                    break;

                case "0":
                    running = false;
                    break;
            }
        }
    }
}