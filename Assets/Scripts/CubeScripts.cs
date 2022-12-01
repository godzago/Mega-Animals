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
    public int MyID;
    public int value;

    private void Awake()
    {
        MyID = GetInstanceID();
        CubeRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy01"))
        {
            if (collision.gameObject.TryGetComponent(out CubeScripts cube))
            {
                if(cube.value == value)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("DÝFFRETN CUBE");
                }
            }
        }
    }

}
