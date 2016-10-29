using UnityEngine;
using System.Collections;

public class DeceptPlayerBehaviour : MonoBehaviour {

	private Camera cam;

	void Awake() {
		cam = Camera.main;
	}

	void Update() {
		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer == TimeLayer.First) { return; }

		Vector3 pos = transform.position;

		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		height /= 2.0f;
		width /= 2.0f;

		if (pos.x < cam.transform.position.x - width || pos.x > cam.transform.position.x + width || 
			pos.y < cam.transform.position.y - height || pos.y > cam.transform.position.y + height) {
			IngameHandlerBehaviour.Instance.Handler.PopInceptState();
		}
	}
}
