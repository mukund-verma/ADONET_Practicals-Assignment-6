/*using System;
using System.Data.SqlClient;
class P1
{
    static void Main()
    {
        string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                      Database=CollegeDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;";
        SqlConnection con = new SqlConnection(cs);
        string query = "SELECT * FROM Student";
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        Console.WriteLine("STUDENT RECORDS");
        Console.WriteLine("-----------------------------");
        while (dr.Read())
        {
            Console.WriteLine("Student ID: " + dr["StudentID"]);
            Console.WriteLine("Student Name: " + dr["StudentName"]);
            Console.WriteLine("Age: " + dr["Age"]);
            Console.WriteLine("Course: " + dr["Course"]);
            Console.WriteLine("-----------------------------");
        }
        dr.Close();
        con.Close();
        Console.WriteLine("Database Connection Closed.");
        Console.ReadLine();
    }
}
*/