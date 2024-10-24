using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using MySql.Data;

public class AddUser : MonoBehaviour
{
    public InputField Login;
    public InputField Password;
    public Dropdown Role;

    public GameObject ScriptNewList;

public void AddUserToBD()
    {



        int rolBD = 0;
        if(Role.value.ToString() == "0")
        {
            rolBD = Role.value+2;
        }
        else if(Role.value.ToString() == "1")
        {
            rolBD = Role.value+2;
        }
        BDConnect.conn.Open();
        BDConnect.cmd = new MySqlCommand($"INSERT INTO users (login,password,role_id) values ('{Login.text}','{Password.text}',{rolBD})", BDConnect.conn);
        BDConnect.cmd.ExecuteNonQuery();
        BDConnect.conn.Close();
        //print("!!!!!!!!!");

        ScriptNewList.GetComponent<Autorization>().DownloadBDToList("SELECT * FROM users");
        ScriptNewList.GetComponent<Autorization>().ClickLogin();
    }
}
