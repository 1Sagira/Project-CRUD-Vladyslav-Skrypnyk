Projekt-CRUD-Vladyslav-Skrypnyk
Projekt „Zadania” to lekka aplikacja typu CRUD stworzona w ramach zadania szkolnego.
Służy do zarządzania listą zadań — pozwala dodawać nowe pozycje, przeglądać istniejące oraz usuwać te zakończone.

🔗 Technologie

Backend: ASP.NET Core Web API napisany w C#

Baza danych: SQLite z wykorzystaniem Entity Framework Core

Frontend: Prosty interfejs zbudowany w HTML, CSS i JavaScript


 🔗 Uruchomienie projektu

Pobierz lub sklonuj projekt na swój komputer.

Otwórz terminal w katalogu głównym projektu.

Utwórz bazę danych i wykonaj migrację:

dotnet ef migrations add Init
dotnet ef database update


 🔗 Uruchom aplikację poleceniem:

dotnet run


W przeglądarce otwórz adres podany w terminalu, np.
👉 http://localhost:5000

🔗 Dostępne endpointy API

Aplikacja udostępnia REST API, które umożliwia pełną obsługę zadań:

GET /api/zadania — pobiera listę wszystkich zadań

GET /api/zadania/{id} — zwraca jedno zadanie po jego ID

POST /api/zadania — dodaje nowe zadanie

PUT /api/zadania/{id} — edytuje istniejące zadanie

DELETE /api/zadania/{id} — usuwa zadanie z listy

🖼️ Interfejs użytkownika

Aplikacja posiada prostą stronę HTML, która umożliwia bezpośrednią interakcję z API.
Użytkownik może dodawać nowe zadania, przeglądać listę lub usuwać pozycje jednym kliknięciem.

Przykładowy wygląd listy zadań:<img width="1916" height="940" alt="photo" src="https://github.com/user-attachments/assets/eafd73df-7456-4120-ba71-9afaa421e5e1" />
