using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    Ray ray;
    RaycastHit rayhit;
    private Vector3 offset;

	void Update() {
		if (transform.position.z < -5.0f && GameObject.Find("Spawner").GetComponent<Spawner>().control == true) {
			transform.position = new Vector3(transform.position.x, transform.position.y, -5.0f);
		} 		
	}

    void OnMouseOver() {
//        if (GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
//        {
//            Vector3 axis = new Vector3(1.0f, 0.0f, 0.0f);
//            transform.Rotate(axis, 20);
//        }
    }

    void OnMouseDown() {
        if (GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
        {
            offset = transform.position - GetHitPos();
        }
    }

    void OnMouseDrag()
    {
        if (GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = new Vector3(GetHitPos().x + offset.x, GetHitPos().y + offset.y, transform.position.z);
        }
    }

    Vector3 GetHitPos() {
        Plane plane = new Plane(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
}
