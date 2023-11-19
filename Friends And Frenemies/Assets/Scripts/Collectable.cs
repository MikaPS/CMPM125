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

    public void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
            if (tag == "Stone") {
                stoneCount += 1;
                countText.text = "" + stoneCount;
            } else {
                woodCount += 1;
                countText.text = "" + woodCount;
            }
        }

        // Check for a win/lose
        checkForWin();
    }

    public void checkForWin() {
        // Player 1 goals
        if (GoalsManager.GoalManager.player1Goals[1] == "Stone") {
            if (stoneCount >= int.Parse(GoalsManager.GoalManager.player1Goals[0])) {
                player1GoalsCompleted += 1;
                Debug.Log("Player 1, Goal 1 complete!");
            }
        } else {
            if (woodCount >= int.Parse(GoalsManager.GoalManager.player1Goals[0])) {
                player1GoalsCompleted += 1;
                Debug.Log("Player 1, Goal 1 complete!");
            }
        }
        if (GoalsManager.GoalManager.player1Goals[3] == "Stone") {
            if (stoneCount >= int.Parse(GoalsManager.GoalManager.player1Goals[2])) {
                player1GoalsCompleted += 1;
                Debug.Log("Player 1, Goal 2 complete!");
            }
        } else {
            if (woodCount >= int.Parse(GoalsManager.GoalManager.player1Goals[2])) {
                player1GoalsCompleted += 1;
                Debug.Log("Player 1, Goal 2 complete!");
            }
        }

        // Player 2 goals
        if (GoalsManager.GoalManager.player2Goals[1] == "Stone") {
            if (stoneCount >= int.Parse(GoalsManager.GoalManager.player2Goals[0])) {
                player2GoalsCompleted += 1;
                Debug.Log("Player 2, Goal 1 complete!");
            }
        } else {
            if (woodCount >= int.Parse(GoalsManager.GoalManager.player2Goals[0])) {
                player2GoalsCompleted += 1;
                Debug.Log("Player 2, Goal 1 complete!");
            }
        }
        if (GoalsManager.GoalManager.player2Goals[3] == "Stone") {
            if (stoneCount >= int.Parse(GoalsManager.GoalManager.player2Goals[2])) {
                player2GoalsCompleted += 1;
                Debug.Log("Player 2, Goal 2 complete!");
            }
        } else {
            if (woodCount >= int.Parse(GoalsManager.GoalManager.player2Goals[2])) {
                player2GoalsCompleted += 1;
                Debug.Log("Player 2, Goal 2 complete!");
            }
        }

        if (player1GoalsCompleted == 2) {
            winText.text = "PLAYER 1 WON!!";
        }
        if (player2GoalsCompleted == 2) {
            winText.text = "PLAYER 2 WON!!";
        }
    }
}
