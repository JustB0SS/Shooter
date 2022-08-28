using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private void Awake()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
