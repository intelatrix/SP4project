using UnityEngine;
using System.Collections;

public class CheckOutOfBound : MonoBehaviour {
    
    public GameObject rightPlank;
    public GameObject leftPlank;
    
    private GameObject obj = null;
    private int numOfCorrect = 2;

	private bool gameover = false;

	void Start() {
		numOfCorrect = GameObject.Find ("Spawner").GetComponent<Spawner> ().setCorrectNo;
	}

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Spawner").GetComponent<Spawner>().control == true) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "Obj") {
                    obj = hit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && GameObject.Find("Spawner").GetComponent<Spawner>().control == true)
        {
            if (numOfCorrect > 0)
            {
                if (obj != null)
                {
                    Vector3 newVector = rightPlank.transform.position - obj.transform.position;

                    float dotproduct = Vector3.Dot(newVector, rightPlank.transform.position);

                    Vector3 newVector2 = leftPlank.transform.position - obj.transform.position;

                    float dotproduct2 = Vector3.Dot(newVector2, leftPlank.transform.position);

                    if ((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings>().getActive())
                    {
                        if (dotproduct < 0 && obj.GetComponent<ObjSettings>().getLeftOrRight() == 1)
                        {
                            Debug.Log("Right");
                        }
                        else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings>().getLeftOrRight() == 2)
                        {
                            Debug.Log("Left");
                        }
                        else if (dotproduct < 0 && obj.GetComponent<ObjSettings>().getLeftOrRight() == 2)
                        {
                            Debug.Log("It's suppose to be left, you dumb ass");
                        }
                        else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings>().getLeftOrRight() == 1)
                        {
                            Debug.Log("It's suppose to be right, you dumb ass");
                        }
                        --numOfCorrect;
					} else {
						Debug.Log("Game Over!");
						gameover = true;
					}
                }
                obj = null;
            }
        }
	}
}
