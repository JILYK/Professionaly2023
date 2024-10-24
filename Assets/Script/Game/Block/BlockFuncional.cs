using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockFuncional : MonoBehaviour
{
    private GameObject DragBlock;

    public GameObject BD;

    private GameObject StartBlock;
    private GameObject SaveStartBlock;
    public void DragAndDrop()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 90));
        if (DragBlock == null && !this.gameObject.name.Contains("(Clone)"))
        {
            DragBlock = Instantiate(this.gameObject);
            DragBlock.transform.parent = transform.root;
            DragBlock.transform.localScale = this.transform.localScale;

            if (DragBlock.gameObject.name.Contains("StartEnd") && !config.StartGameBlock)
            {
                DragBlock.transform.GetChild(6).gameObject.SetActive(true);
                config.StartGameBlock = true;
                StartBlock = DragBlock;
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            else if (DragBlock.gameObject.name.Contains("StartEnd") && config.StartGameBlock)
            {
                DragBlock.transform.GetChild(7).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            if (DragBlock.gameObject.name.Contains("If"))
            {
                DragBlock.transform.GetChild(1).gameObject.SetActive(true);
                DragBlock.transform.GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(4).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
            }
            if (DragBlock.gameObject.name.Contains("For"))
            {
                DragBlock.transform.GetChild(1).gameObject.SetActive(true);
                DragBlock.transform.GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(4).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
            }
            if (DragBlock.gameObject.name.Contains("Vvod"))
            {
                DragBlock.transform.GetChild(1).gameObject.SetActive(true);
                DragBlock.transform.GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(3).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            if (DragBlock.gameObject.name.Contains("Math"))
            {
                DragBlock.transform.GetChild(1).gameObject.SetActive(true);
                DragBlock.transform.GetChild(2).gameObject.SetActive(true);
                DragBlock.transform.GetChild(5).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DragBlock.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name.Contains("(Clone)"))
        {
            DragBlock = this.gameObject;
        }
        DragBlock.transform.position = MousePosition;
    }
    public void DragAndDropEnd()
    {
        DragBlock = null;
    }

    public void DelBlock()
    {
        print("click");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("del");

            for (int i = 5; i < this.transform.childCount; i++)
            {

                if (this.transform.GetChild(i).name.Contains("Line"))
                {

                    GameObject DelLine = this.transform.GetChild(i).gameObject;
                    //   DelLine.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line");
                    Destroy(DelLine.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line"));
                    // config.LineRendereList.Remove(DelLine.GetComponent<ConfigLine>().Position1.transform.parent.parent.Find("Line").gameObject);
                    config.LineRendereList.Remove(DelLine);

                }
            }
            Destroy(this.gameObject);
        }
    }

    public string ResultLog = "";

    public void onEnableProverka()
    {
        if (StartBlock != null)
        {
            StartBlock.GetComponent<BlockFuncional>().StartCoroutine(PuskProverkaCoroutine(StartBlock));
            SaveStartBlock = StartBlock;
            StartBlock = null;
        }
    }
    IEnumerator PuskProverkaCoroutine(GameObject NextPusk)
    {
        NextPusk.GetComponent<Animator>().enabled = true;

        
        yield return new WaitForSeconds(0.3f);
        if (NextPusk.name.Contains("Start"))
        {
            StartEndBlockFuncional(NextPusk);
        }
        if (NextPusk.name.Contains("Vvod"))
        {
            VvodBlockFuncional(NextPusk);
        }
        if (NextPusk.name.Contains("If"))
        {
            IfBlockFuncional(NextPusk);
        }     
        if (NextPusk.name.Contains("For"))
        {
            ForBlockFuncional(NextPusk);
        }   
        if (NextPusk.name.Contains("Math"))
        {
            MathBlockFuncional(NextPusk);
        }
        print(ResultLog);
        yield break;
    }
    public void StartEndBlockFuncional(GameObject Me)
    {
        bool EndBool = true;
        ResultLog += "StartEnd->";
        // Me.gameObject.GetComponent<Animator>().enabled = false;

        // Me.transform.Find("Line").gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line");
        for (int i = 5; i < Me.transform.childCount; i++)
        {
            if (Me.transform.GetChild(i).name.Contains("Line"))
            {
                EndBool = false;
                StartCoroutine(PuskProverkaCoroutine(
                    Me.transform.GetChild(i).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
            }

        }
        if (EndBool)
        {
            print("BOOOOOOOOL");
         if(config.UserId == "2")
            {
                print("2");

                BD.GetComponent<DownlouadScene>().TaskUpLoud(ResultLog);
            }
            if (config.UserId == "3")
            {
                print("3");

                if (config.TaskList[config.IdLoadTask][2] == ResultLog)
                {
                    print("Verno");

                    config.studenTaskValue++;
                    

                }
                BD.GetComponent<DownlouadScene>().NestTask();
            }
        }
        
    }

    public void VvodBlockFuncional(GameObject Me)
    {
        string peremA = Me.transform.GetChild(1).GetComponent<InputField>().text;
        string peremB = Me.transform.GetChild(2).GetComponent<InputField>().text;

        config.PeremdenDict[peremA] = peremB;

        print(config.PeremdenDict[peremA] + " &???& ");
        ResultLog += "Vvod(" + (string)peremA + ","  + (string)peremB + ")->";




        // Me.gameObject.GetComponent<Animator>().enabled = false;

        // Me.transform.Find("Line").gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line");
        for (int i = 5; i < Me.transform.childCount; i++)
        {
            if (Me.transform.GetChild(i).name.Contains("Line"))
            {
                StartCoroutine(PuskProverkaCoroutine(
                    Me.transform.GetChild(i).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
            }
            else
            {
                StartBlock = SaveStartBlock;
            }
        }
    }
    private GameObject PutiIf;
    private GameObject PutiFor;
    public void IfBlockFuncional(GameObject Me)
    {
        string LogPerem = "";
        string peremA = Me.transform.GetChild(1).GetComponent<InputField>().text;
        string peremB = Me.transform.GetChild(2).GetComponent<InputField>().text;
        string OperantDrop = Me.transform.GetChild(4).GetChild(0).GetComponent<Text>().text;
        print(OperantDrop);
        ResultLog += "If(" + (string)peremA + "," + (string)OperantDrop + ","+ (string)peremB + ")->";
        try
        {
            System.Convert.ToInt32(peremA);
            LogPerem += "aInt";
        }
        catch
        {
            LogPerem += "aNotInt";
        }
        LogPerem += "_";
        try
        {
            System.Convert.ToInt32(peremB);
            LogPerem += "bInt";
        }
        catch
        {
            LogPerem += "bNotInt";
        }
        print(LogPerem);

        bool PutiBool = false;

        try
        {
        if (LogPerem == "aNotInt_bNotInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if(System.Convert.ToInt32(config.PeremdenDict[peremA]) > System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) < System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) == System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) != System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        if (LogPerem == "aInt_bNotInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if (System.Convert.ToInt32(peremA) > System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(peremA) < System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(peremA) == System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(peremA) != System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        if (LogPerem == "aNotInt_bInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) > System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) < System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) == System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) != System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        }
        catch 
        {
            PutiBool = false ;
        }

        // Me.gameObject.GetComponent<Animator>().enabled = false;
        if (PutiBool)
        {
           PutiIf = Me.transform.GetChild(0).Find("True").gameObject;
        }
        else 
        {
            PutiIf = Me.transform.GetChild(0).Find("False").gameObject;
        }
        
        // Me.transform.Find("Line").gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line");
        for (int i = 5; i < Me.transform.childCount; i++)
        {
            if (Me.transform.GetChild(i).name.Contains("Line"))
            {
                if(Me.transform.GetChild(i).gameObject.GetComponent<ConfigLine>().Position1 == PutiIf)
                {
                StartCoroutine(PuskProverkaCoroutine(
                    Me.transform.GetChild(i).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
                }
            }
            else
            {
                StartBlock = SaveStartBlock;
            }
        }
    }   
    public void ForBlockFuncional(GameObject Me)
    {
        string LogPerem = "";
        string peremA = Me.transform.GetChild(1).GetComponent<InputField>().text;
        string peremB = Me.transform.GetChild(2).GetComponent<InputField>().text;
        string OperantDrop = Me.transform.GetChild(4).GetChild(0).GetComponent<Text>().text;
        print(OperantDrop);
        ResultLog += "For(" + (string)peremA + "," + (string)OperantDrop + "," + (string)peremB + ")->";
        try
        {
            System.Convert.ToInt32(peremA);
            LogPerem += "aInt";
        }
        catch
        {
            LogPerem += "aNotInt";
        }
        LogPerem += "_";
        try
        {
            System.Convert.ToInt32(peremB);
            LogPerem += "bInt";
        }
        catch
        {
            LogPerem += "bNotInt";
        }
        print(LogPerem);

        bool PutiBool = false;
        try
        {

        if (LogPerem == "aNotInt_bNotInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) > System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) < System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) == System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) != System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        if (LogPerem == "aInt_bNotInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if (System.Convert.ToInt32(peremA) > System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(peremA) < System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(peremA) == System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(peremA) != System.Convert.ToInt32(config.PeremdenDict[peremB]))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        if (LogPerem == "aNotInt_bInt")
        {
            switch (OperantDrop)
            {
                case ">":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) > System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "<":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) < System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "==":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) == System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
                case "!=":
                    if (System.Convert.ToInt32(config.PeremdenDict[peremA]) != System.Convert.ToInt32(peremB))
                    {
                        PutiBool = true;
                    }
                    else
                    {
                        PutiBool = false;
                    }
                    break;
            }
        }
        }
        catch
        {
            PutiBool = false;
        }

        // Me.gameObject.GetComponent<Animator>().enabled = false;
        if (PutiBool)
        {
            PutiFor = Me.transform.GetChild(0).Find("True").gameObject;
        }
        else
        {
            PutiFor = Me.transform.GetChild(0).Find("False").gameObject;
        }

            print("For");
        // Me.transform.Find("Line").gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.Find("Line");
            if (Me.transform.GetChild(8).gameObject.GetComponent<ConfigLine>().Position1 == PutiFor)
            {
                    StartCoroutine(PuskProverkaCoroutine(
                        Me.transform.GetChild(8).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
            }
            else if (Me.transform.GetChild(9).gameObject.GetComponent<ConfigLine>().Position1 == PutiFor)
            {
                    StartCoroutine(PuskProverkaCoroutine(
                        Me.transform.GetChild(9).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
            }
            
            else
            {
                print("Конец for " + PutiBool + " " + Me.transform.GetChild(9).gameObject.GetComponent<ConfigLine>().Position1.name + " " + PutiIf);
                StartBlock = SaveStartBlock;
            }
        
    }
    public void MathBlockFuncional(GameObject Me)
    {
        string LogPerem = "";
        string peremA = Me.transform.GetChild(1).GetComponent<InputField>().text;
        string peremB = Me.transform.GetChild(2).GetComponent<InputField>().text;
        string OperantDrop = Me.transform.GetChild(5).GetChild(0).GetComponent<Text>().text;
        print(OperantDrop);
        ResultLog += "Math(" + (string)peremA + "," + (string)OperantDrop + "," + (string)peremB + ")->";

        try
        {
            System.Convert.ToInt32(peremA);
            LogPerem += "aInt";
        }
        catch
        {
            LogPerem += "aNotInt";
        }
        LogPerem += "_";
        try
        {
            System.Convert.ToInt32(peremB);
            LogPerem += "bInt";
        }
        catch
        {
            LogPerem += "bNotInt";
        }
        print(LogPerem);

        bool PutiBool = false;

        if (LogPerem == "aNotInt_bNotInt")
        {
            switch (OperantDrop)
            {
                case "+":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
                        System.Convert.ToInt32(config.PeremdenDict[peremA]) + System.Convert.ToInt32(config.PeremdenDict[peremB]));

                    break;
                case "-":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
      System.Convert.ToInt32(config.PeremdenDict[peremA]) - System.Convert.ToInt32(config.PeremdenDict[peremB]));

                    break;
                case "*":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
    System.Convert.ToInt32(config.PeremdenDict[peremA]) * System.Convert.ToInt32(config.PeremdenDict[peremB]));

                    break;
                case "/":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
     System.Convert.ToInt32(config.PeremdenDict[peremA]) / System.Convert.ToInt32(config.PeremdenDict[peremB]));

                    break; 
                case "%":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
    System.Convert.ToInt32(config.PeremdenDict[peremA]) % System.Convert.ToInt32(config.PeremdenDict[peremB]));
                    break;
            }
        }
        if (LogPerem == "aNotInt_bInt")
        {
            switch (OperantDrop)
            {
                case "+":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
                        System.Convert.ToInt32(config.PeremdenDict[peremA]) + System.Convert.ToInt32(peremB));
                    print(config.PeremdenDict[peremA]);
                    break;
                case "-":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
      System.Convert.ToInt32(config.PeremdenDict[peremA]) - System.Convert.ToInt32(peremB));

                    break;
                case "*":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
    System.Convert.ToInt32(config.PeremdenDict[peremA]) * System.Convert.ToInt32(peremB));

                    break;
                case "/":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
     System.Convert.ToInt32(config.PeremdenDict[peremA]) / System.Convert.ToInt32(peremB));

                    break;
                case "%":
                    config.PeremdenDict[peremA] = System.Convert.ToString(
    System.Convert.ToInt32(config.PeremdenDict[peremA]) % System.Convert.ToInt32(peremB));
                    break;
            }
        }



        

        for (int i = 5; i < Me.transform.childCount; i++)
        {
            if (Me.transform.GetChild(i).name.Contains("Line"))
            {
                StartCoroutine(PuskProverkaCoroutine(
                    Me.transform.GetChild(i).gameObject.GetComponent<ConfigLine>().Position2.transform.parent.parent.gameObject));
            }
            else
            {
                StartBlock = SaveStartBlock;
            }
        }
    }
}
