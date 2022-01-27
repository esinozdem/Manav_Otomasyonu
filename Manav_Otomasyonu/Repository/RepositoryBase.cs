using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Repository
{
   public abstract class RepositoryBase
    {
        //Sql bağlantı kısmını standartlaştırıyoruz.
        SqlConnection connection = null;
        public RepositoryBase()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        }
        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
