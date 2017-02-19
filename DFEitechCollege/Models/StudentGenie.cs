using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public  class StudentGenie : MySQLgenie
    {
        public StudentGenie()
        {
            cmd.Connection = con;
            con.Open();
        }

        ~StudentGenie()
        {
            con.Close();
        }

        public Student InsertStudent(string fname, string lname)
        {
            var student = new Student();
            student.FName = fname;
            student.LName = lname;
            if (lname != "*empty")
            {
                try
                {
                    cmd.CommandText = "INSERT INTO student (student_fname, student_lname) VALUES(@FNAME, @LNAME)";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    student.FName = e.ToString();
                }
            }
            return student;
        }

        public Student UpdateStudent(int id, string fname, string lname)
        {
            var student = new Student();
            student.StudentId = id;
            student.FName = fname;
            student.LName = lname;
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "UPDATE student SET student_fname= @FNAME, student_lname= @LNAME WHERE student_id= @ID";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    student.FName = e.ToString();
                }
            }
            return student;
        }

        public Student DeleteStudent(int id = 0)
        {
            var student = new Student();
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM student WHERE student_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.StudentId = rdr.GetInt32(0);
                        student.FName = rdr.GetString(1);
                        student.LName = rdr.GetString(2); ;
                    }
                    cmd.CommandText = "DELETE FROM student WHERE student_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    student.FName = e.ToString();
                }
            }
            else
            {
                student = new Student() { StudentId = 0, FName = "Please fill in the editor fields" };
            }
            return student;
        }

        public Student GetStudent(int id)
        {
            var student = new Student();
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM student WHERE student_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.StudentId = rdr.GetInt32(0);
                        student.FName = rdr.GetString(1);
                        student.LName = rdr.GetString(2); ;
                    }
                }
                catch (MySqlException e)
                {
                    student.FName = e.ToString();
                }
            }
            return student;
        }


        public List<Student> ListStudents()
        {
            var allStudents = new List<Student>();
            try
            {
                cmd.CommandText = "SELECT * FROM student";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student();
                    student.StudentId = rdr.GetInt32(0);
                    student.FName = rdr.GetString(1);
                    student.LName = rdr.GetString(2);
                    allStudents.Add(student);
                }
            }
            catch (MySqlException e)
            {
                Student student = new Student();
                student.FName = e.ToString();
                allStudents.Add(student);
            }

            return allStudents;
        }

    }
}