using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class AlbumManager
{
    public List<Album> Albums = new List<Album>();

    public void AddAlbum()
    {
        Console.WriteLine("Add a new album:");

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Artist: ");
        string artist = Console.ReadLine()!;

        Console.Write("Category: ");
        string category = Console.ReadLine()!;

        int year;
        while (true)
        {
            Console.Write("Year: ");
            if (int.TryParse(Console.ReadLine(), out year)) break;
            Console.WriteLine("Enter a valid number for year.");
        }

        int rating;
        while (true)
        {
            Console.Write("Rating (1-5): ");
            if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5) break;
            Console.WriteLine("Enter a valid rating between 1 and 5.");
        }

        bool isFavorite = false;
        Console.Write("Favorite? (y/n): ");
        string favInput = Console.ReadLine()!;
        if (favInput.ToLower() == "y") isFavorite = true;

        Console.Write("Description: ");
        string description = Console.ReadLine()!;

        int id = Albums.Count > 0 ? Albums.Max(a => a.Id) + 1 : 1;

        Album newAlbum = new Album(id, name, artist, category, description, year, rating, isFavorite);

        Albums.Add(newAlbum);

        Console.WriteLine($"Album '{name}' added successfully!");
    }

    public void ListAlbums()
    {
        foreach (var a in Albums)
        {
            Console.WriteLine($"{a.Id} - {a.Name} - {a.Artist} - {a.Category} - {a.Year}");
        }
    }

    public void SearchByName(string name)
    {
        var result = Albums.Where(a => a.Name.ToLower().Contains(name.ToLower()));
        foreach (var a in result)
        {
            Console.WriteLine(a.Name);
        }
    }

    public void FilterByCategory(string category)
    {
        var result = Albums.Where(a => a.Category.ToLower() == category.ToLower());
        foreach (var a in result)
        {
            Console.WriteLine(a.Name);
        }
    }

    public void SortByYear()
    {
        Albums = Albums.OrderBy(a => a.Year).ToList();
    }

    public void SaveCsv(string path)
    {
        File.WriteAllLines(path, Albums.Select(a => a.ToCsv()));
    }

    public void LoadCsv(string path)
    {
        Albums.Clear();
        foreach (var line in File.ReadAllLines(path))
        {
            Albums.Add(Album.FromCsv(line));
        }
    }

    public string GenerateItemsTable()
    {
        string rows = "";
        foreach (var a in Albums)
        {
            rows += $"<tr><td>{a.Name}</td><td>{a.Artist}</td><td>{a.Category}</td><td>{a.Year}</td><td>{a.Rating}</td></tr>";
        }

        return $@"
    <table>
        <thead>
            <tr>
                <th>Album</th>
                <th>Artist</th>
                <th>Genre</th>
                <th>Year</th>
                <th>Rating</th>
            </tr>
        </thead>
        <tbody>
            {rows}
        </tbody>
    </table>
    ";
    }

    public string GenerateFavorites()
    {
        string cards = "";

        foreach (var a in Albums.Where(x => x.IsFavorite))
        {
            cards += $"<div class='card'><h3>{a.Name}</h3><p>{a.Artist}</p><p>{a.Description}</p></div>";
        }

        return cards;
    }

    public string GenerateStats()
    {
        int count = Albums.Count;
        int fav = Albums.Count(a => a.IsFavorite);
        int categories = Albums.Select(a => a.Category).Distinct().Count();

        return $@"
        <div class='stats-container'>
            <div class='stat-box'>
                <h3>Albums</h3>
                <p>{count}</p>
            </div>
            <div class='stat-box'>
                <h3>Favorites</h3>
                <p>{fav}</p>
            </div>
            <div class='stat-box'>
                <h3>Categories</h3>
                <p>{categories}</p>
            </div>
        </div>
        ";
    }

    public void ExportHtml()
    {
        string template = File.ReadAllText("template/template.html");

        string index = template.Replace("{{TITLE}}", "Music Albums")
                               .Replace("{{CONTENT}}", GenerateStats());

        File.WriteAllText("output/index.html", index);

        string items = template.Replace("{{TITLE}}", "All Albums")
                               .Replace("{{CONTENT}}", GenerateItemsTable());

        File.WriteAllText("output/items.html", items);

        string fav = template.Replace("<main>", "<main class='cards'>")
                     .Replace("{{TITLE}}", "Favorites")
                     .Replace("{{CONTENT}}", GenerateFavorites());

        File.WriteAllText("output/favorites.html", fav);
    }
}