using UnityEngine;

public abstract class BaseBullet : MonoBehaviour  // change tag for bullets to Bullet
{
    protected int _damage;
    public abstract void Initialize();
    public abstract void DoDamage(EnemyController other);


}

