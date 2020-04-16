using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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