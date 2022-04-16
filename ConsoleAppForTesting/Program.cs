using Time_TimePeriod;

namespace ConsoleAppForTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Time czas = new Time("23:06:55");
            Time czas1 = new Time(23, 06, 54);
            Time czas2 = new Time(23, 06, 55);
            Time czas3 = new Time(23, 06, 56);
            Console.WriteLine(czas.Equals(czas2));
            Console.WriteLine(czas);
            Console.WriteLine($"\n{czas}\t{czas1}\t{czas2}\t{czas3}");
            Console.WriteLine($"==\t\t{czas == czas1}\t\t{czas == czas2}\t\t{czas == czas3}");
            Console.WriteLine($"!=\t\t{czas != czas1}\t\t{czas != czas2}\t\t{czas != czas3}");
            Console.WriteLine($">\t\t{czas > czas1}\t\t{czas > czas2}\t\t{czas > czas3}");
            Console.WriteLine($">=\t\t{czas >= czas1}\t\t{czas >= czas2}\t\t{czas >= czas3}");
            Console.WriteLine($"<\t\t{czas < czas1}\t\t{czas < czas2}\t\t{czas < czas3}");
            Console.WriteLine($"<=\t\t{czas <= czas1}\t\t{czas <= czas2}\t\t{czas <= czas3}");
            Console.WriteLine();
            TimePeriod okresCzasu = new TimePeriod(23, 59, 59);
            Time czasAktualny = new Time(20, 13, 0);
            Console.WriteLine(czasAktualny + okresCzasu);
            Console.WriteLine(czasAktualny - okresCzasu);

            Console.WriteLine("\n==========\nTimePeriod");
            TimePeriod period = new TimePeriod(47945); // 13:19:05
            Console.WriteLine(period);
            TimePeriod periodFull = new TimePeriod(23, 19, 18);
            Console.WriteLine(periodFull.NumberOfSeconds);
            Console.WriteLine(periodFull);

            Console.WriteLine(new Time(20, 35, 00) + new TimePeriod(54302));

            var t1 = new Time(0, 0, 0);
            var t2 = new Time(23, 59, 59);
            var timep = new TimePeriod(t1, t2);
            timep = new TimePeriod(129, 58, 12);
            Console.WriteLine(timep);
            TimePeriod p1czas = new TimePeriod("23:06:55");
            TimePeriod p2czas = new TimePeriod(23, 06, 54);
            TimePeriod p3czas = new TimePeriod(23, 06, 55);
            TimePeriod p4czas = new TimePeriod(23, 06, 56);

            Console.WriteLine($"\n{p1czas}\t{p2czas}\t{p3czas}\t{p4czas}");
            Console.WriteLine($"==\t\t{p1czas == p2czas}\t\t{p1czas == p3czas}\t\t{p1czas == p4czas}");
            Console.WriteLine($"!=\t\t{p1czas != p2czas}\t\t{p1czas != p3czas}\t\t{p1czas != p4czas}");
            Console.WriteLine($">\t\t{p1czas > p2czas}\t\t{p1czas > p3czas}\t\t{p1czas > p4czas}");
            Console.WriteLine($">=\t\t{p1czas >= p2czas}\t\t{p1czas >= p3czas}\t\t{p1czas >= p4czas}");
            Console.WriteLine($"<\t\t{p1czas < p2czas}\t\t{p1czas < p3czas}\t\t{p1czas < p4czas}");
            Console.WriteLine($"<=\t\t{p1czas <= p2czas}\t\t{p1czas <= p3czas}\t\t{p1czas <= p4czas}");

            Console.WriteLine(p2czas + p1czas);

            timep = new TimePeriod(848974);
            Console.WriteLine(timep);

            Console.WriteLine(new TimePeriod(54302));
            var czasTeraz = DateTime.Now;
            Time x = new Time((byte)czasTeraz.Hour, (byte)czasTeraz.Minute, (byte)czasTeraz.Second);

            while (true)
            {
                TimePeriod sekunda = new TimePeriod(0, 0, 1);
                var g = x.Plus(sekunda);
                Console.WriteLine(g);
                x = new Time(g.Hours, g.Minutes, g.Seconds);
                Thread.Sleep(1000);
            }
        }
    }
}