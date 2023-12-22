using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLScriptExecutor.Classes
{
    [Serializable]
    public class AppSettings
    {
        private List<ConnectionItem> connectionItems;
        public List<ConnectionItem> ConnectionItems 
        {
            get => connectionItems; 
            set => connectionItems = value; 
        }
        public AppSettings()
        {
            
        }
    }
}
