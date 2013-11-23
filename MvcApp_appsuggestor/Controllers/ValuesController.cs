using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApp_appsug.Controllers
{
    public class application
    {
        public string rate  { get; set; }
        public string name  { get; set; }
        public string ver  { get; set; }
        public string lastupdate  { get; set; }
        public string download   { get; set; }
        public string size  { get; set; }
        public string price  { get; set; }
        public string creator  { get; set; }
        public string describtion { get; set; }
        public string similarapp { get; set; }
    }


    public class AppdetailController : ApiController
    {
        application app = new application();

        // GET api/values
        public application Get(string id, int id2)
        {
            if (id != "")
                if (id2 == 1)
                    return Packagename2OtherAttributes(id, "app_by_full_package_name", "@app_full_packagename");
                else
                    return Packagename2OtherAttributes(id, "app_by_full_name", "@app_full_name");
            else
                return Packagename2OtherAttributes("=com.glu.ewarriors2", "app_by_full_package_name", "@app_full_packagename");
        }


        private application Packagename2OtherAttributes(string AppId, string sp_name, string parameter)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut

            //conn = new SqlConnection("Server=pc5\\sqlexpress;DataBase=appsugg_db; Integrated Security=SSPI");
            //Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AddressBook.mdf;Integrated Security=True;User Instance=True
            //کانکشن به سرور خوش گفتار
            //conn = new SqlConnection("Data Source=khoshgoftar-pc\\reza;initial catalog=MvcWebApp_appsug_db; user id=saber;password=1234567aA");
            conn = new SqlConnection("Data Source=81.17.18.82\\SQLEXPRESS;initial catalog=asanhost_learnkey; user id=learnkeyusr;password=63Vg*)k73D");
            //conn = new SqlConnection("Data Source=.\\SQL;Initial Catalog=app_sugg_db;user id=sa;password=1234567aA");

            //                conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\MvcWebApp_appsug_db.mdf;User Instance=True");
            //conn.Open();
            conn.Open();

            // 1.  create a command object identifying
            //     the stored procedure
            SqlCommand cmd = new SqlCommand(
                sp_name, conn);

            // 2. set the command object so it knows
            //    to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which
            //    will be passed to the stored procedure
            cmd.Parameters.Add(
                new SqlParameter(parameter, AppId));

            // execute the command
            rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            if (rdr.Read())
            {
                //Console.WriteLine(
                //    "Product: {0,-35} Total: {1,2}",

                //app.app.rate=
                app.rate = rdr["rate"].ToString();
                app.name = rdr["name"].ToString();
                app.ver = rdr["ver"].ToString();
                app.lastupdate = rdr["lastupdatedatepersian"].ToString();
                app.download = rdr["download"].ToString();
                app.size = rdr["size"].ToString();
                app.price = rdr["price"].ToString();
                app.creator = rdr["creator"].ToString();
                app.describtion = rdr["describtion"].ToString();
                app.similarapp = rdr["similarapp"].ToString();
            }
//            return new string[] { rate, name, ver, lastupdate, download, size, price, creator, describtion, similarapp };
            return app;
        }



        // GET api/values
        public IEnumerable<string> Get()
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=biztalk\\SQLEXPRESS;Initial Catalog=appsugg_db;Integrated Security=True; MultipleActiveResultSets=True");
            //MvcWebApp_appsug.Models.AppDBContext();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class SetUserIDbyDeviceIDController : ApiController
    {

        userdevice userdev = new userdevice();



        // GET esl/values
        public userdevice Get(string id, string id2,string id3)
        {
            if (id != "" & id2 != "" & id3 != "")
                    return esl_set_userid_by_deviceid(id,id2,id3, "esl_set_userid_by_deviceid", "@esl_user_id","@esl_device_id","@esl_mobile_number");
            else
                 return userdev;
            //    return Packagename2OtherAttributes("=com.glu.ewarriors2", "app_by_full_package_name", "@app_full_packagename");
        }


        private userdevice esl_set_userid_by_deviceid(string UserId, string DeviceId,string mobilenumber, string sp_name, string esl_user_id, string esl_device_id,string esl_mobile_number)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut

            //conn = new SqlConnection("Server=pc5\\sqlexpress;DataBase=appsugg_db; Integrated Security=SSPI");
            //Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AddressBook.mdf;Integrated Security=True;User Instance=True
            //کانکشن به سرور خوش گفتار
            //conn = new SqlConnection("Data Source=khoshgoftar-pc\\reza;initial catalog=MvcWebApp_appsug_db; user id=saber;password=1234567aA");
            conn = new SqlConnection("Data Source=81.17.18.82\\SQLEXPRESS;initial catalog=asanhost_learnkey; user id=learnkeyusr;password=63Vg*)k73D");
            //conn = new SqlConnection("Data Source=.\\SQL;Initial Catalog=app_sugg_db;user id=sa;password=1234567aA");

            //                conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\MvcWebApp_appsug_db.mdf;User Instance=True");
            //conn.Open();
            conn.Open();

            // 1.  create a command object identifying
            //     the stored procedure
            SqlCommand cmd = new SqlCommand(
                sp_name, conn);

            // 2. set the command object so it knows
            //    to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which
            //    will be passed to the stored procedure
            cmd.Parameters.Add(
                new SqlParameter(esl_user_id, UserId));

            cmd.Parameters.Add(
                new SqlParameter(esl_device_id, DeviceId));

            cmd.Parameters.Add(
                new SqlParameter(esl_mobile_number, mobilenumber));
            try
            {
                            // execute the command
            rdr = cmd.ExecuteReader();

            return userdev;
            }
            catch (Exception e_esl_register_deviceid_by_userid)
            {
                userdev.error = "error " + e_esl_register_deviceid_by_userid.Message.ToString();

            return userdev;

                throw;
            }

        }


        // GET esl/values
        public IEnumerable<string> Get()
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=biztalk\\SQLEXPRESS;Initial Catalog=appsugg_db;Integrated Security=True; MultipleActiveResultSets=True");
            //MvcWebApp_appsug.Models.AppDBContext();
            return new string[] { "value1", "value2" };
        }

        // GET esl/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST esl/values
        public void Post([FromBody]string value)
        {
        }

        // PUT esl/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE esl/values/5
        public void Delete(int id)
        {
        }
    }

    public class userdevice {
        public string userid { get; set; }
        public string deviceid { get; set; }
        public string mobilenumber { get; set; }
        public string modifydatetime { get; set; }
        public string error { get; set; }
    }

    public class getmobilenumberbyUseridDeviceIDController : ApiController
    {
            userdevice userdev = new userdevice( );

        



        // GET esl/values
        public userdevice Get(string id, string id2)
        {

            if (id != "" & id2 != "")
                return esl_get_last_userid_by_deviceid(id, id2, "esl_get_last_userid_by_deviceid", "@esl_user_id", "@esl_device_id");
            else
                return userdev;
            //    return Packagename2OtherAttributes("=com.glu.ewarriors2", "app_by_full_package_name", "@app_full_packagename");
        }


        private userdevice esl_get_last_userid_by_deviceid(string UserId, string DeviceId, string sp_name, string esl_user_id, string esl_device_id)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut

            //conn = new SqlConnection("Server=pc5\\sqlexpress;DataBase=appsugg_db; Integrated Security=SSPI");
            //Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AddressBook.mdf;Integrated Security=True;User Instance=True
            //کانکشن به سرور خوش گفتار
            //conn = new SqlConnection("Data Source=khoshgoftar-pc\\reza;initial catalog=MvcWebApp_appsug_db; user id=saber;password=1234567aA");
            conn = new SqlConnection("Data Source=81.17.18.82\\SQLEXPRESS;initial catalog=asanhost_learnkey; user id=learnkeyusr;password=63Vg*)k73D");
            //conn = new SqlConnection("Data Source=.\\SQL;Initial Catalog=app_sugg_db;user id=sa;password=1234567aA");

            //                conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\MvcWebApp_appsug_db.mdf;User Instance=True");
            //conn.Open();
            conn.Open();

            // 1.  create a command object identifying
            //     the stored procedure
            SqlCommand cmd = new SqlCommand(
                sp_name, conn);

            // 2. set the command object so it knows
            //    to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which
            //    will be passed to the stored procedure
            cmd.Parameters.Add(
                new SqlParameter(esl_user_id, UserId));

            cmd.Parameters.Add(
                new SqlParameter(esl_device_id, DeviceId));
            try
            {
                // execute the command
                rdr = cmd.ExecuteReader();

                if (rdr.Read()) 
                {

                    userdev.mobilenumber = rdr["mobilenumber"].ToString();
                    userdev.modifydatetime = rdr["modifyDateTime"].ToString();
                }
                return userdev ;
            }
            catch (Exception e_esl_get_mobilenumber_deviceid_by_userid)
            {
                userdev.error = "error"+ e_esl_get_mobilenumber_deviceid_by_userid.ToString();
                return userdev ;

                throw;
            }

        }



        // GET esl/values
        public IEnumerable<string> Get()
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=biztalk\\SQLEXPRESS;Initial Catalog=appsugg_db;Integrated Security=True; MultipleActiveResultSets=True");
            //MvcWebApp_appsug.Models.AppDBContext();
            return new string[] { "value1", "value2" };
        }

        // GET esl/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST esl/values
        public void Post([FromBody]string value)
        {
        }

        // PUT esl/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE esl/values/5
        public void Delete(int id)
        {
        }



    }



    public class Employee
    {
        public string Name { get; set; }
        public Department Department { get; set; }
    }

    public class Department
    {
        public string Name { get; set; }
        public Employee Manager { get; set; }
    }

    public class DepartmentsController : ApiController
    {
        public Department Get(int id)
        {
            Department sales = new Department() { Name = "Sales" };
            Employee alice = new Employee() { Name = "Alice", Department = sales };
            sales.Manager = alice;
            return sales;
        }
    }
}