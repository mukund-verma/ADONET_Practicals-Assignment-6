/*
using System;
using Microsoft.Data.SqlClient;

class P2
{
    static void Main()
    {
        string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                      Database=CollegeDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;";

        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "INSERT INTO Student (StudentID, StudentName, Age, Course) VALUES (@id, @name, @age, @course)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@course", course);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Student Record Inserted Successfully!");
                }
            }
        }

        Console.ReadLine();
    }
}
*/