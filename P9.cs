/*using System;
using System.Data;
using Microsoft.Data.SqlClient;

class P9
{
    static void Main()
    {
        string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                      Database=CollegeDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;";

        SqlConnection con = new SqlConnection(cs);

        SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM Student", con);

        DataSet ds = new DataSet();

        da.Fill(ds, "Student");

        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        DataTable dt = ds.Tables["Student"];

        // INSERT
        DataRow newRow = dt.NewRow();

        newRow["StudentID"] = 105;
        newRow["StudentName"] = "Neha";
        newRow["Age"] = 20;
        newRow["Course"] = "BCA";

        dt.Rows.Add(newRow);

        da.Update(ds, "Student");

        Console.WriteLine("Record inserted.");

        // UPDATE
        foreach (DataRow row in dt.Rows)
        {
            if ((int)row["StudentID"] == 105)
            {
                row["StudentName"] = "Neha Sharma";
                row["Age"] = 21;
            }
        }

        da.Update(ds, "Student");

        Console.WriteLine("Record updated.");

        // DELETE
        foreach (DataRow row in dt.Rows)
        {
            if ((int)row["StudentID"] == 105)
            {
                row.Delete();
                break;
            }
        }

        da.Update(ds, "Student");

        Console.WriteLine("Record deleted.");
    }
}*/