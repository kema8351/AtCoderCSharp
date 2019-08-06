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
            var res = 0L;
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

        public IEnumerable<long> Loop(long count) => Loop(0, count - 1);
        public IEnumerable<long> Loop(long from, long to)
        {
            for (long i = from; i <= to; i++)
                yield return i;
        }

        public string YesNo(bool isYes) => isYes ? "Yes" : "No";

        public HashSet<T> ToHashSet<T>(IEnumerable<T> ts) => new HashSet<T>(ts);

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

        int GetFirstIndexGreater(long x, ref List<long> listOrdered)
        {
            var count = listOrdered.Count;

            if (count == 0)
                return 0;

            if (listOrdered[count - 1] <= x)
                return count;

            int low = 0;
            int high = listOrdered.Count - 1;

            while (low < high)
            {
                var mid = (low + high) / 2;

                if (listOrdered[mid] > x)
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }

        int GetFirstIndexGreater(int x, ref List<int> listOrdered)
        {
            var count = listOrdered.Count;

            if (count == 0)
                return 0;

            if (listOrdered[count - 1] <= x)
                return count;

            int low = 0;
            int high = listOrdered.Count - 1;

            while (low < high)
            {
                var mid = (low + high) / 2;

                if (listOrdered[mid] > x)
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }

        int GetLastIndexLess(long x, ref List<long> listOrdered)
        {
            var count = listOrdered.Count;

            if (count == 0)
                return -1;

            if (listOrdered[0] >= x)
                return -1;

            int low = 0;
            int high = listOrdered.Count - 1;

            while (low < high)
            {
                var mid = (low + high + 1) / 2;

                if (listOrdered[mid] < x)
                    low = mid;
                else
                    high = mid - 1;
            }

            return low;
        }

        int GetLastIndexLess(int x, ref List<int> listOrdered)
        {
            var count = listOrdered.Count;

            if (count == 0)
                return -1;

            if (listOrdered[0] >= x)
                return -1;

            int low = 0;
            int high = listOrdered.Count - 1;

            while (low < high)
            {
                var mid = (low + high + 1) / 2;

                if (listOrdered[mid] < x)
                    low = mid;
                else
                    high = mid - 1;
            }

            return low;
        }
    }

    class Bit
    {
        long length;
        long[] binaryIndexedTree;
        public Bit(long length)
        {
            this.length = length;
            binaryIndexedTree = new long[length + 1];
        }

        public void Add(long indexZeroBase, long additional)
        {
            // i += i & -i
            // 1が立っている最下位ビットを足す、の意味
            for (long i = indexZeroBase + 1; i <= length; i += i & -i)
            {
                binaryIndexedTree[i] += additional;
            }
        }

        public long Sum(long indexZeroBase)
        {
            long result = 0;

            // i += i & -i
            // 1が立っている最下位ビットを引く、の意味
            for (long i = indexZeroBase + 1; i > 0; i -= i & -i)
            {
                result += binaryIndexedTree[i];
            }

            return result;
        }
    }

    struct Mint
    {
        public static long Divider { set { divider = value; } }
        private static long divider = 1000000007;
        public static void Set998244353() { divider = 998244353; }

        public long Value { get; }

        public Mint(long value)
        {
            this.Value = value;
        }

        public static Mint operator +(Mint a, Mint b) => new Mint((a.Value + b.Value) % divider);

        public static Mint operator -(Mint a, Mint b)
        {
            var t = (a.Value - b.Value) % divider;
            if (t < 0)
                t += divider;
            return new Mint(t);
        }

        public static Mint operator *(Mint a, Mint b) => new Mint((a.Value * b.Value) % divider);

        public static Mint operator /(Mint a, Mint b) => new Mint((a.Value * InvImpl(b.Value)) % divider);

        public Mint Pow(long p) => new Mint(PowImpl(Value, p));
        private static long PowImpl(long a, long p)
        {
            if (p == 0)
                return 1L;

            if (p == 1)
                return a;

            var halfP = p / 2;
            var halfPowered = PowImpl(a, halfP);
            var powered = halfPowered * halfPowered % divider;
            return p % 2 == 0 ? powered : powered * a % divider;
        }

        public static Mint Inv(long a) => new Mint(InvImpl(a));
        private static readonly Dictionary<long, long> invCache = new Dictionary<long, long>();
        private static long InvImpl(long a)
        {
            long cache = 0L;
            if (invCache.TryGetValue(a, out cache))
                return cache;

            var result = PowImpl(a, divider - 2);
            invCache.Add(a, result);
            return result;
        }

        public static Mint Fac(long a) => new Mint(FacImpl(a));
        private static readonly List<long> facCache = new List<long>() { 1L };
        private static long FacImpl(long a)
        {
            if (a >= divider)
                return 0;

            if (a < facCache.Count)
                return facCache[(int)a];

            var val = facCache.Last();
            var start = facCache.Count;
            for (int i = start; i <= a; i++)
            {
                val = (val * i) % divider;
                facCache.Add(val);
            }

            return val;
        }

        public static Mint Perm(long n, long r) => new Mint(PermImpl(n, r));
        private static long PermImpl(long n, long r)
        {
            if (n < r)
                return 0L;

            if (r <= 0)
                return 1L;

            var nn = FacImpl(n);
            var nr = FacImpl(n - r);
            return (nn * InvImpl(nr)) % divider;
        }

        public static Mint Comb(long n, long r) => new Mint(CombImpl(n, r));
        private static long CombImpl(long n, long r)
        {
            if (n < r)
                return 0L;

            if (n == r)
                return 1L;

            var nn = FacImpl(n);
            var nr = FacImpl(n - r);
            var rr = FacImpl(r);

            var nndnr = (nn * InvImpl(nr)) % divider;
            return (nndnr * InvImpl(rr)) % divider;
        }
    }
}