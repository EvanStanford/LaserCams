using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LaserCams.Utils
{
    public class InputReader : IInputReader
    {
        public Tuple<List<Point>, List<Point>> Read(string filePath)
        {
            List<InputRow> rows;
            using (TextReader textReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(textReader);
                rows = csv.GetRecords<InputRow>().ToList();
            }
            return new Tuple<List<Point>, List<Point>>
                (rows.Select(r => new Point(r.X1, r.Y1, 0)).ToList(),
                rows.Select(r => new Point(r.X2, r.Y2, 0)).ToList());
        }

        private class InputRow
        {
            public float X1 { get; set; }
            public float Y1 { get; set; }
            public float X2 { get; set; }
            public float Y2 { get; set; }
        }
    }
}
