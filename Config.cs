using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace oil_points

{
    /// <summary>
    /// статический класс конфигурационных параметров приложения
    /// </summary>
    public static class Config
    {
        public static string connectionString
        {
            get {

                try
                    {

                    return ConfigurationManager.AppSettings.Get("conString");
                    //return @"connection timeout=20;Asynchronous Processing=true;MultipleActiveResultSets=true;Data Source=DESKTOP-ATH7E91;database=sts7_test;Integrated Security=true;";
                    //return @"connection timeout=20;Asynchronous Processing=true;MultipleActiveResultSets=true;Data Source=WIN-DJR4IA08G74\STS7;database=sts7_test;User ID=rebus;Password=1;";
                }
                    catch (SystemException ex)
                    {
                        return "";
                    }
                }
        }

        /// <summary>
        /// сохранять входящие файлы в архив
        /// </summary>
        public static bool StoreFilesToArchive
        {
            get;
            set;
        }

        /// <summary>
        /// корневой каталог отчетов
        /// </summary>
        public static string root_in_folder
        {
            get
            {
                try
                {

                    return ConfigurationManager.AppSettings.Get("IN_root_folder");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// корневой каталог архива
        /// </summary>
        public static string root_arhive_folder
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings.Get("Arhiv_root_folder");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// входной каталог отчетов
        /// </summary>
        public static string ReportsFolder
        {
            get
            {
                try
                {
                    return Path.Combine(root_in_folder, "Reports");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// входной каталог событий
        /// </summary>
        public static string EventsFolder
        {
            get
            {
                try
                {
                    return Path.Combine(root_in_folder, "Events");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// входной каталог протоколов
        /// </summary>
        public static string ProtocolsFolder
        {
            get
            {
                try
                {
                    return Path.Combine(root_in_folder, "Protocols");

                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// каталог архива отчетов
        /// </summary>
        public static string ReportFolderArchive
        {
            get
            {
                try
                {
                    return Path.Combine(root_arhive_folder, "Reports");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// каталог архива событий
        /// </summary>
        public static string EventsFolderArchive
        {
            get
            {
                try
                {
                    return Path.Combine(root_arhive_folder, "Events");
                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// каталог архива протоколов
        /// </summary>
        public static string ProtocolsFolderArchive
        {
            get
            {
                try
                {

                    return Path.Combine(root_arhive_folder, "Protocols");

                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                catch (SystemException ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                {
                    return null;
                }
            }
        }

    }
}
