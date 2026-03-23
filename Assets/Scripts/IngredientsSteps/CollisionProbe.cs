using UnityEngine;

public class CollisionProbe : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🔥 TRIGGER ENTER on " + gameObject.name + " hit " + other.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("💥 COLLISION on " + gameObject.name + " hit " + collision.gameObject.name);
    }
}