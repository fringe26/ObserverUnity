using System;
using UnityEngine;

public class Bullet20 : BaseBullet
{
    private new int _damage;

    public int Damage => _damage;
 

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.localPosition += Vector3.forward * (15f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<EnemyController>(out EnemyController enemyController))
        {
            DoDamage(enemyController);
        }
        
    }

    public override void Initialize()
    {
        _damage = 20;
    }

    public override void DoDamage(EnemyController other)
    {
        other.TakeDamage(_damage);
    }
}