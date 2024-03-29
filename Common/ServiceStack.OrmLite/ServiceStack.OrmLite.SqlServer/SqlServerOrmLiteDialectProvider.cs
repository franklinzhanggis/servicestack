using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ServiceStack.OrmLite.SqlServer
{
	public class SqlServerOrmLiteDialectProvider 
		: OrmLiteDialectProviderBase
	{
		public static SqlServerOrmLiteDialectProvider Instance = new SqlServerOrmLiteDialectProvider();

		private static DateTime timeSpanOffset = new DateTime(1900,01,01);

		public SqlServerOrmLiteDialectProvider()
		{
			base.AutoIncrementDefinition = "IDENTITY(1,1)";
			base.StringColumnDefinition = "VARCHAR(8000)";
			//base.DateTimeColumnDefinition = base.StringColumnDefinition;
			base.BoolColumnDefinition = base.IntColumnDefinition;
			base.GuidColumnDefinition = "UniqueIdentifier";
			base.RealColumnDefinition = "FLOAT";
			base.DecimalColumnDefinition = "DECIMAL(38,6)";

			base.InitColumnTypeMap();
		}

		public override IDbConnection CreateConnection(string connectionString, Dictionary<string, string> options)
		{
			var isFullConnectionString = connectionString.Contains(";");

			if (!isFullConnectionString)
			{
				var filePath = connectionString;

				var filePathWithExt = filePath.ToLower().EndsWith(".mdf")
					? filePath 
					: filePath + ".mdf";

				var fileName = Path.GetFileName(filePathWithExt);
				var dbName = fileName.Substring(0, fileName.Length - ".mdf".Length);

				connectionString = string.Format(
				@"Data Source=.\SQLEXPRESS;AttachDbFilename={0};Initial Catalog={1};Integrated Security=True;User Instance=True;",
					filePathWithExt, dbName);
			}

			if (options != null)
			{
				foreach (var option in options)
				{
					if (option.Key.ToLower() == "read only")
					{
						if (option.Value.ToLower() == "true")
						{
							connectionString += "Mode = Read Only;";
						}
						continue;
					}
					connectionString += option.Key + "=" + option.Value + ";";
				}
			}

			return new SqlConnection(connectionString);
		}

		public override object ConvertDbValue(object value, Type type)
		{
			try
			{
				if (value == null || value is DBNull) return null;

				if (type == typeof(bool))
				{
					var intVal = Convert.ToInt32(value.ToString());
					return intVal != 0;
				}

				if (type == typeof(TimeSpan) && value is DateTime)
				{
					var dateTimeValue = (DateTime)value;
					return dateTimeValue - timeSpanOffset;
				}

				return base.ConvertDbValue(value, type);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override string GetQuotedValue(object value, Type fieldType)
		{
			if (value == null) return "NULL";

			if (fieldType == typeof(Guid))
			{
				var guidValue = (Guid)value;
				return string.Format("CAST('{0}' AS UNIQUEIDENTIFIER)", guidValue);
			}
			if (fieldType == typeof(DateTime))
			{
				var dateValue = (DateTime)value;
				const string iso8601Format = "yyyy-MM-dd HH:mm:ss.fff";
				return base.GetQuotedValue(dateValue.ToString(iso8601Format), typeof(string));
			}
			if (fieldType == typeof(bool))
			{
				var boolValue = (bool)value;
				return base.GetQuotedValue(boolValue ? 1 : 0, typeof(int));
			}

			return base.GetQuotedValue(value, fieldType);
		}

		public override long GetLastInsertId(IDbCommand dbCmd)
		{
			dbCmd.CommandText = "SELECT SCOPE_IDENTITY()";
			var result = dbCmd.ExecuteScalar();
			//if (result is DBNull) return 0;
			return (long)result;
		}
	}
}