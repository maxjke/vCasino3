using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.DiceGame;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Interfaces.SlotMacine;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class DiceButton : MonoBehaviour, IDiceButton
{
    public Dice dice1;
    public Dice dice2;
    public DiceBet bet;
    private IRemoverInvisibleCharacters remover;
    public TextMeshProUGUI input;

    private void Start()
    {
        remover = new RemoverInvisibleCharacters();
        bet = FindAnyObjectByType<DiceBet>();
    }


    public void OnButtonClick()
    {
        var x = input.GetParsedText();
        x = remover.RemoveInvisibleCharacters(x);
        if (bet.BetCheck() != -1)
        {
            Settings.Balance.setAmount(Settings.Balance.getAmount() - decimal.Parse(x));
            dice1.RollDice();
            dice2.RollDice();
        }
    }
}
