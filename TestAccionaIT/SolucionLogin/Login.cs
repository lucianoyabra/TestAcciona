using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccionaIT
{
    public class Login
    {
        public Usuario userLogin = new Usuario();
        //private JavaScriptSerializer serializer = new JavaScriptSerializer();
        private string loginResponse = "";

        public string LoguearUsuer(string usuario, string password)
        {
            try
            {
                loginResponse = userLogin.ValidarUserLogin(usuario, password);
            }
            catch (Exception ex)
            {
                loginResponse = "{" + '"' + "Error" + '"' + ":" + '"' + "Hubo un error en el sistema, contactar al administrador" + '"' + "}";
            }
            finally
            {
                if (loginResponse == "")
                {
                    loginResponse = "{" + '"' + "Error" + '"' + ":" + '"' + "Hubo un error en el sistema, contactar al administrador" + '"' + "}";
                }

            }
            return loginResponse;
        }
    }
}
