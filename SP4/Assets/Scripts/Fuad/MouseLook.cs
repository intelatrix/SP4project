using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	float lookSens = 5;
	public static float xRot;
	public static float yRot;
	float cur_xRot;
	float cur_yRot;
	float xRotV;
	float yRotV;
	float lookSmoothness = 0.1f;
	
	public static float aimTrue = 1;
	float cameraDefault = 60;
	public static float targetCamera = 60;
	float cameraZoom = 1;
	float cameraZoomV;
	float cameraZoomSpeed;

	void Start(){
		Screen.showCursor = false;
	}

	void Update ()
	{
		if (TimeManager.isStart) {
			if (aimTrue == 1) {
				cameraZoom = Mathf.SmoothDamp (cameraZoom, 1, ref cameraZoomV, cameraZoomSpeed);
			} else {
				cameraZoom = Mathf.SmoothDamp (cameraZoom, 0, ref cameraZoomV, cameraZoomSpeed);
			}

			camera.fieldOfView = Mathf.Lerp (targetCamera, cameraDefault, cameraZoom);

			yRot += Input.GetAxis ("Mouse X") * lookSens;
			xRot -= Input.GetAxis ("Mouse Y") * lookSens;

			xRot = Mathf.Clamp (xRot, -80, 100);

			cur_xRot = Mathf.SmoothDamp (cur_xRot, xRot, ref xRotV, lookSmoothness);
			cur_yRot = Mathf.SmoothDamp (cur_yRot, yRot, ref yRotV, lookSmoothness);

			transform.rotation = Quaternion.Euler (xRot, yRot, 0);
		}
	}

 
}