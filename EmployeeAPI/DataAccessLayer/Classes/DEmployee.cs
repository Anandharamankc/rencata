using DataAccessLayer.Interfaces;
using DBLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Classes
{
    public class DEmployee: IDEmployee
    {

        #region Declaration

        DBCon objDBCon = new DBCon();
        DataTable objDataTable;
        DBCon objDBLibrary;
        SqlParameter[] objSqlParameter;

        #endregion

        #region Employee_details
        public DataTable Employee_details(ClsEmployee ObjClsEmployee)
        {
            DataTable objDataTable = new DataTable();

            try
            {
                DataSet objDataset;

                objDBLibrary = new DBCon();

                objDBLibrary._stringCommandText = "sp_employee_master";
                objDBLibrary._CommandType = CommandType.StoredProcedure;

                objSqlParameter = new SqlParameter[9];

                objSqlParameter[0] = new SqlParameter("@employee_id", SqlDbType.Int);
                objSqlParameter[0].Value = ObjClsEmployee.employee_id;

                objSqlParameter[1] = new SqlParameter("@employee_name", SqlDbType.VarChar, 50);
                objSqlParameter[1].Value = ObjClsEmployee.employee_name;

                objSqlParameter[2] = new SqlParameter("@father_name", SqlDbType.VarChar, 50);
                objSqlParameter[2].Value = ObjClsEmployee.father_name;

                objSqlParameter[3] = new SqlParameter("@mother_name", SqlDbType.VarChar, 50);
                objSqlParameter[3].Value = ObjClsEmployee.mother_name;

                objSqlParameter[4] = new SqlParameter("@DOB", SqlDbType.Date);
                objSqlParameter[4].Value = ObjClsEmployee.DOB;

                objSqlParameter[5] = new SqlParameter("@gender", SqlDbType.Int);
                objSqlParameter[5].Value = ObjClsEmployee.gender;

                objSqlParameter[6] = new SqlParameter("@marital_status", SqlDbType.Int);
                objSqlParameter[6].Value = ObjClsEmployee.marital_status;

                objSqlParameter[7] = new SqlParameter("@Address", SqlDbType.VarChar, 2000);
                objSqlParameter[7].Value = ObjClsEmployee.Address;

                objSqlParameter[8] = new SqlParameter("@Dml_Indicator", SqlDbType.VarChar, 10);
                objSqlParameter[8].Value = ObjClsEmployee.Dml_Indicator;


                objDataset = objDBLibrary.GetDataAdapter(objSqlParameter);

                if (objDataset != null && objDataset.Tables[0].Rows.Count > 0)
                {
                    return objDataset.Tables[0];
                }

            }
            catch (Exception objException)
            {
                Exception objErr = objException.GetBaseException();
            }

            return objDataTable;
        }



       
        #endregion
    }
}
