using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp_appsuggestor.Controllers
{
    public class ValuesController : ApiController
    {
        string rate = "";
        string name = "";
        string ver = "";
        string lastupdate = "";
        string download = "";
        string size = "";
        string price = "";
        string creator = "";
        string describtion = "";
        string similarapp = "";

            // GET api/values
            public IEnumerable<string> Get()
        {
            return Packagename2OtherAttributes("=com.glu.ewarriors2", "app_by_full_package_name", "@app_full_packagename");
        }

            private IEnumerable<string> Packagename2OtherAttributes(string AppId,string sp_name,string parameter)
            {
                SqlConnection conn = null;
                SqlDataReader rdr = null;

                // typically obtained from user
                // input, but we take a short cut

                conn = new SqlConnection("Server=pc5\\sqlexpress;DataBase=appsugg_db; Integrated Security=SSPI");
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
                    rate = rdr["rate"].ToString();
                    name = rdr["name"].ToString();
                    ver = rdr["ver"].ToString();
                    lastupdate = rdr["lastupdatedatepersian"].ToString();
                    download = rdr["download"].ToString();
                    size = rdr["size"].ToString();
                    price = rdr["price"].ToString();
                    creator = rdr["creator"].ToString();
                    describtion = rdr["describtion"].ToString();
                    similarapp = rdr["similarapp"].ToString();
                }
                return new string[] { rate, name,ver,lastupdate,download,size,price,creator,describtion,similarapp };
            }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        public IEnumerable<string> Get(string AppName)
        {
            return Packagename2OtherAttributes(AppName, "app_by_full_name", "@app_full_name");
        }
        // GET api/values/5
        //public IEnumerable<string> Get(string Appid)
        //{
        //    return Packagename2OtherAttributes("=" + Appid, "app_by_full_package_name", "@app_full_packagename");
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
}