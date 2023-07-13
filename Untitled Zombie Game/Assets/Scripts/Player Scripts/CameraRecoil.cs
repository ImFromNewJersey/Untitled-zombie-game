using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{

    [Header("Recoil")]
    private Vector3 currentRotation;
    private bool isAiming;
    private Vector3 targetRotation;
    [Tooltip("Recoil in the X axis."), SerializeField]
    private float RecoilX;
    [Tooltip("Recoil in the Y axis."), SerializeField]
    private float RecoilY;
    [Tooltip("Recoil in the Z axis."), SerializeField]
    private float RecoilZ;

    [Tooltip("ADSRecoil in the X axis."), SerializeField]
    private float ADSRecoilX;
    [Tooltip("ADSRecoil in the Y axis."), SerializeField]
    private float ADSRecoilY;
    [Tooltip("ADSRecoil in the Z axis."), SerializeField]
    private float ADSRecoilZ;

    [Tooltip("Recoil snapiness."), SerializeField]
    private float Snap;
    [Tooltip("Recoil return speed."), SerializeField]
    private float returnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Snap * Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Snap * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void ShotRecoil()
    {
        if(Input.GetMouseButton(1))
            targetRotation += new Vector3(ADSRecoilX, Random.Range(-ADSRecoilY, ADSRecoilY), Random.Range(-ADSRecoilZ, ADSRecoilZ));
        else
            targetRotation += new Vector3(RecoilX, Random.Range(-RecoilY, RecoilY), Random.Range(-RecoilZ, RecoilZ));
    }

}
