using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpin : MonoBehaviour
{
    private bool isAutoSpinRunning = false;
    private Coroutine autoSpinCoroutine = null;
    public SlotMachine slotMachine;

    public void OnAutoSpinButtonClicked()
    {
        if (!isAutoSpinRunning)
        {
          
            autoSpinCoroutine = StartCoroutine(AutoSpinCoroutine());
        }
        else
        {
            
            if (autoSpinCoroutine != null)
            {
                StopCoroutine(autoSpinCoroutine);
            }
            isAutoSpinRunning = false;
        }
    }
    IEnumerator AutoSpinCoroutine()
    {
        isAutoSpinRunning = true;
        while (isAutoSpinRunning)
        {
            slotMachine.Play(); 
            yield return new WaitForSeconds(3); 
        }
    }

}
