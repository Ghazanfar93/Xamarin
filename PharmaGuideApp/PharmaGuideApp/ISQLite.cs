using System;
using SQLite.Net;
namespace PharmaGuideApp
{

    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }

}
