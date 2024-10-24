using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    public GameObject Papa;
public void Clock()
    {
        this.transform.parent = Papa.transform;
    }
}
