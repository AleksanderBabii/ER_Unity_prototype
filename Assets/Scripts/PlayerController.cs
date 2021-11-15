using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private float speed = 35.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;

        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();
        }
        verticalInput = Input.GetAxis("Vertical");

        // Moves the car forweard.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Rotate the car.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
    public void Die()
    {
        alive = false;
        // Restert the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}