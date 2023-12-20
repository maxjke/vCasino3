using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{
    public ButtonManager button;
    public TextMeshProUGUI input;

    public void OnButtonClick()
    {
        string parsedText = input.GetParsedText();
        string parsedbuttonText = button.buttonText;

        parsedText = RemoveInvisibleCharacters(parsedText).Replace(" ˆ", "");
        parsedbuttonText = RemoveInvisibleCharacters(parsedbuttonText).Replace(" ˆ", "");

        if (string.IsNullOrWhiteSpace(parsedText))
        {
            Debug.Log("[OnButtonClick] Parsed text is null or whitespace.");
            return;
        }

        if (string.IsNullOrWhiteSpace(parsedbuttonText))
        {
            button.buttonText = int.Parse(parsedText) + " ˆ";
            button.UpdateUI();
            return;
        }

        button.buttonText = int.Parse(parsedText) + int.Parse(parsedbuttonText) + " ˆ";
        button.UpdateUI();
    }

    private string RemoveInvisibleCharacters(string str)
    {
        return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    }
}
