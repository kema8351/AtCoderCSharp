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
            var n = Read;
            return 0;
        }

        public bool SolveBool()
        {
            var n = Read;
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
        public Solver(Scanner sc, Printer pr) { this.sc = sc; this.pr = pr; }
        private readonly Scanner sc;
        private readonly Printer pr;

        private IEnumerable<int> Loop(int n) => C.Loop(n);
        private IEnumerable<long> Loop(long n) => C.Loop(n);

        private int RdInt => sc.Int;
        private int ReadInt => sc.Int;
        private long Rd => sc.Long;
        private long Read => sc.Long;
        private long ReadLong => sc.Long;
        private double RdDouble => sc.Double;
        private double ReadDouble => sc.Double;
        private string Str => sc.Str;
        private string RdStr => sc.Str;
        private string ReadStr => sc.Str;
        private int[] ArrInt(int n) => sc.Ints(n);
        private int[] ArrInt(long n) => sc.Ints(n);
        private long[] Arr(int n) => sc.Longs(n);
        private long[] Arr(long n) => sc.Longs(n);
        private long[] ArrLong(int n) => sc.Longs(n);
        private long[] ArrLong(long n) => sc.Longs(n);
        private double[] ArrDouble(int n) => sc.Doubles(n);
        private double[] ArrDouble(long n) => sc.Doubles(n);
        private string[] ArrStr(int n) => sc.Strs(n);
        private string[] ArrStr(long n) => sc.Strs(n);

        private void Wr(string s) => pr.Write(s);
        private void Wr(object obj) => pr.Write(obj);
        private void Wr<T>(IEnumerable<T> ts) => pr.Write(ts);
        private void Wr(params object[] objs) => pr.Write(objs);
        private void Write(string s) => pr.Write(s);
        private void Write(object obj) => pr.Write(obj);
        private void Write<T>(IEnumerable<T> ts) => pr.Write(ts);
        private void Write(params object[] objs) => pr.Write(objs);
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
    static class Extension
    {
        public static bool SafeAdd<T>(this HashSet<T> ts, T t)
        {
            if (ts.Contains(t))
            {
                return false;
            }
            else
            {
                ts.Add(t);
                return false;
            }
        }
        public static bool SafeRemove<T>(this HashSet<T> ts, T t)
        {
            if (ts.Contains(t))
            {
                ts.Remove(t);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void SafeSet<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] = value;
            else
                ts.Add(t, value);
        }
        public static void SafeAdd<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] += value;
            else
                ts.Add(t, value);
        }
        public static void SafeSub<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] -= value;
            else
                ts.Add(t, value);
        }
        public static void SafeMult<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] *= value;
            else
                ts.Add(t, value);
        }
        public static void SafeDiv<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] /= value;
            else
                ts.Add(t, value);
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> ts) => new HashSet<T>(ts.Distinct());
        public static long ToDigit(this char c) => (long)(c - '0');
        public static long ToSmallAbcIndex(this char c) => (long)(c - 'a');
        public static long ToLargeAbcIndex(this char c) => (long)(c - 'A');
        public static long Count<T1, T2>(this IGrouping<T1, T2> gs) => gs.LongCount();
        public static string ToStr(this IEnumerable<char> cs) => new string(cs.ToArray());
        public static long ToLong(this IEnumerable<char> s)
        {
            var basis = 1L;
            var res = 0L;
            foreach (var c in s)
            {
                var d = c.ToSmallAbcIndex() + 1;
                res += d * basis;
                basis *= 27;
            }
            return res;
        }
    }
    class C
    {
        public class IterTools
        {
            /// <summary>
            /// 組み合わせ（重複なし）
            /// n = 4, k = 3 => (0,1,2) (0,1,3) (0,2,3) (1,2,3)
            /// </summary>
            public static IEnumerable<IReadOnlyList<long>> Combinations(long n, long k)
            {
                if (k <= 0)
                    yield break;

                long[] indices = new long[k];
                long pointer = 0;

                while (pointer >= 0)
                {
                    if (indices[pointer] < n)
                    {
                        if (pointer >= k - 1)
                        {
                            yield return indices;
                            indices[pointer]++;
                        }
                        else
                        {
                            indices[pointer + 1] = indices[pointer] + 1;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                            indices[pointer]++;
                    }
                }
            }

            /// <summary>
            /// 組み合わせ（重複なし）
            /// n = 4, k = 3 => (0,1,2) (0,1,3) (0,2,3) (1,2,3)
            /// </summary>
            public static IEnumerable<IReadOnlyList<T>> Combinations<T>(T[] ts, long k)
            {
                if (k <= 0)
                    yield break;

                long[] indices = new long[k];
                T[] container = new T[k];
                long pointer = 0;
                long n = ts.LongLength;

                while (pointer >= 0)
                {
                    if (indices[pointer] < n)
                    {
                        container[pointer] = ts[indices[pointer]];

                        if (pointer >= k - 1)
                        {
                            yield return container;
                            indices[pointer]++;
                        }
                        else
                        {
                            indices[pointer + 1] = indices[pointer] + 1;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                            indices[pointer]++;
                    }
                }
            }

            /// <summary>
            /// 組み合わせ（重複あり）
            /// n = 3, k = 2 => (0,0) (0,1) (0,2) (1,0) (1,1) (1,2) (2,0) (2,1) (2,2) 
            /// </summary>
            public static IEnumerable<IReadOnlyList<long>> CombinationsWithReplacement(long n, long k)
            {
                if (k <= 0)
                    yield break;

                long[] container = new long[k];
                long pointer = 0;

                while (pointer >= 0)
                {
                    if (container[pointer] < n)
                    {
                        if (pointer >= k - 1)
                        {
                            yield return container;
                            container[pointer]++;
                        }
                        else
                        {
                            container[pointer + 1] = 0;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                            container[pointer]++;
                    }
                }
            }

            /// <summary>
            /// 組み合わせ（重複あり）
            /// n = 3, k = 2 => (0,0) (0,1) (0,2) (1,0) (1,1) (1,2) (2,0) (2,1) (2,2) 
            /// </summary>
            public static IEnumerable<IReadOnlyList<T>> CombinationsWithReplacement<T>(T[] ts, long k)
            {
                if (k <= 0)
                    yield break;

                long[] indices = new long[k];
                T[] container = new T[k];
                long pointer = 0;
                long n = ts.LongLength;

                while (pointer >= 0)
                {
                    if (indices[pointer] < n)
                    {
                        container[pointer] = ts[indices[pointer]];

                        if (pointer >= k - 1)
                        {
                            yield return container;
                            indices[pointer]++;
                        }
                        else
                        {
                            indices[pointer + 1] = 0;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                            indices[pointer]++;
                    }
                }
            }

            /// <summary>
            /// 順列
            /// n = 3, k = 2 => (0,1) (0,2) (1,0) (1,2) (2,0) (2,1) 
            /// </summary>
            public static IEnumerable<IReadOnlyList<long>> Permutations(long n, long k)
            {
                if (k <= 0)
                    yield break;

                HashSet<long> enumed = new HashSet<long>();
                long[] container = new long[k];
                long pointer = 0;

                while (pointer >= 0)
                {
                    if (container[pointer] < n)
                    {
                        if (enumed.Contains(container[pointer]))
                        {
                            container[pointer]++;
                        }
                        else if (pointer >= k - 1)
                        {
                            yield return container;
                            container[pointer]++;
                        }
                        else
                        {
                            enumed.Add(container[pointer]);
                            container[pointer + 1] = 0;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                        {
                            enumed.Remove(container[pointer]);
                            container[pointer]++;
                        }
                    }
                }
            }

            /// <summary>
            /// 順列
            /// n = 3, k = 2 => (0,1) (0,2) (1,0) (1,2) (2,0) (2,1) 
            /// </summary>
            public static IEnumerable<IReadOnlyList<T>> Permutations<T>(T[] ts, long k)
            {
                if (k <= 0)
                    yield break;

                HashSet<long> enumed = new HashSet<long>();
                long[] indices = new long[k];
                T[] container = new T[k];
                long pointer = 0;
                long n = ts.LongLength;

                while (pointer >= 0)
                {
                    if (indices[pointer] < n)
                    {
                        if (enumed.Contains(indices[pointer]))
                        {
                            indices[pointer]++;
                        }
                        else if (pointer >= k - 1)
                        {
                            container[pointer] = ts[indices[pointer]];
                            yield return container;
                            indices[pointer]++;
                        }
                        else
                        {
                            container[pointer] = ts[indices[pointer]];
                            enumed.Add(indices[pointer]);
                            indices[pointer + 1] = 0;
                            pointer++;
                        }
                    }
                    else
                    {
                        pointer--;

                        if (pointer >= 0)
                        {
                            enumed.Remove(indices[pointer]);
                            indices[pointer]++;
                        }
                    }
                }
            }
        }
        public class Tree
        {
            public Tree() { toNodes = new Dictionary<long, long[]>(); }
            public Tree(Scanner sc, long n, bool base1 = true, bool singleDirection = false) { Adjust(sc.Pairs(n), base1, singleDirection); }
            public Tree(Pair<long, long>[] edges, bool base1 = true, bool singleDirection = false) { Adjust(edges, base1, singleDirection); }
            public Tree(IEnumerable<long> ps, IEnumerable<long> qs, bool base1 = true, bool singleDirection = false) { Adjust(ps.Zip(qs, (p, q) => new Pair<long, long>(p, q)).ToArray(), base1, singleDirection); }

            private void Adjust(Pair<long, long>[] edges, bool base1, bool singleDirection)
            {
                var arrows = base1
                    ? edges.Select(x => new { from = x.X - 1, to = x.Y - 1 })
                    : edges.Select(x => new { from = x.X, to = x.Y });
                if (singleDirection == false)
                    arrows = arrows.Concat(arrows.Select(x => new { from = x.to, to = x.from }));
                toNodes = arrows.GroupBy(x => x.from).ToDictionary(x => x.Key, x => x.Select(xs => xs.to).ToArray());
            }

            private long[] empty = new long[0];
            private Dictionary<long, long[]> toNodes;
            public long[] To(long from)
            {
                long[] res = null;
                if (toNodes.TryGetValue(from, out res))
                    return res;
                else
                    return empty;
            }

            public IEnumerable<Pair<long, long>> GetRouteEdges(long from, long to)
            {
                return GetRouteEdgesImpl(from, to).Skip(1);
            }
            private IEnumerable<Pair<long, long>> GetRouteEdgesImpl(long from, long to)
            {
                var routeNodes = GetRouteNodes(from, to);
                var current = -1L;
                foreach (var next in routeNodes)
                {
                    yield return new Pair<long, long>(current, next);
                    current = next;
                }

            }
            public IEnumerable<long> GetRouteNodes(long from, long to)
            {
                Stack<long> routeNodes = new Stack<long>();
                HashSet<long> checkedNodes = new HashSet<long>();

                GetRouteNodes(from, to, routeNodes, checkedNodes);

                return routeNodes.Reverse();
            }
            private bool GetRouteNodes(long current, long dest, Stack<long> routeNodes, HashSet<long> checkedNodes)
            {
                routeNodes.Push(current);
                checkedNodes.Add(current);

                if (current == dest)
                    return true;

                foreach (var next in toNodes[current])
                {
                    if (checkedNodes.Contains(next))
                        continue;

                    if (GetRouteNodes(next, dest, routeNodes, checkedNodes))
                        return true;
                }

                routeNodes.Pop();
                return false;
            }
        }
        public class PriorityQueue<TKey, TState> where TKey : IComparable<TKey>
        {
            public int Count { get; private set; }
            private readonly Func<TState, TKey> keySelector;
            private readonly bool desc;
            private TState[] states = new TState[65536];
            private TKey[] keys = new TKey[65536];
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            public PriorityQueue(Func<TState, TKey> keySelector, bool desc = false) { this.keySelector = keySelector; this.desc = desc; }
            public TState Top
            {
                //[MethodImpl(MethodImplOptions.AggressiveInlining)]
                get { ValidateNonEmpty(); return states[1]; }
            }
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TState Dequeue()
            {
                var top = Top;
                var item = states[Count];
                var key = keys[Count];
                Count--;
                int index = 1;

                while (true)
                {
                    if ((index << 1) >= Count)
                    {
                        if (index << 1 > Count)
                            break;

                        if (key.CompareTo(keys[index << 1]) <= 0 ^ desc)
                            break;

                        states[index] = states[index << 1];
                        keys[index] = keys[index << 1];
                        index <<= 1;
                    }
                    else
                    {
                        var nextIndex = keys[index << 1].CompareTo(keys[(index << 1) + 1]) <= 0 ^ desc
                            ? (index << 1)
                            : (index << 1) + 1;

                        if (key.CompareTo(keys[nextIndex]) <= 0 ^ desc)
                            break;

                        states[index] = states[nextIndex];
                        keys[index] = keys[nextIndex];
                        index = nextIndex;
                    }
                }

                states[index] = item;
                keys[index] = key;

                return top;
            }
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Enqueue(TState state)
            {
                var key = keySelector.Invoke(state);
                Count++;
                int index = Count;
                if (states.Length == Count)
                    Extend(states.Length * 2);

                while ((index >> 1) != 0)
                {
                    if (keys[index >> 1].CompareTo(key) <= 0 ^ desc)
                        break;

                    states[index] = states[index >> 1];
                    keys[index] = keys[index >> 1];
                    index >>= 1;
                }

                states[index] = state;
                keys[index] = key;
            }
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void Extend(int newSize)
            {
                TState[] newStates = new TState[newSize];
                TKey[] newKeys = new TKey[newSize];
                states.CopyTo(newStates, 0);
                keys.CopyTo(newKeys, 0);
                states = newStates;
                keys = newKeys;
            }
            private void ValidateNonEmpty()
            {
                if (Count == 0)
                    throw new IndexOutOfRangeException();
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
            public static long GetFirstIndexGreater<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetFirstIndexGreater(x, listOrdered, 0, listOrdered.Count - 1);
            }
            public static long GetFirstIndexGreater<T>(T x, IList<T> listOrdered, int low, int high) where T : IComparable
            {
                var count = listOrdered.Count;

                if (count == 0)
                    return low;

                if (listOrdered[high].CompareTo(x) <= 0)
                    return high + 1;

                while (low < high)
                {
                    var mid = (low + high) / 2;

                    if (listOrdered[mid].CompareTo(x) > 0)
                        high = mid;
                    else
                        low = mid + 1;
                }

                return low;
            }
            public static long GetLastIndexLess<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetLastIndexLess(x, listOrdered, 0, listOrdered.Count - 1);
            }
            public static long GetLastIndexLess<T>(T x, IList<T> listOrdered, int low, int high) where T : IComparable
            {
                var count = listOrdered.Count;

                if (count == 0)
                    return low - 1;

                if (listOrdered[0].CompareTo(x) >= 0)
                    return low - 1;

                while (low < high)
                {
                    var mid = (low + high + 1) / 2;

                    if (listOrdered[mid].CompareTo(x) < 0)
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
        private static long divider = 1000000007L;
        public static void Set998244353() { divider = 998244353L; }
        public static void Set1000000009() { divider = 1000000009L; }

        public long Value { get; }
        public override string ToString() => this.Value.ToString();

        public Mint(long value) { this.Value = value; }

        //public static implicit operator Mint(long a) => new Mint(a % divider);
        //public static implicit operator Mint(int a) => new Mint(a % divider);
        //public static explicit operator long(Mint a) => a.Value;
        //public static explicit operator int(Mint a) => (int)a.Value;

        public static Mint operator +(Mint a, Mint b) => new Mint((a.Value + b.Value) % divider);
        public static Mint operator +(Mint a, long b) => a + new Mint(b);
        public static Mint operator +(Mint a, int b) => a + new Mint(b);

        public static Mint operator -(Mint a, Mint b)
        {
            var t = (a.Value - b.Value) % divider;
            if (t < 0L)
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
        public static Mint Pow(long a, long p) => new Mint(PowImpl(a, p));
        private static long PowImpl(long a, long p)
        {
            if (p == 0L)
                return 1L;

            if (p == 1L)
                return a;

            var halfP = p / 2L;
            var halfPowered = PowImpl(a, halfP);
            var powered = halfPowered * halfPowered % divider;
            return p % 2L == 0L ? powered : powered * a % divider;
        }

        public static Mint Inv(long a) => new Mint(InvImpl(a));
        private static readonly Dictionary<long, long> invCache = new Dictionary<long, long>();
        private static long InvImpl(long a)
        {
            long cache;
            if (invCache.TryGetValue(a, out cache))
                return cache;

            var result = PowImpl(a, divider - 2L);
            invCache.Add(a, result);
            return result;
        }

        public static Mint Fac(long a) => new Mint(FacImpl(a));
        private static long[] facCache = new long[262144];
        private static long cachedFac = 0L;
        private static long FacImpl(long a)
        {
            if (a >= divider)
                return 0L;

            facCache[0] = 1L;
            if (facCache.LongLength <= a)
            {
                long newSize = facCache.LongLength;
                while (newSize <= a)
                {
                    newSize *= 2;
                }

                ExtendFacCache(newSize);
            }

            if (cachedFac < a)
            {
                var val = facCache[cachedFac];
                var start = cachedFac + 1L;
                for (long i = start; i <= a; i++)
                {
                    val = (val * i) % divider;
                    facCache[i] = val;
                }

                cachedFac = a;
            }

            return facCache[a];
        }
        private static void ExtendFacCache(long newSize)
        {
            long[] newFacCache = new long[newSize];
            facCache.CopyTo(newFacCache, 0);
            facCache = newFacCache;
        }

        public static Mint Perm(long n, long r) => new Mint(PermImpl(n, r));
        private static long PermImpl(long n, long r)
        {
            if (n < r)
                return 0L;

            if (r <= 0L)
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

            var nn = FacImpl(n);
            var nr = FacImpl(n - r);
            var rr = FacImpl(r);

            var nrrr = (nr * rr) % divider;
            return (nn * InvImpl(nrrr)) % divider;
        }
    }
}