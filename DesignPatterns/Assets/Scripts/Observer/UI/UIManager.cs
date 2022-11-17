using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _enemyHealthBar;
    [SerializeField] private TextMeshProUGUI _text;
    
    [SerializeField] EnemyController _enemy;
    private float _health = 100;

    private int _score = 0;
    private void OnEnable()
    {
        _enemy = FindObjectOfType<EnemyController>();
        _enemy.OnTakeDamage += AttackEnemy;
        _enemy.OnEnemyDead += ScoreChange;
    }

    private void AttackEnemy(int damage)
    {
       
            _health -= damage;

            DOTween.To(() => _enemyHealthBar.fillAmount, x => _enemyHealthBar.fillAmount = x, _health / 100.0f,0.5f);
       
    }

    private void ScoreChange()
    {
        Debug.Log("Hello");
        _score++;
        _text.text = $"Score: {_score}";
    }
    
    
    
}
