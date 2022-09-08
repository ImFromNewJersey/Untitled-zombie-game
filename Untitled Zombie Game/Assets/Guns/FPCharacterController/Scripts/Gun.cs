using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    Camera FPSCam;
    public ParticleSystem MuzzleFlash;
    GameObject impacteffect;
    public float impactforce = 30f;
    public float firerate = 30f;
    public AudioSource FireSound;
    public float pitchchange;
    public int MaxAmmo = 10;
    private int currentammo;
    public float reloadTime = 1f;
    private bool isreloading = false;
    public Animator animator;
    public AudioSource reloadsound;
    private float nextTimeToFire = 0f;
    public Vector3 Zoomposition;
    public float ADSSmoothing;
    private Vector3 OriginalPos;
    Image Reticle;
    TextMeshProUGUI ammoDisplayHUD;
    float DefaultFOV = 60f;
    public float AimFOV = 45f;
    public float AimTime = 5f;

    private void Start()
    {
        currentammo = MaxAmmo;
        OriginalPos = transform.localPosition;

        Reticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Image>();
        ammoDisplayHUD = GameObject.FindGameObjectWithTag("Ammo Count").GetComponent<TextMeshProUGUI>();
        FPSCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        impacteffect = GameObject.FindGameObjectWithTag("ImpactFX");
    }


    void Update()
    {

        ammoDisplayHUD.text = (currentammo.ToString() + "/" + MaxAmmo.ToString());

        if (Input.GetMouseButton(1) && !isreloading)
        {
            Ads();
        }
        else
        {
            animator.SetBool("Aiming", false);
            FPSCam.fieldOfView = Mathf.Lerp(FPSCam.fieldOfView, DefaultFOV, AimTime * Time.deltaTime);
            Reticle.enabled = true;
        }

        if (isreloading)
        {
            return;
        }

        if(currentammo <= 0)
        {
            StartCoroutine(reload());
            return;
        }

        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
            GameObject.FindGameObjectWithTag("Recoil").GetComponent<Recoil>().Fire();
        }
    }

    void OnEnable()
    {
        isreloading = false;
        animator.SetBool("Reloading", false);
    }

    void Shoot()
    {
        animator.SetTrigger("Shooting");    
        MuzzleFlash.Play();
        FireSound.Play();
        currentammo--;
        FireSound.pitch = UnityEngine.Random.Range(1.0f - pitchchange, 1.0f + pitchchange);
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {

            Debug.DrawRay(FPSCam.transform.position, hit.collider.transform.position, Color.red);
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(hit.collider.name);
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }

            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    IEnumerator reload()
    {
        isreloading = true;
        reloadsound.Play();

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);
        currentammo = MaxAmmo;
        isreloading = false;
    }

    void Ads()
    {
        animator.SetBool("Aiming", true);
        Reticle.enabled = false;
        FPSCam.fieldOfView = Mathf.Lerp(FPSCam.fieldOfView, AimFOV, AimTime * Time.deltaTime);
    }

}
