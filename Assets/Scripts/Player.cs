using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float cubeMaxPosX;
    [Space]
    public SliderScripts touchSlider;

    public CubeScripts mainCube;

    private bool isPointerDown;
    private Vector3 cubePos;

    public CubeSpawnerScripts CubeSpawnerScripts;

    private void Start()
    {
        // Listen to slider events:
        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
        touchSlider.On += OnPointerUp;
    }

    
    private void Update()
    {
        if (isPointerDown)
            mainCube.transform.position = Vector3.Lerp(
               mainCube.transform.position,
               cubePos,
               moveSpeed * Time.deltaTime
            );

        mainCube = CubeSpawnerScripts.currentCube;
    }

    private void OnPointerDown()
    {
        isPointerDown = true;
    }

    private void OnPointerDrag(float xMovement)
    {
        if (isPointerDown)
        {
            cubePos = mainCube.transform.position;
            cubePos.x = xMovement * cubeMaxPosX;
        }
    }

    private void OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;

            // Push the cube:
            mainCube.CubeRigidbody.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);

        }
    }

    private void SpawnNewCube()
    {
        mainCube.IsMainCube = false;
    }

    private void OnDestroy()
    {
        //remove listeners:
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
        touchSlider.On -= OnPointerUp;
    }
}