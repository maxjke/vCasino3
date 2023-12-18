using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    private SlotMachineController machineController;

    private void Start()
    {
        machineController = GetComponent<SlotMachineController>();
    }

    public void Play()
    {
        machineController.StartSpin();
    }
}