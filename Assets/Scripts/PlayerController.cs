using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public Transform model; // drag the child model here

    private Rigidbody rb;
    private Vector3 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        // Freeze ALL physics rotation
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        // Move with physics
        rb.linearVelocity = new Vector3(
            moveInput.x * moveSpeed,
            rb.linearVelocity.y,
            moveInput.z * moveSpeed
        );

        // Rotate ONLY the visual model
        if (moveInput.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            model.rotation = Quaternion.Slerp(
                model.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );
        }
    }
}
