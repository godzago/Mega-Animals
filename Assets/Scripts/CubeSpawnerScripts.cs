using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerScripts : MonoBehaviour
{
    public static CubeSpawnerScripts Instance;

    public List<CubeScripts> cubeList = new List<CubeScripts>();
    public CubeScripts currentCube;
    public Transform spawnPoint;

    private bool gameison;
    private void Start()
    {
        currentCube = PickRandomCube();
        gameison = true;
    }

    private void OnTriggerEnter(Collider other)
    {
            StartCoroutine(SetCube());       
    }
    private IEnumerator SetCube()
    {
        yield return new WaitForSeconds(0.75f);
            currentCube = PickRandomCube();
    }
    private CubeScripts PickRandomCube()
    {
        GameObject temp = Instantiate(cubeList[Random.Range(0, cubeList.Count)].gameObject, spawnPoint.position, Quaternion.Euler(0,-180,0));
        return temp.GetComponent<CubeScripts>();
    }
}
