using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    bool endless = false;
    System.Diagnostics.Stopwatch watch;

    void Start() {
        endless = GetComponent<GameManager>().endlessMode;
        watch = System.Diagnostics.Stopwatch.StartNew();
    }

    // Update is called once per frame
    void Update()
    {
        if (endless) {
            scoreText.text = (watch.ElapsedMilliseconds / 60).ToString();
        }
        else
            scoreText.text = player.position.z.ToString("0");
    }
}
