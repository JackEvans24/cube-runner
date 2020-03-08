using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider collider) {
        Debug.Log(collider.name);

        if (collider.name != "Player")
            return;
        
        gameManager.CompleteLevel();
    }
}
