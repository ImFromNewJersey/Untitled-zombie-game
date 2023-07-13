using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraSetPos : MonoBehaviour
{
    public Transform ObjectToMove;
    [Range(0.01f, 2f)]
    public float Speed = 0.5f;

    //

    public Vector3 Default_Position;
    public Vector3 Head_Position;
    public Vector3 Torso_Position;
    public Vector3 Legs_Position;
    public Vector3 Feet_Position;

    //

    public Button[] button_cameraViews;

    //

    bool IsMoving = false;

    //

    public void Start()
    {
        SetupListeners();
    }

    void SetupListeners()
    {
        for (int i = 0; i < button_cameraViews.Length; i++)
        {
            int k = i;

            button_cameraViews[k].onClick.AddListener(delegate { ChangePosition(k); });
        }
    }

    //

    public void ChangePosition(int ViewID)
    {
        if (IsMoving)
            return;

        switch (ViewID)
        {
            case 0:
                {
                    StartCoroutine(StartChangePosition(Default_Position, Speed));
                }
                break;
            case 1:
                {
                    StartCoroutine(StartChangePosition(Head_Position, Speed));
                }
                break;
            case 2:
                {
                    StartCoroutine(StartChangePosition(Torso_Position, Speed));
                }
                break;
            case 3:
                {
                    StartCoroutine(StartChangePosition(Legs_Position, Speed));
                }
                break;
            case 4:
                {
                    StartCoroutine(StartChangePosition(Feet_Position, Speed));
                }
                break;
        }
    }

    IEnumerator StartChangePosition(Vector3 position, float speed)
    {
        IsMoving = true;

        float timeElapsed = 0f;
        while (timeElapsed < speed)
        {
            ObjectToMove.position = Vector3.Lerp(ObjectToMove.position, position, (timeElapsed / speed));
            timeElapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        ObjectToMove.position = position;
        IsMoving = false;
    }
}

