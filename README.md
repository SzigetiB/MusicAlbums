# MusicAlbums
# Music Project

## Csapattagok
- Balázs Szigeti
- [Másik tag neve]

## Választott téma
Zenei albumok gyűjteménye

## Adatmodell
A fő osztály `Album` a következő mezőkkel:
- `Id` (int) – egyedi azonosító
- `Name` (string) – album címe
- `Category` (string) – műfaj
- `Description` (string) – rövid leírás
- `Year` (int) – megjelenés éve
- `Rating` (int) – értékelés 1–10
- `IsFavorite` (bool) – kedvenc jelzés

További osztályok:
- `AlbumManager` – lista kezelése, keresés, szűrés, CSV kezelés, HTML generálás

## Program funkciók
- Menü alapú konzolos felület
- Új album hozzáadása
- Albumok listázása
- Keresés név alapján
- Szűrés kategória/műfaj szerint
- Rendezés év vagy értékelés szerint
- CSV export/import
- HTML export (index.html, items.html, favorites.html)

## Generált oldalak

### index.html
- Projekt címe és rövid leírás
- Statisztikai adatok (összes album, kategóriák száma)
- Néhány kiemelt album

### items.html
- Összes album táblázatban
- Minden mező megjelenítése
- Kategória címkék

### favorites.html
- Csak kedvenc albumok
- Kártya formátum
- Kiemelt vizuális megjelenítés

## Képernyőképek
![Főoldal](screenshots/index.png)
![Album lista](screenshots/items.png)
![Kedvencek](screenshots/favorites.png)