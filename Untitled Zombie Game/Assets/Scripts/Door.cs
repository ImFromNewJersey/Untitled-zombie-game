using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject EventManager;
    public TextMeshProUGUI PurchaseUI;
    public int purchaseprice;


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
                    GameObject.FindWithTag("Game Manager").GetComponent<Score>().score -= purchaseprice;
                    Destroy(gameObject, 0);
                    PurchaseUI.enabled = false;
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

}
