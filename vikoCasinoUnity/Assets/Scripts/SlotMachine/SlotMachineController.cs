using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

[System.Serializable]
public class SymbolMultiplier
{
    public Sprite symbol;
    public int multiplier;
}
public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // ������ GameObject ���������
    public Sprite[] symbols; // ������ ���� ��������� �������� ��������
    public SymbolMultiplier[] symbolMultipliers;
    private Vector3[] initialPositions; // ������ ��� �������� ��������� ������� ���������
    // ���������� ��� ������ �������� � ������������ ���������
    private int stoppedReels;

   


    public void Start()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        // �������������� ������ ��������� �������
        initialPositions = new Vector3[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {
            // ��������� ��������� ������� ������� ��������
            initialPositions[i] = reels[i].transform.position;
        }
    }

    public void StartSpin()
    {
        foreach(GameObject reel in reels)
        {
            reel.GetComponent<Spin>().StartSpinning();
        }
    }

    public void ReelStopped()
    {
        stoppedReels++;
        if(stoppedReels == reels.Length)
        {
            CheckWin(0, 0, 1);
            CheckWin(0, 1, 1);
            CheckWin(0, 2, 1);
            CheckVLineWin(1);
            Spin.isAnyReelSpinning = false;
            stoppedReels = 0;
           
        }
        else
        {
            Spin.isAnyReelSpinning = true;
        }
    }

    // ������������ �������� �� ��������� ��������
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
            // �������� ������� ������� �������� � ��� ��������� �������
            reels[i].transform.position = initialPositions[i];
            // ��������������� ������� �� ��������
            RandomizeReel(reels[i]);
            
        }
    }

    public void CheckWin(int r, int p, int UserBet)
    {
        int bet = UserBet;
        Sprite firstSymbol = GetSymbolAtPosition(reels[r], p);
        int winningLinesCount = WinningLines(firstSymbol);

        if (winningLinesCount > 0)
        {
            List<Sprite> landedSymbols = GetLandedSymbols();
            int reward = CalculateReward(landedSymbols, bet);
            Debug.Log("Win on " + winningLinesCount + " horizontal lines with reward: " + reward);
        }
        else
        {
            Debug.Log("Lose");
        }
    }

    public void CheckVLineWin(int UserBet)
    {
        for (int length = 5; length >= 3; length--)
        {
            // ������������, ��� ������ ��� �������� ������� � ������� �������� � ������� ������
            Sprite firstSymbol = GetSymbolAtPosition(reels[0], 0);

            if (IsVWinningLine(firstSymbol, length))
            {
                int bet = UserBet;
                List<Sprite> landedSymbols = GetLandedSymbols();
                int reward = CalculateReward(landedSymbols, bet);
                Debug.Log($"Win on V-line of length {length} with reward: " + reward);
                return; // ��� ���������� ���������� ����� ���������� ��������
            }
        }

        Debug.Log("No win on V-line");
    }

    public int WinningLines(Sprite firstSymbol)
    {
        int totalHorizontalWinningLines = 0;

        for (int line = 0; line < 3; line++)
        {
            if (IsWinningLine(firstSymbol, line))
            {
                totalHorizontalWinningLines++;
            }
        }

        return totalHorizontalWinningLines;
    }

    private bool IsWinningLine(Sprite symbol, int line)
    {
        int count = 0;
        for (int reel = 0; reel < reels.Length; reel++)
        {
            Sprite currentSymbol = GetSymbolAtPosition(reels[reel], line);
            if (currentSymbol == symbol)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        return count >= 3;
    }

    private bool IsVWinningLine(Sprite symbol, int length)
    {
        if (length < 3 || length > 5) return false;

        int midReel = (reels.Length - 1) / 2;
        int lastIndex = length - 1;

        for (int i = 0; i < length; i++)
        {
            int reelIndex, position;

            if (i <= midReel)
            {
                // ���������� ����� V
                reelIndex = i;
                position = i;
            }
            else
            {
                // ���������� ����� V
                reelIndex = lastIndex - (i - midReel);
                position = lastIndex - i;
            }

            if (GetSymbolAtPosition(reels[reelIndex], position) != symbol)
            {
                return false;
            }
        }

        return true;
    }


    public Sprite GetSymbolAtPosition(GameObject reel, int position)
    {
        // ������� ���������� �������� � ����� ��������, ����������� ��� last 3 - ��� 0, last 2 - ��� 1 � last 1 - ��� 2
        string[] winningSymbolNames = { "last 1", "last 2", "last 3" };

        if (position < 0 || position >= winningSymbolNames.Length)
        {
            Debug.LogError("Position for GetSymbolAtPosition is out of range.");
            return null;
        }

        // ���� �������� ������ �� �����, ���������������� ����������� �������
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

    public List<Sprite> GetLandedSymbols()
    {
        List<Sprite> landedSymbols = new List<Sprite>();

        for (int reelIndex = 0; reelIndex < reels.Length; reelIndex++)
        {
            for (int position = 0; position < 3; position++)
            { // ����������� 3 ������� �� ��������
                Sprite symbol = GetSymbolAtPosition(reels[reelIndex], position);
                if (symbol != null)
                {
                    landedSymbols.Add(symbol);
                }
            }
        }

        return landedSymbols;
    }
    public int CalculateReward(List<Sprite> landedSymbols, int betAmount)
    {
        // ������� ��� �������� ���������� ������� �������
        Dictionary<Sprite, int> symbolCounts = new Dictionary<Sprite, int>();
        int totalReward = 0;

        // ������������ ���������� ������� �������
        foreach (var symbol in landedSymbols)
        {
            if (symbolCounts.ContainsKey(symbol))
            {
                symbolCounts[symbol]++;
            }
            else
            {
                symbolCounts[symbol] = 1;
            }
        }

        // ��������� ��������� � �����������
        foreach (var symbolCount in symbolCounts)
        {
            foreach (var symbolMultiplier in symbolMultipliers)
            {
                if (symbolCount.Key == symbolMultiplier.symbol)
                {
                    totalReward += symbolCount.Value * symbolMultiplier.multiplier * betAmount;
                    break; // ����� ���������� ��������� ��� �������, ��������� � ����������
                }
            }
        }

        return totalReward;
    }
}
