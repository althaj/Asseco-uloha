# Asseco úloha

# Installation
Download the project. Open the project in Visual Studio. Run DatabazaOsob project.
You will arrive at a swagger page with 2 endpoints - GET /api/Osoby/{id} and POST /api/Osoby.

# Creating Osoba
Use the POST request to create a new Osoba entity. Here's an example request body:
```
{
  "jmeno": "Jan",
  "prijmeni": "Novák",
  "rodnePrijmeni": "Novák",
  "rodneCislo": "9504097372",
  "datumNarozeni": "1985-01-01T00:00:00",
  "narodnost": "Česká",
  "bydliste": {
    "ulice": "Hlavní 123",
    "mesto": "Praha",
    "psc": "11000",
    "stat": "Česká republika"
  },
  "kontakty": [
    {
      "typKontaktu": "Telefon",
      "hodnota": "+420123456789"
    },
    {
      "typKontaktu": "Email",
      "hodnota": "jan.novak@example.com"
    }
  ]
}
```

# Database and logs
Database and logs are located in C:\Users\<USER>\AppData\Local\DatabazaOsob
