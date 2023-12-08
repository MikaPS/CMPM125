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
    public float yOffset = 0f;  // Offset in the y-axis above the player
    public float xOffset = 20f;  
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    void Awake()
    {
        particleSystem1.Stop(); 
        particleSystem2.Stop(); 
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
        findPlayer1();
        findPlayer2();
        
    }

public void findPlayer1() {
        GameObject player1Object = GameObject.FindWithTag("Player1");
        if (player1Object != null)
        {
            player1 = player1Object.transform;
        }
    }

    public void findPlayer2() {
        GameObject player2Object = GameObject.FindWithTag("Player2");
        if (player2Object != null)
        {
            player2 = player2Object.transform;
        }
    }
    public void updateSprite(string currentPlayer, Sprite sprite)
    {  
        if (currentPlayer == "Player2") {
            findPlayer2();
            Vector3 playerPosition = player2.position;
            Vector3 abovePlayerPosition = new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, 1);
            particleSystem2.transform.position = abovePlayerPosition;
            particleSystem2.Play();
            spriteRenderer2.enabled = true;
            spriteRenderer2.sprite = sprite;
            spriteRenderer2.sortingOrder = 999;
            effects2.position = abovePlayerPosition;
            Invoke("changeVisibility2", 1.0f);
        } else {
            findPlayer1();
            Vector3 playerPosition = player1.position;
            Vector3 abovePlayerPosition = new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, 1);
            particleSystem1.transform.position = abovePlayerPosition;
            particleSystem1.Play();
            spriteRenderer1.enabled = true;
            spriteRenderer1.sprite = sprite;
            spriteRenderer1.sortingOrder = 999;
            effects1.position = abovePlayerPosition;
            Invoke("changeVisibility1", 1.0f);
        }
    }

    public void changeVisibility2() {
        spriteRenderer2.enabled = !spriteRenderer2.enabled;
        particleSystem2.Stop();
    }
    public void changeVisibility1() {
        spriteRenderer1.enabled = !spriteRenderer1.enabled;
        particleSystem1.Stop();
    }
}
