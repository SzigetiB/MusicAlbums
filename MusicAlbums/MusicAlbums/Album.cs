using System;

class Album
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public int Rating { get; set; }
    public bool IsFavorite { get; set; }

    public Album(int id, string name, string artist, string category,
                 string description, int year, int rating, bool favorite)
    {
        Id = id;
        Name = name;
        Artist = artist;
        Category = category;
        Description = description;
        Year = year;
        Rating = rating;
        IsFavorite = favorite;
    }
    
    public string ToCsv()
    {
        return $"{Id};{Name};{Artist};{Category};{Description};{Year};{Rating};{IsFavorite}";
    }

    public static Album FromCsv(string line)
    {
        var d = line.Split(';');
        return new Album(
            int.Parse(d[0]),
            d[1],
            d[2],
            d[3],
            d[4],
            int.Parse(d[5]),
            int.Parse(d[6]),
            bool.Parse(d[7])
        );
    }
}
