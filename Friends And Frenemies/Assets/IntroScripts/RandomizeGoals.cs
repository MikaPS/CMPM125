using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RandomizeGoals : MonoBehaviour
{
    //private static List<string> goalsArray = new List<string>  { "Pet a dog", "Collect 10 wood", "Destroy a building", "Talk to 3 NPCs", "End the zombie apocalypse"};
    private static List<string> goalsArray = new List<string> { "2 Wood", "3 Wood", "1 Stone", "5 Stone", "3 Stone"};

    public Text goalsText;


    // Selects a random value from the goals array, removes it, and returns it
   public string getRandomGoal() {
    if (goalsArray.Count > 0) {
        int i = Random.Range(0, goalsArray.Count);
        string goal = goalsArray[i];
        goalsArray.RemoveAt(i);
        string[] words = goal.Split(' ');

        foreach (string word in words) {
            if (tag == "Player1") { 
                GoalsManager.GoalManager.player1Goals.Add(word);
            }
            else if (tag == "Player2") {
                GoalsManager.GoalManager.player2Goals.Add(word);
            }
        }
       
        return goal;
    }
    return "";
   }

   public void setTextToGoals() {
        goalsText.text = "To win, you will need to collect:\n- " + getRandomGoal() + "\n- " + getRandomGoal();
   }
}
