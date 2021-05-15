using Infrastructure.Data.IDBAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utility
{
    public static class ComObject
    {
        public static bool Open(ISageAccess sageAccess)
        {
            try
            {
                sageAccess.GetSageDatabase.CompanyServer = sageAccess.GetDatabaseInstance;
                sageAccess.GetSageDatabase.CompanyDatabaseName = sageAccess.GetDatabaseName;
                sageAccess.GetSageDatabase.Loggable.UserName = sageAccess.GetUsername;
                sageAccess.GetSageDatabase.Loggable.UserPwd = sageAccess.GetUserPwd;
                sageAccess.GetSageDatabase.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Close(ISageAccess sageAccess)
        {
            try
            {
                if (sageAccess.GetSageDatabase.IsOpen)
                {
                    sageAccess.GetSageDatabase.Close();
                }
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
