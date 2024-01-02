using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Classes.Roullete;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories.Roullete;
using Michsky.MUIP;
using System;
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
    private IGameSessionManager betManager;
    private RouletteUserBets userBet;
    private Sprite icon;
    private INotificationManager notificationManager;
    [SerializeField] private Michsky.MUIP.NotificationManager myNotification;

    private void Awake()
    {
        // icon = Resources.Load<Sprite>("Arrow Down");
        betManager = new GameSessionManager();
        notificationManager = new NotificationManager(myNotification, this);
    }

    public void OnButtonClick()
    {

        string parsedText = input.GetParsedText();
        string parsedbuttonText = button.buttonText;


        parsedText = RemoveInvisibleCharacters(parsedText).Replace(" ˆ", "");
        parsedbuttonText = RemoveInvisibleCharacters(parsedbuttonText).Replace(" ˆ", "");

        if (!Settings.GameSession.CanWeBet || Settings.Balance.getAmount() < decimal.Parse(parsedText)) 
        {
            //notificationManager.ShowNotification("Error", "You cannot bet more than you have in balance.", icon);
            return;
        }

        if (string.IsNullOrWhiteSpace(parsedText))
        {
            Debug.LogWarning("[OnButtonClick] Parsed text is null or whitespace.");
            return;
        }

        string buttonName = RemoveInvisibleCharacters(button.ToSafeString());

        userBet = new RouletteUserBets(buttonName,int.Parse(parsedText));

        if (string.IsNullOrWhiteSpace(parsedbuttonText))
        {
            button.buttonText = int.Parse(parsedText) + " ˆ";

            betManager.AddUserBet(userBet);

            button.UpdateUI();
            return;
        }

        betManager.AddUserBet(userBet);

        button.buttonText = (int.Parse(parsedText) + int.Parse(parsedbuttonText)) + " ˆ";
        button.UpdateUI();
    }

    private string RemoveInvisibleCharacters(string str)
    {
        return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    }
}
