using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public TimeLayer ActiveInTimeLayer { get; private set; }
    public float lifeTime;
    private float alive = 0;

    void Awake()
    {
        ActiveInTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
    }

    void Update()
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveInTimeLayer && ActiveInTimeLayer != TimeLayer.All) { return; }
        alive += Time.deltaTime;
        if(alive >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
	
}
