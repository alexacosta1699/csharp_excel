using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Read the Excel file into a DataSet
        var dataSet = ReadExcelFile("path/to/excel/file.xlsx");

        // Step 2: Select the column containing the dates
        var datesColumn = dataSet.Tables["Sheet1"].Columns["Date"];

        // Step 3: Convert the dates column to a list
        var datesList = new List<string>();
        foreach (var row in dataSet.Tables["Sheet1"].Rows)
        {
            datesList.Add(row[datesColumn].ToString());
        }

        // Step 4: Print out the dates list
        Console.WriteLine(string.Join(",", datesList));
    }

    static DataSet ReadExcelFile(string filePath)
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                return reader.AsDataSet();
            }
        }
    }
}