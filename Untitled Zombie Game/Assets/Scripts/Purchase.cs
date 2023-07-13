using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;



public class Purchase : MonoBehaviour
{

    public GameObject PurchasableGun;
    GameObject Gun;
    public GameObject EventManager;
    public GameObject Holster;
    public TextMeshProUGUI PurchaseUI;

    bool OneGun = true;

    public int purchaseprice;

    private void Start()
    {

        PurchaseUI.enabled = false;

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            PurchaseUI.enabled = true;
            PurchaseUI.GetComponentInChildren<TextMeshProUGUI>().SetText("Purchase: " + purchaseprice.ToString());

            if (Input.GetKeyDown("e"))
            {
                if (EventManager.GetComponent<Score>().score >= purchaseprice)
                {
                    if (OneGun)
                    {
                        EventManager.GetComponent<Score>().score -= purchaseprice;
                        StartCoroutine(FirstBuy());
                        GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        EventManager.GetComponent<Score>().score -= purchaseprice;
                        StartCoroutine(Buy());
                        GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PurchaseUI.enabled = false;
        }
    }

    IEnumerator Buy()
    {
        Destroy(GameObject.FindWithTag("Holster").GetComponent<SwitchWeapon>().CurrentGun);
        Gun = Instantiate(PurchasableGun);
        Gun.transform.SetParent(Holster.transform);
        Gun.transform.localPosition = new Vector3 (0.3000012f, -0.1433333f, 0.4120007f);
        Gun.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        Gun.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.FindWithTag("Holster").GetComponent<SwitchWeapon>().SelectPurchasedWeapon();
        yield return new WaitForSeconds(.1f);
    }

    IEnumerator FirstBuy()
    {
        Gun = Instantiate(PurchasableGun);
        Gun.transform.SetParent(Holster.transform);
        Gun.transform.localPosition = new Vector3(0.3000012f, -0.1433333f, 0.4120007f);
        Gun.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        Gun.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.FindWithTag("Holster").GetComponent<SwitchWeapon>().SelectPurchasedWeapon();
        yield return new WaitForSeconds(.1f);
        OneGun = false;
    }

}
