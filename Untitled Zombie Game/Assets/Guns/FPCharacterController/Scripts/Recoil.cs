using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    public float rotationspeed = 6f;
    public float returnspeed = 25f;

    public Vector3 recoilrotation = new Vector3(2f, 2f, 2f);

    public Vector3 recoilrotationaiming = new Vector3(0.5f, 0.5f, 1.5f);

    public bool aiming;

    private Vector3 currentRotation;
    private Vector3 rot;


    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnspeed * Time.deltaTime);
        rot = Vector3.Slerp(rot, currentRotation, rotationspeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(rot);
    }

    public void Fire()
    {
        if (aiming)
        {
            currentRotation += new Vector3(-recoilrotationaiming.x, Random.Range(-recoilrotationaiming.y, recoilrotationaiming.y), Random.Range(-recoilrotationaiming.z, recoilrotationaiming.z));
        }
        else
        {
            currentRotation += new Vector3(-recoilrotation.x, Random.Range(-recoilrotation.y, recoilrotation.y), Random.Range(-recoilrotation.z, recoilrotation.z));
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }
    }
}
