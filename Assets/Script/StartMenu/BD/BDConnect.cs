
using MySql.Data.MySqlClient;

public static class BDConnect 
{
    public static MySqlConnection conn;
    public static MySqlCommand cmd;
    public static void PuskConect()
    {
        conn = new MySqlConnection($"Server={config.Server};" +
                                   $"Port={config.Port};" +
                                   $"Database={config.Database};" +
                                   $"Uid={config.Uid};" +
                                   $"Pwd={config.Pwd};");
        cmd = new MySqlCommand();
    }
    }
