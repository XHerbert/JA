using System.Collections.Generic;
using JA.Core.Const;
using JA.Core.Enums;
using JA.Core.ManageUser;
using JA.Core.UserManager;

namespace JA.Core.Infrastructure
{
    public static class DictionaryHandler
    {
        /*2020.05.01增加根据用户信息加载字典数据源sql*/

        /// <summary>
        /// 获取自定义数据源sql
        /// </summary>
        /// <param name="dicNo"></param>
        /// <param name="originalSql"></param>
        /// <returns></returns>
        public static string GetCustomDBSql(string dicNo, string originalSql)
        {
            switch (dicNo)
            {
                case DictionaryKey.roles:
                    originalSql = GetRolesSql(originalSql);
                    break;
                //2020.05.24增加绑定table表时，获取所有的角色列表
                //注意，如果是2020.05.24之前获取的数据库脚本
                //请在菜单【下拉框绑定设置】添加一个字典编号【t_roles】,除了字典编号，其他内容随便填写
                case DictionaryKey.tRoles:
                    originalSql = GetRolesSql();
                    break;
                case DictionaryKey.HouseCanRent:
                    originalSql = GetHousesSql(originalSql);
                    break;
                default:
                    break;
            }
            return originalSql;
        }
        /// <summary>
        /// 2020.05.24增加绑定table表时，获取所有的角色列表
        /// </summary>
        /// <param name="context"></param>
        /// <param name="originalSql"></param>
        /// <returns></returns>
        public static string GetRolesSql()
        {
            if (DBType.Name == DbCurrentType.PgSql.ToString())
            {
                return "SELECT \"Role_Id\" as key,\"RoleName\" as value from Sys_Role";
            }
            return $@"SELECT Role_Id as 'key',RoleName as 'value' FROM Sys_Role 
                           WHERE Enable=1 ";
        }

        /// <summary>
        /// 获取解决的数据源，只能看到自己与下级所有角色
        /// </summary>
        /// <param name="context"></param>
        /// <param name="originalSql"></param>
        /// <returns></returns>
        public static string GetRolesSql(string originalSql)
        {
            if (UserContext.Current.IsSuperAdmin)
            {
                return originalSql;
            }
            int currnetRoleId = UserContext.Current.RoleId;
            List<int> roleIds = RoleContext.GetAllChildrenIds(currnetRoleId);
            roleIds.Add(currnetRoleId);
            string sql = $@"SELECT Role_Id as 'key',RoleName as 'value' FROM Sys_Role 
                           WHERE Enable=1  and Role_Id in ({string.Join(',', roleIds)})";
            return sql;
        }

        /// <summary>
        /// 根据角色获取房屋列表
        /// </summary>
        /// <param name="originalSql"></param>
        /// <returns></returns>
        public static string GetHousesSql(string originalSql)
        {
            if (UserContext.Current.IsSuperAdmin)
            {
                return originalSql;
            }
            //根据角色显示房屋信息
            int role = UserContext.Current.RoleId;
            string sql = string.Empty;
            int belongUnit = -1;
            switch (role)
            {
                case 5:
                case 7:
                    belongUnit = 1;
                    break;
                case 8:
                case 11:
                    belongUnit = 2;
                    break;
                case 9:
                case 12:
                    belongUnit = 3;
                    break;
                case 10:
                case 13:
                    belongUnit = 4;
                    break;
                default:
                    break;
            }

            sql = $"select Id as `key`,HouseCode as `value` from house where enableflag = 1 and housestatus = 1 and belongunit = {belongUnit}";
            return sql;
        }
    }

    public class DictionaryKey
    {
        public const string roles = "roles";
        public const string tRoles = "t_roles";
        public const string Tenants = "Tenants";
        public const string HouseCanRent = "HouseCanRent";
    }
}
