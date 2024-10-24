using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLineFunction : MonoBehaviour
{
    private GameObject Position1;
    public GameObject LineRendererPrefab;
    private GameObject LineRendererPrefabClone;
    public void GenLine(GameObject ConectLine)
    {
        //print("Click");
        if (ConectLine.tag == "FromLine" && Position1 == null)
        {
            //print("From");
            Position1 = ConectLine.gameObject;
        }
        else if (ConectLine.tag == "FromLine" && Position1 != null)
        {
            Position1 = null;
        }
        else if (ConectLine.tag == "InLine" && Position1 != null)
        {
            //print("In");
            LineRendererPrefabClone = Instantiate(LineRendererPrefab);
            LineRendererPrefabClone.transform.parent = Position1.transform.parent.parent;
            LineRendererPrefabClone.GetComponent<ConfigLine>().Position1 = Position1.gameObject;
            LineRendererPrefabClone.GetComponent<ConfigLine>().Position2 = ConectLine.gameObject;
            config.LineRendereList.Add(LineRendererPrefabClone);
        }
    }
    void Update()
    {

        for (int i = 0; i < config.LineRendereList.Count; i++)
        {
            
            try
            {

                config.LineRendereList[i].GetComponent<LineRenderer>().SetPosition(0, new Vector3(
                config.LineRendereList[i].GetComponent<ConfigLine>().Position1.transform.position.x,
                config.LineRendereList[i].GetComponent<ConfigLine>().Position1.transform.position.y,
                0));
                config.LineRendereList[i].GetComponent<LineRenderer>().SetPosition(1, new Vector3(
                    config.LineRendereList[i].GetComponent<ConfigLine>().Position2.transform.position.x,
                    config.LineRendereList[i].GetComponent<ConfigLine>().Position2.transform.position.y,
                    0));
            }
            catch
            {
                print("123а213а1223аудалил");

                    print("удалил");
                    Destroy(config.LineRendereList[i]);
                    config.LineRendereList.RemoveAt(i);
                
            }
        }


    }
}
