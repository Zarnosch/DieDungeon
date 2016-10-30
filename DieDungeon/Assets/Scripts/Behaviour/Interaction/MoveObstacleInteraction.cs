using UnityEngine;
using System.Collections;

public class MoveObstacleInteraction : MonoBehaviour {

    public bool CreateSpline;
    public Color StartColor;
    public Color EndColor;
    public Rigidbody2D RigidbodyOfThisObstacle;
    public Vector2 ForceOnActivate;
    private bool _triggered;
    private bool _inRange;
    private float _timer;
    private float _maxTime;
    private bool _timerTriggered;
    private BezierSpline _spline;
    private ParticleSystem _partSystem;
    public TimeLayer ActiveTimeLayer { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    // Use this for initialization

    void Awake()
    {
        _timer = 0f;
        _inRange = false;
        _triggered = false;
        RigidbodyOfThisObstacle = GetComponent<Rigidbody2D>();
        _partSystem = GetComponentInChildren<ParticleSystem>();
        _partSystem.gameObject.SetActive(false);
        RigidbodyOfThisObstacle.constraints = RigidbodyConstraints2D.FreezeAll;
        ActiveTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
        Renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Renderer.gameObject.layer = 0;
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        Renderer.gameObject.layer = 8;
        if (_timerTriggered)
        {
            if (CreateSpline)
            {
                float t = (_maxTime - _timer) / _maxTime;
                _partSystem.gameObject.transform.position = _spline.GetPointAt(t);
                _partSystem.startColor = Color.Lerp(StartColor, EndColor, t);
            }
            _timer -= Time.deltaTime;
        }
        if(_timer <= 0f && _timerTriggered)
        {
            Activate();
        }
        if (_inRange && Input.GetButtonDown("Fire3") && !_triggered && IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != TimeLayer.First)
        {
            Activate();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        if (collider.tag == "Player")
        {
            _inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        if (collider.tag == "Player")
        {
            _inRange = false;
        }
    }

    public void Activate()
    {
        _partSystem.gameObject.SetActive(false);
        _timerTriggered = false;
        _triggered = true;
        RigidbodyOfThisObstacle.constraints = RigidbodyConstraints2D.None;
        RigidbodyOfThisObstacle.AddForce(ForceOnActivate);
    }

    public void Activate(float time, Vector3 position)
    {
        if (CreateSpline)
        {
            Point p0 = new Point(position, 1);
            Point p1 = new Point(position + Random.insideUnitSphere * Random.value * 20, 1);
            Point p2 = new Point(gameObject.transform.position + Random.insideUnitSphere * Random.value * 20, 1);
            Point p3 = new Point(gameObject.transform.position, 1);
            _partSystem.gameObject.SetActive(true);
            _spline = new BezierSpline(new Spline(p0, p1, p2, p3));
        }
        _timerTriggered = true;
        _maxTime = time;
        _timer = time;
    }
}
