using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{  
    [SerializeField] private Canvas inventoryCanvas;
    private bool _state = false;

    private void Start()
    {
        inventoryCanvas.enabled = _state;
    }

    public void ToggleInventory(InputAction.CallbackContext context)
    {
        _state = !_state;
        inventoryCanvas.enabled = _state;
    }
    
}
