using Assets.DataAccess.Classes.Base_Classes;
using DataAccess.Classes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreSettings : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI balanceText;

    private User User = new User("stylew8","xxx","",new System.DateTime(),1,30);
    private Balance balance = new Balance(1,300);

    // Start is called before the first frame update
    void Awake()
    {
        Settings.setStaticSettings(User,balance);
    }

    // Update is called once per frame
    void Update()
    {
        balanceText.text = Settings.Balance.getAmount().ToString();
    }
}
