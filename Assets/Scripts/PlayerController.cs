using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform model;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector3 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        rb.constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotateModel();
    }

    void MovePlayer()
    {
        if (cameraTransform == null) return;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection =
            forward * moveInput.z +
            right * moveInput.x;

        rb.linearVelocity =
            moveDirection * moveSpeed +
            new Vector3(0, rb.linearVelocity.y, 0);
    }

    void RotateModel()
    {
        if (model == null) return;

        Vector3 horizontalVelocity =
            new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (horizontalVelocity.sqrMagnitude > 0.01f)
        {
            model.rotation =
                Quaternion.LookRotation(horizontalVelocity);
        }
    }
}