using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int CurrentWeapon = 0;
    public int previousweapon;

    public GameObject CurrentGun;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {

        previousweapon = CurrentWeapon;


        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(CurrentWeapon >= transform.childCount - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }

        if(previousweapon != CurrentWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == CurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
                CurrentGun = weapon.gameObject;
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void SelectPurchasedWeapon()
    {

        if (CurrentWeapon >= transform.childCount - 1)
        {
            CurrentWeapon = 0;
        }
        else
        {
            CurrentWeapon++;
        }

        if (previousweapon != CurrentWeapon)
        {
            SelectWeapon();
        }

    }

}
