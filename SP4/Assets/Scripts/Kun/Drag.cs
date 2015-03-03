using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    Ray ray;
    RaycastHit rayhit;
    private Vector3 offset;

	public Texture2D cursorTexture;
	public Texture2D cursorTexture2;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotspot = Vector2.zero;
	//private bool drag = false;

	void Update() {
		if (transform.position.z < -5.0f && GameObject.Find("Spawner").GetComponent<Spawner>().control == true) {
			transform.position = new Vector3(transform.position.x, transform.position.y, -5.0f);
		} 		
	}

    void OnMouseEnter() {
		Cursor.SetCursor (cursorTexture, hotspot, cursorMode);
    }

	void OnMouseExit() {
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
	}


    void OnMouseDown() {
        if (GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
        {
			Cursor.SetCursor (cursorTexture2, hotspot, cursorMode);
            //offset = transform.position - GetHitPos();
        }
    }

	void OnMouseUp() {
		Cursor.SetCursor (cursorTexture, hotspot, cursorMode);
	}

    void OnMouseDrag()
    {
        if (GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
        {
            //rigidbody.velocity = Vector3.zero;
            //transform.position = new Vector3(GetHitPos().x + offset.x, GetHitPos().y + offset.y, transform.position.z);
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
