using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // Массив GameObject барабанов
    public Sprite[] symbols; // Массив всех возможных спрайтов символов
    private Vector3[] initialPositions; // Массив для хранения начальных позиций барабанов
    // Вызывается для начала вращения и рандомизации барабанов
    public void SpinReels()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        
        // Здесь можно добавить логику для начала вращения барабанов
    }



    public void Start()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        // Инициализируем массив начальных позиций
        initialPositions = new Vector3[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {
            // Сохраняем начальную позицию каждого барабана
            initialPositions[i] = reels[i].transform.position;
        }
    }

    // Рандомизация символов на отдельном барабане
    public void RandomizeReel(GameObject reel)
    {
        foreach (Transform symbol in reel.transform)
        {
            int randomIndex = Random.Range(0, symbols.Length);
            Sprite selectedSprite = symbols[randomIndex];

            Vector3 newPosition = symbol.transform.position;
            newPosition.z = -2;

            symbol.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            symbol.transform.position = newPosition;
        }
    }

    public void ResetReels()
    {
        
        for (int i = 0; i < reels.Length; i++)
        {
            // Сбросить позицию каждого барабана в его начальную позицию
            reels[i].transform.position = initialPositions[i];
            // Рандомизировать символы на барабане
            RandomizeReel(reels[i]);
            
        }
    }

    public void CheckWin(int r, int p)
    {
        var x = WinningLines(GetSymbolAtPosition(reels[r],p));
        if (x)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Lose");
        }
        
    
    }
    
    public bool WinningLines(Sprite firstSymbol)
    {
       
        
        for (int i = 0; i < 3; i++)
        {
            if (GetSymbolAtPosition(reels[i], 0) != firstSymbol)
            {
                   return false;
            }
        }
        return true;
    }


    public Sprite GetSymbolAtPosition(GameObject reel, int position)
    {
        // Позиции выигрышных символов в вашей иерархии, предполагая что last 3 - это 0, last 2 - это 1 и last 1 - это 2
        string[] winningSymbolNames = { "last 1", "last 2", "last 3" };

        if (position < 0 || position >= winningSymbolNames.Length)
        {
            Debug.LogError("Position for GetSymbolAtPosition is out of range.");
            return null;
        }

        // Ищем дочерний объект по имени, соответствующему выигрышному символу
        Transform symbolTransform = reel.transform.Find(winningSymbolNames[position]);
        if (symbolTransform == null)
        {
            Debug.LogError("Could not find a symbol at the specified position: " + position);
            return null;
        }

        SpriteRenderer spriteRenderer = symbolTransform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.sprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer not found on the symbol at position: " + position);
            return null;
        }
    }
}
