using UnityEngine;
using System.Collections;


public class RangedWeaponBehaviour : MonoBehaviour {

    public RangedWeaponData Data;
    public Vector3 MovementDirection;
    public float MovementSpeed;
    public GameObject Explosion;
    public TimeLayer ActiveInTimeLayer { get; set; }
    private ParticleSystem[] _particles;

    void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
        ActiveInTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
    }

    void Update()
    {
        if(IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveInTimeLayer && ActiveInTimeLayer != TimeLayer.All) {return;}
        float deg = 270 + Mathf.Rad2Deg * Mathf.Atan2(MovementDirection.y, MovementDirection.x);
        transform.rotation = Quaternion.identity;
        transform.RotateAround(transform.position, new Vector3(0, 0, 1), deg);
        MovementDirection = MovementDirection.normalized;
        transform.position += (MovementDirection.normalized * MovementSpeed * Time.deltaTime);
    }
}
