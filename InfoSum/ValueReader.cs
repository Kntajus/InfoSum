using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace InfoSum
{
    public class ValueReader : IDisposable
    {
        StreamReader _reader;
        CsvReader _csvReader;

        public ValueReader(string pathToCsv)
        {
            _reader = new StreamReader(pathToCsv);
            _csvReader = new CsvReader(_reader);
        }

        public IEnumerable<DataRow> GetRows() => _csvReader.EnumerateRecords(new DataRow());

        public void Dispose()
        {
            _csvReader.Dispose();
            _reader.Dispose();
        }
    }
}
