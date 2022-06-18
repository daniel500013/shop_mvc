
![](/git/image.png)

# Sklep
Uproszczony projekt sklepu stworzony przy użyciu Entity Framework Core oraz wzorca MVC

# Wymagania
`` SQL Server >2016``
<br />
``.NET Core 6``

# Domyślne dane logowania
### Admin
`` Login: admin@admin.com``
<br />
`` Hasło: user``
<br />
### User
`` Login: user@user.com``
<br />
`` Hasło: user``
<br />

# Baza danych
### Konfiguracja
Aby nie wystąpił błąd przy połączeniu z bazą danych należy podmienić dane potrzebne do połączenia w pliku ``appsettings.json`` przy linij ``9``
### Dodawanie 
Aby dodać baze z migracij użyj polecenia update-database w menadżerze pakietów
#### Przykład
> PM> update-database