using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public class TeacherGenie : MySQLgenie
    {
        public TeacherGenie()
        {
            cmd.Connection = con;
            con.Open();
        }

        ~TeacherGenie()
        {
            con.Close();
        }

        public Teacher InsertTeacher(string fname, string lname)
        {
            var teacher = new Teacher();
            teacher.FName = fname;
            teacher.LName = lname;
            if (lname != "*empty")
            {
                try
                {
                    cmd.CommandText = "INSERT INTO teacher (teacher_fname, teacher_lname) VALUES(@FNAME, @LNAME)";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    teacher.FName = e.ToString();
                }
            }
            return teacher;
        }

        public Teacher UpdateTeacher(int id, string fname, string lname)
        {
            var teacher = new Teacher();
            teacher.TeacherId = id;
            teacher.FName = fname;
            teacher.LName = lname;
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "UPDATE teacher SET teacher_fname= @FNAME, teacher_lname= @LNAME WHERE teacher_id= @ID";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    teacher.FName = e.ToString();
                }
            }
            return teacher;
        }

        public Teacher DeleteTeacher(int id = 0)
        {
            var teacher = new Teacher();
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM teacher WHERE teacher_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher.TeacherId = rdr.GetInt32(0);
                        teacher.FName = rdr.GetString(1);
                        teacher.LName = rdr.GetString(2); ;
                    }
                    cmd.CommandText = "DELETE FROM teacher WHERE teacher_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    teacher.FName = e.ToString();
                }
            }
            else
            {
                teacher = new Teacher() { TeacherId = 0, FName = "Please fill in the editor fields" };
            }
            return teacher;
        }

        public Teacher GetTeacher(int id)
        {
            var teacher = new Teacher();
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM teacher WHERE teacher_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher.TeacherId = rdr.GetInt32(0);
                        teacher.FName = rdr.GetString(1);
                        teacher.LName = rdr.GetString(2); ;
                    }
                }
                catch (MySqlException e)
                {
                    teacher.FName = e.ToString();
                }
            }
            else
            {
                teacher = new Teacher() { TeacherId = 0, FName = "Please fill in the Teacher ID field" };
            }
            con.Close();
            con.Open();
            return teacher;
        }


        public List<Teacher> ListTeachers()
        {
            var allTeachers = new List<Teacher>();
            try
            {
                cmd.CommandText = "SELECT * FROM teacher";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherId = rdr.GetInt32(0);
                    teacher.FName = rdr.GetString(1);
                    teacher.LName = rdr.GetString(2);
                    allTeachers.Add(teacher);
                }
            }
            catch (MySqlException e)
            {
                Teacher teacher = new Teacher();
                teacher.FName = e.ToString();
                allTeachers.Add(teacher);
            }
            return allTeachers;
        }
    }
}