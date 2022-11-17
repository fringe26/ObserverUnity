using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    
    //Singletone pattern
    private static PlayerController _instance;
    public static PlayerController Instance => _instance;

    //Events
    public event Action OnBulletCollect; 
    
    //Bullet
    [SerializeField] private  GameObject _bullet;
    [SerializeField] private List<GameObject> _bulletsPrefabList = new List<GameObject>();
    
    //FireTransform
    [SerializeField] private Transform _fireTransform;

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _smoothTurnTime = 0.1f;

    private float _horizontal;
    private float _vertical;
    private float _turnSmoothVelocity;
    private Vector3 _direction;

    private Rigidbody _physics;
    private Transform _transform;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        _physics = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _direction = new Vector3(_horizontal, 0, _vertical);

        if (_direction.magnitude > 0.01f)
        {
            var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            var Angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                _smoothTurnTime);
            _transform.rotation = Quaternion.Euler(0, Angle, 0);

            _physics.MovePosition(_transform.position + (_direction * (_speed * Time.fixedDeltaTime)));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_bullet is null) return;
            Instantiate(_bullet, _fireTransform.position,Quaternion.identity);
              
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var bullet = _bulletsPrefabList.FirstOrDefault(x => x.CompareTag(other.tag));
        if (bullet != null)
        {
            _bullet = bullet;
            Destroy(other.gameObject);
            OnBulletCollect?.Invoke();
        }
    }

     // private void OnMouseDown()
     // {
     //     if (_bullet is null) return;
     //     Instantiate(_bullet, _fireTransform.position,Quaternion.identity);
     // }
}