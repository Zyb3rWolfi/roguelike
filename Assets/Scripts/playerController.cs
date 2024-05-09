using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int health;
    [Header("Inventory Settings")]
    [SerializeField] private InventoryObject _inventoryObject;
    
    private Rigidbody2D _rb;
    private bool _canHit = false;
    private Vector2 _moveInput;

    public static Action<GameObject, int> HitEnemy;
    public static Action<int> UpdateHealth;

    private void OnEnable()
    {
        EnemyController.AttackPlayer += TakeDamage;
    }

    private void OnDisable()
    {
        EnemyController.AttackPlayer -= TakeDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = new Vector3(_moveInput.x, _moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount);
    } 

    public void moveScript(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void HitButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HitEnemy?.Invoke(enemy, _inventoryObject.currentWeapon.damage);
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _canHit = true;
            enemy = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _canHit = false;
            enemy = null;
        }
    }

    private void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealth?.Invoke(health);
    }
}
