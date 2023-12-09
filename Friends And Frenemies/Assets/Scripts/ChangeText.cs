using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    public int sortingOrder = 9999;

    private void Start()
    {
        // Get the Canvas associated with the Text component
        Canvas canvas = text.GetComponentInParent<Canvas>();

        if (canvas != null)
        {
            // Set the sorting order
            canvas.sortingOrder = sortingOrder;
        }
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
