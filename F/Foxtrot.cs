using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace V
{
    class Solver
    {
        public void Solve()
        {
        }

        public Solver(Scanner sc, Printer sw) { this.sc = sc; this.sw = sw; }
        private readonly Scanner sc;
        private readonly Printer sw;
    }
}
namespace V
{
    class Scanner
    {
        private readonly TextReader reader;
        public Scanner(TextReader reader) { this.reader = reader; }

        public string Str => reader.ReadLine().Trim();
        public int Int => int.Parse(this.Str);
        public long Long => long.Parse(this.Str);
        public double Double => double.Parse(this.Str);

        public string[] StrArray => Str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        public int[] IntArray => StrArray.Select(int.Parse).ToArray();
        public long[] LongArray => StrArray.Select(long.Parse).ToArray();
        public double[] DoubleArray => StrArray.Select(double.Parse).ToArray();

        public static bool TypeEquals<T1, T2>() => typeof(T1).Equals(typeof(T2));
        public static T1 ChangeTypes<T1, T2>(T2 t2) => (T1)System.Convert.ChangeType(t2, typeof(T1));
        public static T1 Convert<T1>(string s) =>
            TypeEquals<T1, int>() ? ChangeTypes<T1, int>(int.Parse(s)) :
            TypeEquals<T1, long>() ? ChangeTypes<T1, long>(long.Parse(s)) :
            TypeEquals<T1, double>() ? ChangeTypes<T1, double>(int.Parse(s)) :
            TypeEquals<T1, char>() ? ChangeTypes<T1, char>(s[0]) : ChangeTypes<T1, string>(s);

        public P2<TX, TY> P2<TX, TY>() => new P2<TX, TY>(Convert<TX>(this.Str), Convert<TY>(this.Str));
        public P3<TX, TY, TZ> P3<TX, TY, TZ>() => new P3<TX, TY, TZ>(Convert<TX>(this.Str), Convert<TY>(this.Str), Convert<TZ>(this.Str));
        public P4<TX, TY, TZ, TW> P4<TX, TY, TZ, TW>() => new P4<TX, TY, TZ, TW>(Convert<TX>(this.Str), Convert<TY>(this.Str), Convert<TZ>(this.Str), Convert<TW>(this.Str));
    }
    static class ScannerExtension
    {
        public static int[] EInts(this Scanner scanner, int n) => scanner.EInts((long)n);
        public static int[] EInts(this Scanner scanner, long n) => scanner.ScanLines<int>(n).ToArray();
        public static long[] ELongs(this Scanner scanner, int n) => scanner.ELongs((long)n);
        public static long[] ELongs(this Scanner scanner, long n) => scanner.ScanLines<long>(n).ToArray();
        public static double[] EDoubles(this Scanner scanner, int n) => scanner.EDoubles((long)n);
        public static double[] EDoubles(this Scanner scanner, long n) => scanner.ScanLines<double>(n).ToArray();
        public static string[] EStrs(this Scanner scanner, int n) => scanner.EStrs((long)n);
        public static string[] EStrs(this Scanner scanner, long n) => scanner.ScanLines<string>(n).ToArray();
        private static IEnumerable<T> ScanLines<T>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return Scanner.Convert<T>(scanner.Str); }

        public static P2<TX, TY>[] EP2<TX, TY>(this Scanner scanner, int n) => scanner.EP2<TX, TY>((long)n);
        public static P2<TX, TY>[] EP2<TX, TY>(this Scanner scanner, long n) => scanner.ScanLines<TX, TY>(n).ToArray();
        private static IEnumerable<P2<TX, TY>> ScanLines<TX, TY>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P2<TX, TY>(); }

        public static P3<TX, TY, TZ>[] EP3<TX, TY, TZ>(this Scanner scanner, int n) => scanner.EP3<TX, TY, TZ>((long)n);
        public static P3<TX, TY, TZ>[] EP3<TX, TY, TZ>(this Scanner scanner, long n) => scanner.ScanLines<TX, TY, TZ>(n).ToArray();
        private static IEnumerable<P3<TX, TY, TZ>> ScanLines<TX, TY, TZ>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P3<TX, TY, TZ>(); }

        public static P4<TX, TY, TZ, TW>[] EP4<TX, TY, TZ, TW>(this Scanner scanner, int n) => scanner.EP4<TX, TY, TZ, TW>((long)n);
        public static P4<TX, TY, TZ, TW>[] EP4<TX, TY, TZ, TW>(this Scanner scanner, long n) => scanner.ScanLines<TX, TY, TZ, TW>(n).ToArray();
        private static IEnumerable<P4<TX, TY, TZ, TW>> ScanLines<TX, TY, TZ, TW>(this Scanner scanner, long n) { for (long i = 0; i < n; i++) yield return scanner.P4<TX, TY, TZ, TW>(); }
    }
    class P2<TX, TY> { public TX X { get; } public TY Y { get; } public P2(TX x, TY y) { this.X = x; this.Y = y; } }
    class P3<TX, TY, TZ> { public TX X { get; } public TY Y { get; } public TZ Z { get; } public P3(TX x, TY y, TZ z) { this.X = x; this.Y = y; this.Z = z; } }
    class P4<TX, TY, TZ, TW> { public TX X { get; } public TY Y { get; } public TZ Z { get; } public TW W { get; } public P4(TX x, TY y, TZ z, TW w) { this.X = x; this.Y = y; this.Z = z; this.W = w; } }
    class Printer
    {
        private readonly TextWriter writer;
        public Printer(TextWriter writer) { this.writer = writer; }
        public void Write(object obj) { writer.WriteLine(obj.ToString()); }
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
    }
    static class U
    {
        public static int Gcd(int a, int b)
        {
            if (a < b)
                return GcdImpl(b, a);
            else
                return GcdImpl(a, b);
        }
        private static int GcdImpl(int a, int b)
        {
            var remainder = a % b;
            if (remainder == 0)
                return b;
            else
                return GcdImpl(b, remainder);
        }
        public static int Lcm(int a, int b)
        {
            return a / Gcd(a, b) * b;
        }
        public static IEnumerable<int> Range(int n)
        {
            for (int i = 0; i < n; i++)
                yield return i;
        }
        public static IEnumerable<long> Range(long n)
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
                throw e;
            }
        }
    }
}