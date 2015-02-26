using UnityEngine;
using System.Collections;

public class ObjSettings : MonoBehaviour {

    private int leftOrRight = -1;
    private bool isActive = false;
    private int type = -1;

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
        return isActive;
    }

    public void setActive(bool exist) {
        isActive = exist;
    }

    public int getType() {
        return type;
    }

    public void setType(int newNum) {
        type = newNum;
    }
}
