using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform _fireTransform;
    [SerializeField] private List<BaseBullet> _bullets = new List<BaseBullet>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(_bullets.ElementAt(0), _fireTransform.position,Quaternion.identity).Initialize();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(_bullets.ElementAt(1), _fireTransform.position,Quaternion.identity).Initialize();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(_bullets.ElementAt(2), _fireTransform.position,Quaternion.identity).Initialize();
        }
    }
}
