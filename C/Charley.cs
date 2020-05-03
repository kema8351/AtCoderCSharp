using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace V
{
    partial class Solver
    {
        public void Solve()
        {
            Write(SolveLong());
            //YesNo(SolveBool());
        }

        public long SolveLong()
        {
            var n = Scan;
            var m = Scan;
            var h = ScanArr(n);
            var e = scanner.Pairs(m);
            e = e.Concat(e.Select(x => new Pair<long, long>(x.Y, x.X))).ToArray();
            var d = e.GroupBy(x => x.X).ToDictionary(x => x.Key - 1, x => x.Select(xs => xs.Y - 1).ToArray());

            var res = 0;
            for (long i = 0; i < n; i++)
            {
                if (d.ContainsKey(i))
                {
                    var ds = d[i];
                    var hh = h[i];
                    if (ds.All(x => h[x] < hh))
                        res++;
                }
                else
                {
                    res++;
                }
            }

            return res;
        }

        public bool SolveBool()
        {
            var n = Scan;
            return false;
        }
    }
}
namespace V
{
    class StartingPoint
    {
        static void Main(string[] args)
        {
            try
            {
                var streamReader = args.Any() ? new StreamReader(args[0]) : new StreamReader(Console.OpenStandardInput());
                var streamWriter = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
                var scanner = new Scanner(streamReader);
                var printer = new Printer(streamWriter);
                var solver = new Solver(scanner, printer);
                solver.Solve();
                streamWriter.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (args.Any() == false)
                    throw e;
            }

            if (args.Any())
                Console.ReadKey();
        }
    }
}
namespace V
{
    partial class Solver
    {
        public Solver(Scanner sc, Printer sw) { this.scanner = sc; this.printer = sw; }
        private readonly Scanner scanner;
        private readonly Printer printer;

        private IEnumerable<int> Loop(int n) => C.Loop(n);
        private IEnumerable<long> Loop(long n) => C.Loop(n);

        private int ScanInt => scanner.Int;
        private long Sc => scanner.Long;
        private long Scan => scanner.Long;
        private long ScanLong => scanner.Long;
        private double ScanDouble => scanner.Double;
        private string Str => scanner.Str;
        private string ScanStr => scanner.Str;
        private int[] IntArr(int n) => scanner.Ints(n);
        private int[] IntArr(long n) => scanner.Ints(n);
        private long[] Scs(int n) => scanner.Longs(n);
        private long[] Scs(long n) => scanner.Longs(n);
        private long[] ScanArr(int n) => scanner.Longs(n);
        private long[] ScanArr(long n) => scanner.Longs(n);
        private long[] LongArr(int n) => scanner.Longs(n);
        private long[] LongArr(long n) => scanner.Longs(n);
        private double[] DoubleArr(int n) => scanner.Doubles(n);
        private double[] DoubleArr(long n) => scanner.Doubles(n);
        private string[] StrArr(int n) => scanner.Strs(n);
        private string[] StrArr(long n) => scanner.Strs(n);

        private void Wr(string s) => printer.Write(s);
        private void Wr(object obj) => printer.Write(obj);
        private void Wr<T>(IEnumerable<T> ts) => printer.Write(ts);
        private void Wr(params object[] objs) => printer.Write(objs);
        private void Write(string s) => printer.Write(s);
        private void Write(object obj) => printer.Write(obj);
        private void Write<T>(IEnumerable<T> ts) => printer.Write(ts);
        private void Write(params object[] objs) => printer.Write(objs);
        private void YesNo(bool b) => Write(b ? "Yes" : "No");
        private void YESNO(bool b) => Write(b ? "YES" : "NO");
    }
    class Scanner
    {
        private readonly TextReader reader;
        public Scanner(TextReader reader) { this.reader = reader; }
        private Queue<string> strQueue = new Queue<string>();

        public string Str
        {
            get
            {
                if (strQueue.Count > 0)
                    return strQueue.Dequeue();

                string[] strs = null;
                do
                {
                    strs = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                } while (strs.Any() == false);

                foreach (var s in strs.Skip(1))
                    strQueue.Enqueue(s);

                return strs[0];
            }
        }

        public int Int => int.Parse(this.Str);
        public long Long => long.Parse(this.Str);
        public double Double => double.Parse(this.Str);

        public static bool TypeEquals<T1, T2>() => typeof(T1).Equals(typeof(T2));
        public static T1 ChangeTypes<T1, T2>(T2 t2) => (T1)System.Convert.ChangeType(t2, typeof(T1));
        public static T1 Convert<T1>(string s) =>
            TypeEquals<T1, int>() ? ChangeTypes<T1, int>(int.Parse(s)) :
            TypeEquals<T1, long>() ? ChangeTypes<T1, long>(long.Parse(s)) :
            TypeEquals<T1, double>() ? ChangeTypes<T1, double>(int.Parse(s)) :
            TypeEquals<T1, char>() ? ChangeTypes<T1, char>(s[0]) : ChangeTypes<T1, string>(s);

        public Pair<TX, TY> P2<TX, TY>() => new Pair<TX, TY>(Convert<TX>(this.Str), Convert<TY>(this.Str));
        public Pair3<TX, TY, TZ> P3<TX, TY, TZ>() => new Pair3<TX, TY, TZ>(Convert<TX>(this.Str), Convert<TY>(this.Str), Convert<TZ>(this.Str));
        public Pair4<TX, TY, TZ, TW> P4<TX, TY, TZ, TW>() => new Pair4<TX, TY, TZ, TW>(Convert<TX>(this.Str), Convert<TY>(this.Str), Convert<TZ>(this.Str), Convert<TW>(this.Str));
    }
    static class ScannerExtension
    {
        public static int[] Ints(this Scanner scanner, int n) => scanner.Ints((long)n);
        public static int[] Ints(this Scanner scanner, long n) => scanner.ScanStrs<int>(n).ToArray();
        public static long[] Longs(this Scanner scanner, int n) => scanner.Longs((long)n);
        public static long[] Longs(this Scanner scanner, long n) => scanner.ScanStrs<long>(n).ToArray();
        public static double[] Doubles(this Scanner scanner, int n) => scanner.Doubles((long)n);
        public static double[] Doubles(this Scanner scanner, long n) => scanner.ScanStrs<double>(n).ToArray();
        public static string[] Strs(this Scanner scanner, int n) => scanner.Strs((long)n);
        public static string[] Strs(this Scanner scanner, long n) => scanner.ScanStrs<string>(n).ToArray();
        private static IEnumerable<T> ScanStrs<T>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return Scanner.Convert<T>(scanner.Str); }

        public static Pair<TX, TY>[] Pairs<TX, TY>(this Scanner scanner, int n) => scanner.Pairs<TX, TY>((long)n);
        public static Pair<TX, TY>[] Pairs<TX, TY>(this Scanner scanner, long n) => scanner.ScanPairs<TX, TY>(n).ToArray();
        public static Pair<long, long>[] Pairs(this Scanner scanner, int n) => scanner.Pairs((long)n);
        public static Pair<long, long>[] Pairs(this Scanner scanner, long n) => scanner.ScanPairs<long, long>(n).ToArray();
        public static Pair<int, int>[] PairsInt(this Scanner scanner, int n) => scanner.PairsInt((long)n);
        public static Pair<int, int>[] PairsInt(this Scanner scanner, long n) => scanner.ScanPairs<int, int>(n).ToArray();
        private static IEnumerable<Pair<TX, TY>> ScanPairs<TX, TY>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P2<TX, TY>(); }

        public static Pair3<TX, TY, TZ>[] Pairs3<TX, TY, TZ>(this Scanner scanner, int n) => scanner.Pairs3<TX, TY, TZ>((long)n);
        public static Pair3<TX, TY, TZ>[] Pairs3<TX, TY, TZ>(this Scanner scanner, long n) => scanner.ScanPairs3<TX, TY, TZ>(n).ToArray();
        public static Pair3<long, long, long>[] Pairs3(this Scanner scanner, int n) => scanner.Pairs3((long)n);
        public static Pair3<long, long, long>[] Pairs3(this Scanner scanner, long n) => scanner.ScanPairs3<long, long, long>(n).ToArray();
        public static Pair3<int, int, int>[] Pairs3Int(this Scanner scanner, int n) => scanner.Pairs3Int((long)n);
        public static Pair3<int, int, int>[] Pairs3Int(this Scanner scanner, long n) => scanner.ScanPairs3<int, int, int>(n).ToArray();
        private static IEnumerable<Pair3<TX, TY, TZ>> ScanPairs3<TX, TY, TZ>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P3<TX, TY, TZ>(); }

        public static Pair4<TX, TY, TZ, TW>[] Pairs4<TX, TY, TZ, TW>(this Scanner scanner, int n) => scanner.Pairs4<TX, TY, TZ, TW>((long)n);
        public static Pair4<TX, TY, TZ, TW>[] Pairs4<TX, TY, TZ, TW>(this Scanner scanner, long n) => scanner.ScanPairs4<TX, TY, TZ, TW>(n).ToArray();
        public static Pair4<long, long, long, long>[] Pairs4(this Scanner scanner, int n) => scanner.Pairs4((long)n);
        public static Pair4<long, long, long, long>[] Pairs4(this Scanner scanner, long n) => scanner.ScanPairs4<long, long, long, long>(n).ToArray();
        public static Pair4<int, int, int, int>[] Pairs4Int(this Scanner scanner, int n) => scanner.Pairs4Int((long)n);
        public static Pair4<int, int, int, int>[] Pairs4Int(this Scanner scanner, long n) => scanner.ScanPairs4<int, int, int, int>(n).ToArray();
        private static IEnumerable<Pair4<TX, TY, TZ, TW>> ScanPairs4<TX, TY, TZ, TW>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P4<TX, TY, TZ, TW>(); }
    }
    class Pair<TX, TY> { public TX X { get; } public TY Y { get; } public Pair(TX x, TY y) { this.X = x; this.Y = y; } }
    class Pair : Pair<long, long> { public Pair(long x, long y) : base(x, y) { } }
    class PairInt : Pair<int, int> { public PairInt(int x, int y) : base(x, y) { } }
    class Pair3<TX, TY, TZ> { public TX X { get; } public TY Y { get; } public TZ Z { get; } public Pair3(TX x, TY y, TZ z) { this.X = x; this.Y = y; this.Z = z; } }
    class Pair3 : Pair3<long, long, long> { public Pair3(long x, long y, long z) : base(x, y, z) { } }
    class Pair3Int : Pair3<int, int, int> { public Pair3Int(int x, int y, int z) : base(x, y, z) { } }
    class Pair4<TX, TY, TZ, TW> { public TX X { get; } public TY Y { get; } public TZ Z { get; } public TW W { get; } public Pair4(TX x, TY y, TZ z, TW w) { this.X = x; this.Y = y; this.Z = z; this.W = w; } }
    class Pair4 : Pair4<long, long, long, long> { public Pair4(long x, long y, long z, long w) : base(x, y, z, w) { } }
    class Pair4Int : Pair4<int, int, int, int> { public Pair4Int(int x, int y, int z, int w) : base(x, y, z, w) { } }
    class Printer
    {
        private readonly TextWriter writer;
        public Printer(TextWriter writer) { this.writer = writer; }
        public void Write(string obj) { writer.WriteLine(obj); }
        public void Write(object obj) { writer.WriteLine(obj); }
        public void Write<T>(IEnumerable<T> ts) { writer.WriteLine(string.Join(" ", ts)); }
        public void Write(params object[] objs) { writer.WriteLine(string.Join(" ", objs)); }
    }
    class C
    {
        public class PriorityQueue<TKey, TValue>
        {
            SortedDictionary<TKey, Queue<TValue>> dictionary = new SortedDictionary<TKey, Queue<TValue>>();
            int count = 0;
            public int Count
            {
                get
                {
                    return count;
                }
            }
            public void Add(TKey key, TValue value)
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary[key] = new Queue<TValue>();
                }

                dictionary[key].Enqueue(value);
                count++;
            }
            public KeyValuePair<TKey, TValue> Dequeue()
            {
                var queue = dictionary.First();
                if (queue.Value.Count <= 1)
                {
                    dictionary.Remove(queue.Key);
                }
                count--;
                return new KeyValuePair<TKey, TValue>(queue.Key, queue.Value.Dequeue());
            }
        }
        public class BinaryIndexTree
        {
            long length;
            long[] binaryIndexedTree;
            public BinaryIndexTree(long length)
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
        public static class BinarySearch
        {
            public static int GetFirstIndexGreater(long x, ref List<long> listOrdered)
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
            public static int GetFirstIndexGreater(int x, ref List<int> listOrdered)
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
            public static int GetLastIndexLess(long x, ref List<long> listOrdered)
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
            public static int GetLastIndexLess(int x, ref List<int> listOrdered)
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
        public static class BellmanFord
        {
            public class Vertex
            {
                public long Distance { get; set; }

                public Vertex()
                {
                    Distance = long.MaxValue;
                }
            }

            public class Edge
            {
                public int From { get; private set; }
                public int To { get; private set; }
                public long Weight { get; private set; }

                public Edge(int from, int to, long weight)
                {
                    From = from;
                    To = to;
                    Weight = weight;
                }
            }

            private static void GetReachable(int origin, ref HashSet<int> reached, ref Dictionary<int, int[]> paths)
            {
                if (reached.Contains(origin))
                    return;

                reached.Add(origin);

                if (paths.ContainsKey(origin) == false)
                    return;

                foreach (var p in paths[origin])
                    GetReachable(p, ref reached, ref paths);
            }

            /// <summary>
            /// null: 負の無限大
            /// long.MaxValue: たどり着けない
            /// その他: 距離
            /// </summary>
            public static long? RunBellmanFord(int vertexCount, List<Edge> rawEdges, int source, int dest)
            {
                var forwards = rawEdges.GroupBy(x => x.From).ToDictionary(x => x.Key, x => x.Select(xs => xs.To).ToArray());
                var reverses = rawEdges.GroupBy(x => x.To).ToDictionary(x => x.Key, x => x.Select(xs => xs.From).ToArray());

                var fromSource = new HashSet<int>();
                var toDest = new HashSet<int>();

                GetReachable(source, ref fromSource, ref forwards);
                GetReachable(dest, ref toDest, ref reverses);

                var edges = rawEdges
                    .Where(e => fromSource.Contains(e.From))
                    .Where(e => fromSource.Contains(e.To))
                    .Where(e => toDest.Contains(e.From))
                    .Where(e => toDest.Contains(e.To))
                    .ToArray();

                // initialize distances
                var vertices = new List<Vertex>();
                for (int i = 0; i < vertexCount; i++)
                    vertices.Add(new Vertex());
                vertices[source].Distance = 0L;

                // update distances
                for (int i = 0; i < vertices.Count; i++)
                {
                    foreach (var e in edges)
                    {
                        var from = vertices[e.From];
                        var to = vertices[e.To];

                        if (from.Distance == long.MaxValue)
                            continue;

                        var newDistance = from.Distance + e.Weight;
                        if (to.Distance > newDistance)
                        {
                            to.Distance = newDistance;
                        }
                    }
                }

                // check negative cycle
                foreach (var e in edges)
                {
                    var from = vertices[e.From];
                    var to = vertices[e.To];

                    if (from.Distance + e.Weight < to.Distance)
                        return null;
                }

                return vertices[dest].Distance;
            }
        }
        public static long Gcd(int a, int b) => Gcd((long)a, (long)b);
        public static long Gcd(long a, long b)
        {
            if (a < b)
                return GcdImpl(b, a);
            else
                return GcdImpl(a, b);
        }
        private static long GcdImpl(long a, long b)
        {
            var remainder = a % b;
            if (remainder == 0)
                return b;
            else
                return GcdImpl(b, remainder);
        }
        public static long Lcm(int a, int b) => Lcm((long)a, (long)b);
        public static long Lcm(long a, long b)
        {
            return a / Gcd(a, b) * b;
        }
        public static long Pow(int n, int p) => Pow((long)n, (long)p);
        public static long Pow(long n, long p)
        {
            var res = 1L;
            for (long i = 0; i < p; i++)
                res *= n;
            return res;
        }
        public static Dictionary<long, long> Factorize(int n) => Factorize((long)n);
        public static Dictionary<long, long> Factorize(long n)
        {
            var res = new Dictionary<long, long>();
            var r = n;
            for (long i = 2; i * i <= r; i++)
            {
                var c = 0L;
                while (r % i == 0)
                {
                    c++;
                    r /= i;
                }
                if (c > 0)
                    res.Add(i, c);
            }
            if (r > 1)
                res.Add(r, 1);
            return res;
        }
        public static IEnumerable<long> Divisors(int n) => Divisors((long)n);
        public static IEnumerable<long> Divisors(long n)
        {
            var cache = new Stack<long>();
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    cache.Push(i);
                }
            }

            var r = cache.Peek();
            if (r * r == n)
                cache.Pop();

            while (cache.Count > 0)
            {
                var i = cache.Pop();
                yield return n / i;
            }
        }
        public static IEnumerable<int> Loop(int n)
        {
            for (int i = 0; i < n; i++)
                yield return i;
        }
        public static IEnumerable<long> Loop(long n)
        {
            for (long i = 0L; i < n; i++)
                yield return i;
        }
    }
    struct Mint
    {
        public static long Divider { set { divider = value; } }
        private static long divider = 1000000007;
        public static void Set998244353() { divider = 998244353; }

        public long Value { get; }
        public override string ToString() => this.Value.ToString();

        public Mint(long value)
        {
            this.Value = value;
        }

        public static Mint operator +(Mint a, Mint b) => new Mint((a.Value + b.Value) % divider);
        public static Mint operator +(Mint a, long b) => a + new Mint(b);
        public static Mint operator +(Mint a, int b) => a + new Mint(b);

        public static Mint operator -(Mint a, Mint b)
        {
            var t = (a.Value - b.Value) % divider;
            if (t < 0)
                t += divider;
            return new Mint(t);
        }
        public static Mint operator -(Mint a, long b) => a - new Mint(b);
        public static Mint operator -(Mint a, int b) => a - new Mint(b);

        public static Mint operator *(Mint a, Mint b) => new Mint((a.Value * b.Value) % divider);
        public static Mint operator *(Mint a, long b) => a * new Mint(b);
        public static Mint operator *(Mint a, int b) => a * new Mint(b);

        public static Mint operator /(Mint a, Mint b) => new Mint((a.Value * InvImpl(b.Value)) % divider);
        public static Mint operator /(Mint a, long b) => a / new Mint(b);
        public static Mint operator /(Mint a, int b) => a / new Mint(b);

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

            var val = 1L;
            var start = 1;
            for (int i = start; i <= a; i++)
            {
                val = (val * i) % divider;
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

            if (n - r < r)
                return CombImpl(n, n - r);

            var nr = 1L;
            for (var i = n; i > n - r; i--)
            {
                nr *= i;
                nr %= divider;
            }
            var rr = FacImpl(r);

            return (nr * InvImpl(rr)) % divider;
        }
    }
}