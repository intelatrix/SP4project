using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Logo : MonoBehaviour {
	
	private bool change = false;

	void Update() {
		if (change) {
			Color newColor = guiTexture.color;
			newColor.a = 1.0f;
			guiTexture.color = newColor;
		} else {
			Color newColor = guiTexture.color;
			newColor.a = 0.2f;
			guiTexture.color = newColor;
		}

		if (guiTexture.HitTest(Input.mousePosition, Camera.main)) {
			change = true;
		} else {
			change = false;
		}
	}
}
