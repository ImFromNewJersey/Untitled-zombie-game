using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("The main camera."), SerializeField]
    private Camera FPSCam;

    [Header("Gun Attributes")]
    [Tooltip("How much damage the gun does per shot."), SerializeField]
    private float damage = 10f;
    [Tooltip("How far bullets travel before disappearing."), SerializeField]
    private float range = 100f;
    [Tooltip("How hard bullets impact entities."), SerializeField]
    private float impactforce = 30f;
    [Tooltip("How fast the gun fires."), SerializeField]
    private float firerate = 30f;
    [Tooltip("Maximum ammo for this gun."), SerializeField]
    private int MaxAmmo = 10;
    [Tooltip("Current ammo of the weapon.")]
    private int currentammo;
    [Tooltip("Time to reload."), SerializeField]
    private float reloadTime = 1f;
    [Tooltip("True while the player is reloading.")]
    private bool isreloading = false;
    [Tooltip("Default FOV."), SerializeField]
    private float DefaultFOV = 60f;
    [Tooltip("FOV while aiming."), SerializeField]
    private float AimFOV = 45f;
    [Tooltip("Time to aim for gun."), SerializeField]
    private float AimTime = 5f;

    [Header("Recoil Atributes")]
    [Tooltip("How much damage the gun does per shot."), SerializeField]
    public Transform recoilPosition;
    public Transform rotationPoint;
    public float positionalRecoilSpeed = 8f;
    public float rotationalRecoilSpeed = 8f;
    public float positionalReturnSpeed = 18f;
    public float rotationalReturnSpeed = 38f;
    public Vector3 RecoilRotation = new Vector3(10, 5, 7);
    public Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);
    public Vector3 RecoilRotationAim = new Vector3(10, 4, 6);
    public Vector3 RecoilKickBackAim = new Vector3(0.015f, 0f, -0.2f);
    Vector3 rotationalRecoil;
    Vector3 positionalRecoil;
    Vector3 Rot;

    [Header("Gun VFX")]
    [Tooltip("MuzzleFlash particle."), SerializeField]
    private ParticleSystem MuzzleFlash;
    [Tooltip("Impact particle."), SerializeField]
    private GameObject impacteffect;
    [Tooltip("Gun Reticle."), SerializeField]
    private Image Reticle;

    [Header("Gun SFX")]
    [Tooltip("Firing SFX."), SerializeField]
    private AudioSource FireSound;
    [Tooltip("Reloading SFX."), SerializeField]
    private AudioSource reloadsound;
    [Tooltip("How much the pitch changes each shot."), SerializeField]
    private float pitchchange;


    [Header("Gun Animations")]
    [Tooltip("Gun Animator."), SerializeField]
    private Animator animator;
    [Tooltip("Time between shots."), SerializeField]
    private float nextTimeToFire = 0f;
    [Tooltip("original position of gun."), SerializeField]
    private Vector3 OriginalPos;
    [Tooltip("Where the gun moves while zooming."), SerializeField]
    private Vector3 Zoomposition;
    [Tooltip("Smooths aiming."), SerializeField]
    private float ADSSmoothing;
    [Tooltip("Heads up Display."), SerializeField]
    TextMeshProUGUI ammoDisplayHUD;

    [Tooltip("Recoil Script location."), SerializeField]
    private CameraRecoil recoilScript;
    private void Start()
    {
        //Instantiating Variables
        currentammo = MaxAmmo;
        OriginalPos = transform.localPosition;
    }


    void Update()
    {
        GunHandler();
        UpdateHud();
    }

    private void FixedUpdate()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
        positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime);

        recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.deltaTime);
        rotationPoint.localRotation = Quaternion.Euler(Rot);
    }

    void OnEnable()
    {
        isreloading = false;
        animator.SetBool("Reloading", false);
    }

    void GunHandler()
    {
        //Aims down sights when player is eligible to aim
        if (Input.GetMouseButton(1) && !isreloading)
        {
            animator.SetBool("Aiming", true);
            Reticle.enabled = false;
            FPSCam.fieldOfView = Mathf.Lerp(FPSCam.fieldOfView, AimFOV, AimTime * Time.deltaTime);
        }
        //otherwise keep player in hipfire
        else
        {
            animator.SetBool("Aiming", false);
            FPSCam.fieldOfView = Mathf.Lerp(FPSCam.fieldOfView, DefaultFOV, AimTime * Time.deltaTime);
            Reticle.enabled = true;
        }
        //Prevents audio from bugging if you run out of ammo
        if (isreloading)
        {
            return;
        }
        //If ammo runs our or reload button is hit, run reload();
        if (currentammo <= 0)
        {
            StartCoroutine(reload());
            return;
        }
        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(reload());
            return;
        }
        //If the fire button is pressed and enough time has passed between the next time to fire
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            //Sets nextTimeToFire to increase and fire weapon
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
            recoilScript.ShotRecoil();
        }
    }
    //handles firing of weapon and calling of scripts on applicable entities
    void Shoot()
    {
        //handles Animation and FX
        animator.SetTrigger("Firing");
        recoilFire();
        MuzzleFlash.Play();
        FireSound.Play();
        FireSound.pitch = UnityEngine.Random.Range(1.0f - pitchchange, 1.0f + pitchchange);
        currentammo--;
        //creates a raycast for each "bullet"
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            /*debug info
            Debug.DrawRay(FPSCam.transform.position, hit.collider.transform.position, Color.red);
            Debug.Log(hit.collider.name);
            */

            //accesses the target script from any enemies hit
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                //calls target takedamage function if they are still present
                target.TakeDamage(damage);
            }
            //if the ray hits a rigidbody (ragdolled enemy), applies force to their body
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }
            //creates an impact FX and destroys it after 2 seconds
            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    void recoilFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rotationalRecoil += new Vector3(-RecoilRotationAim.x, Random.Range(-RecoilRotationAim.y, RecoilRotationAim.y), Random.Range(-RecoilRotationAim.z, RecoilRotationAim.z));
            positionalRecoil += new Vector3(Random.Range(-RecoilKickBackAim.x, RecoilKickBackAim.x), Random.Range(-RecoilKickBackAim.y, RecoilKickBackAim.y), RecoilKickBackAim.z);

        }
        else
        {
            rotationalRecoil += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
            rotationalRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);
        }
    }
    //Handles reloading in a IEnumerator to allow halting of actions during animation
    IEnumerator reload()
    {
        //sets reloading to true and plays reloading sound
        isreloading = true;
        reloadsound.Play();
        //sets variables for animators while halting actions for the duration of the reload
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        //sets current ammo back to full and reloading to false before returning
        currentammo = MaxAmmo;
        isreloading = false;
    }
    //sets the ammo text to the current amount of ammo and max ammo
    void UpdateHud()
    {
        ammoDisplayHUD.text = (currentammo.ToString() + "/" + MaxAmmo.ToString());
    }

}
