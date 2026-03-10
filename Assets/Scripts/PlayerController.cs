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

        Vector3 move = new Vector3(x, 0f, z);
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}