# Aplikacja zegara i stopera w oparciu o własny typ struct `Time` i `TimePeriod`

## Aplikacja ma zaimplementowane 2 funkcjonalności:

- Zegar wyświetla aktualną godzinę, wykorzystuje strukturę `Time`, instancja zegara jest tworzona po zmianie z ekranu powitalnego, wybierając z menu rozwijanego ikonę zegara i działa jako singleton do końca działania aplikacji

- Stoper odmierza czas, wykorzystuje strukturę `TimePeriod`, instancja zegara jest tworzona po zmianie z ekranu powitalnego, wybierając z menu rozwijanego ikonę stopera i działa jako singleton do końca działania aplikacji. Można zresetować działanie stopera klikając na przycisk RESET. Stoper można zatrzymać w każdym momencie i wznowić działanie w celu dalszego odliczania czasu.

## Krótki opis implementacji struktur

W aplikacji zaprogramowane zostały struktury `Time` oraz `TimePeriod` aby spełniały wymagania:

### Struktura `Time`

- Zmienna typu Time opisuje punkt w czasie, w przedziale 00:00:00 - 23:59:59
- Struktura jest readonly, aby nie było możliwości modyfikacji property żadnej istniejącej instancji
- Przeciążone domyślne metody wirtualne, tz. ToString(), GetHashCode() oraz Equals()
- Implementacja interfejsów generycznych IEquatable oraz IComparable, co pozwoliło utworzyć własne metody CompareTo oraz Equals
- Konstruktory przyjmują czas w formacie liczb typu `byte` a także zapewniona została implementacja z typu `string`
- Implementacja podstawowych operatorów działań na czasie, tj.

> - operator równości `==` oraz nierówności `!=`
> - operator większy `>` oraz większy lub równy `>=`
> - operator mniejszy `<` oraz mniejszy lub równy `<=`
> - operator dodawania `+` oraz odejmowanmia `-`

- Metody `Time Plus(TimePeriod)`, `Time Minus(TimePeriod)`
- Metody statyczne struktury `Time.Plus(Time, TimePeriod)`, `Time.Minus(Time, TimePeriod)`

Metody te mają na celu od punktu w czasie `Time` dodać / odjąć podany odstęp czasu, długość czasu `TimePeriod`, na przykład,
do godziny 13:12:00 po dodaniu 22:10:30 dostaniemy w wyniku sumowania instancje typu Time o wartości 11:22:30

### Struktura `TimePeriod`

- Zmienna typu TimePeriod opisuje długość odcinka w czasie tj. nie ma limitu godzin jak w przypadku struktury `Time`, przykładowo może istnieć obiekt o wartościach '234:00:00'
- Struktura jest readonly, aby nie było możliwości modyfikacji property żadnej istniejącej instancji
- Przeciążone domyślne metody wirtualne, tz. ToString(), GetHashCode() oraz Equals()
- Implementacja interfejsów generycznych IEquatable oraz IComparable, co pozwoliło utworzyć własne metody CompareTo oraz Equals
- Konstruktory przyjmują czas w formacie liczb typu `byte` a także zapewniona została implementacja z typu `string`
- Zaimplementowane wszystkie operatory takie same jak w przypadku `Time`, lecz jest jeszcze:

> - operator mnożenia `*` - mnoży liczbę godzin w instancji przez mnożnik podany po operatorze *

- Metody `TimePeriod Plus(TimePeriod)`, `TimePeriod Minus(TimePeriod)`
- Metody statyczne struktury `TimePeriod.Plus(TimePeriod, TimePeriod)`, `TimePeriod.Minus(TimePeriod, TimePeriod)`

Metody te mają na celu do odstępu czasu `TimePeriod` dodać / odjąć podaną długość czasu `TimePeriod`, na przykład, do godziny 13:12:00 po dodaniu 22:10:30 dostaniemy w wyniku sumowania instancje typu TimePeriod o wartości 35:22:30

Do obu struktur zostały zaimplementowane obszerne testy jednostkowe, walidujące poprawność tworzenia instancji, porównywań, operacji arytmetycznych.

Autor: Krystian Petek

Pomysłodawca aplikacji, wykładowca WSEI Kraków [Krzysztof Molenda](https://github.com/kmolenda), dokładny [opis](https://github.com/wsei-csharp201/cs-lab-Time-and-TimePeriod)
