using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{
    [SerializeField] private ItemScriptable _item;
    [SerializeField] private Animator _animator;
    public static Action Attack;

    public static Action<ItemScriptable> pickupItem;
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        Attack += AttackAnimation;
    
    }
    
    private void OnDisable()
    {
        Attack -= AttackAnimation;
    }

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    
    // ANIMATION LOGIC
    private void AttackAnimation()
    {
        _animator.SetTrigger("hit");
    }
    
    public void ResetAttack()
    {
        _animator.ResetTrigger("hit");
        _animator.Play("woodenSwordIdle");
    }
    
    // PICKUP LOGIC
    public void OnMouseDown()
    {
        pickupItem?.Invoke(_item);
        Destroy(gameObject);
    }
}
