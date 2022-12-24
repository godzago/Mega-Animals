using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedZone : MonoBehaviour
{
    private UIManager _uýManager;
    [SerializeField] GameObject _gameOverTwo;
    private void Awake()
    {
        _uýManager = GameObject.Find("Canvas").GetComponent<UIManager>();       
    }

    private void OnTriggerStay(Collider other)
    {
        CubeScripts cube = other.GetComponent<CubeScripts>();       

        if (cube != null)
        {
            if (!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < .1f)
            {
                _gameOverTwo.SetActive(true);
                StartCoroutine(GameOverTwo());         
            }
        }
    }
    public IEnumerator GameOverTwo()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.25f);
        _gameOverTwo.SetActive(false);
        _uýManager.GameOver();
    }
}
