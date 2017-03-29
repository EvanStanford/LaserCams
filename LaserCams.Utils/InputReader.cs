using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LaserCams.Utils
{
    public class InputReader : IInputReader
    {
        public InputCams Read(string filePath)
        {
            List<InputRow> rows;
            using (TextReader textReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(textReader);
                rows = csv.GetRecords<InputRow>().ToList();
            }
            return new InputCams
            {
                BCam = rows.Select(r => new Point(r.BX, r.BY, 0)).ToList(),
                ACam = rows.Select(r => new Point(r.AX, r.AY, 0)).ToList(),
            };
        }

        private class InputRow
        {
            public float BX { get; set; }
            public float BY { get; set; }
            public float AX { get; set; }
            public float AY { get; set; }
        }
    }
}
