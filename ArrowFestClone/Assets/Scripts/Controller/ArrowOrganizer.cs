using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrganizer : MonoBehaviour
{
    //TODO PUT TO THE ARROWSTACK GAMEOBJECT TO ORDER THE CHILDREN ARROW IN A WAY
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        int count = transform.childCount;
        for(int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);
            //TODO THE POSITION OF EACH CHILDREN
        }
    }
}