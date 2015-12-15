using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPY.DISMetroUIPortal.Web
{
    using System;
    using System.Data.SqlClient;

    public class DISMetroUIPortalWindowsAbpSession : Abp.Runtime.Session.ClaimsAbpSession
    {
        public DISMetroUIPortalWindowsAbpSession(Abp.Configuration.Startup.IMultiTenancyConfig multiTenancy) : base(multiTenancy)
        {
        }

        protected object ExecuteScalar(SqlCommand command)
        {
            object obj2;
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                using (command)
                {
                    obj2 = command.ExecuteScalar();
                }
                connection.Close();
            }
            return obj2;
        }

        public override long? UserId
        {
            get
            {
                var claimsPrincipal = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
                if (claimsPrincipal == null)
                {
                    return null;
                }

                var claimsIdentity = claimsPrincipal.Identity as System.Security.Principal.WindowsIdentity;
                if (claimsIdentity == null)
                {
                    return base.UserId;
                }

                if (claimsIdentity.Name == "")
                {
                    return null;
                }

                SqlCommand command = new SqlCommand("SELECT Id from AbpUsers where UserName = @UserName AND IsDeleted = 0; SELECT SCOPE_IDENTITY();");
                SqlParameter parmaeter = new SqlParameter { DbType = System.Data.DbType.String, ParameterName = "@UserName", Value = claimsIdentity.Name };
                command.Parameters.Add(parmaeter);
                var vyseldek = Convert.ToInt32(ExecuteScalar(command));

                return vyseldek;
            }
        }
    }
}