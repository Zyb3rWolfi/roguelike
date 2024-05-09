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
    [SerializeField] private int distance;
    [SerializeField] private int damage;
    
    private Rigidbody2D _rb;
    private playerController player;
    
    public static Action<int> AttackPlayer;

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
        // Set the enemy stats
        health = enemyType.health;
        distance = enemyType.followDistance;
        moveSpeed = enemyType.speed;
        damage = enemyType.damage;
        
        // Get the player and rigidbody
        player = FindObjectOfType<playerController>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        
        // Start the coroutines
        StartCoroutine(CheckIfPlayerIsClose());
        StartCoroutine(DealDamage());
    }
    
    // Takes damage from player
    private void TakeDamage(GameObject enemy, int damage)
    {
        if (enemy != gameObject) return;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator CheckIfPlayerIsClose()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < distance)
            {
                print("Player is near");
                _rb.velocity = (player.transform.position - transform.position).normalized * moveSpeed;
            } else {
                _rb.velocity = Vector2.zero;
            }
            
            
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    // Deals damage to player every 1 second
    private IEnumerator DealDamage()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 1)
            {
                AttackPlayer?.Invoke(damage);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
