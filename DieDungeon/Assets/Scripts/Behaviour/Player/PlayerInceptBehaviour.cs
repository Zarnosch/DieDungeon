using UnityEngine;
using System.Collections;

public class PlayerInceptBehaviour : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			IngameHandlerBehaviour.Instance.Handler.PushInceptState();
		}
	}
}
