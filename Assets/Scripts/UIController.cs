using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable()
    {
        playerController.UpdateHealth += UpdateHealth;
    }
    
    private void OnDisable()
    {
        playerController.UpdateHealth -= UpdateHealth;
    }

    private void UpdateHealth(int healthAmount)
    {
        healthText.text = "HEALTH: " + healthAmount.ToString();
    }
}
