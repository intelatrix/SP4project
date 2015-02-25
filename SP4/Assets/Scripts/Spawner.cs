using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    //cannonball
    public GameObject obj1;
    //crate
    public GameObject obj2;
	//Barge
	public GameObject obj3;
	//Grain
	public GameObject obj4;
	//Barrel
	public GameObject obj5;
	//Chest
	public GameObject obj6;

    public GameObject dirLeft;
    public GameObject dirRight;

    public bool control = false;
    private bool done = true;
    public bool phase1 = false;
    public bool phase2 = false;
    private bool skip = false;

    private GameObject[] arrayList;
    private GameObject display = null;
    private int[] holder;
    public int setCorrectNo = 2;
    private int numOfObj = 6;

    private float timer = 0;
    private int objCounter = 0;
    private int dirCounter = 0;

     Vector3 pos;
    //
    //
    //
    //
    //
    //
    //

	// Use this for initialization
	void Start () {
        Spawn();
        Init();
        pos.x = 66.4f;
        pos.y = -10.2f;
        pos.z = -9.8f;
        timer = Time.time + 0.5f;
        done = true;
	}
	
	// Update is called once per frame
	void Update () {

        //if all the flashing isnt done
        if (control == false)
        {
            //done all the stuff and ready for the next increment
            if (done && phase1 == false)
            {
                StartingScreen();
                done = false;
            }
            
			if (done && phase1 == true && phase2 == false)
            {
                done = false;
                DirectionTime();
            }
        }
        //all completed
        else if (control == true)
        {
            StartMainGame();
        }

        //check if time is up while player does not have control or skip the turn if there is the obj is not correct
        if ((timer < Time.time || skip == true) && control == false)
        {
            //destroy the object
            if (display != null)
            {
                GameObject.Destroy(display);
            }

            //cal the direction function after checking all the object
            if (objCounter == (numOfObj-1) && phase1 == false)
            {
				done = true;
                phase1 = true;
            }

            //start the main game after all the direction is done
			if (dirCounter == (numOfObj-1) && phase2 == false)
            {
                phase2 = true;
            }

            //while obj flashing isnt complete
            if (phase1 == false && done == false)
            {
                objCounter++;
                done = true;
            }

            //while dir flashing isnt complete
            if (phase1 == true && phase2 == false && done == false)
            {
                dirCounter++;
                done = true;
            }
            
			if (phase1 == true && phase2 == true)
            {
                control = true;
                done = true;
            }

          
            //reset timer to 0.5s into the future
            timer = Time.time + 1.0f;

            //set back skip to false
            skip = false;
        }
	}

    void Spawn() {
		arrayList = new GameObject[numOfObj];
		holder = new int[numOfObj];
        for (int i = 0; i < numOfObj; i++) {
            //int randNum = Random.Range(1 , 3);
            float posX = Random.Range(-3.5f, 3.5f);
            float posZ = Random.Range(-5.0f, 8.5f);
            if (i == 0)
            {
				arrayList[i] = Instantiate(obj1, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
                holder[i] = 1;
            } else if (i == 1) {
                arrayList[i] = Instantiate(obj2, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
                holder[i] = 2;
			}  else if (i == 2) {
				arrayList[i] = Instantiate(obj3, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
				holder[i] = 3;
			}  else if (i == 3) {
				arrayList[i] = Instantiate(obj4, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
				holder[i] = 4;
			}  else if (i == 4) {
				arrayList[i] = Instantiate(obj5, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
				holder[i] = 5;
			}  else if (i == 5) {
				arrayList[i] = Instantiate(obj6, new Vector3(posX, 0.5f, posZ), Quaternion.identity) as GameObject;
				holder[i] = 6;
			}
            arrayList[i].tag = "Obj";
        }
    }

    void Init() {
        while (setCorrectNo != 0) {
			for (int i = 0; i < numOfObj; i++) {
                ObjSettings script = arrayList[i].GetComponent<ObjSettings>();

                if (script.getActive() == false && setCorrectNo != 0) {
                    int randNum = Random.Range(1, 101);
                    float leftOrRight = Random.Range(0.0f, 10.0f);
                    script.setType(holder[i]);

                    if (randNum >= 40) {
                        script.setActive(true);

                        if (leftOrRight < 5.0f)
                        {
                            //left
                            script.setLeftOrRight(1);
                        }
                        else if (leftOrRight >= 5.0f)
                        {
                            //right
                            script.setLeftOrRight(2);
                        }
                        leftOrRight = 0;
                        --setCorrectNo;
                    }
                }
            }
        }
    }

    void StartingScreen() {
        ObjSettings script = arrayList[objCounter].GetComponent<ObjSettings>();

        if (script.getActive() == true)
        {
            if (script.getType() == 1)
            {
                display = Instantiate(obj1, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
                display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            }
			else if (script.getType() == 2)
            {
                display = Instantiate(obj2, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
                display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
			} else if (script.getType() == 3)
			{
				display = Instantiate(obj3, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
				display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
			} else if (script.getType() == 4)
			{
				display = Instantiate(obj4, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
				display.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 90.0f);
				display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
			} else if (script.getType() == 5)
			{
				display = Instantiate(obj5, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
				display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
			} else if (script.getType() == 6)
			{
				display = Instantiate(obj6, new Vector3(pos.x-8.0f, pos.y, pos.z), Quaternion.identity) as GameObject;
				display.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 90.0f);
			}
        }
        else
        {
            //reset timer to 0.5s into the future
            timer = Time.time + 1.0f;
            skip = true;
        }
    }

    void DirectionTime()
    {
        ObjSettings script = arrayList[dirCounter].GetComponent<ObjSettings>();

        if (script.getActive())
        {
            if (script.getLeftOrRight() == 1)
            {
                display = Instantiate(dirLeft, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
                display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
                display.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 90.0f);
            }
            else if (script.getLeftOrRight() == 2)
            {
                display = Instantiate(dirRight, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
                display.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
                display.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 90.0f);
            }
        }
        else
        {
            //reset timer to 0.5s into the future
            timer = Time.time + 1.0f;
            skip = true;
        }
    }

    void StartMainGame() {
        Camera.main.transform.position = new Vector3(0.0f, 3.0f, -10.0f);
        Camera.main.transform.rotation = Quaternion.Euler(10.0f, 0.0f, 0.0f);
    }
}
