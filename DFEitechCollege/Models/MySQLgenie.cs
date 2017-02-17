using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public class MySQLgenie
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;User ID=root;password=secret;Database=dfeidata");
        MySqlDataAdapter adp;
        MySqlDataReader rdr;


        /** Subject ****************************************************************************/
        public Subject InsertSubject(string name, Boolean higher)
        {
            var subject = new Subject();
            subject.SubjectName = name;
            subject.SubjectHigher = higher;
            if (name != "*empty")
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "INSERT INTO subject (subject_name, subject_higher) VALUES(@NAME, @HIGHER)";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@HIGHER", higher);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }
            }
            return subject;
        }

        public Subject UpdateSubject(int id, string name, Boolean higher)
        {
            var subject = new Subject();
            subject.SubjectId = id;
            subject.SubjectName = name;
            subject.SubjectHigher = higher;
            if(id != 0 && name != "*empty")
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "UPDATE subject SET subject_name= @NAME, subject_higher= @HIGHER WHERE subject_id= @ID";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@HIGHER", higher);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }
            }
            return subject;
        }

        public Subject DeleteSubject(int id=0)
        {
            var subject = new Subject();
            if (id != 0)
            {
                cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "SELECT * FROM subject WHERE subject_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        subject.SubjectId = rdr.GetInt32(0);
                        subject.SubjectName = rdr.GetString(1);
                        subject.SubjectHigher = rdr.GetBoolean(2); ;
                    }
                    con.Close();

                    con.Open();
                    cmd.CommandText = "DELETE FROM subject WHERE subject_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }
            }
            else
            {
                subject = new Subject() { SubjectId = 0, SubjectName = "Please fill in the editor fields" };
            }
            return subject;
        }

        public List<Subject> ListSubjects()
        {
            var allSubjects = new List<Subject>();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM subject";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Subject subject = new Subject();
                    subject.SubjectId = rdr.GetInt32(0);
                    subject.SubjectName = rdr.GetString(1);
                    subject.SubjectHigher = rdr.GetBoolean(2);
                    allSubjects.Add(subject);
                }
                con.Close();
            }
            catch (MySqlException e)
            {
                Subject subject = new Subject();
                subject.SubjectName = e.ToString();
                allSubjects.Add(subject);
            }

            return allSubjects;
        }

        /** Teacher ****************************************************************************/
        public Teacher InsertTeacher(string fname, string lname)
        {
            var teacher = new Teacher();
            teacher.FName = fname;
            teacher.LName = lname;
            if (lname != "*empty")
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "INSERT INTO teacher (teacher_fname, teacher_lname) VALUES(@FNAME, @LNAME)";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();
                    con.Close();
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
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "UPDATE teacher SET teacher_fname= @FNAME, teacher_lname= @LNAME WHERE teacher_id= @ID";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
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
                cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "SELECT * FROM teacher WHERE teacher_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher.TeacherId = rdr.GetInt32(0);
                        teacher.FName = rdr.GetString(1);
                        teacher.LName = rdr.GetString(2); ;
                    }
                    con.Close();

                    con.Open();
                    cmd.CommandText = "DELETE FROM teacher WHERE teacher_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
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


        public List<Teacher> ListTeachers()
        {
            var allTeachers = new List<Teacher>();
            cmd = new MySqlCommand();
            try
            {
                cmd.Connection = con;
                con.Open();
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
                con.Close();
            }
            catch (MySqlException e)
            {
                Teacher teacher = new Teacher();
                teacher.FName = e.ToString();
                allTeachers.Add(teacher);
            }

            return allTeachers;
        }

        /** Student ****************************************************************************/
        public Student InsertStudent(string fname, string lname)
        {
            var student = new Student();
            student.FName = fname;
            student.LName = lname;
            if (lname != "*empty")
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "INSERT INTO student (student_fname, student_lname) VALUES(@FNAME, @LNAME)";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();
                    con.Close();
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
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "UPDATE student SET student_fname= @FNAME, student_lname= @LNAME WHERE student_id= @ID";
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
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
                cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "SELECT * FROM student WHERE student_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.StudentId = rdr.GetInt32(0);
                        student.FName = rdr.GetString(1);
                        student.LName = rdr.GetString(2); ;
                    }
                    con.Close();

                    con.Open();
                    cmd.CommandText = "DELETE FROM student WHERE student_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
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


        public List<Student> ListStudents()
        {
            var allStudents = new List<Student>();
            cmd = new MySqlCommand();
            try
            {
                cmd.Connection = con;
                con.Open();
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
                con.Close();
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