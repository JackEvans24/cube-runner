using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a ref to the Rigidbody component set in Unity
    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 500f;

    float horizontalMovement;

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    // We used FixedUpdate instead of Update because Unity prefers this method when messing with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (horizontalMovement > 0)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (horizontalMovement < 0)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
