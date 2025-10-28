namespace MatrixLibrary;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

public static class MatrixFileReader
{


    public static Matrix LoadFromTxt(string inpath)
    {
        if (string.IsNullOrWhiteSpace(inpath))
            throw new ArgumentException("Path is empty.", nameof(inpath));
        if (!File.Exists(inpath))
            throw new FileNotFoundException("File does not exist.", inpath);

        var lines = File.ReadAllLines(inpath);
        var matrixData = new List<List<float>>();
        int? expectedCols = null;
        int lineNo = 0;

        foreach (string rawLine in lines)
        {
            lineNo++;
            string line = rawLine.Trim();

            if (line == "" || line.StartsWith("#"))
                continue;

            var tokens = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

            if (expectedCols == null)
            {
                expectedCols = tokens.Length;
                if (expectedCols == 0)
                    throw new FormatException($"No columns detected at line {lineNo}.");
            }
            else if (tokens.Length != expectedCols)
            {
                throw new FormatException($"Inconsistent column count at line {lineNo}: " +
                                          $"expected {expectedCols}, got {tokens.Length}.");
            }

            var row = new List<float>(tokens.Length);
            for (int col = 0; col < tokens.Length; col++)
            {
                var token = tokens[col];
                if (!float.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                    throw new FormatException($"Invalid number '{token}' at line {lineNo}, column {col + 1}.");

                row.Add(value);
            }
            matrixData.Add(row);
        }

        if (matrixData.Count == 0)
        {
            throw new FormatException("File contains no data rows.");
        }
        return new Matrix(matrixData);
    }
    public static Matrix LoadFromJson(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path is empty.", nameof(path));
        
        if (!File.Exists(path))
            throw new FileNotFoundException("JSON file does not exist.", path);

        string json = File.ReadAllText(path);
        Matrix? matrix = JsonSerializer.Deserialize<Matrix>(json);
        if (matrix == null)
            throw new JsonException("JSON could not be deserialized into a Matrix.");
        if (matrix.Data == null || matrix.Data.Count == 0)
            throw new FormatException("JSON contains no matrix data (Data is null or empty).");
        int cols = matrix.Data[0].Count;
        if (cols == 0)
            throw new FormatException("JSON matrix has zero columns.");
        for (int r = 0; r < matrix.Data.Count; r++)
        {
            var row = matrix.Data[r];
            if (row == null)
                throw new FormatException($"JSON matrix row {r + 1} is null.");
            if (row.Count != cols)
                throw new FormatException($"JSON matrix is ragged at row {r + 1}: expected {cols}, got {row.Count}.");
        }           
        if (matrix.Rows != matrix.Data.Count || matrix.Columns != cols)
            throw new FormatException("JSON matrix dimension fields (Rows/Columns) do not match the Data payload.");

        return matrix;
        
    }

}