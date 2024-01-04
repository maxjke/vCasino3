using Assets.DataAccess.Classes.Base_Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SlotMachine : MonoBehaviour, ISlotMachine
{
    private SlotMachineController machineController;
    public TextMeshProUGUI input;
    public SlotMachineController controller;
  
    private void Start()
    {
        machineController = GetComponent<SlotMachineController>();
    }

    
    public void Play()
    {
        var x = input.GetParsedText();
        x = RemoveInvisibleCharacters(x);
        if (controller.canWeBet == true && controller.Bet() != -1) {
            Settings.Balance.setAmount(Settings.Balance.getAmount() - decimal.Parse(x));
            machineController.StartSpin();
            controller.canWeBet = false;
            }
    }
    private string RemoveInvisibleCharacters(string str)
    {
        return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    }

}
