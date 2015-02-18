using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float maxDist;
	public float inFront = 0.001f;
	public GameObject hitWall;
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, maxDist)) 
		{

			if(hit.transform.tag == "Wall")
			{
				Instantiate(hitWall, hit.point + (hit.normal * inFront), Quaternion.LookRotation(hit.normal));
				Destroy (gameObject);
			}

		}


	}
}
