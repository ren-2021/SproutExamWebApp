using Sprout.Exam.DataAccess.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.DataAccess
{
    public abstract class BaseDataAccess
    {
        public IDLEmployee DLEmployee
        {
            get
            {
                return dlEmployee;
            }
        }
        private IDataAccess dataAccess { get; set; }
        private IDLEmployee dlEmployee;

        public BaseDataAccess(IDataAccess pDataAccess, IDataAccessFactory dataFactory)
        {
            dataAccess = pDataAccess;
            dataFactory = new DataAccessFactory(dataAccess);
            dlEmployee = dataFactory.GetDL<IDLEmployee>();
        }
    }
}
