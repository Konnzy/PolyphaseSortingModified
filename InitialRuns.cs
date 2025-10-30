namespace PolyphaseSorting
{
    public static class InitialRuns
    {
        public static List<string> CreateSortedRuns(string inputPath, string runDir, int blockSize)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[Phase 1] Creating sorted runs..");
            Console.ResetColor();
            var runs = new List<string>();
            using var sr = new StreamReader(inputPath);
            var buffer = new List<Record>(blockSize);
            string? line;
            var runIndex = 0;

            while ((line = sr.ReadLine()) != null)
            {
                buffer.Add(Record.Parse(line));
                if (buffer.Count >= blockSize)
                    runs.Add(FlushRun(runDir, ref runIndex, buffer));
            }

            if (buffer.Count > 0)
                runs.Add(FlushRun(runDir, ref runIndex, buffer));
            return runs;
        }

        private static string FlushRun(string dir, ref int index, List<Record> buffer)
        {
            MergeSort.Sort(buffer, 0, buffer.Count - 1);
            var path = Path.Combine(dir, $"run_{index++:000}.tmp");

            File.WriteAllLines(path, buffer.Select(r => r.ToString()));
            buffer.Clear();
            return path;
        }
    }
}