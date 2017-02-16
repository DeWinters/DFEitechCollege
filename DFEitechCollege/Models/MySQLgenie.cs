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
    }
}