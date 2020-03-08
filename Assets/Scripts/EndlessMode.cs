using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    public GameManager gameManager;
    public Transform obstaclePrefab;
    public float forwardForce;
    public int waitInterval = 30;
    int realWaitInterval;
    int ticker = 0;
    int intervalTicker = 0;

    void Start() {
        realWaitInterval = waitInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var obstacles = FindObjectsOfType<Rigidbody>()
                            .Where(r => r.tag == "Obstacle");

        if (gameManager.gameHasEnded) {
            foreach (var ob in obstacles)
            {
                ob.velocity = Vector3.zero;
                ob.angularVelocity = Vector3.zero;
            }
            return;
        }

        foreach (var ob in obstacles) {
            if (ob.position.z < -10)
                Destroy(ob.gameObject);
            ob.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (ticker < realWaitInterval)
            ticker++;
        else {
            forwardForce++;
            intervalTicker++;
            if (intervalTicker > 5)
                waitInterval--;

            ticker = 0;
            SpawnObstacles();            
        }
    }

    bool spawning = false;
    void SpawnObstacles() {
        if (spawning)
            return;

        var rnd = new System.Random();
        foreach (var spawnLocation in spawnLocations[rnd.Next(spawnLocations.Count)])
            Instantiate(obstaclePrefab, new Vector3(spawnLocation, 1f, 150f), Quaternion.identity);
        
        realWaitInterval = waitInterval + rnd.Next(-20, 20);
    }

    List<List<float>> spawnLocations = new List<List<float>> {
        new List<float>() { -4f },
        new List<float>() { -2f },
        new List<float>() { 0f },
        new List<float>() { 2f },
        new List<float>() { 4f },
        new List<float>() { -6f, 6f },
        new List<float>() { -4f, 4f },
        new List<float>() { -1f, 1f },
        new List<float>() { -6f, -3f },
        new List<float>() { 6f, 3f },
        new List<float>() { -6f, 0f, 6f }
    };
}
