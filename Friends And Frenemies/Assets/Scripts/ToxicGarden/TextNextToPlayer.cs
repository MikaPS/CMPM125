using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNextToPlayer : MonoBehaviour
{
    public static TextNextToPlayer textEffects;
    public Transform player1;
    public Transform player2;
    public Transform effects1;
    public Transform effects2;
    public string currentPlayer = "";
    // public Sprite sprite;
    public float yOffset = 0f;  // Offset in the y-axis above the player
    public float xOffset = 20f;  
    public SpriteRenderer spriteRenderer1;
    
    public SpriteRenderer spriteRenderer2;
    void Awake()
    {
        // gameObject.SetActive(!gameObject.activeSelf);
        if (textEffects == null)
        {
            textEffects = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void start() {
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void updateSprite(string currentPlayer, Sprite sprite)
    {  
        // spriteRenderer.enabled = true;
        // spriteRenderer.sprite = sprite;
        // spriteRenderer.sortingOrder = 999;
        // Vector3 playerPosition = player1.position;
        if (currentPlayer == "Player2") {
            spriteRenderer2.enabled = true;
            spriteRenderer2.sprite = sprite;
            spriteRenderer2.sortingOrder = 999;
            Vector3 playerPosition = player2.position;
            Vector3 abovePlayerPosition = new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, 1);
            effects2.position = abovePlayerPosition;
            Invoke("changeVisibility2", 2.0f);
        } else {
            spriteRenderer1.enabled = true;
            spriteRenderer1.sprite = sprite;
            spriteRenderer1.sortingOrder = 999;
            Vector3 playerPosition = player1.position;
            Vector3 abovePlayerPosition = new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, 1);
            effects1.position = abovePlayerPosition;
            Invoke("changeVisibility1", 2.0f);
        }
        // Vector3 abovePlayerPosition = new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, 1);
        // transform.position = abovePlayerPosition;   
        // if (currentPlayer == "Player2") {
        //     effects2 = abovePlayerPosition;
        // } else {
        //     effects1 = abovePlayerPosition;
        // }
        // Invoke("changeVisibility", 2.0f);
    }

    public void changeVisibility2() {
        spriteRenderer2.enabled = !spriteRenderer2.enabled;
    }
    public void changeVisibility1() {
        spriteRenderer1.enabled = !spriteRenderer1.enabled;
    }
}
