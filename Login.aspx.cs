using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace IT2163PracAssign
{
    public partial class Login : System.Web.UI.Page
    {
        // Debug and test later
        // string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MYDBConnection"].ConnectionString;
        // static string finalHash;
        // static string salt;
        //byte[] Key;
        // byte[] IV;

        // static string line = "\r";

        //static string isDebug = ConfigurationManager.AppSettings["isDebug"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    protected void LoginMe(object sender, EventArgs e)
    {
        if (tb_fn.Text.Trim().Equals("u") && tb_pwd.Text.Trim().Equals("p"))
        {
            HttpContext.Current.Session["LoggedIn"] = tb_fn.Text.Trim();
            HttpContext.Current.Response.Redirect("HomePage.html", false);
        }
        else
        {
            lblMessage.Text = "Wrong username or password";
        }
    }

    public class MyObject
    {
        public string success { get; set; }
        public List<string> ErrorMessage { get; set; }

    }

    public bool ValidateCaptcha()
    {
        bool result = true;

        string captchaResponse = HttpContext.Current.Response.Form["g-recaptcha-response"];

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            (" https://www.google.com/recaptcha/api/siteverify?secret=6Lf0I3AeAAAAAO3FnKjQhWZSSEf_Oeby5ML4qbyt &response=" + captchaResponse);

        try
        {
            using (WebResponse wResponse = req.GetResponse())
            {
                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    string jsonResponse = readStream.ReadToEnd();

                    lbl_gScore.Text = jsonResponse.ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();

                    MyObject jsonObject = js.Deserialize<MyObject>(jsonResponse);

                    result = Convert.ToBoolean(jsonObject.success);

                }
            }
            return result;
        }
        catch (WebException ex)
        {
            throw ex;
        }

    }
}