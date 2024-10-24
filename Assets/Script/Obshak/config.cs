using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class config
{
    public static string Server = "127.0.0.1";
    public static string Port = "3306";
    public static string Database = "bd_code_construct";
    public static string Uid = "root";
    public static string Pwd = "root";


    public static string UserRole = "";
    public static string UserId = "";



    public static List<string[]> UsersList = new List<string[]>();
    public static List<string[]> TaskList = new List<string[]>();

    public static List<GameObject> LineRendereList= new List<GameObject>();

    public static bool StartGameBlock = false;

    public static Dictionary<string, string> PeremdenDict = new Dictionary<string, string>();


    public static string loadGameType = "";
    public static int IdLoadTask = 0;


    public static int studenTaskValue = 0;


}
