using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;
using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Interfaces.SlotMacine;
using Assets.DataAccess.Classes.SlotMacine;
using Assets.DataAccess.Classes.Base_Classes;
using UnityEngine.Windows;
using TMPro;
using System.Linq;

public class SlotMachineController : MonoBehaviour
{
    //public GameObject[] reels; 
    //public Sprite[] symbols; 
    //public SymbolMultiplier[] symbolMultipliers;
    //private Vector3[] initialPositions;
    //private int stoppedReels;
    //public TextMeshProUGUI bet;
    //public bool canWeBet = true;
    //public void Start()
    //{
    //    foreach (GameObject reel in reels)
    //    {
    //        RandomizeReel(reel);
    //    }
    //    initialPositions = new Vector3[reels.Length];
    //    for (int i = 0; i < reels.Length; i++)
    //    {
          
    //        initialPositions[i] = reels[i].transform.position;
    //    }
    //}

    //public int Bet()
    //{   
    //    var x = bet.GetParsedText();
    //    x = RemoveInvisibleCharacters(x);

    //    if (int.Parse(x) > Settings.Balance.getAmount() )
    //    {
    //        return -1;
    //    }
    //    else 
    //    {
    //        return int.Parse(x);
    //    }
      
    //}
   
    //public void StartSpin()
    //{
    //    foreach(GameObject reel in reels)
    //    {
    //        reel.GetComponent<Spin>().StartSpinning();
    //    }
    //}

    //public void ReelStopped()
    //{
    //    stoppedReels++;
    //    if(stoppedReels == reels.Length)
    //    {  
    //        CheckWin(0, Bet());
    //        CheckWin(1, Bet());
    //        CheckWin(2, Bet());
    //        CheckVLineWin(Bet());
    //        CheckInverseVLineWin(Bet());
    //        Spin.isAnyReelSpinning = false;
    //        canWeBet = true;
    //        stoppedReels = 0;
           
    //    }
    //    else
    //    {
    //        Spin.isAnyReelSpinning = true;
    //        canWeBet = false;
    //    }
    //}

    //public void RandomizeReel(GameObject reel)
    //{
    //    foreach (Transform symbol in reel.transform)
    //    {
    //        int randomIndex = Random.Range(0, symbols.Length);
    //        Sprite selectedSprite = symbols[randomIndex];

    //        Vector3 newPosition = symbol.transform.position;
    //        newPosition.z = -2;

    //        symbol.GetComponent<SpriteRenderer>().sprite = selectedSprite;
    //        symbol.transform.position = newPosition;
    //    }
    //}

    //public void ResetReels()
    //{
        
    //    for (int i = 0; i < reels.Length; i++)
    //    {
            
    //        reels[i].transform.position = initialPositions[i];
          
    //        RandomizeReel(reels[i]);
            
    //    }
    //}

    //public void CheckWin(int lineIndex, int betAmount)
    //{
       

    //    List<Sprite> winningSymbols = GetWinningSymbols(LineType.Horizontal, lineIndex);
    //    if (winningSymbols.Count > 0)
    //    {
    //        int reward = CalculateReward(winningSymbols, betAmount);
    //        Debug.Log($"Win on horizontal line with reward: {reward}");
    //        Settings.Balance.setAmount(Settings.Balance.getAmount()+reward);
    //    }
    //    else
    //    {
    //        Debug.Log("No win on horizontal line");
    //    }
    //}

    //public void CheckVLineWin(int betAmount)
    //{
    //    for (int length = 5; length >= 3; length--)
    //    {
    //        List<Sprite> winningSymbols = GetWinningSymbols(LineType.VShape, 0, length);
    //        if (winningSymbols.Count > 0)
    //        {
    //            int reward = CalculateReward(winningSymbols, betAmount);
    //            Debug.Log($"Win on V-line of length {length} with reward: {reward}");
    //            Settings.Balance.setAmount(Settings.Balance.getAmount() + reward);
    //            return; 
    //        }
    //    }

    //    Debug.Log("No win on V-line");
    //}


    //public void CheckInverseVLineWin(int betAmount)
    //{
    //    for (int length = 5; length >= 3; length--)
    //    {
    //        List<Sprite> winningSymbols = GetWinningSymbols(LineType.InverseV, 0, length);
    //        if (winningSymbols.Count > 0)
    //        {
    //            int reward = CalculateReward(winningSymbols, betAmount);
    //            Debug.Log($"Win on inverse V-line of length {length} with reward: {reward}");
    //            Settings.Balance.setAmount(Settings.Balance.getAmount() + reward);
    //            return; 
    //        }
    //    }

    //    Debug.Log("No win on inverse V-line");
    //}

    //public bool IsWinningLine(Sprite symbol, int line)
    //{
    //    int count = 0;
    //    for (int reel = 0; reel < reels.Length; reel++)
    //    {
    //        Sprite currentSymbol = GetSymbolAtPosition(reels[reel], line);
    //        if (currentSymbol == symbol)
    //        {
    //            count++;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    return count >= 3;
    //}

    //public bool IsVWinningLine(Sprite symbol, int length)
    //{
    //    if (length < 3 || length > 5) return false;

    //    int midReel = (reels.Length - 1) / 2;
    //    int lastIndex = length - 1;

    //    for (int i = 0; i < length; i++)
    //    {
    //        int reelIndex, position;

    //        if (i <= midReel)
    //        {
                
    //            reelIndex = i;
    //            position = i;
    //        }
    //        else
    //        {
                
    //            reelIndex = lastIndex - (i - midReel);
    //            position = lastIndex - i;
    //        }

    //        if (GetSymbolAtPosition(reels[reelIndex], position) != symbol)
    //        {
    //            return false;
    //        }
    //    }

    //    return true;
    //}

    //public bool IsInverseVWinningLine(Sprite symbol, int length)
    //{

    //    if (length == 5)
    //    {
    //        return GetSymbolAtPosition(reels[0], 2) == symbol &&
    //               GetSymbolAtPosition(reels[1], 1) == symbol &&
    //               GetSymbolAtPosition(reels[2], 0) == symbol &&
    //               GetSymbolAtPosition(reels[3], 1) == symbol &&
    //               GetSymbolAtPosition(reels[4], 2) == symbol;
    //    }
    //    else if (length == 4)
    //    {
    //        return GetSymbolAtPosition(reels[0], 2) == symbol &&
    //               GetSymbolAtPosition(reels[1], 1) == symbol &&
    //               GetSymbolAtPosition(reels[2], 0) == symbol &&
    //               GetSymbolAtPosition(reels[3], 1) == symbol;
    //    }
    //    else if (length == 3)
    //    {
    //        return GetSymbolAtPosition(reels[0], 2) == symbol &&
    //               GetSymbolAtPosition(reels[1], 1) == symbol &&
    //               GetSymbolAtPosition(reels[2], 0) == symbol;
    //    }

    //    return false;
    //}

    //    public Sprite GetSymbolAtPosition(GameObject reel, int position)
    //    { 
    //    int maxPosition = 2; 

    //    if (position < 0 || position > maxPosition)
    //    {
    //        Debug.LogError("Position for GetSymbolAtPosition is out of range.");
    //        return null;
    //    }
    //    string[] winningSymbolNames = { "last 1", "last 2", "last 3" };

    //    if (position < 0 || position >= winningSymbolNames.Length)
    //    {
    //        Debug.LogError("Position for GetSymbolAtPosition is out of range.");
    //        return null;
    //    }

       
    //    Transform symbolTransform = reel.transform.Find(winningSymbolNames[position]);
    //    if (symbolTransform == null)
    //    {
    //        Debug.LogError("Could not find a symbol at the specified position: " + position);
    //        return null;
    //    }

    //    SpriteRenderer spriteRenderer = symbolTransform.GetComponent<SpriteRenderer>();
    //    if (spriteRenderer != null)
    //    {
    //        return spriteRenderer.sprite;
    //    }
    //    else
    //    {
    //        Debug.LogError("SpriteRenderer not found on the symbol at position: " + position);
    //        return null;
    //    }
    //}

    //public enum LineType
    //{
    //    Horizontal,
    //    VShape,
    //    InverseV
    //}

    //public List<Sprite> GetWinningSymbols(LineType lineType, int lineIndex, int length = 0)
    //{
    //    List<Sprite> winningSymbols = new List<Sprite>();

    //    switch (lineType)
    //    {
    //        case LineType.Horizontal:
    //            Sprite firstSymbol = GetSymbolAtPosition(reels[0], lineIndex);
    //            if (IsWinningLine(firstSymbol, lineIndex))
    //            {
    //                for (int reel = 0; reel < reels.Length; reel++)
    //                {
    //                    winningSymbols.Add(GetSymbolAtPosition(reels[reel], lineIndex));
    //                }
    //            }
    //            break;

    //        case LineType.VShape:
    //        case LineType.InverseV:
    //            Sprite symbol = lineType == LineType.VShape ? GetSymbolAtPosition(reels[0], 0) : GetSymbolAtPosition(reels[0], 2);
    //            bool isWinning = lineType == LineType.VShape ? IsVWinningLine(symbol, length) : IsInverseVWinningLine(symbol, length);
    //            if (isWinning)
    //            {
    //                int midReel = (reels.Length - 1) / 2;
    //                int lastIndex = length - 1;

    //                for (int i = 0; i < length; i++)
    //                {
    //                    int reelIndex, position;
    //                    if (lineType == LineType.VShape)
    //                    {
    //                        reelIndex = i <= midReel ? i : lastIndex - (i - midReel);
    //                        position = i <= midReel ? i : lastIndex - i;
    //                    }
    //                    else
    //                    {
    //                        reelIndex = i <= midReel ? i : lastIndex - (i - midReel);
    //                        position = i <= midReel ? 2 - i : 1 + (i - midReel);
    //                    }
    //                    winningSymbols.Add(GetSymbolAtPosition(reels[reelIndex], position));
    //                }
    //            }
    //            break;
    //    }

    //    return winningSymbols;
    //}
    //public int CalculateReward(List<Sprite> winningSymbols, int betAmount)
    //{
    //    Dictionary<Sprite, int> symbolCounts = new Dictionary<Sprite, int>();
    //    int totalReward = 0;

        
    //    foreach (var symbol in winningSymbols)
    //    {
    //        if (symbolCounts.ContainsKey(symbol))
    //        {
    //            symbolCounts[symbol]++;
    //        }
    //        else
    //        {
    //            symbolCounts[symbol] = 1;
    //        }
    //    }

       
    //    foreach (var symbolCount in symbolCounts)
    //    {
    //        foreach (var symbolMultiplier in symbolMultipliers)
    //        {
    //            if (symbolCount.Key == symbolMultiplier.symbol)
    //            {
    //                int multiplier = 0;
    //                switch (symbolCount.Value)
    //                {
    //                    case 3:
    //                        multiplier = symbolMultiplier.multiplierForThree;
    //                        break;
    //                    case 4:
    //                        multiplier = symbolMultiplier.multiplierForFour;
    //                        break;
    //                    case 5:
    //                        multiplier = symbolMultiplier.multiplierForFive;
    //                        break;
    //                }

    //                totalReward += multiplier * betAmount;
    //                break;
    //            }
    //        }
    //    }

    //    return totalReward;
    //}
    //private string RemoveInvisibleCharacters(string str)
    //{
    //    return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
    //}
}
