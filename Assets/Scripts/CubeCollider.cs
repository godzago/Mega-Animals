using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    CubeScripts _cubeScripts;

    private void Awake()
    {
        _cubeScripts = GetComponent<CubeScripts>();
    }


}
