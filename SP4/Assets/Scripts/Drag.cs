using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    Ray ray;
    RaycastHit rayhit;

    void OnMouseDrag()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayhit)) {
            transform.position = new Vector3(rayhit.point.x, rayhit.point.y, transform.position.z);
        }
    }
}
