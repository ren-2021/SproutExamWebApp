using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.DataAccess
{
    public class DataAccessFactory: IDataAccessFactory
    {
        public IDataAccess DataAccess { get; set; }
        public DataAccessFactory(IDataAccess pDataAccess)
        {
            DataAccess = pDataAccess;
        }

        public T GetDL<T>()
        {
            T Value = default;

            try
            {
                Type tDL = DataAccess.GetType();
                Type[] ArrInterfaces = tDL.GetInterfaces();

                foreach (Type iT in ArrInterfaces)
                {
                    if (iT.Name == typeof(T).Name)
                    {
                        Value = (T)DataAccess;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Value;
        }
    }
}
