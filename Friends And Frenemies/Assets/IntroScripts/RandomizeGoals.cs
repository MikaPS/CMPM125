using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RandomizeGoals : MonoBehaviour
{
    private static List<string> goalsArray = new List<string>  { "Pet a dog", "Collect 10 wood", "Destroy a building", "Talk to 3 NPCs", "End the zombie apocalypse"};
    public Text goalsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Selects a random value from the goals array, removes it, and returns it
   public string getRandomGoal() {
    if (goalsArray.Count > 0) {
        int i = Random.Range(0, goalsArray.Count);
        string goal = goalsArray[i];
        goalsArray.RemoveAt(i);
        return goal;
    }
    return "";
   }

   public void setTextToGoals() {
        goalsText.text = "Your goals are:\n" + getRandomGoal() + "\n" + getRandomGoal();
   }
}
