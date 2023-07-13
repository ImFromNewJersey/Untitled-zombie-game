using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI ScoreDisplayHUD;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplayHUD.text = score.ToString();
    }
}
