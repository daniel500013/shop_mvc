

![](/git/image.png)

# Sklep
Uproszczony projekt sklepu stworzony przy użyciu Entity Framework Core oraz wzorca MVC

# Funkcje
- ``Wyświetlanie listy produktów``
- ``Dodawanie produktów``
- ``Edycja produktów``
- ``Usuwanie produktów``
- ``Autoryzacja użytkowników``

# Wymagania
`` SQL Server >2016``
<br />
``.NET Core 6``

# Domyślne dane logowania
### Admin
`` Login: admin@admin.com``
<br />
`` Hasło: admin``
<br />
### User
`` Login: user@user.com``
<br />
`` Hasło: user``
<br />

# Baza danych
### Konfiguracja
Aby nie wystąpił błąd przy połączeniu z bazą danych należy podmienić dane potrzebne do połączenia w pliku ``appsettings.json`` przy linii ``9``
### Dodawanie 
Aby dodać baze z migracji użyj polecenia update-database w menadżerze pakietów
#### Przykład
> PM> update-database