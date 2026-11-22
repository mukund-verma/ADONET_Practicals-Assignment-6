using System;
using System.Data;
using Microsoft.Data.SqlClient;
class Program
{
    static string cs = @"Server=LAPTOP-JI945SVP\SQLEXPRESS;
                         Database=CollegeDB;
                         Trusted_Connection=True;
                         TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== ADO.NET CRUD OPERATIONS =====");
            Console.WriteLine("1. Connected Architecture");
            Console.WriteLine("2. Disconnected Architecture");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ConnectedMenu();
                    break;

                case 2:
                    DisconnectedMenu();
                    break;

                case 0:
                    Console.WriteLine("Program Ended.");
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    // =====================================
    // CONNECTED ARCHITECTURE
    // =====================================
    static void ConnectedMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- CONNECTED ARCHITECTURE ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ConnectedInsert();
                    break;

                case 2:
                    ConnectedRead();
                    break;

                case 3:
                    ConnectedUpdate();
                    break;

                case 4:
                    ConnectedDelete();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    // CREATE - INSERT
    static void ConnectedInsert()
    {
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
            string query = "INSERT INTO Student VALUES (@id, @name, @age, @course)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@course", course);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + " Student Record Inserted.");
            }
        }
    }

    // READ - DISPLAY
    static void ConnectedRead()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * FROM Student";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nSTUDENT RECORDS");

                    while (dr.Read())
                    {
                        Console.WriteLine(
                            dr["StudentID"] + " | " +
                            dr["StudentName"] + " | " +
                            dr["Age"] + " | " +
                            dr["Course"]);
                    }
                }
            }
        }
    }

    // UPDATE
    static void ConnectedUpdate()
    {
        Console.Write("Enter Student ID to Update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Course: ");
        string course = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "UPDATE Student SET StudentName=@name, Age=@age, Course=@course WHERE StudentID=@id";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@course", course);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Student Record Updated.");
                else
                    Console.WriteLine("Student ID Not Found.");
            }
        }
    }

    // DELETE
    static void ConnectedDelete()
    {
        Console.Write("Enter Student ID to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "DELETE FROM Student WHERE StudentID=@id";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Student Record Deleted.");
                else
                    Console.WriteLine("Student ID Not Found.");
            }
        }
    }

    // =====================================
    // DISCONNECTED ARCHITECTURE
    // =====================================

    static void DisconnectedMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- DISCONNECTED ARCHITECTURE ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisconnectedInsert();
                    break;

                case 2:
                    DisconnectedRead();
                    break;

                case 3:
                    DisconnectedUpdate();
                    break;

                case 4:
                    DisconnectedDelete();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    // READ - DISCONNECTED
    static void DisconnectedRead()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * FROM Student";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                DataSet ds = new DataSet();

                da.Fill(ds, "Student");

                DataTable dt = ds.Tables["Student"];

                Console.WriteLine("\nSTUDENT RECORDS FROM DATASET");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                        row["StudentID"] + " | " +
                        row["StudentName"] + " | " +
                        row["Age"] + " | " +
                        row["Course"]);
                }
            }
        }
    }

    // CREATE - DISCONNECTED INSERT
    static void DisconnectedInsert()
    {
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
            string query = "SELECT * FROM Student";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                using (SqlCommandBuilder builder = new SqlCommandBuilder(da))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds, "Student");

                    DataTable dt = ds.Tables["Student"];

                    DataRow row = dt.NewRow();

                    row["StudentID"] = id;
                    row["StudentName"] = name;
                    row["Age"] = age;
                    row["Course"] = course;

                    dt.Rows.Add(row);

                    int result = da.Update(ds, "Student");

                    Console.WriteLine(result + " Student Record Inserted.");
                }
            }
        }
    }

    // UPDATE - DISCONNECTED
    static void DisconnectedUpdate()
    {
        Console.Write("Enter Student ID to Update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Course: ");
        string course = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * FROM Student";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                using (SqlCommandBuilder builder = new SqlCommandBuilder(da))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds, "Student");

                    DataTable dt = ds.Tables["Student"];

                    DataRow row = dt.Rows.Find(id);

                    if (row != null)
                    {
                        row["StudentName"] = name;
                        row["Age"] = age;
                        row["Course"] = course;

                        int result = da.Update(ds, "Student");

                        Console.WriteLine(result + " Student Record Updated.");
                    }
                    else
                    {
                        Console.WriteLine("Student ID Not Found.");
                    }
                }
            }
        }
    }

    // DELETE - DISCONNECTED
    static void DisconnectedDelete()
    {
        Console.Write("Enter Student ID to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * FROM Student";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                using (SqlCommandBuilder builder = new SqlCommandBuilder(da))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds, "Student");

                    DataTable dt = ds.Tables["Student"];

                    DataRow row = dt.Rows.Find(id);

                    if (row != null)
                    {
                        row.Delete();

                        int result = da.Update(ds, "Student");

                        Console.WriteLine(result + " Student Record Deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Student ID Not Found.");
                    }
                }
            }
        }
    }
}
