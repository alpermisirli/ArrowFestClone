using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Material blueMaterial;

    [SerializeField] private Material redMaterial;
    [SerializeField] private TMP_Text _gateText;
    private MeshRenderer _meshRenderer;
    private int gateNumber;

    private string gateOperator;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        AssignOperator();
        AssignNumber();
        AssignText();
        //Debug.Log(gameObject + "Number : " + gateNumber + " Operator : " + gateOperator);
    }

    /// <summary>
    /// Assigns an operator and color to the gate
    /// </summary>
    private void AssignOperator()
    {
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
}