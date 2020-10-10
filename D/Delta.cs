using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace V
{
    partial class Solver
    {
        public void Solve()
        {
            //var n = Read;
            Write(SolveLong());
            //YesNo(SolveBool());
        }

        public long SolveLong()
        {
            var n = Read;
            var k = Read;
            var a = Arr(n);
            var res = 0L;
            return res;
        }

        public bool SolveBool()
        {
            var n = Read;
            var res = false;
            return res;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafeSet<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] = value;
            else
                ts.Add(t, value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafePlus<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] += value;
            else
                ts.Add(t, value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafeSub<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] -= value;
            else
                ts.Add(t, value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafeMult<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] *= value;
            else
                ts.Add(t, value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafeDiv<T>(this Dictionary<T, long> ts, T t, long value)
        {
            if (ts.ContainsKey(t))
                ts[t] /= value;
            else
                ts.Add(t, value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> ts) => new HashSet<T>(ts.Distinct());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Queue<T> ToQueue<T>(this IEnumerable<T> ts) => new Queue<T>(ts);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToDigit(this char c) => (long)(c - '0');
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToSmallAbcIndex(this char c) => (long)(c - 'a');
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLargeAbcIndex(this char c) => (long)(c - 'A');
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<T1, T2>(this IGrouping<T1, T2> gs) => gs.LongCount();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToStr(this IEnumerable<char> cs) => new string(cs.ToArray());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMin<T>(this ref T current, T newer) where T : struct, IComparable<T>
        {
            if (current.CompareTo(newer) <= 0)
                return false;

            current = newer;
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMax<T>(this ref T current, T newer) where T : struct, IComparable<T>
        {
            if (current.CompareTo(newer) >= 0)
                return false;

            current = newer;
            return true;
        }
    }
    class C
    {
        public class SegmentTree<T>
        {
            private readonly int valueCount;
            private readonly int baseCount;
            private readonly int baseIndex;
            private readonly T[] nodes;
            private readonly Func<T, T, T> func;
            private readonly T defaultValue;

            public SegmentTree(IReadOnlyList<T> ts, Func<T, T, T> func, T filling = default(T))
            {
                this.func = func;
                this.defaultValue = filling;
                valueCount = ts.Count;
                baseCount = 1;
                while (valueCount > baseCount)
                    baseCount <<= 1;
                nodes = new T[baseCount * 2 - 1];
                baseIndex = baseCount - 1;

                for (int i = 0; i < ts.Count; i++)
                    nodes[baseIndex + i] = ts[i];
                for (int i = ts.Count; i < baseCount; i++)
                    nodes[baseIndex + i] = filling;

                for (int i = baseIndex - 1; i >= 0; i--)
                    nodes[i] = func.Invoke(nodes[i * 2 + 1], nodes[i * 2 + 2]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(int index, T t)
            {
                var i = baseIndex + index;
                nodes[i] = t;
                while (i > 0)
                {
                    i -= 1;
                    i /= 2;
                    nodes[i] = func.Invoke(nodes[i * 2 + 1], nodes[i * 2 + 2]);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public T Query(int leftIndex, int rightNextIndex)
            {
                T left = defaultValue;
                T right = defaultValue;

                int l = leftIndex + baseCount - 1;
                int r = rightNextIndex + baseCount - 1;
                for (; l < r; l >>= 1, r >>= 1)
                {
                    if ((l & 1) == 0)
                    {
                        left = func.Invoke(left, nodes[l]);
                    }

                    if ((r & 1) == 0)
                    {
                        r--;
                        right = func.Invoke(right, nodes[r]);
                    }
                }

                return func.Invoke(left, right);
            }
        }
        public class SegmentTree
        {
            public static SegmentTree<int> Sum(IReadOnlyList<int> values) => new SegmentTree<int>(values, (x, y) => x + y);
            public static SegmentTree<long> Sum(IReadOnlyList<long> values) => new SegmentTree<long>(values, (x, y) => x + y);
            public static SegmentTree<double> Sum(IReadOnlyList<double> values) => new SegmentTree<double>(values, (x, y) => x + y);

            public static SegmentTree<int> Mult(IReadOnlyList<int> values) => new SegmentTree<int>(values, (x, y) => x * y, 1);
            public static SegmentTree<long> Mult(IReadOnlyList<long> values) => new SegmentTree<long>(values, (x, y) => x * y, 1);
            public static SegmentTree<double> Mult(IReadOnlyList<double> values) => new SegmentTree<double>(values, (x, y) => x * y, 1);

            public static SegmentTree<int> Min(IReadOnlyList<int> values) => new SegmentTree<int>(values, Math.Min, int.MaxValue);
            public static SegmentTree<long> Min(IReadOnlyList<long> values) => new SegmentTree<long>(values, Math.Min, long.MaxValue);
            public static SegmentTree<double> Min(IReadOnlyList<double> values) => new SegmentTree<double>(values, Math.Min, double.MaxValue);

            public static SegmentTree<int> Max(IReadOnlyList<int> values) => new SegmentTree<int>(values, Math.Max, int.MinValue);
            public static SegmentTree<long> Max(IReadOnlyList<long> values) => new SegmentTree<long>(values, Math.Max, long.MinValue);
            public static SegmentTree<double> Max(IReadOnlyList<double> values) => new SegmentTree<double>(values, Math.Max, double.MinValue);
        }

        public class UnionFind
        {
            private int[] parents;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public UnionFind(int count)
            {
                parents = Enumerable.Repeat(-1, count).ToArray();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool TryUnite(int x, int y)
            {
                var rootX = GetRoot(x);
                var rootY = GetRoot(y);

                if (rootX == rootY)
                    return false;

                if (parents[rootY] < parents[rootX])
                {
                    var temp = rootX;
                    rootX = rootY;
                    rootY = temp;
                }
                parents[rootX] += parents[rootY];
                parents[rootY] = rootX;

                return true;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Find(int x, int y) => GetRoot(x) == GetRoot(y);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetRoot(int x)
            {
                while (parents[x] >= 0)
                    x = parents[x];
                return x;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long GetSize(int x) => -parents[GetRoot(x)];
        }
        public class IterTools
        {
            /// <summary>
            /// 組み合わせ（重複なし）
            /// n = 4, k = 3 => (0,1,2) (0,1,3) (0,2,3) (1,2,3)
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IEnumerable<long> GetRouteNodes(long from, long to)
            {
                Stack<long> routeNodes = new Stack<long>();
                HashSet<long> checkedNodes = new HashSet<long>();

                GetRouteNodes(from, to, routeNodes, checkedNodes);

                return routeNodes.Reverse();
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            /// <summary>
            /// 木の直径（一番長い枝）を求める
            /// </summary>
            /// <returns>木の直径（一番長い枝）</returns>
            public long GetDiameter()
            {
                long firstFarthest = 0;
                long _1 = 0;
                GetDiameterImpl(-1, 0, 0, ref _1, ref firstFarthest);
                long maxDistance = 0;
                long _2 = 0;
                GetDiameterImpl(-1, firstFarthest, 0, ref maxDistance, ref _2);
                return maxDistance;
            }
            private void GetDiameterImpl(long from, long current, long distance, ref long maxDistance, ref long farthest)
            {
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    farthest = current;
                }

                foreach (var to in To(current))
                {
                    if (from == to)
                        continue;

                    GetDiameterImpl(current, to, distance + 1, ref maxDistance, ref farthest);
                }
            }
        }
        public class PriorityQueue<TKey, TState> where TKey : IComparable<TKey>
        {
            public int Count { get; private set; }
            private readonly Func<TState, TKey> keySelector;
            private readonly bool desc;
            private TState[] states = new TState[65536];
            private TKey[] keys = new TKey[65536];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public PriorityQueue(Func<TState, TKey> keySelector, bool desc = false) { this.keySelector = keySelector; this.desc = desc; }
            public TState Top
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get { ValidateNonEmpty(); return states[1]; }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void Extend(int newSize)
            {
                TState[] newStates = new TState[newSize];
                TKey[] newKeys = new TKey[newSize];
                states.CopyTo(newStates, 0);
                keys.CopyTo(newKeys, 0);
                states = newStates;
                keys = newKeys;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public BinaryIndexTree(long length)
            {
                this.length = length;
                binaryIndexedTree = new long[length + 1];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Add(long indexZeroBase, long additional)
            {
                // i += i & -i
                // 1が立っている最下位ビットを足す、の意味
                for (long i = indexZeroBase + 1; i <= length; i += i & -i)
                {
                    binaryIndexedTree[i] += additional;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetCountLarger<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return listOrdered.Count - GetCountSmallerOrEqual(x, listOrdered);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetCountLargerOrEqual<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return listOrdered.Count - GetCountSmaller(x, listOrdered);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetCountSmaller<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetLastIndexLess(x, listOrdered) + 1;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetCountSmallerOrEqual<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetFirstIndexGreater(x, listOrdered);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetFirstIndexGreater<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetFirstIndexGreater(x, listOrdered, 0, listOrdered.Count - 1);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static long GetLastIndexLess<T>(T x, IList<T> listOrdered) where T : IComparable
            {
                return GetLastIndexLess(x, listOrdered, 0, listOrdered.Count - 1);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Gcd(int a, int b) => Gcd((long)a, (long)b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Gcd(long a, long b)
        {
            if (a < b)
                return GcdImpl(b, a);
            else
                return GcdImpl(a, b);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long GcdImpl(long a, long b)
        {
            var remainder = a % b;
            if (remainder == 0)
                return b;
            else
                return GcdImpl(b, remainder);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Lcm(int a, int b) => Lcm((long)a, (long)b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Lcm(long a, long b)
        {
            return a / Gcd(a, b) * b;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Pow(int n, int p) => Pow((long)n, (long)p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Pow(long n, long p)
        {
            var res = 1L;
            for (long i = 0; i < p; i++)
                res *= n;
            return res;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<long, long> Factorize(int n) => Factorize((long)n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<long> Divisors(int n) => Divisors((long)n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long InversionNumberCountWithCompression<T>(IList<T> list) where T : IComparable<T>
        {
            var compressed = list
                .Select((n, i) => new { n, i })
                .GroupBy(x => x.n)
                .OrderBy(x => x.Key)
                .Select((g, i) => new { g, i })
                .SelectMany(x => x.g.Select(xs => new { order = xs.i, index = x.i }))
                .OrderBy(x => x.index)
                .Select(x => x.order);

            return InversionNumberCount(compressed, list.Count);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long InversionNumberCountWithMinusCheck(IList<int> list)
        {
            var min = list.Min();
            var max = list.Max();

            if (min < 0)
                return InversionNumberCount(list.Select(x => x - min), max - min);
            else
                return InversionNumberCount(list, max);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long InversionNumberCount(IEnumerable<int> list, int maxValue)
        {

            var bit = new BinaryIndexTree(maxValue + 1);
            var res = 0L;
            var i = 0;
            foreach (var n in list)
            {
                res += i - bit.Sum(n);
                bit.Add(n, +1);
                i++;
            }

            return res;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<int> Loop(int n)
        {
            for (int i = 0; i < n; i++)
                yield return i;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<long> Loop(long n)
        {
            for (long i = 0L; i < n; i++)
                yield return i;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> Repeat<T>(T t, long n)
        {
            for (long i = 0L; i < n; i++)
                yield return t;
        }
    }
    struct Mint
    {
        public static long Divider { set { divider = value; } }
        private static long divider = 1000000007L;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set998244353() { divider = 998244353L; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set1000000009() { divider = 1000000009L; }

        public long Value { get; }
        public override string ToString() => this.Value.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Mint(long value)
        {
            this.Value = value % divider;
            if (this.Value < 0)
                this.Value += divider;
        }

        //public static implicit operator Mint(long a) => new Mint(a % divider);
        //public static implicit operator Mint(int a) => new Mint(a % divider);
        //public static explicit operator long(Mint a) => a.Value;
        //public static explicit operator int(Mint a) => (int)a.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator +(Mint a, Mint b) => new Mint((a.Value + b.Value) % divider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator +(Mint a, long b) => a + new Mint(b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator +(Mint a, int b) => a + new Mint(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator -(Mint a, Mint b)
        {
            var t = (a.Value - b.Value) % divider;
            if (t < 0L)
                t += divider;
            return new Mint(t);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator -(Mint a, long b) => a - new Mint(b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator -(Mint a, int b) => a - new Mint(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator *(Mint a, Mint b) => new Mint((a.Value * b.Value) % divider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator *(Mint a, long b) => a * new Mint(b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator *(Mint a, int b) => a * new Mint(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator /(Mint a, Mint b) => new Mint((a.Value * InvImpl(b.Value)) % divider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator /(Mint a, long b) => a / new Mint(b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint operator /(Mint a, int b) => a / new Mint(b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Mint Pow(long p) => new Mint(PowImpl(Value, p));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint Pow(long a, long p) => new Mint(PowImpl(a, p));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint Inv(long a) => new Mint(InvImpl(a));
        private static readonly Dictionary<long, long> invCache = new Dictionary<long, long>();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long InvImpl(long a)
        {
            long cache;
            if (invCache.TryGetValue(a, out cache))
                return cache;

            var result = PowImpl(a, divider - 2L);
            invCache.Add(a, result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint Fac(long a) => new Mint(FacImpl(a));
        private static long[] facCache = new long[262144];
        private static long cachedFac = 0L;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ExtendFacCache(long newSize)
        {
            long[] newFacCache = new long[newSize];
            facCache.CopyTo(newFacCache, 0);
            facCache = newFacCache;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint Perm(long n, long r) => new Mint(PermImpl(n, r));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint Comb(long n, long r) => new Mint(CombImpl(n, r));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Mint CombOneByOne(long n, long r)
        {
            if (n < r)
                return new Mint(0);

            if (n == r)
                return new Mint(1);

            if (n - r < r)
                return CombOneByOne(n, n - r);

            var res = new Mint(1);
            for (long i = 1; i <= r; i++)
            {
                res *= n - i + 1;
                res /= i;
            }

            return res;
        }
    }
}
