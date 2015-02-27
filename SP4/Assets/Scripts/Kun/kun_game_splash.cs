using UnityEngine;
using System.Collections;

public class kun_game_splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {			
			Application.LoadLevel ("SangNilaUtama_SinkingShip");
		}
	}
}
