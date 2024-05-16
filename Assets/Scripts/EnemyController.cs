using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Type")]
    [SerializeField] private EnemyTypes enemyType;
    [Header("Enemy Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int health;
    [SerializeField] private int distance;
    [SerializeField] private int damage;
    private Animator _animator;
    
    private Rigidbody2D _rb;
    private playerController player;
    [SerializeField] private bool _isInAttackRange = false;
    private bool _attacking = false;
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
        _animator = gameObject.GetComponent<Animator>();
        
        // Get the player and rigidbody
        player = FindObjectOfType<playerController>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        
        // Start the coroutines
        StartCoroutine(CheckIfPlayerIsClose());
        StartCoroutine(IsPlayerInRange());
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
        while (!_attacking)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < distance)
            {
                _animator.Play("slimeGoingUndeground");
            } else {
                _rb.velocity = Vector2.zero;
            }
            
            
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private IEnumerator IsPlayerInRange()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < distance)
            {
                _isInAttackRange = true;
            }
            else
            {
                _isInAttackRange = false;
                _attacking = false;
                StartCoroutine(CheckIfPlayerIsClose());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    // TeleportToPlayer teleports the enemy to the player
    // StartAttackAnimation starts the attack animation
    // AttackPlayerNow runs when the attack animation is over dealing damage
    public IEnumerator TeleportToPlayer()
    {
        _attacking = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        if (transform.position.x < player.transform.position.x)
        {
            transform.position = player.transform.position + new Vector3(-0.5f, 0, 0);
        } else {
            transform.position = player.transform.position + new Vector3(0.5f, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        _animator.Play("default");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        StartAttackAnimation();
    }

    private void StartAttackAnimation()
    {
        _animator.Play("SlimeAttacking");
    }

    // Returns the enemy to the normal state
    public IEnumerator AttackPlayerNow()
    {
        AttackPlayer?.Invoke(damage);
        _animator.Play("default");
        if (_isInAttackRange)
        {
            yield return new WaitForSeconds(1f);
            StartAttackAnimation();
        }
    }
    
}
