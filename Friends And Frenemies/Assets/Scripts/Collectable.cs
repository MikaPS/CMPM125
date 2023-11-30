using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Collectable : MonoBehaviour
{
    public Text countText;
    public Text winText;

    private static int woodCount = 0; // Static since all wood objects have the script
    private static int stoneCount = 0; // Static since all wood objects have the script

    public int player1GoalsCompleted = 0;
    public int player2GoalsCompleted = 0;

    public InventoryManager inv;
  
    public void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            if (tag == "Stone") {
                stoneCount += 1;
                countText.text = "" + stoneCount;

            } else if (tag == "Apple") {
                FoodBar.foodManager.UpdateFood(5);
            }
             else {
                woodCount += 1;
                countText.text = "" + woodCount;
            }
            Destroy(gameObject);

            if (GoalsManager.GoalManager.CheckPlayerGoals(GoalsManager.GoalManager.player1Goals, stoneCount, woodCount) == 2) {
            winText.text = "PLAYER 1 WON!!";
            }
            if (GoalsManager.GoalManager.CheckPlayerGoals(GoalsManager.GoalManager.player2Goals, stoneCount, woodCount) == 2) {
                winText.text = "PLAYER 2 WON!!";
            }
        }
    }
}
