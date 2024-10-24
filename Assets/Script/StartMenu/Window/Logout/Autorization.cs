using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Autorization : MonoBehaviour
{
    public InputField LoginText;
    public InputField PasswordText;

    public GameObject AdminW;
    public GameObject TeacherW;
    public GameObject StudentW;

    public Text AdminListUser;
    public GameObject TeacherListTask;

    private void OnEnable()
    {
        config.TaskList.Clear();
        config.UsersList.Clear();

        BDConnect.PuskConect();
        DownloadBDToList("SELECT * FROM users");
        DownloadBDToList("SELECT * FROM task");
    }

    public void DownloadBDToList(string Zapros)
    {
        BDConnect.conn.Open();
        //cmd = new MySqlCommand("SELECT * FROM users", conn);
        BDConnect.cmd = new MySqlCommand(Zapros, BDConnect.conn);
        MySqlDataReader reader = BDConnect.cmd.ExecuteReader();
        //print("!!!!!!!!!");
        if (Zapros.Contains("users"))
        {
            config.UsersList.Clear();
            while (reader.Read())
            {
                config.UsersList.Add(new string[] {
                reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) });
            }
        }
        else if (Zapros.Contains("task"))
        {
            config.TaskList.Clear();
            while (reader.Read())
            {
                config.TaskList.Add(new string[] {
                reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) });
            }
        }
        BDConnect.conn.Close();
        //print(config.UsersList.Count);
        ///print(config.UsersList[0].Length);

    }

    public void ClickLogin() //авторизация
    {
        
        for (int i = 0; i < config.UsersList.Count; i++) // проверка на совпадение логина и пароль
        {
            //print("+");
            if (LoginText.text == config.UsersList[i][1] && PasswordText.text == config.UsersList[i][2])
            {
                //print("+");
                config.UserRole = config.UsersList[i][3]; // сохраняем роль
                config.UserId = config.UsersList[i][0]; // сохраняем id
                break;
            }

        }
        // проверка ролей
        if (config.UserRole == "1") //admin
        {
            AdminListUser.text = "";
            print("ADMIN!!!!!!!!!!!!!!");





            transform.root.gameObject.GetComponent<Drop>().ClickDrop(AdminW);
            for (int i = 0; i < config.UsersList.Count; i++)
            {
                AdminListUser.text += config.UsersList[i][1] + "   ";
                if (config.UsersList[i][3] == "2")
                {
                    AdminListUser.text += "Учитель";
                }
                else if (config.UsersList[i][3] == "3")
                {
                    AdminListUser.text += "Студент";
                }
            AdminListUser.text += "\n";
            }
        }
        if (config.UserRole == "2") //teacher
        {
            print("TEACHER!!!!!!!!!!!!!!");


            transform.root.gameObject.GetComponent<Drop>().ClickDrop(TeacherW);
            for (int i = 0; i < config.TaskList.Count; i++)
            {
                print(config.TaskList[i][3]+  "  +   " + config.UserId + "  +   " + config.UsersList[1][0]);
                if(config.TaskList[i][3] == config.UserId)//если id юзера совпадает с id учителя создавшего задания, отображаеться
                {
                print("++");
                    GameObject CloneTask = Instantiate(TeacherListTask);
                    CloneTask.transform.parent = TeacherListTask.transform.parent;
                    CloneTask.transform.localScale = TeacherListTask.transform.localScale;
                    CloneTask.GetComponent<Text>().text = config.TaskList[i][1];
                    CloneTask.transform.GetChild(0).name = config.TaskList[i][0];
                    CloneTask.gameObject.SetActive(true);
                }
            }
        }
        if (config.UserRole == "3")//student
        {
            transform.root.gameObject.GetComponent<Drop>().ClickDrop(StudentW);
        }

    }
}
