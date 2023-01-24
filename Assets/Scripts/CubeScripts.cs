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

    public SpriteRenderer _sprite;

    [SerializeField] AudioClip _Clip;

    private float time = 0.2f;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        CubeRigidbody = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float b = 0;
        if (collision.gameObject.CompareTag("enemy01"))
        {         
            if (collision.gameObject.TryGetComponent(out CubeScripts cube))
            {
                if (cube.value == value)
                {
                    CubeRigidbody.AddForce(transform.up * 350);
                    StartCoroutine(SetCloseGameObject());
                    if (Time.time >= b+time)
                    {
                        b = Time.time;

                        _gameManager.ScorManager();
                    }                   
                    _collider.material.dynamicFriction = daynanicMat;
                    SoundManager.Instance.PlaySound(_Clip);
                }
            }
        }
    }
    private void Update()
    {
        if (CubeRigidbody.velocity.magnitude == 0)
        {
            _sprite.color = new Color(r: 1f, g: 1f, b: 1f, a: 0f);
        }
        else
        {
            _sprite.color = new Color(r: 1f, g: 1f, b: 1f, a: 0.1f);
        }
    }
    public IEnumerator SetCloseGameObject()
    {
        _particleSystem = Instantiate(_particleSystem, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        this.gameObject.SetActive(false);
    }
}
