using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changingText() {
        if (text.text == "Garden") {
            text.text = "Forest";
        } else {
            text.text = "Garden";
        }
    }
}
