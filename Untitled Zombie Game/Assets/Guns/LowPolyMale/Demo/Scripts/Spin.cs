using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Spin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isSpinLeft;
    public Transform spinObject;
    public float speed = 1f;

    bool canSpin = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        canSpin = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canSpin = false;
    }

    void Update()
    {
        if (!canSpin)
            return;

        if (isSpinLeft)
        {
            spinObject.Rotate(0f, -speed, 0f, Space.Self);
        }
        else
        {
            spinObject.Rotate(0f, speed, 0f, Space.Self);
        }
    }
}
