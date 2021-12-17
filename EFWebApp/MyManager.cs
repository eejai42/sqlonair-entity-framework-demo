using Microsoft.Data.SqlClient;
using SSoTme.OST.Lib.CLIOptions;
using System;
using System.IO;

namespace entity_framework_test2
{
    internal class MyManager : SQLonAirManager
    {
        internal static void BuildSQLonAir(string csvFileName, string connectionString)
        {
            var csvFI = new FileInfo(csvFileName);
            if (!csvFI.Exists) throw new Exception($"CSV FileName '{csvFileName}' not found.");
            else
            {
                var soaBuildFolder = new DirectoryInfo(Path.Combine(csvFI.Directory.FullName, "SQLonAir"));
                if (!soaBuildFolder.Exists) soaBuildFolder.Create();
                Environment.CurrentDirectory = soaBuildFolder.FullName;

                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    using (var cmd = sqlConn.CreateCommand())
                    {
                        cmd.CommandText = "select * from sys.tables for XML AUTO, root('tables')";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var xml = reader.GetString(0);
                                var csv = File.ReadAllText(csvFileName);
                                WriteFilesToBuildFolder(soaBuildFolder, xml, csv);
                            }
                        }
                    }
                }
            }
        }

        private static void WriteFilesToBuildFolder(DirectoryInfo soaBuildFolder, string xml, string csv)
        {
            var xmlFI = new FileInfo(Path.Combine(soaBuildFolder.FullName, "SqlSchema.xml"));
            var csvFI = new FileInfo(Path.Combine(soaBuildFolder.FullName, "CalculatedFields.csv"));
            File.WriteAllText(xmlFI.FullName, xml);
            File.WriteAllText(csvFI.FullName, csv);
            var handler = SSoTmeCLIHandler.CreateHandler("odxml42/sql-schema-to-odxml -i sqlschema.xml");
            var intValue = handler.TranspileProject();
            object o = 1;
        }
    }
}