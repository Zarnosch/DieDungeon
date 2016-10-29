using UnityEngine;
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
			
		PlayerHandlerBehaviour.Instance.CreatePlayer();
	}

	public void PopInceptState() {
		ActiveTimeLayer--;
		if (ActiveTimeLayer < TimeLayer.First) {
			ActiveTimeLayer = TimeLayer.First;
		}

		// TODO blending of objects that changed
	}
}
