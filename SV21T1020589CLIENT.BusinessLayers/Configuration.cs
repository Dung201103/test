﻿namespace SV21T1020589CLIENT.BusinessLayers
{
    public static class Configuration
    {

        private static string connectionString = "";
        /// <summary>
        /// Khởi tạo cấu hình cho businessLayers
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            Configuration.connectionString = connectionString;
        }
        /// <summary>
        /// Chuỗi tham số kết nối CSDL
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
