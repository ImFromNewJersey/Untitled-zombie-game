using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{

    public GameObject SwayBone;

    public float amount;
    public float smoothamount;
    public float maxAmount;
    public float ADSAmount;
    Vector3 initialPos;
    Vector3 finalPos;

    public float rotationAmount;
    public float maxRotationAmount;
    public float smoothRotation;
    private Quaternion initialRotation;
    Quaternion finalRotation;

    public bool rotationX = true;
    public bool rotationY = true;
    public bool rotationZ = true;


    private float inputX;
    private float inputY;

    void Start()
    {
        initialPos = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CalculateSway();
            MoveSway(ADSAmount);
            tiltSway(ADSAmount);
        }
        CalculateSway();
        MoveSway(maxAmount);
        tiltSway(maxRotationAmount);
    }

    void CalculateSway()
    {
        inputX = -Input.GetAxis("Mouse X");
        inputY = -Input.GetAxis("Mouse Y");
    }

    void MoveSway(float maxAmount)
    {
        float movementX = Mathf.Clamp(inputX * amount, -maxAmount, maxAmount);
        float movementY = Mathf.Clamp(inputY * amount, -maxAmount, maxAmount);

        finalPos = new Vector3(movementX, movementY, 0);
        SwayBone.transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + initialPos, Time.deltaTime * smoothamount);
    }


    void tiltSway(float maxRotationAmount)
    {
        float TiltY = Mathf.Clamp(inputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float TiltX = Mathf.Clamp(inputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

        finalRotation = Quaternion.Euler(new Vector3(rotationX ? -TiltX : 0f,rotationY ? TiltY : 0, rotationZ ? TiltY : 0));
        SwayBone.transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothRotation);
    }

    void ReturnToOrigin()
    {
        SwayBone.transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation, Time.deltaTime * smoothRotation);
        SwayBone.transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, Time.deltaTime * smoothamount);
    }

}
