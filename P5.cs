/*using System;
using System.Data;
using Microsoft.Data.SqlClient;

class P5
{
    static void Main()
    {
        string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                      Database=CollegeDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;";

        SqlConnection con = new SqlConnection(cs);

        string query = "SELECT * FROM Student";

        SqlDataAdapter da = new SqlDataAdapter(query, con);

        DataSet ds = new DataSet();

        da.Fill(ds, "Student");

        DataTable dt = ds.Tables["Student"];

        Console.WriteLine("Student Records:");
        Console.WriteLine("-------------------------------");

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine("ID: " + row["StudentID"]);
            Console.WriteLine("Name: " + row["StudentName"]);
            Console.WriteLine("Age: " + row["Age"]);
            Console.WriteLine("Course: " + row["Course"]);
            Console.WriteLine();
        }
    }
}*/