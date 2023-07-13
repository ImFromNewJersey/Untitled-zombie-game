using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public int wave;
    public bool waveended;

    public int ZombiesSpawned;
    public float MaxZombies = 15f;
    public float health = 100f;

    public TextMeshProUGUI WaveText;

    void Start()
    {
        wave = 1;
        WaveText.SetText(wave.ToString());
    }

    private void Update()
    {
        if (waveended)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        ZombiesSpawned = 0;
        wave++;
        health *= 1.2f;
        MaxZombies *= 1.2f;
        WaveText.SetText(wave.ToString());
        waveended = false;
    }

}
