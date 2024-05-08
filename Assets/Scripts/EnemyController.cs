using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyTypes enemyType;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int health;
    private Rigidbody2D _rb;

    private void OnEnable()
    {
        playerController.HitEnemy += TakeDamage;
    }

    private void OnDisable()
    {
        playerController.HitEnemy -= TakeDamage;
    }

    private void Start()
    {
        health = enemyType.health;
    }

    private void TakeDamage(GameObject enemy, int damage)
    {
        if (enemy != gameObject) return;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
