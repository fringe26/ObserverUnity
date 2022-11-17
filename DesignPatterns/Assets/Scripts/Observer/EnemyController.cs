using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using Sequence = Unity.VisualScripting.Sequence;

public class EnemyController : MonoBehaviour
{
    private PlayerController _player;
    private Transform _transform;

    public event Action<int> OnTakeDamage;
    public event Action OnEnemyDead;
    // public delegate void SomeAction();
    //
    // public event SomeAction OnEnemyDead;

    [SerializeField] private int _health = 100;
    private void OnEnable()
    {
        _player = FindObjectOfType<PlayerController>();
        _transform = GetComponent<Transform>();
        //Subscribe Event
        _player.OnBulletCollect += EnemyStartRunning;

    }

    private void OnDisable()
    {
        //Unsubscribe Event
        _player.OnBulletCollect -= EnemyStartRunning;
    }

    public void EnemyStartRunning()
    {
        var myPosition = _transform.position;
        _transform.DOMove(new Vector3(myPosition.x + Random.Range(5,10), myPosition.y, myPosition.z+Random.Range(5,10)), 2f).SetLoops(-1,LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet20"))
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    } 
   

    public void TakeDamage(int damage)
    {
        
        transform.DOShakeScale(1, 0.5f);
        OnTakeDamage?.Invoke(damage);

        _health -= damage;
        if (_health < 1)
        {
            OnEnemyDead?.Invoke();
            var seq = DOTween.Sequence();
            seq.Append(_transform.DOScaleY(1.5f, 1f))
                .Append(_transform.DOScaleY(0, 1f))
                .OnComplete(() => Destroy(gameObject));


        }
    }
    
    
}
