using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public enum ViewDirection {
		LEFT,
		RIGHT
	}

	// public
	public float border = 1.5f;
	public float cameraChangeSpeed = 0.2f;

	public bool drawDebug = false;

	[System.NonSerialized]
	public ViewDirection viewDirection;

	// private
	private bool viewChanged;
	private float datRunningVar = 0;
	private ViewDirection oldViewDirection = ViewDirection.RIGHT;

	private Camera cam;

	void Awake() {
		cam = Camera.main;
	}

	void Update() {
		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != TimeLayer.First) { return; }

		if (drawDebug) {
			Debug.DrawLine (new Vector3 (cam.transform.position.x - border, transform.position.y + 2, transform.position.z),
				new Vector3 (cam.transform.position.x - border, transform.position.y - 2, transform.position.z));

			Debug.DrawLine (new Vector3 (cam.transform.position.x + border, transform.position.y + 2, transform.position.z),
				new Vector3 (cam.transform.position.x + border, transform.position.y - 2, transform.position.z));	
		}
			
		if (oldViewDirection != viewDirection) {
			datRunningVar = 0;
			viewChanged = true;
			oldViewDirection = viewDirection;
		}

		float lerpedCameraX = 0;

		if (viewChanged && viewDirection == ViewDirection.LEFT) {
			datRunningVar += cameraChangeSpeed * Time.deltaTime;
			lerpedCameraX = Mathf.Lerp (cam.transform.position.x, transform.position.x + border, datRunningVar);

			if (datRunningVar >= 1) {
				datRunningVar = 0;
				viewChanged = false;
			}
		} else if (viewChanged && viewDirection == ViewDirection.RIGHT) {
			datRunningVar += cameraChangeSpeed * Time.deltaTime;
			lerpedCameraX = Mathf.Lerp (cam.transform.position.x, transform.position.x - border, datRunningVar);

			if (datRunningVar >= 1) {
				datRunningVar = 0;
				viewChanged = false;
			}
		} else {
			if (viewDirection == ViewDirection.LEFT) {
				lerpedCameraX = transform.position.x + border;
			} else {
				lerpedCameraX = transform.position.x - border;
			}
		}

		oldViewDirection = viewDirection;
			
		cam.transform.position = new Vector3 (lerpedCameraX, transform.position.y, cam.transform.position.z);
	}
}
