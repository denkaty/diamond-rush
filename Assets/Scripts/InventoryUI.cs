using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;

    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();

        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory != null)
        {
            UpdateDiamondText(playerInventory);
        };
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = $"{playerInventory.Diamonds}/5";
    }
}
