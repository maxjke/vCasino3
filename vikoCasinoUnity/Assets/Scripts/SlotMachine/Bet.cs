using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bet : MonoBehaviour, IBet
{
    public TextMeshProUGUI bet;
    public static bool canWeBet = true;

    public int BetCheck()
    {
            var x = bet.GetParsedText();
            x = RemoveInvisibleCharacters(x);
        if (string.IsNullOrEmpty(x)) return -1;

            if (int.Parse(x) > Settings.Balance.getAmount())
            {
                return -1;
            }
            else
            {
                return int.Parse(x);
            }
        
    }
    public string RemoveInvisibleCharacters(string str)
    {
        return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    }
}
