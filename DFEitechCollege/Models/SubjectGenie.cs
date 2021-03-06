﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public class SubjectGenie : MySQLgenie
    {
        public SubjectGenie()
        {
            cmd.Connection = con;
        }

        ~SubjectGenie()
        {
            con.Close();
        }

        public Subject InsertSubject(string name, Boolean higher)
        {
            var subject = new Subject();
            subject.SubjectName = name;
            subject.SubjectHigher = higher;
            if (name != "*empty")
            {

                try
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO subject (subject_name, subject_higher) VALUES(@NAME, @HIGHER)";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@HIGHER", higher);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }finally
                {
                    con.Close();
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
            if (id != 0 && name != "*empty")
            {
                try
                {
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
                finally
                {
                    con.Close();
                }
            }
            return subject;
        }

        public Subject DeleteSubject(int id = 0)
        {
            var subject = new Subject();
            if (id != 0)
            {
                try
                {
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
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }finally
                {
                    con.Close();
                }
            }
            else
            {
                subject = new Subject() { SubjectId = 0, SubjectName = "Please fill in the editor fields" };
            }
            return subject;
        }

        public Subject GetSubject(int id)
        {
            var subject = new Subject();
            if (id != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM subject WHERE subject_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        subject.SubjectId = rdr.GetInt32(0);
                        subject.SubjectName = rdr.GetString(1);
                        subject.SubjectHigher = rdr.GetBoolean(2); ;
                    }
                }
                catch (MySqlException e)
                {
                    subject.SubjectName = e.ToString();
                }finally
                {
                    con.Close();
                }
            }
            
            return subject;
        }

        public List<Subject> ListSubjects()
        {
            var allSubjects = new List<Subject>();
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
            }
            catch (MySqlException e)
            {
                Subject subject = new Subject();
                subject.SubjectName = e.ToString();
                allSubjects.Add(subject);
            }
            finally
            {
                con.Close();
            }

            return allSubjects;
        }

    }
}