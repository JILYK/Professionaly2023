using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class StudentButton : MonoBehaviour
{
public void Test()
    {
        
        config.loadGameType = "s_test";
        config.IdLoadTask = System.Convert.ToInt32(config.TaskList[0][0]);
        EditorSceneManager.LoadScene("Game");
    }
    public void Trenirovka()
    {
        config.loadGameType = "s_tren";
        config.IdLoadTask = System.Convert.ToInt32(config.TaskList[0][0]);
        EditorSceneManager.LoadScene("Game");
    }
}
