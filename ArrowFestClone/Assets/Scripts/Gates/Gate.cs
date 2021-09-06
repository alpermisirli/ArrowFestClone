using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    private GameObject arrowStack;

    [SerializeField] private Material blueMaterial;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Material redMaterial;
    [SerializeField] private TMP_Text _gateText;
    [SerializeField] private bool start;
    private MeshRenderer _meshRenderer;
    private int gateNumber;


    public string gateOperator;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        AssignOperator();
        AssignNumber();
        AssignText();
        //Debug.Log(gameObject + "Number : " + gateNumber + " Operator : " + gateOperator);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arrowStack = other.gameObject;
            GateOperation();
        }
    }

    /// <summary>
    /// Assigns an operator and color to the gate
    /// </summary>
    private void AssignOperator()
    {
        if (start)
        {
            return;
        }

        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                gateOperator = "+";
                _meshRenderer.material = blueMaterial;
                break;
            case 1:
                gateOperator = "-";
                _meshRenderer.material = redMaterial;
                break;
            case 2:
                gateOperator = "*";
                _meshRenderer.material = blueMaterial;
                break;
            case 3:
                gateOperator = "/";
                _meshRenderer.material = redMaterial;
                break;
        }
    }

    /// <summary>
    /// Assigns a number to the gate
    /// </summary>
    private void AssignNumber()
    {
        if (gateOperator == "*" || gateOperator == "/")
        {
            gateNumber = Random.Range(1, 4);
        }
        else
        {
            gateNumber = Random.Range(1, 51);
        }
    }

    /// <summary>
    /// Assigns text to gate
    /// </summary>
    private void AssignText()
    {
        _gateText.text = gateOperator + gateNumber;
    }

    /// <summary>
    /// Calculates the new arrow size
    /// </summary>
    private void GateOperation()
    {
        int arrowCount = arrowStack.transform.childCount;
        int newArrowCount;
        int arrowToInstantiate;
        int arrowToDestroy;
        Debug.Log("There are ," + arrowCount + " child objects in arrow stack");
        if (gateOperator == "*")
        {
            newArrowCount = arrowCount * gateNumber;
            arrowToInstantiate = newArrowCount - arrowCount;
            for (int i = 0; i < arrowToInstantiate; i++)
            {
                Instantiate(arrowPrefab, arrowStack.transform);
            }

            Debug.Log("New arrow count is :" + newArrowCount);
        }
        else if (gateOperator == "/")
        {
            newArrowCount = arrowCount / gateNumber;
            arrowToDestroy = arrowCount - newArrowCount;
            for (int i = 0; i < arrowToDestroy; i++)
            {
                Destroy(arrowStack.transform.GetChild(i).gameObject);
            }

            Debug.Log("New arrow count is :" + newArrowCount);
        }
        else if (gateOperator == "+")
        {
            newArrowCount = arrowCount + gateNumber;
            arrowToInstantiate = newArrowCount - arrowCount;
            for (int i = 0; i < arrowToInstantiate; i++)
            {
                Instantiate(arrowPrefab, arrowStack.transform);
            }

            Debug.Log("New arrow count is :" + newArrowCount);
        }
        else if (gateOperator == "-")
        {
            newArrowCount = arrowCount - gateNumber;
            arrowToDestroy = arrowCount - newArrowCount;
            for (int i = 0; i < arrowToDestroy; i++)
            {
                Destroy(arrowStack.transform.GetChild(i).gameObject);
            }

            Debug.Log("New arrow count is :" + newArrowCount);
        }
    }
}