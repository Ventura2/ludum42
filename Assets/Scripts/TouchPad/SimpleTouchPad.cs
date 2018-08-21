using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    public float smoothing = 0.1f;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    private void Awake() {
        direction = Vector2.zero;
        touched = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (!touched) {
            touched = true;
            pointerID = eventData.pointerId;
            origin = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(eventData.pointerId == pointerID) { 
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }

    }

    public void OnPointerUp(PointerEventData eventData) {
        if (eventData.pointerId == pointerID) {
            direction = Vector2.zero;
        }
    }

    public Vector2 GetDirection() {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
