using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.DataAccess
{
    public interface IDataAccessFactory
    {
        IDataAccess DataAccess { get; set; }

        T GetDL<T>();
    }
}
