using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Repositories;
using DataAccess.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulleteWheel : MonoBehaviour
{
    // Start is called before the first frame update
    private RoulleteGame properties;
    private RoulleteRepository controller;

    public Text winningText;

    void Start()
    {
        IBetStrategy startegy = new RoulleteDefaultBetStrategy();
        IRandomNumberGenerator random = new RandomNumberGenerator();

        properties = new RoulleteGame();
        controller = new RoulleteRepository(startegy,random);

        properties.setCanWeTurn(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && properties.getCanWeTurn())
        {
            StartCoroutine(TurnTheWheel());
        }
    }

    private IEnumerator TurnTheWheel()
    {
        properties.setCanWeTurn(false);

        properties.setNumberOfTurns(controller.GetRandomNumberOfTurns());

        properties.setSpeed(0.01f);

        for (int i = 0; i < properties.getNumberOfTurns(); i++)
        {
            transform.Rotate(0, 0, 5f);

            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.2f))
            {
                properties.setSpeed(0.02f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.3f))
            {
                properties.setSpeed(0.03f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.4f))
            {
                properties.setSpeed(0.04f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.5f))
            {
                properties.setSpeed(0.05f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.6f))
            {
                properties.setSpeed(0.06f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.7f))
            {
                properties.setSpeed(0.07f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.8f))
            {
                properties.setSpeed(0.08f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.9f))
            {
                properties.setSpeed(0.09f);
            }

            yield return new WaitForSeconds(properties.getSpeed());
        }

        TurnIfUneven();

        winningText.text = controller.GetWinBet((int)(transform.eulerAngles.z / 9.72)).ToString();

        properties.setCanWeTurn(true);
    }

    public void TurnIfUneven()
    {
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 10 != 0)
        {
            transform.Rotate(0, 0, 5f);
        }
    }

}
