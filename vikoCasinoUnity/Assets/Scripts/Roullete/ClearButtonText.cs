using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearButtonText : MonoBehaviour
{
    [SerializeField] public List<ButtonManager> buttons;
    IClearButtonUI clearButtonUI;

    public void ClearAllButtonTexts()
    {
        clearButtonUI.ClearAllButtonTexts();
    }

    void Start()
    {
        clearButtonUI = new Assets.DataAccess.Repositories.Roullete.UIManager(buttons);
        ClearAllButtonTexts();
    }
}
