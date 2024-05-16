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

    [Header("Animation")] [SerializeField] private Animator _animator;
    
    [Header("Weapon Placement")]
    [SerializeField] private Vector3 _rightLocation;
    [SerializeField] private Vector3 _leftLocation;
    [SerializeField] private Vector3 _upLocation;
    [SerializeField] private Vector3 _downLocation;
    
    private Rigidbody2D _rb;
    private bool _canHit = false;
    private Vector2 _moveInput;
    private bool is_moveing = false;
    private Vector2 _magnitude;
    private int speed_modifier = 0;

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
        _rb.velocity = _moveInput * (moveSpeed + speed_modifier);
        
    }

    private void FixedUpdate()
    {
        if (_inventoryObject.currentArmour)
        {
            speed_modifier = _inventoryObject.currentArmour.speed_modifier;
            
        }
        if (_magnitude != Vector2.zero)
        {
            _animator.SetFloat("Xinput", _magnitude.x);
            _animator.SetFloat("Yinput", _magnitude.y);
        }
        else
        {
            is_moveing = false;
        }

        if (_magnitude.x < 0) 
        {
            GameObject child = player.transform.GetChild(0).gameObject;
            child.transform.localPosition = _leftLocation;
            child.GetComponent<SpriteRenderer>().sortingOrder = 12;

            child.GetComponent<SpriteRenderer>().flipY = false;
            child.GetComponent<SpriteRenderer>().flipX = true;
        } else if (_magnitude.x > 0)
        {
            GameObject child = player.transform.GetChild(0).gameObject;
            child.transform.localPosition = _rightLocation;
            child.GetComponent<SpriteRenderer>().sortingOrder = 12;
            child.GetComponent<SpriteRenderer>().flipY = true;
            child.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (_magnitude.y > 0)
        {
            GameObject child = player.transform.GetChild(0).gameObject;
            child.transform.localPosition = _upLocation;
            child.GetComponent<SpriteRenderer>().sortingOrder = 1;
            child.GetComponent<SpriteRenderer>().flipY = false;
            child.GetComponent<SpriteRenderer>().flipX = false;

        } else if (_magnitude.y < 0)
        {
            GameObject child = player.transform.GetChild(0).gameObject;
            child.transform.localPosition = _downLocation;
            child.GetComponent<SpriteRenderer>().sortingOrder = 12;
            child.GetComponent<SpriteRenderer>().flipY = true;
            child.GetComponent<SpriteRenderer>().flipX = false;
        }
        handleAnimation();
    }

    private void handleAnimation()
    {
        if (is_moveing)
        {
            _animator.Play("running");
        }
        else
        {
            _animator.Play("Idle");
        }
    }

    public void moveScript(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        _magnitude = _moveInput.normalized;
        is_moveing = true;
    }

    public void HitButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HitEnemy?.Invoke(enemy, _inventoryObject.currentWeapon.damage);
            WeaponAnimations.Attack?.Invoke();
            
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
        if (_inventoryObject.currentArmour)
        {
            int armourAmount = _inventoryObject.currentArmour.defence;
            health -= amount - armourAmount;
            UpdateHealth?.Invoke(health);
            
        } else
        {
            health -= amount;
            UpdateHealth?.Invoke(health);
        }
    }
}
