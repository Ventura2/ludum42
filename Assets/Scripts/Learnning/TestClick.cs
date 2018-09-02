using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestClick : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public string message;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log("Pointer down: " + eventData.pointerId + " message: " + message);
    }
}
