using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Models
{
    public abstract class MySQLgenie
    {
        protected MySqlCommand cmd = new MySqlCommand();
        protected MySqlConnection con = new MySqlConnection(@"server=testmysqlinst.corprrs97lob.eu-west-1.rds.amazonaws.com;port=3306;User ID=root;password=gyrfalcon5151;Database=eamotest");
        protected MySqlDataReader rdr;        
    }
}