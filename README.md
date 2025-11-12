Raport Techniczny Projektu "Zadania" (Aplikacja CRUD)
Cel: Stworzenie w pełni funkcjonalnej aplikacji CRUD do zarządzania zadaniami z pełną walidacją (UI i backend), niestandardową obsługą błędów i konfiguracją potoku CI/CD.

1. Przegląd Architektury i Adresy URL
Projekt składa się z kilku kluczowych komponentów:

Backend (API): Wykorzystuje ASP.NET Core 8 w C#. Adres API to: https://project-crud-vladyslav-skrypnyk2.onrender.com/api/zadania

Frontend (UI): Jest zbudowany w oparciu o czysty HTML5, CSS i JavaScript. Aplikacja dostępna jest pod adresem: https://project-crud-vladyslav-skrypnyk2.onrender.com/

Baza danych: Używa Entity Framework Core z bazą SQLite.

CI/CD: Proces jest zarządzany przez GitHub Actions i wykorzystuje Docker.

2. Realizacja Wymagań
2.1. Walidacja (UI i Backend)
Frontend (index.html):
Natywna Walidacja HTML5: Pola wejściowe są wyposażone w atrybuty takie jak required, minlength, maxlength, min i max, co wymusza wstępną walidację po stronie przeglądarki.

Korekta Formularza: Kontener formularza został zmieniony z elementu <div> na element <form id="zadanie-form">, co naprawiło błąd checkValidity is not a function i umożliwiło poprawne działanie natywnej walidacji.

Backend (C#):
Walidacja Modeli: W klasie Zadanie.cs użyto Atrybutów Danych ([Required], [StringLength], [Range]) do egzekwowania reguł biznesowych.

Niestandardowa Obsługa Błędów: Kontroler ZadaniaController.cs w przypadku niepowodzenia walidacji zwraca odpowiedź z kodem 400 Bad Request w wymaganym formacie JSON, zawierającym szczegółową listę błędów pól (fieldErrors).

2.2. Format Kodów Błędów HTTP
Serwer poprawnie obsługuje i zwraca następujące kody HTTP:

400 Bad Request: Zwracany w przypadku nieudanej walidacji danych, wraz z niestandardowym JSON-em błędu.

404 Not Found: Zwracany, gdy próbuje się pobrać lub usunąć nieistniejący zasób.

201 Created: Zwracany po pomyślnym utworzeniu nowego zasobu.

204 No Content: Zwracany po pomyślnym usunięciu zasobu.

2.3. Infrastruktura i CI/CD
Konfiguracja Aplikacji: W pliku Program.cs skonfigurowano politykę CORS (dla adresu https://project-crud-vladyslav-skrypnyk2.onrender.com) i dodano automatyczne stosowanie migracji bazy danych.

Potok CI/CD: Utworzono potok GitHub Actions (main.yml). Uruchamia się on przy push do gałęzi main. Potok składa się z kroków kompilacji, uruchomienia testów i wdrożenia (deployment) – ostatni krok jest wykonywany tylko wtedy, gdy testy zakończyły się sukcesem.

3. Punkty Kontrolne
Stan realizacji kluczowych wymagań:

Walidacja w UI i backendzie: Zaimplementowana i działa.

Poprawne kody błędów HTTP: Zaimplementowane.

Pipeline CI/CD działa: Potok jest skonfigurowany.

Testy uruchamiane automatycznie: Krok dotnet test jest włączony w potoku CI/CD.

Adresy środowisk w dokumencie: Adresy URL zostały dodane w sekcji 1.

Naprawiono błąd checkValidity: Błąd został usunięty.

