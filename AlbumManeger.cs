using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class AlbumManager
{
    public List<Album> Albums = new List<Album>();

    public void AddAlbum(Album album)
    {
        Albums.Add(album);
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

        return rows;
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

        return $"<p>Albums: {count}</p><p>Favorites: {fav}</p><p>Categories: {categories}</p>";
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

        string fav = template.Replace("{{TITLE}}", "Favorites")
                             .Replace("{{CONTENT}}", GenerateFavorites());

        File.WriteAllText("output/favorites.html", fav);
    }
}