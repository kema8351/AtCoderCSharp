using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace A
{
    partial class Program
    {
        public IEnumerable<string> Solve()
        {
            var res = 0;
            yield return res.ToString();
        }
    }

    class StartingPoint
    {
        static void Main(string[] args)
        {
            if (args?.Any() == true)
            {
                var assembly = Assembly.GetEntryAssembly();
                var resourceName = "AtCoderCSharp.In.txt";
                var stream = assembly.GetManifestResourceStream(resourceName);
                var streamReader = new StreamReader(stream, Encoding.UTF8);
                var str = streamReader.ReadToEnd();
                var textReader = new StringReader(str);
                Console.SetIn(textReader);
            }

            try
            {
                foreach (var s in new Program().Solve())
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (args?.Any() != true)
                    throw e;
            }

            if (args?.Any() == true)
                Console.ReadKey();
        }
    }

    partial class Program
    {
        public List<int> ScanInts(int count) => Enumerable.Range(0, count).Select(_ => ScanInt).ToList();
        public List<int> ScanInts(long count) => ScanInts((int)count);
        public List<long> ScanLongs(int count) => Enumerable.Range(0, count).Select(_ => Scan).ToList();
        public List<long> ScanLongs(long count) => ScanLongs((int)count);
        public int ScanInt => int.Parse(Str);
        public long Scan => long.Parse(Str);
        public double ScanDouble => (double)Scan;

        StringBuilder sb = new StringBuilder();

        public string Str => ScanStr();
        public string ScanStr()
        {
            sb.Clear();

            int r = 0;
            bool? b = null;
            do
            {
                r = Console.Read();
                b = IsBreak(r);
            } while (b == true);

            if (b == null)
                throw new Exception("input error: unexpected end of stream");

            do
            {
                sb.Append((char)r);
                r = Console.Read();
                b = IsBreak(r);
            } while (b == false);

            return sb.ToString();
        }

        bool? IsBreak(int c)
        {
            switch (c)
            {
                case -1:
                    return null;
                case (int)' ':
                case (int)'\n':
                case (int)'\r':
                    return true;
                default:
                    return false;
            }
        }

        public IEnumerable<int> Loop(int count) => Enumerable.Range(0, count);
        public IEnumerable<int> Loop(int from, int to) => Enumerable.Range(from, to - from + 1);

        public string YesNo(bool isYes) => isYes ? "Yes" : "No";

        public int Gcm(int a, int b)
        {
            if (a < b)
                return GcmImpl(b, a);
            else
                return GcmImpl(a, b);
        }

        int GcmImpl(int a, int b)
        {
            var remainder = a % b;
            if (remainder == 0)
                return b;
            else
                return GcmImpl(b, remainder);
        }

        public int Lcm(int a, int b)
        {
            return a / Gcm(a, b) * b;
        }
    }

    class Mod
    {
        readonly int _divider = 1000000007;
        public Mod(int divider = 1000000007)
        {
            _divider = divider;
        }

        public int Add(int a, int b) => (int)Add((long)a, (long)b);
        public int Sub(int a, int b) => (int)Sub((long)a, (long)b);
        public int Mul(int a, int b) => (int)Mul((long)a, (long)b);
        public int Div(int a, int b) => (int)Div((long)a, (long)b);
        public int Pow(int a, int p) => (int)Pow((long)a, (long)p);

        public long Add(long a, long b) => (a + b) % _divider;

        public long Sub(long a, long b)
        {
            var t = (a - b) % _divider;
            if (t < 0)
                t += _divider;
            return t;
        }

        public long Mul(long a, long b) => (a * b) % _divider;

        public long Div(long a, long b) => Mul(a, Inv(b));

        public long Pow(long a, long p)
        {
            switch (p)
            {
                case 0: return 1;
                case 1: return a;
                default:
                    var halfP = p / 2;
                    var halfPowered = Pow(a, halfP);
                    var powered = Mul(halfPowered, halfPowered);
                    return p % 2 == 0 ? powered : Mul(powered, a);
            }
        }

        readonly Dictionary<long, long> invCache = new Dictionary<long, long>();
        long Inv(long a)
        {
            long cache = 0L;
            if (invCache.TryGetValue(a, out cache))
                return cache;

            var result = Pow(a, _divider - 2);
            invCache.Add(a, result);
            return result;
        }

        readonly List<int> facCache = new List<int>() { 1 };
        public int Fac(int a)
        {
            if (a < facCache.Count)
                return facCache[a];

            var val = facCache.Last();
            var start = facCache.Count;
            for (int i = start; i <= a; i++)
            {
                val = Mul(val, i);
                facCache.Add(val);
            }

            return val;
        }

        public int Perm(int n, int r)
        {
            if (n < r)
                return 0;

            if (r <= 0)
                return 1;

            int nn = Fac(n);
            int nr = Fac(n - r);
            return Div(nn, nr);
        }

        public int Comb(int n, int r)
        {
            if (n < r)
                return 0;

            if (n == r)
                return 1;

            int nn = Fac(n);
            int nr = Fac(n - r);
            int rr = Fac(r);
            return Div(Div(nn, nr), rr);
        }
    }
}