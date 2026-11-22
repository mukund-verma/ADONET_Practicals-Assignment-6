/*using System;
using System.Data;
using Microsoft.Data.SqlClient;

class P7
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
            if ((int)row["StudentID"] == 101)
            {
                row["StudentName"] = "Rahul Verma";
                row["Age"] = 22;
                row["Course"] = "MCA";
            }
        }

        SqlCommand updateCmd = new SqlCommand(
            "UPDATE Student SET StudentName=@name, Age=@age, Course=@course WHERE StudentID=@id",
            con);

        updateCmd.Parameters.Add("@name", SqlDbType.VarChar, 50, "StudentName");
        updateCmd.Parameters.Add("@age", SqlDbType.Int, 0, "Age");
        updateCmd.Parameters.Add("@course", SqlDbType.VarChar, 50, "Course");

        SqlParameter idParam = updateCmd.Parameters.Add("@id", SqlDbType.Int, 0, "StudentID");
        idParam.SourceVersion = DataRowVersion.Original;

        da.UpdateCommand = updateCmd;

        da.Update(ds, "Student");

        Console.WriteLine("Student updated successfully.");
    }
}*/