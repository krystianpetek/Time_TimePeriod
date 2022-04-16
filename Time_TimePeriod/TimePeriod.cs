namespace Time_TimePeriod
{
    /// <summary>
    /// Struktura <c>TimePeriod</c> reprezentuje długość odcinka w czasie (odległość między dwoma punktami czasowymi, czas trwania)
    /// </summary>
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <summary>
        /// Reprezentuje godzinę w sekundach, pole jest tylko do odczytu.
        /// </summary>
        public long NumberOfSeconds { get; init; }

        /// <summary>
        /// Reprezentuje liczbę godzin w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Hours => (NumberOfSeconds / 60) / 60;

        /// <summary>
        /// Reprezentuje liczbę minut w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Minutes => (NumberOfSeconds / 60) % 60;

        /// <summary>
        /// Reprezentuje liczbę sekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Seconds => NumberOfSeconds % 60;

        /// <summary>
        /// Konstruktor przyjmuje 3 argumenty reprezentacji odcinka czasu tj. godzina, minuta, sekunda.
        /// </summary>
        /// <param name="numOfHours">Parametr <c>numOfHours</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <param name="numOfMinutes">Parametr <c>numOfMinutes</c> reprezentuje liczbę minut w odcinku czasu</param>
        /// <param name="numOfSeconds">Parametr <c>numOfSeconds</c> reprezentuje liczbę sekund w odcinku czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu minut i sekund</exception>
        public TimePeriod(long numOfHours, long numOfMinutes, long numOfSeconds)
        {
            if (numOfHours < 0 || numOfMinutes >= 60 || numOfMinutes < 0 || numOfSeconds >= 60 || numOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong range of time.");

            NumberOfSeconds = (numOfHours * 3600) + (numOfMinutes * 60) + numOfSeconds;
        }

        /// <summary>
        /// Konstruktor przyjmuje 2 argumenty reprezentacji odcinka czasu tj. godzina, minuta.
        /// </summary>
        /// <param name="numOfHours">Parametr <c>numOfHours</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <param name="numOfMinutes">Parametr <c>numOfMinutes</c> reprezentuje liczbę minut w odcinku czasu</param>
        public TimePeriod(long numOfHours, long numOfMinutes) : this(numOfHours, numOfMinutes, 0) { }

        /// <summary>
        /// Konstruktor domyślny reprezentacji odcinka czasu. Wszystkie wartości default czyli 0.
        /// </summary>
        public TimePeriod() : this(0, 0, 0) { }

        /// <summary>
        /// Konstruktor przyjmuje 1 argument reprezentacji czasu tj. sekundy. Przykładowo argument 3600 tworzy obiekt TimePeriod o wartości 1 godzina, 0 minut, 0 sekund
        /// </summary>
        /// <param name="numberOfSeconds">Parametr <c>numberOfSeconds</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku podania wartości z poza zakresu, tj, wartości ujemnych</exception>
        public TimePeriod(long numberOfSeconds)
        {
            if (numberOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong value of seconds.");

            NumberOfSeconds = numberOfSeconds;
        }

        /// <summary>
        /// Konstruktor tworzy obiekt typu TimePeriod, o wartościach różnicy czasu Time t1 i t2
        /// </summary>
        /// <param name="t1">Argument typu <c>Time</c> przyjmuje punkt w czasie t1</param>
        /// <param name="t2">Argument typu <c>Time</c> przyjmuje punkt w czasie t2</param>
        public TimePeriod(Time t1, Time t2)
        {
            long hours = 0, minutes = 0, seconds = 0;
            if (t1.CompareTo(t2) > 0)
            {
                hours = t1.Hours - t2.Hours;
                minutes = t1.Minutes - t2.Minutes;
                seconds = t1.Seconds - t2.Seconds;
            }
            else if (t1.CompareTo(t2) < 0)
            {
                hours = t2.Hours - t1.Hours;
                minutes = t2.Minutes - t1.Minutes;
                seconds = t2.Seconds - t1.Seconds;
            }

            NumberOfSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// Konstruktor tworzy obiekt TimePeriod parsując argument czas ze <c>String</c>'a
        /// </summary>
        /// <param name="timePattern">Parametr timePattern reprezentuje czas, lecz w formie string'a</param>
        /// <exception cref="FormatException">Wyrzuca wyjątek w momencie wprowadzenia złych danych, niemożliwych do parsowania</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public TimePeriod(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length != 3)
                throw new ArgumentOutOfRangeException("Wrong data in argument");

            bool parseHours = byte.TryParse(splitTime[0], out byte hours);
            bool parseMinutes = byte.TryParse(splitTime[1], out byte minutes);
            bool parseSeconds = byte.TryParse(splitTime[2], out byte seconds);

            if (!parseHours || !parseMinutes || !parseSeconds)
                throw new ArgumentOutOfRangeException("Invalid argument for parse to Time.");

            if (hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");

            NumberOfSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// Tekstowa reprezentacja odcinka czasu TimePeriod, zwraca zewnętrzną reprezentacje czasu w formie string'a
        /// </summary>
        /// <returns>Zwraca zewnętrzną reprezentacje TimePeriod</returns>
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        /// <summary>
        /// Porównuje obiekt TimePeriod instancji i przekazany obiekt w parametrze, zwraca wartość:
        /// <list type="table">
        /// <term>1</term> <description>gdy obiekt instancji jest większy niż obiekt przekazany w parametrze</description><br/>
        /// <term>0</term> <description>gdy obiekt instancji jest równy obiektowi przekazanemu w parametrze</description><br/>
        /// <term>-1</term> <description>gdy obiekt instancji jest mniejszy niż obiekt przekazany w parametrze</description>
        /// </list></summary>
        /// <param name="other">Obiekt porównywany typu TimePeriod</param>
        /// <returns>Zwraca wartość pomiędzy 1, 0 lub -1</returns>
        public int CompareTo(TimePeriod other)
        {
            if (this.NumberOfSeconds > other.NumberOfSeconds)
                return 1;
            else if (this.NumberOfSeconds < other.NumberOfSeconds)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Sprawdza czy obiekt instancji TimePeriod i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją typu TimePeriod, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public bool Equals(TimePeriod other)
        {
            if (this.NumberOfSeconds == other.NumberOfSeconds)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt instancji TimePeriod i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="obj">Obiekt porównywany z instancją typu TimePeriod, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public override bool Equals(object? obj)
        {
            if (obj is TimePeriod)
                return Equals(obj as TimePeriod?);
            return false;
        }

        /// <summary>
        /// Służy jako domyślna funkcja skrótu
        /// </summary>
        /// <returns>Zwraca wartość int, zawierającą obliczoną funkcję skrótu obiektu</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        /// <summary>
        /// Sprawdza czy obiekty TimePeriod przekazane przez parametr są sobie równe
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public static bool operator ==(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.Equals(timePeriod2);
        }

        /// <summary>
        /// Sprawdza czy obiekty TimePeriod przekazane przez parametr są różne
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są różne</returns>
        public static bool operator !=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return !(timePeriod1 == timePeriod2);
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriod timePeriod1 jest mniejszy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriod timePeriod1 jest mniejszy od TimePeriod timePeriod2</returns>
        public static bool operator <(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriod timePeriod1 jest większy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest większy od Time t2</returns>
        public static bool operator >(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriod timePeriod1 jest mniejszy lub równy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriod timePeriod1 jest mniejszy lub równy od TimePeriod timePeriod2</returns>

        public static bool operator <=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriod timePeriod1 jest większy lub równy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriod timePeriod1 jest większy lub równy od TimePeriod timePeriod2</returns>
        public static bool operator >=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod sumujący odcinki czasu TimePeriod</returns>
        public TimePeriod Plus(TimePeriod timePeriod)
        {
            return this + timePeriod;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod sumujący odcinki czasu TimePeriod</returns>
        public static TimePeriod Plus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 + timePeriod2;
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod odejmujący odcinki czasu TimePeriod</returns>
        public TimePeriod Minus(TimePeriod timePeriod)
        {
            return this - timePeriod;
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod odejmujący odcinki czasu TimePeriod</returns>
        public static TimePeriod Minus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 - timePeriod2;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod sumujący odcinki czasu TimePeriod</returns>
        public static TimePeriod operator +(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return new TimePeriod(timePeriod1.NumberOfSeconds + timePeriod2.NumberOfSeconds);
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriod, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriod odejmujący odcinki czasu TimePeriod</returns>
        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.NumberOfSeconds > timePeriod2.NumberOfSeconds)
                return new TimePeriod(timePeriod1.NumberOfSeconds - timePeriod2.NumberOfSeconds);
            else if (timePeriod1.NumberOfSeconds < timePeriod2.NumberOfSeconds)
                return new TimePeriod(timePeriod2.NumberOfSeconds - timePeriod1.NumberOfSeconds);
            else
                return new TimePeriod();
        }

        /// <summary>
        /// Operator mnożenia mnoży godzinę z okresu czasu, o mnożnik podany po operatorze
        /// </summary>
        /// <param name="timePeriod">Obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <param name="iloraz">Mnożnik godzin</param>
        /// <returns></returns>
        public static TimePeriod operator *(TimePeriod timePeriod, int iloraz)
        {
            return new TimePeriod(timePeriod.Hours * iloraz, timePeriod.Minutes, timePeriod.Seconds);
        }
    }
}