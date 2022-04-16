namespace Time_TimePeriod
{
    /// <summary>
    /// Struktura <c>Time</c> opisuje punkt w czasie w przedziale od 00:00:00 - 23:59:59
    /// </summary>
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        /// <summary>
        /// Reprezentuje liczbę godzin w czasie, pole jest tylko do odczytu.
        /// </summary>
        public byte Hours { get; init; }

        /// <summary>
        /// Reprezentuje liczbę minut w czasie, pole jest tylko do odczytu.
        /// </summary>
        public byte Minutes { get; init; }

        /// <summary>
        /// Reprezentuje liczbę sekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public byte Seconds { get; init; }

        /// <summary>
        /// Konstruktor przyjmuje 3 argumenty reprezentacji czasu tj. hours, minutes, seconds.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        /// <param name="minutes">Parametr minutes reprezentuje liczbę minut w punkcie czasu</param>
        /// <param name="seconds">Parametr seconds reprezentuje liczbę sekund w punkcie czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");
            Hours = hours;
            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");
            Minutes = minutes;
            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Seconds = seconds;
        }

        /// <summary>
        /// Konstruktor przyjmuje 2 argumenty reprezentacji czasu tj. hours, minutes.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        /// <param name="minutes">Parametr minutes reprezentuje liczbę minut w punkcie czasu</param>
        public Time(byte hours, byte minutes) : this(hours, minutes, 0)
        {
        }

        /// <summary>
        /// Konstruktor przyjmuje 1 argument reprezentacji czasu tj. hours.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        public Time(byte hours) : this(hours, 0, 0)
        {
        }

        /// <summary>
        /// Konstruktor domyślny reprezentacji czasu, przyjmuje wszystkie wartości default.
        /// </summary>
        public Time() : this(0, 0, 0)
        {
        }

        /// <summary>
        /// Konstruktor tworzy obiekt Time parsując argument czas ze <c>String</c>'a
        /// </summary>
        /// <param name="timePattern">Parametr timePattern reprezentuje czas, lecz w formie string'a</param>
        /// <exception cref="FormatException">Wyrzuca wyjątek w momencie wprowadzenia złych danych, niemożliwych do Parsowania</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public Time(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length != 3)
                throw new ArgumentOutOfRangeException("Wrong data in argument");

            bool parseHours = byte.TryParse(splitTime[0], out byte hours);
            bool parseMinutes = byte.TryParse(splitTime[1], out byte minutes);
            bool parseSeconds = byte.TryParse(splitTime[2], out byte seconds);

            if (!parseHours || !parseMinutes || !parseSeconds)
                throw new ArgumentOutOfRangeException("Invalid argument for parse to Time.");

            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");
            Hours = hours;

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");
            Minutes = minutes;

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Seconds = seconds;
        }

        /// <summary>
        /// Tekstowa reprezentacja punktu w czasie Time, zwraca zewnętrzną reprezentacje czasu w formie string'a
        /// </summary>
        /// <returns>Zwraca zewnętrzną reprezentacje Time</returns>
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        /// <summary>
        /// Sprawdza czy obiekt Time instancje i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją typu Time, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public bool Equals(Time other)
        {
            if (this.Hours != other.Hours)
                return false;
            if (this.Minutes != other.Minutes)
                return false;
            if (this.Seconds != other.Seconds)
                return false;
            return true;
        }

        /// <summary>
        /// Sprawdza czy obiekt Time instancji i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Time)
                return Equals(obj as Time?);
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
        /// Porównuje obiekt Time instancji i przekazany obiekt w parametrze, zwraca wartość:
        /// <list type="table">
        /// <term>1</term> <description>gdy obiekt instancji jest większy niż obiekt przekazany w parametrze</description><br/>
        /// <term>0</term> <description>gdy obiekt instancji jest równy obiektowi przekazanemu w parametrze</description><br/>
        /// <term>-1</term> <description>gdy obiekt instancji jest mniejszy niż obiekt przekazany w parametrze</description>
        /// </list></summary>
        /// <param name="other">Obiekt porównywany typu Time</param>
        /// <returns>Zwraca wartość pomiędzy 1, 0 lub -1</returns>
        public int CompareTo(Time other)
        {
            if (this.Hours > other.Hours)
                return 1;
            else if (this.Hours == other.Hours)
            {
                if (this.Minutes > other.Minutes)
                    return 1;
                else if (this.Minutes == other.Minutes)
                {
                    if (this.Seconds > other.Seconds)
                        return 1;
                    if (this.Seconds == other.Seconds)
                        return 0;
                    return -1;
                }
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// Sprawdza czy obiekty Time przekazane przez parametr są sobie równe
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public static bool operator ==(Time time1, Time time2)
        {
            if (time1.Equals(time2))
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekty Time przekazane przez parametr są różne
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są różne</returns>
        public static bool operator !=(Time time1, Time time2)
        {
            if (time1 == time2)
                return false;
            return true;
        }

        /// <summary>
        /// Sprawdza czy obiekt Time t1 jest mniejszy od Time t2
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest mniejszy od Time t2</returns>
        public static bool operator <(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt Time t1 jest większy od Time t2
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest większy od Time t2</returns>
        public static bool operator >(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt Time t1 jest mniejszy bądź róny Time t2
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest mniejszy bądź róny Time t2</returns>
        public static bool operator <=(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt Time t1 jest większy bądź równy Time t2
        /// </summary>
        /// <param name="time1">obiekt typu Time time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu Time time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest większy bądź równy Time t2</returns>
        public static bool operator >=(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Dodaje do instancji czasu Time, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu
        /// </summary>
        /// <param name="period">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time sumującą punkt w czasie i okres czasu typu TimePeriod</returns>
        public Time Plus(TimePeriod period)
        {
            return this + period;
        }

        /// <summary>
        /// Dodaje do obiektu Time przekazany przez parametr obiekt TimePeriod. Dodaje okres czasu do punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu Time time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time sumującą punkt w czasie i okres czasu typu TimePeriod</returns>
        public static Time Plus(Time time, TimePeriod period)
        {
            return time + period;
        }

        /// <summary>
        /// Odejmuje od instancji czasu Time, obiekt przekazany przez parametr typu TimePeriod, określoną jednostkę czasu.
        /// </summary>
        /// <param name="period">obiekt typu TimePeriod, reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time odejmujący okres czasu typu TimePeriod od punkcie w czasie typu Time</returns>
        public Time Minus(TimePeriod period)
        {
            return this - period;
        }

        /// <summary>
        /// Odejmuje od obiektu Time przekazany przez parametr obiekt TimePeriod. Odejmuje okres czasu od punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu Time time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time odejmujący okres czasu typu TimePeriod od punkcie w czasie typu Time</returns>
        public static Time Minus(Time time, TimePeriod period)
        {
            return time - period;
        }

        /// <summary>
        /// Dodaje do obiektu Time przekazany przez parametr obiekt TimePeriod. Dodaje okres czasu do punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu Time time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time sumującą punkt w czasie i okres czasu typu TimePeriod</returns>
        public static Time operator +(Time time, TimePeriod period)
        {
            long sumOfSeconds = (time.Seconds + period.Seconds);
            byte seconds = (byte)(sumOfSeconds % 60);
            long sumOfMinutes = (sumOfSeconds / 60) + time.Minutes + period.Minutes;
            byte minutes = (byte)(sumOfMinutes % 60);
            long sumOfHours = (sumOfMinutes / 60) + time.Hours + period.Hours;
            byte hours = (byte)(sumOfHours % 24);

            return new Time(hours, minutes, seconds);
        }

        /// <summary>
        /// Odejmuje od obiektu Time przekazany przez parametr obiekt TimePeriod. Odejmuje okres czasu od punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu Time time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriod reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu Time odejmujący okres czasu typu TimePeriod od punkcie w czasie typu Time</returns>
        public static Time operator -(Time time, TimePeriod period)
        {
            long sumOfSeconds = (time.Seconds - period.Seconds) + 60;
            byte seconds = (byte)(sumOfSeconds % 60);

            long sumOfMinutes = time.Minutes - period.Minutes - ((time.Seconds - period.Seconds < 0) ? 1 : 0) + 60;
            bool decyzja = time.Minutes - period.Minutes - ((time.Seconds - period.Seconds < 0) ? 1 : 0) < 0;
            byte minutes = (byte)(sumOfMinutes % 60);
            long sumOfHours = time.Hours - period.Hours - (decyzja ? 1 : 0) + 24;
            byte hours = (byte)(sumOfHours % 24);

            return new Time(hours, minutes, seconds);
        }
    }
}