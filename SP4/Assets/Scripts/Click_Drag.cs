using UnityEngine;
using System.Collections;

public class Click_Drag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log(onObject(100));
    }

    GameObject onObject(float distance)
    {
        Vector3 objPos = gameObject.transform.position;
        RaycastHit ray;
        Vector3 target = objPos + Camera.main.transform.forward * distance;
        if (Physics.Linecast(objPos, target, out ray))
        {
            return ray.collider.gameObject;
        }
        return null;
    }
}
