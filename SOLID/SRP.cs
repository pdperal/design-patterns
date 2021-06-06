using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
    }


    public class SRP
    {
        static void MainSRP(string[] args)
        {
            var j = new Journal();

            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");

            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);

            ReadKey();
        }
    }
}
