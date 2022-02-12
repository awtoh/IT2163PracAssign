using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace IT2163PracAssign
{
    public partial class _Registration : System.Web.UI.Page
    {

        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MYDBConnection"].ConnectionString;
        static string ccFinalHash;
        static string pwdFinalHash;
        static string salt;
        byte[] Key;
        byte[] IV;

        static string line = "\r";

        //static string isDebug = ConfigurationManager.AppSettings["isDebug"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string cc = tb_cc.Text.ToString().Trim(); ;
            string pwd = tb_pwd.Text.ToString().Trim(); ;

            //Generate random "salt" 
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];

            //Fills array of bytes with a cryptographically strong sequence of random values.
            rng.GetBytes(saltByte);
            salt = Convert.ToBase64String(saltByte);

            SHA512Managed hashing = new SHA512Managed();

            string ccWithSalt = cc + salt;
            byte[] ccPlainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(cc));
            byte[] ccHashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(ccWithSalt));

            string pwdWithSalt = pwd + salt;
            byte[] pwdPlainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            byte[] pwdHashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            ccFinalHash = Convert.ToBase64String(ccHashWithSalt);
            pwdFinalHash = Convert.ToBase64String(pwdHashWithSalt);

            lb_error1.Text = "Credit Card Salt:" + salt;
            lb_error2.Text = "Credit Card Hash with salt:" + ccFinalHash;
            lb_error3.Text = "Password Salt:" + salt;
            lb_error4.Text = "Password Hash with salt:" + pwdFinalHash;

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateKey();
            Key = cipher.Key;
            IV = cipher.IV;


            createAccount();
        }


        protected void createAccount()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Account VALUES(@FirstName,@LastName,@CreditCard,@Email,@Password,@DateOfBirth,@Photo,@CreditCardHash,@PasswordHash,@Salt,@DateTimeRegistered,@IV,@Key)"))
                    //using (SqlCommand cmd = new SqlCommand("INSERT INTO Account VALUES(@FirstName,@LastName,@CreditCard,@Email,@Password,@DateOfBirth,@Photo,@CreditCardHash,@PasswordHash,@Salt,@DateTimeRegistered,@IV,@Key)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@FirstName", tb_fn.Text.Trim());
                            cmd.Parameters.AddWithValue("@LastName", tb_ln.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreditCard", Convert.ToBase64String(encryptData(tb_cc.Text.Trim())));
                            cmd.Parameters.AddWithValue("@Email", tb_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", Convert.ToBase64String(encryptData(tb_pwd.Text.Trim())));
                            cmd.Parameters.AddWithValue("@DateOfBirth", tb_dob.Text.Trim());
                            cmd.Parameters.AddWithValue("@Photo", tb_photo.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreditCardHash", ccFinalHash);
                            cmd.Parameters.AddWithValue("@PasswordHash", pwdFinalHash);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@DateTimeRegistered", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IV", Convert.ToBase64String(IV));
                            cmd.Parameters.AddWithValue("@Key", Convert.ToBase64String(Key));
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected byte[] encryptData(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                cipher.Key = Key;
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                //ICryptoTransform decryptTransform = cipher.CreateDecryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);


                //Encrypt
                //cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
                //cipherString = Convert.ToBase64String(cipherText);
                //Console.WriteLine("Encrypted Text: " + cipherString);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            finally { }
            return cipherText;
        }


    }
}
