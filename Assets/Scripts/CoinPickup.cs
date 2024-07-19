using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    // Coin point's worth:
    [SerializeField] int coinPointWorth = 5;

    // The coin will be destroyed when the player comes in contact with it:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // FindObjectType calls a 'cs' file and will then call the method within it:
        // This will then change the text to the amount of points the player has collected:
        FindObjectOfType<GameSession>().AddToScore(coinPointWorth);

        // When player picks up a coin, it will play a sfx at where the coin was:
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);

        // Destroys the coin (game object):
        Destroy(gameObject);   
    }
}
