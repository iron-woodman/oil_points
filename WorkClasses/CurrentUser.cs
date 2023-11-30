using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oil_points.WorkClasses
{
    /// <summary>
    /// учетная запись текущего пользователя
    /// </summary>
    static class CurrentUser
    {
        /// <summary>
        /// Тип учетной записи
        /// </summary>
        public static UserRole Role { get; private set; }


        private static string login;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public static string Login 
        {
            get
            {
                return login;
            }
            set 
            {
                if (value == "Admin")
                {
                    Role = UserRole.ADMIN;
                }
                else
                {
                    Role = UserRole.USER;
                }
                login = value;
            } 
        }
    }

    /// <summary>
    /// Типы учетных записей пользователя
    /// </summary>
    public enum UserRole { ADMIN, USER};
}
