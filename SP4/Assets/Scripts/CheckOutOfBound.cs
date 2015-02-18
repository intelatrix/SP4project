using UnityEngine;
using System.Collections;

public class CheckOutOfBound : MonoBehaviour {
    
    public GameObject rightPlank;
    public GameObject leftPlank;
    
    private GameObject obj = null;

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "Obj") {
                    obj = hit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (obj != null)
            {
                Vector3 newVector = rightPlank.transform.position - obj.transform.position;

                float dotproduct = Vector3.Dot(newVector, rightPlank.transform.position);

                Vector3 newVector2 = leftPlank.transform.position - obj.transform.position;

                float dotproduct2 = Vector3.Dot(newVector2, leftPlank.transform.position);

                if ((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings>().getActive())
                {
                    Debug.Log("Hi");
                }
            }
            obj = null;
        }

        //if (Vector3.Magnitude(rightPlank.transform.position - obj.transform.position) > Vector3.Dot(obj.transform.position, rightPlank.transform.position)) {
        //    Debug.Log("Hi");
        //}
	}
}
