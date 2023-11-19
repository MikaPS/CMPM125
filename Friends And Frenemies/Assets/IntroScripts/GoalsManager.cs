using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GoalsManager GoalManager;
    public List<string> player1Goals = new List<string>{};
    // public string[] player1Goal2;
    public List<string> player2Goals = new List<string>{};
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
    
}
