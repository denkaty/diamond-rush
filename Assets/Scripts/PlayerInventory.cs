using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int InventoryCapacity;
    public int Diamonds;

    private GameManager gameManager;

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public TextMeshProUGUI winText;

    private void Start()
    {
        InventoryCapacity = 5;
        Diamonds = 0;
        winText.enabled = false;
        gameManager = FindObjectOfType<GameManager>();
    }
    public void DiamondCollected()
    {
        Diamonds++;
        OnDiamondCollected.Invoke(this);
        if(Diamonds == InventoryCapacity)
        {
            StartCoroutine(ShowVictoryMessageAndReset());
        }
    }

    private IEnumerator ShowVictoryMessageAndReset()
    {
        gameManager.FreezeTimer();
        winText.enabled = true;

        yield return new WaitForSeconds(3f);

        ResetGame();
    }

    private void ResetGame()
    {
        Diamonds = 0;

        winText.text = "";
        winText.enabled = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
