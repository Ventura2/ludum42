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

    public GameObject joystick;
    public GameObject miniJoystick;

    private float widthJoystick;

    private void Awake() {
#if  !UNITY_ANDROID
        this.gameObject.SetActive(false);
#endif
        direction = Vector2.zero;
        touched = false;

        widthJoystick = joystick.GetComponent<RectTransform>().rect.width;
        joystick.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData) {

        if (!touched) {
            touched = true;
            pointerID = eventData.pointerId;
            origin = eventData.position;

            joystick.SetActive(true);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            newPosition.z = 0;
            joystick.transform.position = newPosition;
            
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(eventData.pointerId == pointerID) { 
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;

            
            Vector3 newPosition;
            float radius = widthJoystick / 2f;
            if (directionRaw.magnitude > radius) {
                newPosition = Camera.main.ScreenToWorldPoint((directionRaw.normalized * radius) + origin);
            }
            else {
                newPosition = Camera.main.ScreenToWorldPoint(currentPosition);
            }

            newPosition.z = 0;
            miniJoystick.transform.position = newPosition;

        }

    }

    public void OnPointerUp(PointerEventData eventData) {
        if (eventData.pointerId == pointerID) {
            direction = Vector2.zero;
            touched = false;
            joystick.SetActive(false);

        }
    }

    public Vector2 GetDirection() {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
