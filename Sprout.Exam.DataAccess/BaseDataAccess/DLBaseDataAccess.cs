using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprout.Exam.DataAccess.BaseDataAccess
{
    public abstract class DLBaseDataAccess
    {

        private string connectionString;
        public IConfiguration Configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json").Build();
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public DLBaseDataAccess()
        {
            connectionString = Configuration["ConnectionStrings:DefaultConnection"].ToString();
        }
    }
}
