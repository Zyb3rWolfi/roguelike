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

    [Header("Weapon Placement")] [SerializeField]
    private GameObject _weaponParent;

    [SerializeField] private GameObject _rightPlaceholder;
    [SerializeField] private GameObject _leftPlaceholder;
    
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
        _weaponParent.transform.SetParent(_leftPlaceholder.transform);
        _weaponParent.transform.localPosition = new Vector3(0, 0, 0);

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
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            _weaponParent.transform.SetParent(_leftPlaceholder.transform);
            _weaponParent.transform.localPosition = new Vector3(0, 0, 0);
            _weaponParent.transform.localScale = new Vector3(-1, 1, -1);

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            _weaponParent.transform.SetParent(_rightPlaceholder.transform);
            _weaponParent.transform.localPosition = new Vector3(0, 0, 0);
            _weaponParent.transform.localScale = new Vector3(1, 1, -1);

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
