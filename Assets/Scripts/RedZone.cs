using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedZone : MonoBehaviour
{
    private UIManager _u�Manager;

    private void Awake()
    {
        _u�Manager = GameObject.Find("Canvas").GetComponent<UIManager>();       
    }

    private void OnTriggerStay(Collider other)
    {
        CubeScripts cube = other.GetComponent<CubeScripts>();       

        if (cube != null)
        {
            if (!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < .1f)
            {               
                _u�Manager.GameOver();              
            }
        }
    }
}
