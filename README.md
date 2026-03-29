# MusicAlbums

## Csapattagok

* Szigeti Balázs
* Varga Márk

## Választott téma

Zenei albumok gyűjteménye

## Adatmodell

A fő osztály `Album` mezői:

* Id (int) – egyedi azonosító
* Name (string) – album címe
* Artist (string) – előadó
* Category (string) – műfaj
* Description (string) – leírás
* Year (int) – megjelenés éve
* Rating (int) – értékelés
* IsFavorite (bool) – kedvenc
* ImageFile (string) – kép fájl neve

További osztály:

* AlbumManager – lista kezelése, keresés, szűrés, rendezés, CSV/JSON kezelés, HTML generálás

## Program funkciók

* Menü alapú konzolos felület
* Új album hozzáadása
* Albumok listázása
* Keresés név alapján
* Szűrés kategória szerint
* Rendezés év szerint
* CSV mentés és betöltés
* JSON betöltés
* HTML export

## Generált HTML oldalak

* index.html – statisztika
* items.html – összes album táblázatban
* favorites.html – kedvenc albumok kártyákban

## Mappaszerkezet

```
MusicAlbums/
│-- Program.cs
│-- Album.cs
│-- AlbumManager.cs
│-- data/
│   └-- albums.json
│-- images/
│   └-- 1.jpg ... 200.jpg
│-- template/
│   └-- template.html
│-- output/
│   └-- index.html, items.html, favorites.html
│-- style.css
│-- README.md
```

## Program futtatása

1. Program indítása
2. JSON vagy CSV betöltése
3. Menü használata
4. HTML export
5. HTML fájlok az output mappában jelennek meg
