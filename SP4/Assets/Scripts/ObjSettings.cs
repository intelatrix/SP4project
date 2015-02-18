using UnityEngine;
using System.Collections;

public class ObjSettings : MonoBehaviour {

    private int leftOrRight = -1;
    private bool active = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getLeftOrRight() {
        return leftOrRight;
    }

    public void setLeftOrRight(int newNum) {
        leftOrRight = newNum;
    }

    public bool getActive() {
        return active;
    }

    public void setActive(bool exist) {
        active = exist;
    }
}
