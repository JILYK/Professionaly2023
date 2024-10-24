using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class DownlouadScene : MonoBehaviour
{
    public GameObject TeacherButton;
    public GameObject StudentButtonTrenirovka;
    public GameObject StudentButtonTest;

    public Text StudentText;
    public GameObject TeacherText;


    private int counterZadan = 0;
    private void Start()
    {
        if (config.UserRole == "2" && config.loadGameType == "t_red")
        {
            TeacherButton.gameObject.SetActive(true);
            TeacherText.gameObject.SetActive(true);
        }
        if (config.UserRole == "2" && config.loadGameType == "t_create")
        {
            TeacherButton.gameObject.SetActive(true);
            TeacherText.gameObject.SetActive(true);
        }

        if (config.UserRole == "3" && config.loadGameType == "s_tren")
        {
            print("STUDENT!$");
            StudentButtonTrenirovka.gameObject.SetActive(true);
            StudentText.gameObject.SetActive(true);
            StudentText.text = config.TaskList[counterZadan][1];
        }
        if (config.UserRole == "3" && config.loadGameType == "s_test")
        {
            print("STUDENT!$");
            StudentButtonTest.gameObject.SetActive(true);
            StudentText.gameObject.SetActive(true);

            StudentText.text = config.TaskList[counterZadan][1];
        }

        print("CONFIG DATA" + config.IdLoadTask + " " + config.loadGameType);
    }
    public void TaskUpLoud(string ResultTaskUploud)
    {
        string DescriptionAdd = TeacherText.GetComponent<InputField>().text;
        print(DescriptionAdd);
        BDConnect.PuskConect();
        BDConnect.conn.Open();
        BDConnect.cmd = new MySqlCommand($"INSERT INTO task (description,result,teacher_id) VALUES ('{DescriptionAdd}','{ResultTaskUploud}',{config.UserId});", BDConnect.conn);
        BDConnect.cmd.ExecuteNonQuery();
        BDConnect.conn.Close();
    }
    public void NestTask()
    {
        if(config.UserId == "3") config.IdLoadTask = System.Convert.ToInt32(config.TaskList[counterZadan][0]);
        StudentText.text = config.TaskList[counterZadan][2];
        counterZadan++;
    }
}
