using Dapper;
using SV21T1020589CLIENT.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SV21T1020589CLIENT.DataLayers.SQLite
{
	public class ProvinceDAL : BaseDAL, ISimpleQueryDAL<Province>
	{
		public ProvinceDAL(string connectionString) : base(connectionString)
		{
		}

		public List<Province> List()
		{
			List<Province> data = new List<Province>();
			using (var connection = OpenConnection())
			{
				var sql = @"select * from Provinces";
				data = connection.Query<Province>(sql: sql, commandType: System.Data.CommandType.Text).ToList();
				connection.Close();
			}
			return data;
		}
	}
}
