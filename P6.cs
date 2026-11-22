/*using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
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

        DataTable dt = ds.Tables["Student"];

        DataRow newRow = dt.NewRow();

        newRow["StudentID"] = 104;
        newRow["StudentName"] = "Rohit";
        newRow["Age"] = 22;
        newRow["Course"] = "MCA";

        dt.Rows.Add(newRow);

        SqlCommand insertCmd = new SqlCommand(
            "INSERT INTO Student VALUES (@id, @name, @age, @course)", con);

        insertCmd.Parameters.Add("@id", SqlDbType.Int, 0, "StudentID");
        insertCmd.Parameters.Add("@name", SqlDbType.VarChar, 50, "StudentName");
        insertCmd.Parameters.Add("@age", SqlDbType.Int, 0, "Age");
        insertCmd.Parameters.Add("@course", SqlDbType.VarChar, 50, "Course");

        da.InsertCommand = insertCmd;

        da.Update(ds, "Student");

        Console.WriteLine("Student inserted successfully.");
    }
}*/