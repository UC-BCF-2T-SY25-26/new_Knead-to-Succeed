using UnityEngine;

public class PrefabHolder : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}