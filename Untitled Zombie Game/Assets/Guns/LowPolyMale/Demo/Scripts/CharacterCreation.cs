using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterCreation : MonoBehaviour
{
    [Header("Mesh")]

    public SkinnedMeshRenderer[] mesh_hair;
    public SkinnedMeshRenderer[] mesh_eyebrows;
    public SkinnedMeshRenderer[] mesh_eyes;
    public SkinnedMeshRenderer[] mesh_facialHair;
    public SkinnedMeshRenderer[] mesh_hat;
    public SkinnedMeshRenderer[] mesh_glasses;
    public SkinnedMeshRenderer[] mesh_torso;
    public SkinnedMeshRenderer[] mesh_jacket;
    public SkinnedMeshRenderer[] mesh_hands;
    public SkinnedMeshRenderer[] mesh_legs;
    public SkinnedMeshRenderer[] mesh_feet;
    public SkinnedMeshRenderer[] mesh_outfits;
    public SkinnedMeshRenderer[] mesh_armour;

    [Header("UI")]
    public Button[] button_prev;
    public Button[] button_next;
    public Button[] button_reset;

    public Button ChangePartsButton;
    public Button ChangeColourButton;
    public GameObject[] ChangePanels;

    public Material BodyMaterial;
    public BodyColour[] bodyColours;


    // Current Id's
    int ID_hair = -1;
    int ID_eyebrows = -1;
    int ID_eyes = -1;
    int ID_facialHair = -1;
    int ID_hat = -1;
    int ID_glasses = -1;
    int ID_torso = -1;
    int ID_jacket = -1;
    int ID_hands = -1;
    int ID_legs = -1;
    int ID_feet = -1;
    int ID_outfits = -1;
    int ID_armour = -1;


    public void Start()
    {
        SetupListeners();
    }

    void SetupListeners()
    {
        for (int i = 0; i < button_prev.Length; i++)
        {
            int k = i;

            button_prev[k].onClick.AddListener(delegate { Set_Previous(k); });
        }
        for (int i = 0; i < button_next.Length; i++)
        {
            int k = i;

            button_next[k].onClick.AddListener(delegate { Set_Next(k); });
        }
        for (int i = 0; i < button_reset.Length; i++)
        {
            int k = i;

            button_reset[k].onClick.AddListener(delegate { Reset(k); });
        }

        //

        ChangePartsButton.onClick.AddListener(delegate { OpenPanel(0); });
        ChangeColourButton.onClick.AddListener(delegate { OpenPanel(1); });

        //

        // Hair
        for (int i = 0; i < bodyColours[0].Colours.Length; i++)
        {
            int k = i;

            bodyColours[0].Colours[k].onClick.AddListener(delegate { SetColour(0, k); });
        }
        // Hair2
        for (int i = 0; i < bodyColours[1].Colours.Length; i++)
        {
            int k = i;

            bodyColours[1].Colours[k].onClick.AddListener(delegate { SetColour(1, k); });
        }
        // Skin
        for (int i = 0; i < bodyColours[2].Colours.Length; i++)
        {
            int k = i;

            bodyColours[2].Colours[k].onClick.AddListener(delegate { SetColour(2, k); });
        }
        // Eyes
        for (int i = 0; i < bodyColours[3].Colours.Length; i++)
        {
            int k = i;

            bodyColours[3].Colours[k].onClick.AddListener(delegate { SetColour(3, k); });
        }
        // Mouth
        for (int i = 0; i < bodyColours[4].Colours.Length; i++)
        {
            int k = i;

            bodyColours[4].Colours[k].onClick.AddListener(delegate { SetColour(4, k); });
        }
        // FacialHair
        for (int i = 0; i < bodyColours[5].Colours.Length; i++)
        {
            int k = i;

            bodyColours[5].Colours[k].onClick.AddListener(delegate { SetColour(5, k); });
        }
        // Underwear Top
        for (int i = 0; i < bodyColours[6].Colours.Length; i++)
        {
            int k = i;

            bodyColours[6].Colours[k].onClick.AddListener(delegate { SetColour(6, k); });
        }
        // Underwear Bottom
        for (int i = 0; i < bodyColours[7].Colours.Length; i++)
        {
            int k = i;

            bodyColours[7].Colours[k].onClick.AddListener(delegate { SetColour(7, k); });
        }
    }

    //

    void Set_Previous(int ID)
    {
        switch (ID)
        {
            case 0:
                {
                    ID_hair--;

                    if (ID_hair < 0)
                        ID_hair = mesh_hair.Length - 1;

                    Set_Hair(ID_hair);
                }
                break;
            case 1:
                {
                    ID_eyebrows--;

                    if (ID_eyebrows < 0)
                        ID_eyebrows = mesh_eyebrows.Length - 1;

                    Set_Eyebrows(ID_eyebrows);
                }
                break;
            case 2:
                {
                    ID_eyes--;

                    if (ID_eyes < 0)
                        ID_eyes = mesh_eyes.Length - 1;

                    Set_Eyes(ID_eyes);
                }
                break;
            case 3:
                {
                    ID_facialHair--;

                    if (ID_facialHair < 0)
                        ID_facialHair = mesh_facialHair.Length - 1;

                    Set_FacialHair(ID_facialHair);
                }
                break;
            case 4:
                {
                    ID_hat--;

                    if (ID_hat < 0)
                        ID_hat = mesh_hat.Length - 1;

                    Set_Hat(ID_hat);
                }
                break;
            case 5:
                {
                    ID_glasses--;

                    if (ID_glasses < 0)
                        ID_glasses = mesh_glasses.Length - 1;

                    Set_Glasses(ID_glasses);
                }
                break;
            case 6:
                {
                    ID_torso--;

                    if (ID_torso < 0)
                        ID_torso = mesh_torso.Length - 1;

                    Set_Torso(ID_torso);
                }
                break;
            case 7:
                {
                    ID_jacket--;

                    if (ID_jacket < 0)
                        ID_jacket = mesh_jacket.Length - 1;

                    Set_Jacket(ID_jacket);
                }
                break;
            case 8:
                {
                    ID_hands--;

                    if (ID_hands < 0)
                        ID_hands = mesh_hands.Length - 1;

                    Set_Hands(ID_hands);
                }
                break;
            case 9:
                {
                    ID_legs--;

                    if (ID_legs < 0)
                        ID_legs = mesh_legs.Length - 1;

                    Set_Legs(ID_legs);
                }
                break;
            case 10:
                {
                    ID_feet--;

                    if (ID_feet < 0)
                        ID_feet = mesh_feet.Length - 1;

                    Set_Feet(ID_feet);
                }
                break;
            case 11:
                {
                    ID_outfits--;

                    if (ID_outfits < 0)
                        ID_outfits = mesh_outfits.Length - 1;

                    Set_Outfits(ID_outfits);
                }
                break;
            case 12:
                {
                    ID_armour--;

                    if (ID_armour < 0)
                        ID_armour = mesh_armour.Length - 1;

                    Set_Armour(ID_armour);
                }
                break;
        }
    }
    void Set_Next(int ID)
    {
        switch (ID)
        {
            case 0:
                {
                    ID_hair++;

                    if (ID_hair > mesh_hair.Length - 1)
                        ID_hair = 0;

                    Set_Hair(ID_hair);
                }
                break;
            case 1:
                {
                    ID_eyebrows++;

                    if (ID_eyebrows > mesh_eyebrows.Length - 1)
                        ID_eyebrows = 0;

                    Set_Eyebrows(ID_eyebrows);
                }
                break;
            case 2:
                {
                    ID_eyes++;

                    if (ID_eyes > mesh_eyes.Length - 1)
                        ID_eyes = 0;

                    Set_Eyes(ID_eyes);
                }
                break;
            case 3:
                {
                    ID_facialHair++;

                    if (ID_facialHair > mesh_facialHair.Length - 1)
                        ID_facialHair = 0;

                    Set_FacialHair(ID_facialHair);
                }
                break;
            case 4:
                {
                    ID_hat++;

                    if (ID_hat > mesh_hat.Length - 1)
                        ID_hat = 0;

                    Set_Hat(ID_hat);
                }
                break;
            case 5:
                {
                    ID_glasses++;

                    if (ID_glasses > mesh_glasses.Length - 1)
                        ID_glasses = 0;

                    Set_Glasses(ID_glasses);
                }
                break;
            case 6:
                {
                    ID_torso++;

                    if (ID_torso > mesh_torso.Length - 1)
                        ID_torso = 0;

                    Set_Torso(ID_torso);
                }
                break;
            case 7:
                {
                    ID_jacket++;

                    if (ID_jacket > mesh_jacket.Length - 1)
                        ID_jacket = 0;

                    Set_Jacket(ID_jacket);
                }
                break;
            case 8:
                {
                    ID_hands++;

                    if (ID_hands > mesh_hands.Length - 1)
                        ID_hands = 0;

                    Set_Hands(ID_hands);
                }
                break;
            case 9:
                {
                    ID_legs++;

                    if (ID_legs > mesh_legs.Length - 1)
                        ID_legs = 0;

                    Set_Legs(ID_legs);
                }
                break;
            case 10:
                {
                    ID_feet++;

                    if (ID_feet > mesh_feet.Length - 1)
                        ID_feet = 0;

                    Set_Feet(ID_feet);
                }
                break;
            case 11:
                {
                    ID_outfits++;

                    if (ID_outfits > mesh_outfits.Length - 1)
                        ID_outfits = 0;

                    Set_Outfits(ID_outfits);
                }
                break;
            case 12:
                {
                    ID_armour--;

                    if (ID_armour > mesh_armour.Length - 1)
                        ID_armour = 0;

                    Set_Armour(ID_armour);
                }
                break;
        }
    }
    void Reset(int ID)
    {
        switch (ID)
        {
            case 0:
                {
                    for (int i = 0; i < mesh_hair.Length; i++)
                    {
                        int k = i;

                        mesh_hair[k].enabled = false;
                    }
                }
                break;
            case 1:
                {
                    for (int i = 0; i < mesh_eyebrows.Length; i++)
                    {
                        int k = i;

                        mesh_eyebrows[k].enabled = false;
                    }
                }
                break;
            case 2:
                {
                    for (int i = 0; i < mesh_eyes.Length; i++)
                    {
                        int k = i;

                        mesh_eyes[k].enabled = false;
                    }
                }
                break;
            case 3:
                {
                    for (int i = 0; i < mesh_facialHair.Length; i++)
                    {
                        int k = i;

                        mesh_facialHair[k].enabled = false;
                    }
                }
                break;
            case 4:
                {
                    for (int i = 0; i < mesh_hat.Length; i++)
                    {
                        int k = i;

                        mesh_hat[k].enabled = false;
                    }
                }
                break;
            case 5:
                {
                    for (int i = 0; i < mesh_glasses.Length; i++)
                    {
                        int k = i;

                        mesh_glasses[k].enabled = false;
                    }
                }
                break;
            case 6:
                {
                    for (int i = 0; i < mesh_torso.Length; i++)
                    {
                        int k = i;

                        mesh_torso[k].enabled = false;
                    }
                }
                break;
            case 7:
                {
                    for (int i = 0; i < mesh_jacket.Length; i++)
                    {
                        int k = i;

                        mesh_jacket[k].enabled = false;
                    }
                }
                break;
            case 8:
                {
                    for (int i = 0; i < mesh_hands.Length; i++)
                    {
                        int k = i;

                        mesh_hands[k].enabled = false;
                    }
                }
                break;
            case 9:
                {
                    for (int i = 0; i < mesh_legs.Length; i++)
                    {
                        int k = i;

                        mesh_legs[k].enabled = false;
                    }
                }
                break;
            case 10:
                {
                    for (int i = 0; i < mesh_feet.Length; i++)
                    {
                        int k = i;

                        mesh_feet[k].enabled = false;
                    }
                }
                break;
            case 11:
                {
                    for (int i = 0; i < mesh_outfits.Length; i++)
                    {
                        int k = i;

                        mesh_outfits[k].enabled = false;
                    }
                }
                break;
            case 12:
                {
                    for (int i = 0; i < mesh_armour.Length; i++)
                    {
                        int k = i;

                        mesh_armour[k].enabled = false;
                    }
                }
                break;
        }
    }

    //

    public void Set_Hair(int ID)
    {
        for (int i = 0; i < mesh_hair.Length; i++)
        {
            int k = i;

            mesh_hair[k].enabled = false;
        }

        mesh_hair[ID].enabled = true;
    }

    public void Set_Eyebrows(int ID)
    {
        for (int i = 0; i < mesh_eyebrows.Length; i++)
        {
            int k = i;

            mesh_eyebrows[k].enabled = false;
        }

        mesh_eyebrows[ID].enabled = true;
    }

    public void Set_Eyes(int ID)
    {
        for (int i = 0; i < mesh_eyes.Length; i++)
        {
            int k = i;

            mesh_eyes[k].enabled = false;
        }

        mesh_eyes[ID].enabled = true;
    }

    public void Set_FacialHair(int ID)
    {
        for (int i = 0; i < mesh_facialHair.Length; i++)
        {
            int k = i;

            mesh_facialHair[k].enabled = false;
        }

        mesh_facialHair[ID].enabled = true;
    }

    public void Set_Hat(int ID)
    {
        for (int i = 0; i < mesh_hat.Length; i++)
        {
            int k = i;

            mesh_hat[k].enabled = false;
        }

        mesh_hat[ID].enabled = true;
    }

    public void Set_Glasses(int ID)
    {
        for (int i = 0; i < mesh_glasses.Length; i++)
        {
            int k = i;

            mesh_glasses[k].enabled = false;
        }

        mesh_glasses[ID].enabled = true;
    }

    public void Set_Torso(int ID)
    {
        for (int i = 0; i < mesh_torso.Length; i++)
        {
            int k = i;

            mesh_torso[k].enabled = false;
        }

        mesh_torso[ID].enabled = true;
    }

    public void Set_Jacket(int ID)
    {
        for (int i = 0; i < mesh_jacket.Length; i++)
        {
            int k = i;

            mesh_jacket[k].enabled = false;
        }

        mesh_jacket[ID].enabled = true;
    }

    public void Set_Hands(int ID)
    {
        for (int i = 0; i < mesh_hands.Length; i++)
        {
            int k = i;

            mesh_hands[k].enabled = false;
        }

        mesh_hands[ID].enabled = true;
    }

    public void Set_Legs(int ID)
    {
        for (int i = 0; i < mesh_legs.Length; i++)
        {
            int k = i;

            mesh_legs[k].enabled = false;
        }

        mesh_legs[ID].enabled = true;
    }

    public void Set_Feet(int ID)
    {
        for (int i = 0; i < mesh_feet.Length; i++)
        {
            int k = i;

            mesh_feet[k].enabled = false;
        }

        mesh_feet[ID].enabled = true;
    }

    public void Set_Outfits(int ID)
    {
        Reset(4);
        Reset(5);
        Reset(6);
        Reset(7);
        Reset(8);
        Reset(9);
        Reset(10);
        Reset(12);

        for (int i = 0; i < mesh_outfits.Length; i++)
        {
            int k = i;

            mesh_outfits[k].enabled = false;
        }

        mesh_outfits[ID].enabled = true;
    }

    public void Set_Armour(int ID)
    {
        for (int i = 0; i < mesh_armour.Length; i++)
        {
            int k = i;

            mesh_armour[k].enabled = true;
        }
    }

    //

    public void OpenPanel(int PanelToOpen)
    {
        for (int i = 0; i < ChangePanels.Length; i++)
        {
            int k = i;

            ChangePanels[k].SetActive(false);
        }

        ChangePanels[PanelToOpen].SetActive(true);
    }

    public void SetColour(int BodyColourID, int ColourID)
    {
        switch (BodyColourID)
        {
            // Hair
            case 0:
                {
                    BodyMaterial.SetColor("_ColourHair", bodyColours[0].Colours[ColourID].colors.normalColor);
                }
                break;

            // Hair 2
            case 1:
                {
                    BodyMaterial.SetColor("_ColourHair2", bodyColours[1].Colours[ColourID].colors.normalColor);
                }
                break;

            // Skin
            case 2:
                {
                    BodyMaterial.SetColor("_ColourSkin", bodyColours[2].Colours[ColourID].colors.normalColor);
                }
                break;

            // Eyes
            case 3:
                {
                    BodyMaterial.SetColor("_ColourEyes", bodyColours[3].Colours[ColourID].colors.normalColor);
                }
                break;

            // Mouth
            case 4:
                {
                    BodyMaterial.SetColor("_ColourMouth", bodyColours[4].Colours[ColourID].colors.normalColor);
                }
                break;

            // Facial Hair
            case 5:
                {
                    BodyMaterial.SetColor("_ColourFaceHair", bodyColours[5].Colours[ColourID].colors.normalColor);
                }
                break;

            // Underwear Top
            case 6:
                {
                    BodyMaterial.SetColor("_ColourUnderwearT", bodyColours[6].Colours[ColourID].colors.normalColor);
                }
                break;

            // Underwear Bottom
            case 7:
                {
                    BodyMaterial.SetColor("_ColourUnderwearB", bodyColours[7].Colours[ColourID].colors.normalColor);
                }
                break;
        }
    }

    // Not Setup. This is used to Demo how to change Colour for an Attire Items Material!
    public void SetAttireColour(Material AttireMaterial, int MaskArea, Color Colour)
    {
        switch (MaskArea)
        {
            case 0:
                {
                    AttireMaterial.SetColor("_MaskColour1", Colour);
                }
                break;

            case 1:
                {
                    AttireMaterial.SetColor("_MaskColour2", Colour);
                }
                break;

            case 2:
                {
                    AttireMaterial.SetColor("_MaskColour3", Colour);
                }
                break;

            case 3:
                {
                    AttireMaterial.SetColor("_MaskColour4", Colour);
                }
                break;
        }
    }
}

[System.Serializable]
public class BodyColour
{
    public string Name;
    public Button[] Colours;
}
