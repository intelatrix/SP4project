using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;

    private GameObject[] arrayList;
    private int setCorrectNo = 2;
    private int correct = 2;
    private int numOfObj = 5;

	// Use this for initialization
	void Start () {
        Spawn();
        Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn() {
        arrayList = new GameObject[5];
        for (int i = 0; i < numOfObj; i++) {
            int randNum = Random.Range(1 , 3);
            float posX = Random.Range(-3.5f, 3.5f);
            float posZ = Random.Range(-5.0f, 8.5f);
            if (randNum == 1)
            { 
                arrayList[i] = Instantiate(obj1, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
            }
            else {
                arrayList[i] = Instantiate(obj2, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
            }
            arrayList[i].tag = "Obj";
        }
    }

    void Init() {
        while (setCorrectNo != 0) {
            for (int i = 0; i < 5; i++) {
                ObjSettings script = arrayList[i].GetComponent<ObjSettings>();

                if (script.getActive() == false && setCorrectNo != 0) {
                    int randNum = Random.Range(1, 101);
                    float leftOrRight = Random.Range(1.0f, 2.0f);

                    if (randNum >= 40) {
                        script.setActive(true);

                        if (leftOrRight == 1.0f)
                        {
                            script.setLeftOrRight(1);
                        }
                        else
                        {
                            script.setLeftOrRight(2);
                        }
                        leftOrRight = 0;
                        setCorrectNo--;
                    }
                }
            }
        }
    }
}
