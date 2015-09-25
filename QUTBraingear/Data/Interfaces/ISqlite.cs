using System;
using SQLite.Net;

namespace QUTBraingear.Data
{
	public interface ISqlite
	{
		SQLiteConnection GetConnection();
	}
}

