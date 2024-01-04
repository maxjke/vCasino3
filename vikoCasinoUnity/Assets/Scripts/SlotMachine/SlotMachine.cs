using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SlotMachine : MonoBehaviour, ISlotMachine
{
    
    public TextMeshProUGUI input;
    public Bet bet;
    public ReelController reelController;
  
    private void Start()
    {
        reelController = FindAnyObjectByType<ReelController>();
        bet = FindAnyObjectByType<Bet>();
    }

    
    public void Play()
    {
        var x = input.GetParsedText();
        x = RemoveInvisibleCharacters(x);
        if (Bet.canWeBet == true && bet.BetCheck() != -1) {
            Settings.Balance.setAmount(Settings.Balance.getAmount() - decimal.Parse(x));
            reelController.StartSpin();
            Bet.canWeBet = false;
            }
    }
    private string RemoveInvisibleCharacters(string str)
    {
        return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    }

}
