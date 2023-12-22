using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLScriptExecutor.Classes
{
    [Serializable]
    public class ConnectionItem
    {
        private string alias;
        private string server;
        private string database;
        private string user;
        private string password;

        public string Alias 
        { 
            get => alias; 
            set => alias = value; 
        }
        public string Server 
        { 
            get => server; 
            set => server = value; 
        }
        public string Database 
        { 
            get => database; 
            set => database = value; 
        }
        public string User 
        { 
            get => user; 
            set => user = value; 
        }
        public string Password 
        { 
            get => password; 
            set => password = value; 
        }
        public ConnectionItem()
        {

        }
    }
}
