using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public class WorkshopGenie : MySQLgenie
    {
        public WorkshopGenie()
        {
            cmd.Connection = con;
            con.Open();
        }

        ~WorkshopGenie()
        {
            con.Close();
        }

        TeacherGenie teaGenie = new TeacherGenie();
        SubjectGenie subGenie = new SubjectGenie();
        
        public Workshop InsertWorkshop(int subjectId, int year, int teacherId)
        {
            var workshop = new Workshop();
            workshop.Year = year;

            
           // workshop.Instructor = teaGenie.GetTeacher(teacherId);            
           // workshop.Course = subGenie.GetSubject(subjectId);

            if (subjectId != 0 && teacherId != 0)
            {
                try
                {
                    cmd.CommandText = "INSERT INTO workshop (subject_id, year, teacher_id) VALUES(@SUBJECT, @YEAR, @TEACHER)";
                    cmd.Parameters.AddWithValue("@SUBJECT", subjectId);
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TEACHER", teacherId);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    workshop.Instructor.FName = e.ToString();
                }
            }
            return workshop;
        }

        public Workshop UpdateWorkshop(int workshopId, int subjectId, int year, int teacherId)
        {
            var workshop = new Workshop();
            workshop.WorkshopId = workshopId;
            if (workshopId != 0 && subjectId != 0 && year != 0)
            {
                try
                {
                    cmd.CommandText = "UPDATE workshop SET subject_id= @SUBJECTID, year= @YEAR, teacher_id= @TEACHERID WHERE workshop_id= @WORKSHOPID";
                    cmd.Parameters.AddWithValue("@WORKSHOPID", workshopId);
                    cmd.Parameters.AddWithValue("@SUBJECTID", subjectId);
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TEACHERID", teacherId);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    Subject subject = new Subject() { SubjectName = e.ToString() };
                    workshop.Course = subject;
                }
            }
            return workshop;
        }

        public Workshop DeleteWorkshop(int id = 0)
        {
            var workshop = new Workshop();
            if (id != 0)
            {
                try
                {
                    workshop = GetWorkshop(id);
                    cmd.CommandText = "DELETE FROM workshop WHERE worksop_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    Subject subject = new Subject();
                    subject.SubjectName = e.ToString();
                    workshop.Course = subject;
                }
            }
            else
            {
                Teacher teacher = new Teacher() { FName = "Please fill in the editor fields" };
                workshop.Instructor = teacher;
            }
            return workshop;
        }

        public Workshop GetWorkshop(int id)
        {
            var workshop = new Workshop();
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM workshop WHERE workshop_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        workshop.WorkshopId = rdr.GetInt32(0);
                        int subjectId = rdr.GetInt32(1);
                        workshop.Year = rdr.GetInt32(2);
                        int teacherId = rdr.GetInt32(3);
                        workshop.Course = subGenie.GetSubject(subjectId);
                        workshop.Instructor = teaGenie.GetTeacher(teacherId);
                    }
                }
                catch (MySqlException e)
                {
                    Teacher teacher = new Teacher();
                    teacher.FName = e.ToString();
                    workshop.Instructor = teacher;
                }
            }
            return workshop;
        }

        public List<Workshop> ListWorkshops()
        {
            var allWorkshops = new List<Workshop>();
            try
            {
                cmd.CommandText = "SELECT * FROM workshop";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Workshop workshop = new Workshop();
                    workshop.WorkshopId = rdr.GetInt32(0);
                    int subjectId = rdr.GetInt32(1);
                    workshop.Year = rdr.GetInt32(2);
                    int teacherId = rdr.GetInt32(3);
                    workshop.Instructor = teaGenie.GetTeacher(teacherId);
                    workshop.Course = subGenie.GetSubject(subjectId);
                    /**
                        cmd2.CommandText = "SELECT * FROM workshop_students WHERE workshop_id = " + workshop.WorkshopId;
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            Student student = new Student();
                            student.StudentId = rdr2.GetInt32(0);
                            student.FName = rdr2.GetString(1);
                            student.LName = rdr2.GetString(2);
                            workshop.Students.Add(student);
                        }
                **/
                    allWorkshops.Add(workshop);
                }
            }
            catch (MySqlException e)
            {
                Subject subject = new Subject();
                subject.SubjectName = e.ToString();
                Workshop workshop = new Workshop();
                workshop.Course = subject;
                allWorkshops.Add(workshop);
            }

            return allWorkshops;
        }

        /** Workshop-Students **************************************************************************
        public Workshop InsertWorkshopStudent(int workshopId, int studentId)
        {
            var workshop = new Workshop();
            workshop.Year = year;
            workshop.Instructor = GetTeacher(teacherId);
            workshop.Course = GetSubject(subjectId);

            if (subjectId != 0 && teacherId != 0)
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "INSERT INTO workshop (subject_id, year, teacher_id) VALUES(@SUBJECT, @YEAR, @TEACHER)";
                    cmd.Parameters.AddWithValue("@SUBJECT", subjectId);
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@Teacher", teacherId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    workshop.Instructor.FName = e.ToString();
                }
            }
            return workshop;
        }
    **/

    }
}