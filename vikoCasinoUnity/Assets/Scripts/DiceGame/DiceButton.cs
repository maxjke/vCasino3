using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceButton : MonoBehaviour
{
    public Dice dice1;
    public Dice dice2;

    public void OnButtonClick()
    {
        dice1.RollDice();
        dice2.RollDice();
    }
}
