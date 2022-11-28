using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CubeScripts : MonoBehaviour
{
    [HideInInspector] public int CubeID;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
     public Rigidbody CubeRigidbody;
    [HideInInspector] public bool IsMainCube;
    private void Awake()
    {
        //CubeID = staticID++;
        //cubeMeshRenderer = GetComponent<MeshRenderer>();
        CubeRigidbody = GetComponent<Rigidbody>();
    }

    //public void SetColor(Color color)
    //{
    //    CubeColor = color;
    //    //cubeMeshRenderer.material.color = color;
    //}

    //public void SetNumber(int number)
    //{
    //    CubeNumber = number;
    //    for (int i = 0; i < 6; i++)
    //    {
    //        numbersText[i].text = number.ToString();
    //    }
    //}
}
