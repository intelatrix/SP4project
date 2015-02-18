using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    Ray ray;
    RaycastHit rayhit;
    private Vector3 offset;

    void OnMouseOver() {
        Vector3 axis = new Vector3(1.0f, 0.0f, 0.0f);
        transform.Rotate(axis, 20);
    }

    void OnMouseDown() {
        offset = transform.position - GetHitPos();
    }

    void OnMouseDrag()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(GetHitPos().x + offset.x, GetHitPos().y + offset.y, transform.position.z);
    }

    Vector3 GetHitPos() {
        Plane plane = new Plane(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
}
