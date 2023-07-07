using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest_Aha_UI.LoginHelper
{
    public class SessionManager
    {
        private static SessionManager instance;
        private string username;
        private string password;

        private SessionManager() { }

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                }
                return instance;
            }
        }

        public void SetCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
