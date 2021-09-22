using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrganizer : MonoBehaviour
{
    [SerializeField] private float rx = 2f; // horizontal radius
    [SerializeField] private float ry = 1.5f; // vertical radius

    private void Update()
    {
        ArrowPositionUpdater();
    }

    private void ArrowPositionUpdater()
    {
        int arrowCount = transform.childCount;
        float angleSelection = Mathf.PI * 2f / arrowCount;
        for (int i = 0; i < arrowCount; i++)
        {
            Transform child = transform.GetChild(i);
            float angle = i * angleSelection;
            //Reducing ry with the increasing amount of arrows to better fit in the line
            ry = Mathf.Sqrt(arrowCount) / arrowCount;
            //todo increase rx at the end of level
            Vector3 arrowPosition = transform.position + new Vector3(rx * Mathf.Cos(angle),
                ry * Mathf.Sin(angle) * Mathf.Sqrt(i),
                0f);
            //For keeping the first arrow in the middle
            if (i == 0)
            {
                arrowPosition = transform.position;
            }

            child.position = arrowPosition;
        }
    }
}