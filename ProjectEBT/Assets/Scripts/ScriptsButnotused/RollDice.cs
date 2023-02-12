using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollDice : MonoBehaviour
{
    public TextMeshProUGUI Result;
    public Sprite[] dicesprites;
    public Image diceImg1;
    public Image diceImg2;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Roll()
    {
        int diceNum1 = Random.Range(0, 6);
        int diceNum2 = Random.Range(0, 6);

        Result.text = (diceNum1 + diceNum2 + 2).ToString();

        diceImg1.sprite = dicesprites[diceNum1];
        diceImg2.sprite = dicesprites[diceNum2];
       
    }
}
