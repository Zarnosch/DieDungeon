using UnityEngine;
using System.Collections;

public class PlayerInceptBehaviour : MonoBehaviour {

	private ActiveInTimeLayerBehaviour ait;

	void Awake() {
		ait = GetComponent<ActiveInTimeLayerBehaviour>();
	}

	void Update() {
		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ait.ActiveInTimeLayer) { return; }

		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer < TimeLayer.Third && Input.GetButtonDown("Fire1")) {
			IngameHandlerBehaviour.Instance.Handler.PushInceptState();
		}
	}

}
