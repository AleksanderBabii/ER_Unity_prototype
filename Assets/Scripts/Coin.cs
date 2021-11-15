using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleHit>() != null)
        {
            Destroy(gameObject);
            return;
        }
        // Check that the object we colided with is the player
        if (other.gameObject.name != "Car")
        {
            return;
        }
        // Add to the players score
        GameManager.inst.IncrementScore();

        // Destroy Coin
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
           
    }
}
