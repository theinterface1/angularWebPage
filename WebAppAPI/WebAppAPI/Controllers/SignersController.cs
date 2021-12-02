using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppAPI.Models;

namespace WebAppAPI.Controllers
{
    public class SignersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            String query = @"SELECT * From dbo.Signer";
            DataTable table = ExecuteQuery(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public String Post(Signers signer)
        {
            try
            {
                String query = @"INSERT INTO dbo.Signer (FirstName, LastName, Tel, Email)
                            VALUES ('" + signer.FirstName + @"','" + signer.LastName + @"', '" + signer.Tel + @"', '" + signer.Email + @"')";

                ExecuteQuery(query);
                return "Successfully added";
            }
            catch
            {
                return "Failed to add";
            }
        }
        public String Put(Signers signer)
        {
            try
            {
                String query = @"UPDATE dbo.Signer SET 
                            FirstName= '" + signer.FirstName + @"', 
                            LastName= '" + signer.LastName + @"', 
                            tel = '" + signer.Tel + @"', 
                            email= '" + signer.Email + @"'
                            WHERE SignerID = " + signer.SignerID + @"";

                ExecuteQuery(query);
                return "Successfully updated";
            }
            catch
            {
                return "Failed to update";
            }
        }
        public String Delete(int id)
        {
            try
            {
                String query = @"DELETE from dbo.Signer 
                            WHERE SignerID = " + id + @"";

                ExecuteQuery(query);
                return "Successfully deleted";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public DataTable ExecuteQuery(String query)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["WebAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return table;
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
    }
}
