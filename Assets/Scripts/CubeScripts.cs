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

    public int value;

    [SerializeField] GameManager _gameManager;

    [SerializeField] ParticleSystem _particleSystem;

    private Collider _collider;
    private float daynanicMat = 1f;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        CubeRigidbody = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy01"))
        {
            if (collision.gameObject.TryGetComponent(out CubeScripts cube))
            {
                if (cube.value == value)
                {
                    CubeRigidbody.AddForce(transform.up * 500);
                    StartCoroutine(SetCloseGameObject());
                    _gameManager.ScorManager();
                    _collider.material.dynamicFriction = daynanicMat;
                }
            }
        }
    }

    public IEnumerator SetCloseGameObject()
    {
        _particleSystem = Instantiate(_particleSystem, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
