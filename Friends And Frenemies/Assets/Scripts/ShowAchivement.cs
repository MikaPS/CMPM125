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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSprite1() {
        Vector3 playerPosition = player1.position;
        Vector3 abovePlayerPosition = new Vector3(playerPosition.x, playerPosition.y + 5, 1);
        spriteRenderer1.transform.position = abovePlayerPosition;
        spriteRenderer1.enabled = true;
        Invoke("changeVisibility1", 1.0f);
    }

    public void showSprite2() {
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
