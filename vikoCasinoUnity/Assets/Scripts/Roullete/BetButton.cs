using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
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
        button.buttonText = input.GetParsedText();
    }
}
