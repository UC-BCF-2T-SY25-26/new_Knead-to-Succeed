using UnityEngine;

public class ClickDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[GLOBAL CLICK DETECTED]");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("[ONMOUSEDOWN WORKS]");
    }
}