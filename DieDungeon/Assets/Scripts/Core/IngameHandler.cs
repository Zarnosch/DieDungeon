﻿using UnityEngine;
using System;

[Serializable]
public class IngameHandler
{
    public TimeLayer ActiveTimeLayer { get; private set; }

    public void ChangeTimeLayer(TimeLayer changeToThisLayer)
    {
        
    }
		
	public void PushInceptState() {
		ActiveTimeLayer++;
		if (ActiveTimeLayer > TimeLayer.Third) {
			ActiveTimeLayer = TimeLayer.Third;
		}
		if (ActiveTimeLayer == TimeLayer.Second) {
			Camera.main.GetComponent<InceptShaderScript>().StartTransition();	
		}

		PlayerHandlerBehaviour.Instance.CreatePlayer();
	}

	public void PopInceptState() {
		ActiveTimeLayer--;
		if (ActiveTimeLayer < TimeLayer.First) {
			ActiveTimeLayer = TimeLayer.First;
		}

		if (ActiveTimeLayer == TimeLayer.First) {
			Camera.main.GetComponent<InceptShaderScript>().StartTransition(-1);	
		}

		PlayerHandlerBehaviour.Instance.DestroyPlayer();
		//TODO blending 
	}
}
