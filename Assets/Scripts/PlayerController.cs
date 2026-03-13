using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.W))
            z += 1f;

        if (Input.GetKey(KeyCode.S))
            z -= 1f;

        if (Input.GetKey(KeyCode.A))
            x -= 1f;

        if (Input.GetKey(KeyCode.D))
            x += 1f;

        // Calculate movement vector
        Vector3 move = new Vector3(x, 0f, z);

        // If there's any movement, rotate the player to face the direction
        if (move.magnitude > 0f)
        {
            // Normalize the move vector to avoid diagonal movement being faster
            move.Normalize();

            // Rotate the character to face the movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 10f);
        }

        // Move the player
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}