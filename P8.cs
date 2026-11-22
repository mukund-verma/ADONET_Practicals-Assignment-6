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

        foreach (DataRow row in dt.Rows)
        {
            if ((int)row["StudentID"] == 103)
            {
                row.Delete();
                break;
            }
        }

        SqlCommand deleteCmd = new SqlCommand(
            "DELETE FROM Student WHERE StudentID=@id", con);

        SqlParameter idParam = deleteCmd.Parameters.Add(
            "@id", SqlDbType.Int, 0, "StudentID");

        idParam.SourceVersion = DataRowVersion.Original;

        da.DeleteCommand = deleteCmd;

        da.Update(ds, "Student");

        Console.WriteLine("Student deleted successfully.");
    }
}*/