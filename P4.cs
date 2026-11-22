/*using System;
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

        string query = "DELETE FROM Student WHERE StudentID=@id";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@id", 105);

        con.Open();

        int result = cmd.ExecuteNonQuery();

        if (result > 0)
        {
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        con.Close();
    }
}*/