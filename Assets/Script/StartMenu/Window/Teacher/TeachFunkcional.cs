using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEditor.SceneManagement;

public class TeachFunkcional : MonoBehaviour
{
    public void Redactor()
    {
        config.loadGameType = "t_red";
        config.IdLoadTask = System.Convert.ToInt32(this.gameObject.name);


        BDConnect.conn.Open();
        BDConnect.cmd = new MySqlCommand($"DELETE FROM bd_code_construct.task WHERE(id= {config.IdLoadTask}))", BDConnect.conn);
        BDConnect.cmd.ExecuteNonQuery();
        BDConnect.conn.Close();
        EditorSceneManager.LoadScene("Game");        
    }
    public void Creator()
    {
        config.loadGameType = "t_create";
        EditorSceneManager.LoadScene("Game");
    }
}
