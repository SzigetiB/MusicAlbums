import requests
import os
 
INPUT_FILE = "albums.txt"
OUTPUT_DIR = "covers"
 
print("Script elindult...")
 
if not os.path.exists(INPUT_FILE):
    print("NINCS albums.txt fájl!")
    exit()
 
os.makedirs(OUTPUT_DIR, exist_ok=True)
 
def get_cover(artist, album):
    query = f"{artist} {album}"
    url = f"https://itunes.apple.com/search?term={query}&entity=album&limit=1"
 
    try:
        r = requests.get(url)
        data = r.json()
 
        if data["resultCount"] > 0:
            artwork = data["results"][0]["artworkUrl100"]
            return artwork.replace("100x100", "600x600")
    except Exception as e:
        print("Hiba:", e)
 
    return None
 
 
with open(INPUT_FILE, "r", encoding="utf-8") as f:
    for line in f:
        parts = line.strip().split(";")
 
        if len(parts) < 3:
            continue
 
        album_id, album, artist = parts[0], parts[1], parts[2]
 
        print(f"Keresés: {artist} - {album}")
 
        url = get_cover(artist, album)
 
        if url:
            try:
                img = requests.get(url).content
                filename = f"{album_id}.jpg"
 
                with open(os.path.join(OUTPUT_DIR, filename), "wb") as f:
                    f.write(img)
 
                print("OK")
            except:
                print("Letöltési hiba")
        else:
            print("NINCS találat")
 