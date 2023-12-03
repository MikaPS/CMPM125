using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCrafting : MonoBehaviour
{
    private Canvas crafting;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvasObject = GameObject.FindWithTag("CraftingCanvas");
        if (canvasObject != null)
        {
            // Get the Canvas component from the found GameObject
            crafting = canvasObject.GetComponent<Canvas>();
                    crafting.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        crafting.gameObject.SetActive(!crafting.gameObject.activeSelf);
    }

    public void activate() {
        crafting.gameObject.SetActive(true);
    }
}
