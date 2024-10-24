using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
public void ClickDrop( GameObject Next)
    {
        for(int i = 1; this.transform.childCount > i; i++)
        {
            if(this.transform.GetChild(i)!= Next)
            {
                this.transform.GetChild(i).GetComponent<Animator>().SetBool("Close",true);
            }
        }
        Next.gameObject.SetActive(true);
    }
}
