using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchAreaButton : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler {
    
    private bool touched;
    private int pointerID;

    private void Awake() {

#if !UNITY_ANDROID
        this.gameObject.SetActive(false);
#endif
        touched = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (!touched) {
            touched = true;
            pointerID = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (eventData.pointerId == pointerID) {
            touched = false;
        }
    }

    public bool IsTouched() {
        return touched;
    }
}
