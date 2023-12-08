using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAchivement : MonoBehaviour
{
      public Transform player1;
    public Transform player2;
     public static ShowAchivement achivement;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;

    void Awake()
    {
        if (achivement == null)
        {
            achivement = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSprite1() {
        findPlayer1();
        // Debug.Log("here");
        Vector3 playerPosition = player1.position;
        Vector3 abovePlayerPosition = new Vector3(playerPosition.x, playerPosition.y + 5, 1);
        spriteRenderer1.transform.position = abovePlayerPosition;
        spriteRenderer1.enabled = true;
        Invoke("changeVisibility1", 1.0f);
    }

    public void showSprite2() {
        findPlayer2();
       Vector3 playerPosition = player2.position;
        Vector3 abovePlayerPosition = new Vector3(playerPosition.x, playerPosition.y + 5, 1);
        spriteRenderer2.transform.position = abovePlayerPosition;
        spriteRenderer2.enabled = true;
        Invoke("changeVisibility2", 1.0f);
    }

    public void changeVisibility2() {
        spriteRenderer2.enabled = !spriteRenderer2.enabled;
    }
    public void changeVisibility1() {
        spriteRenderer1.enabled = !spriteRenderer1.enabled;
    }
}
