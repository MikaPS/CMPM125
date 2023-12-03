using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodBar : MonoBehaviour
{
    public static FoodBar foodManager;

    public Slider foodSlider;
    public float decreaseAmount = 2.0f;
    

    void Awake()
    {
        if (foodManager == null)
        {
            foodManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foodSlider.value = 100;
        StartCoroutine(UpdateFoodBackground());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFood(float val)
    {
        if (foodSlider.value + val >= 0)
        {
            foodSlider.value += val;
        }
    }

    public IEnumerator UpdateFoodBackground()
    {
        while (foodSlider.value - decreaseAmount >= 0)
        {
            UpdateFood(-decreaseAmount);
            yield return new WaitForSeconds(1.0f);
        }
    }

}
