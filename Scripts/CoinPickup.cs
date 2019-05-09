using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinScore = 100;
    


    private void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<GameSession>().AddToScore(coinScore);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
