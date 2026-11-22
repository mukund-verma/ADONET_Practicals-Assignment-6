/*using System;
using Microsoft.Data.SqlClient;

class P3
{
    static void Main()
    {
        string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                      Database=CollegeDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;";

        SqlConnection con = new SqlConnection(cs);

        string query = "UPDATE Student SET StudentName=@name, Age=@age, Course=@course WHERE StudentID=@id";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@id", 101);
        cmd.Parameters.AddWithValue("@name", "Rahul Sharma");
        cmd.Parameters.AddWithValue("@age", 21);
        cmd.Parameters.AddWithValue("@course", "MCA");

        con.Open();

        int result = cmd.ExecuteNonQuery();

        if (result > 0)
        {
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        con.Close();
    }
}*/