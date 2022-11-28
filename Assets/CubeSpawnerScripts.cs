using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerScripts : MonoBehaviour
{
    public static CubeSpawnerScripts Instance;

    public List<CubeScripts> cubeList = new List<CubeScripts>();
    public CubeScripts currentCube;
    public Transform spawnPoint; 


    private void Start()
    {
        currentCube = PickRandomCube();
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            StartCoroutine(SetCube());    
    }
    private IEnumerator SetCube()
    {
        yield return new WaitForSeconds(1);
            currentCube = PickRandomCube();
    }
    private CubeScripts PickRandomCube()
    {
        GameObject temp = Instantiate(cubeList[Random.Range(0, cubeList.Count)].gameObject, spawnPoint.position, Quaternion.identity);
        return temp.GetComponent<CubeScripts>();
    }
}
