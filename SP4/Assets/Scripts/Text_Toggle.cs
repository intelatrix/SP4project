using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Text_Toggle : MonoBehaviour {
    public GameObject obj;

    public GameObject obj2;
    public GameObject obj3;

    public bool toggle;
	public bool changeText;
    void Start() {
        
    }

    void Update() {
        toggle = GameObject.Find("Spawner").GetComponent<Spawner>().control;
		changeText = GameObject.Find ("Spawner").GetComponent<Spawner>().phase1;
        if (toggle)
        {
            obj.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(true);
        }
        else {
            obj.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
        }

		if (changeText) {
			obj.GetComponent<Text>().text = "Object matches with these direction!";
		}

		if (toggle) {
			obj2.GetComponent<Text>().text = "Throw them down!";
		}
    }
}
