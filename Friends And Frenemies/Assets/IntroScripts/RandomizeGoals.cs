using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RandomizeGoals : MonoBehaviour
{
    //private static List<string> goalsArray = new List<string>  { "Pet a dog", "Collect 10 wood", "Destroy a building", "Talk to 3 NPCs", "End the zombie apocalypse"};
    private static List<Goal> goalsArray = new List<Goal>
    {
        new Goal(2, InventoryManager.ResourceType.Wood),
        new Goal(3, InventoryManager.ResourceType.Wood),
        new Goal(1, InventoryManager.ResourceType.Stone),
        new Goal(5, InventoryManager.ResourceType.Stone),
        new Goal(3, InventoryManager.ResourceType.Stone),
        new Goal(4, InventoryManager.ResourceType.ToxicMushroom),
        new Goal(8, InventoryManager.ResourceType.RedFlower),
        new Goal(3, InventoryManager.ResourceType.MovingThorneBush),
        new Goal(5, InventoryManager.ResourceType.badWater),
        new Goal(2, InventoryManager.ResourceType.cleanWater),
    };
    public Text goalsText;


    // Selects a random value from the goals array, removes it, and returns it
   public string getRandomGoal() {
    if (goalsArray.Count > 0) {
        int i = Random.Range(0, goalsArray.Count);
        Goal goal = goalsArray[i];
        goalsArray.RemoveAt(i);
        
        if (tag == "Player1") { 
            GoalsManager.GoalManager.player1Goals.Add(goal);
        }
        else if (tag == "Player2") {
            GoalsManager.GoalManager.player2Goals.Add(goal);
        }
       
        return $"{goal.targetValue} {goal.type}";
    }
    return "";
   }

   public void setTextToGoals() {
        goalsText.text = "To win, you will need to collect:\n- " + getRandomGoal() + "\n- " + getRandomGoal();
   }
}
