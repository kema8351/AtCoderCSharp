using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace A
{
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

    class Program
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

        public IEnumerable<string> Solve()
        {
            var res = 0L;
            yield return res.ToString();
        }
    }
}