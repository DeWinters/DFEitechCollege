using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public class EnrollGenie : MySQLgenie
    {
        public EnrollGenie()
        {
            cmd.Connection = con;
        }

        ~EnrollGenie()
        {
            con.Close();
        }

        /** Workshop-Students **************************************************************************/
        public void InsertWorkshopStudent(int workshopId, int studentId)
        {
            if (workshopId != 0 && studentId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO workshop_students (workshop_id, student_id) VALUES(@WORKSHOP, @STUDENT)";
                    cmd.Parameters.AddWithValue("@WORKSHOP", workshopId);
                    cmd.Parameters.AddWithValue("@STUDENT", studentId);
                    cmd.ExecuteNonQuery();
                    //workshop = genie.GetWorkshop(workshopId);
                }
                catch (MySqlException e)
                {
                    // lacking feedback point for this error
                }
                finally
                {
                    con.Close();
                }
            }
        }


        public List<Student> GetWorkshopStudents(int workshopId)
        {
            List<Student> workshopStudents = new List<Student>();
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM workshop_students WHERE workshop_id =" + workshopId; // @WORKSHOPED";
                //cmd.Parameters.AddWithValue("@WORKSHOPED", workshopId);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student();
                    student.StudentId = rdr.GetInt32(2);

                    workshopStudents.Add(student);
                }                
            }
            catch (MySqlException e)
            {
                Student student = new Student() { FName = e.ToString() };
                workshopStudents.Add(student);
            }
            finally
            {
                con.Close();
            }
            return workshopStudents;
        }
    }
}