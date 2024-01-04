using Assets.DataAccess.Interfaces.DiceGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDice : MonoBehaviour, IManagerDice
{
    public Dice dice1;
    public Dice dice2;

    private int sum = 0;
    private int dice1Value = 0;
    private int dice2Value = 0;
    private int diceRolled = 0;

    private void Start()
    {
        dice1.OnDiceRolled += (value) => HandleDiceRolled(value, 1);
        dice2.OnDiceRolled += (value) => HandleDiceRolled(value, 2);
    }

    public void HandleDiceRolled(int diceValue, int diceNumber)
    {
        if (diceNumber == 1)
        {
            dice1Value = diceValue;
        }
        else if (diceNumber == 2)
        {
            dice2Value = diceValue;
        }

        sum += diceValue;
        diceRolled++;

        if (diceRolled == 2)
        {
            Debug.Log("Dice 1: " + dice1Value + ", Dice 2: " + dice2Value + ", Sum: " + sum);
            sum = 0;
            diceRolled = 0;
        }
    }
}
