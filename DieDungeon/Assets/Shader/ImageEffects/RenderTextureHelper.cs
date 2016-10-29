using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderTextureHelper : MonoBehaviour {

	private Camera cam;
	private string globalTextureName = "_GlobalKeepColored";

	void GenerateRT() {
		cam = GetComponent<Camera>();

		if (cam.targetTexture != null) {
			RenderTexture temp = cam.targetTexture;

			cam.targetTexture = null;
			DestroyImmediate(temp);
		}

		cam.targetTexture = new RenderTexture(cam.pixelWidth, cam.pixelHeight, 16);
		cam.targetTexture.filterMode = FilterMode.Point;

		Shader.SetGlobalTexture(globalTextureName, cam.targetTexture);
	}

	void Awake() {
		GenerateRT();
	}
}
