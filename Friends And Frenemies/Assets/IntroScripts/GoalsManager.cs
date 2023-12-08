using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct Goal
{
    public int targetValue;
    public InventoryManager.ResourceType type;

    public Goal(int targetValue, InventoryManager.ResourceType type)
    {
        this.targetValue = targetValue;
        this.type = type;
    }
}

public class GoalsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GoalsManager GoalManager;
    public List<Goal> player1Goals = new List<Goal>{};
    public int player1Completed = 0;
    // public string[] player1Goal2;
    public List<Goal> player2Goals = new List<Goal>{};
    public int player2Completed = 0;

    // public string[] player2Goal2;

    void Awake()
    {
        if (GoalManager == null)
            GoalManager = this;
        else
            Destroy(GoalManager);
        // DontDestroyOnLoad(GoalManager);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CheckPlayerGoals(List<Goal> playerGoals, int player)
    {
        int playerGoalsCompleted = 0;
        for (int i = 0; i < playerGoals.Count; i += 1)
        {
            InventoryManager.ResourceType resourceType = playerGoals[i].type;
            int targetAmount = playerGoals[i].targetValue;
         
            foreach (InventoryManager.Resource resource in InventoryManager.resources) {
                if (resourceType == resource.type && resource.amount >= targetAmount) {
                    playerGoalsCompleted += 1;
                    if (player == 1) {
                        if (player1Completed < playerGoalsCompleted) {
                            player1Completed += 1;
                           ShowAchivement.achivement.showSprite1();
                        }
                    }
                    if (player == 2) {
                        if (player2Completed < playerGoalsCompleted) {
                            player2Completed += 1;
                           ShowAchivement.achivement.showSprite2();
                        }
                    }
                }
            }

        }
        return playerGoalsCompleted;
    }
}
