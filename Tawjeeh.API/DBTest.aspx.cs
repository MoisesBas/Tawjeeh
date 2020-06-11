using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPI
{
    public partial class DBTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
            {
                DBConnectionStatus();
                
            }
        }

        private bool DBConnectionStatus()
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection sqlConn =
                    new System.Data.SqlClient.SqlConnection("Data Source=188.121.44.217;Initial Catalog=tawdeef_;Integrated Security=False;User ID=tawdeef;Password=tawdeef@123;Connect Timeout=15;Encrypt=False;"))
                {
                    sqlConn.Open();
                    return (sqlConn.State == System.Data.ConnectionState.Open);
                }
            }
            catch (System.Data.SqlClient.SqlException sqlexception)
            {

                Response.Write(sqlexception.ToString());
                Response.End();
                return false;
            }
            catch (Exception e)
            {
                Response.Write(e.ToString());
                Response.End();
                return false;
            }
        }
    }
}