using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LaserCams.Core
{
    public class InputReader
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
                (rows.Select(r => new Point { X = r.X1, Y = r.Y1 }).ToList(),
                rows.Select(r => new Point { X = r.X2, Y = r.Y2 }).ToList());
        }

        private class InputRow
        {
            public double X1 { get; set; }
            public double Y1 { get; set; }
            public double X2 { get; set; }
            public double Y2 { get; set; }
        }
    }
}
