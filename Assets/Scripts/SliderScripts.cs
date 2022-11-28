using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction On;

    private Slider uiSlider;

    private void Awake()
    {
        uiSlider = GetComponent<Slider>();
        uiSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null)
            OnPointerDownEvent.Invoke();

        if (OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(uiSlider.value);


    }
    private void OnSliderValueChanged(float value)
    {
        if (OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(value);
    }


    private void OnDestroy()
    {
        uiSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (On != null)
        {
            On.Invoke();
        }

        uiSlider.value = 0f;
    }
}
