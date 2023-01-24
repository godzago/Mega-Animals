using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerScripts : MonoBehaviour
{
    public static CubeSpawnerScripts Instance;

    public List<CubeScripts> cubeList = new List<CubeScripts>();
    public CubeScripts currentCube;
    public Transform spawnPoint;
    private UIManager _uýManager;
    [SerializeField] GameObject AdsgameObject;
    private int winBool  = 0;

    private void Awake()
    {
        _uýManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (PlayerPrefs.HasKey("CuneCount") == false)
        {
            PlayerPrefs.SetInt("CuneCount", cubeList.Count);
        }
    }
    private void Start()
    {
        currentCube = PickRandomCube();

        if (PlayerPrefs.GetInt("CuneCount", cubeList.Count) == 11 && winBool == 0)
        {
            cubeList[cubeList.Count + 1] = AdsgameObject.GetComponent<CubeScripts>();
            winBool = 1;
        }      
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
