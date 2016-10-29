using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Camera))]
public class InceptShaderScript : MonoBehaviour {

	public Material mat;

	[Range(0,1)]
	public float blending = 0.0f;
	[Range(0,1)]
	public float blendAmount = 0.05f;

	private float blendTimer = 0.0f;
	private bool blend = false;
	private int blendDir = 1;

	void OnRenderImage(RenderTexture src, RenderTexture dest) {
		mat.SetFloat("_Blending", blending);

		Graphics.Blit(src, dest, mat);
	}

	void Update() {
		if (!blend) { return; }

		blendTimer += blendAmount * blendDir;
		blending = Mathf.SmoothStep(0.0f, 1.0f, blendTimer);

		if (blendTimer > 1) {
			blendTimer = 1;
			blend = false;
		}
	}

	public void StartTransition(int direction = 1) {
		blendDir = direction;
		blend = true;
	}

}
