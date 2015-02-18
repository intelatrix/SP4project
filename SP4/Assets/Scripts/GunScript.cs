using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	

	public float targetXRot;
	public float targetYRot;
	public float targetXRotV;
	public float targetYRotV;
	public float rotSpeed;
	public float holdX;
	public float holdY;
	public float holdZ;
	public float holdDown;
	public float holdDownV;
	public float aimSpeed;
	public float aimingTrue;
	public float zoomAngle;
	public float fireRate;
	public float waitTillFire;
	public GameObject bullet;
	public GameObject spawnBullet;
	public GameObject cameraObject;	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButton ("Fire1")) {
			
			if(waitTillFire <= 0)
			{
				if(bullet){
					Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
				}
				waitTillFire = 1;
			}
			
		}
		
		waitTillFire -= Time.deltaTime * fireRate;

		MouseLook.targetCamera = zoomAngle;
		
		if(Input.GetButton("Fire2"))
		{
			holdDown = Mathf.SmoothDamp(holdDown, 0, ref holdDownV, aimSpeed);
			MouseLook.aimTrue = aimingTrue;
		}
		else
		{
			holdDown = Mathf.SmoothDamp(holdDown, 1, ref holdDownV, aimSpeed);
			MouseLook.aimTrue = 1;
		}
		
		transform.position = cameraObject.transform.position + (Quaternion.Euler (0, targetYRot, 0) * new Vector3 (holdDown * holdX, holdDown * holdY, holdDown * holdZ));
		targetXRot = Mathf.SmoothDamp (targetXRot, MouseLook.xRot, ref targetXRotV, rotSpeed);	
		targetYRot = Mathf.SmoothDamp (targetYRot, MouseLook.yRot, ref targetYRotV, rotSpeed);

		transform.rotation = Quaternion.Euler (targetXRot, targetYRot, 0);

		//float rotation = Input.GetAxis("Mouse X") * rotSpeed;

		//transform.RotateAround (cameraObject.transform.position, Vector3.up, rotation);//rotation * Time.deltaTime);
	}
}
