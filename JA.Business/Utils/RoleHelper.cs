using System;
using System.Collections.Generic;
using System.Text;

namespace JA.Business.Utils
{
    public class RoleHelper
    {
        /// <summary>
        /// 根据角色获取对应单位
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static int GetBelongUnitByUserRole(int role)
        {
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
            return belongUnit;
        }
    }
}
