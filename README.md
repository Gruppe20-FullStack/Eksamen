# Gruppe20App - Full Stack ASP.NET Core MVC

En fullstack webapplikasjon utviklet i ASP.NET Core MVC som del av eksamen i TSD2491-1 26V Programvareutvikling.

Applikasjonen håndterer registrering av organisasjoner og tilhørende rollepersoner, og støtter import av data fra Brønnøysundregistrene via API. 

I tillegg er autentisering implementert med ASP.NET Core Identity.

---

## Funksjonalitet

### Krav 1–6 (grunnfunksjonalitet)
- CRUD for **Organisasjon**
- CRUD for **RollePerson**
- 1:N-relasjon:
  - Én organisasjon → flere rollepersoner
- Bruk av `Include()` for relasjonslasting
- Relaterte data vises i UI
- SQLite database via Entity Framework Core

### Krav 7 (frontend)
- Navigasjonsmeny implementert i layout
- Bruk av Bootstrap og Tailwind for styling

### Krav 8 (API-integrasjon)
- Import av organisasjon via Brønnøysundregistrene API
- Henter JSON-data via HTTP
- Mapper til modell og lagrer i database

Eksempel:

https://data.brreg.no/enhetsregisteret/api/enheter/{orgnr}

### Krav 9 (autentisering)
- ASP.NET Core Identity
- Registrering, innlogging og utlogging
- Bruker lagres i database (AspNetUsers)

---

## Teknologier

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- SQLite
- ASP.NET Core Identity
- Bootstrap

---

## Prosjektstruktur

Gruppe20App/
│
├── Controllers/
├── Models/
├── Views/
├── Data/
├── Services/
│ └── BrregService.cs
├── Areas/
│ └── Identity/
├── wwwroot/
└── Program.cs

---

## Git-struktur

Prosjektet benytter tre brancher:

- `main` → stabil versjon
- `dev` → krav 1–6
- `extraFeature` → krav 7–10

Flyt:

main → dev → main → extraFeature → main

---

## Kjøre applikasjonen

 (```)bash
dotnet restore
dotnet ef database update
dotnet run

Åpne:

http://localhost:5269

---

## Autentisering (Krav 9)

### Registrering

Gå til:

/Identity/Account/Register

Opprett en bruker, f.eks.:

- Email: test@gruppe20.no  
- Passord: Test_123!

### Innlogging

Gå til:

/Identity/Account/Login

Logg inn med samme bruker.

### Utlogging

Tilgjengelig i navigasjonsmenyen etter innlogging.

---

## API-import (Krav 8)

- Trykk på linken 'Import' eller gå til /Organisasjoner/Import

- Skriv inn et organisasjonsnummer, f.eks.:

974760673

- Trykk "Hent fra Brreg".

Resultat:

- Data hentes fra API
- Lagres i databasen
- Vises i /Organisasjoner

---

## Testing

Manuell testing er gjennomført for:

- CRUD-operasjoner
- Relasjonsvisning
- API-import
- Autentisering

---

## Viktige bemerkninger

- SQLite-database genereres lokalt via migrations
- Identity-tabeller opprettes ved migration (AddIdentity)
- API krever gyldig organisasjonsnummer

---

## Utviklere

Gruppe20 - Fullstack