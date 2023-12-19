using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinData : MonoBehaviour
{
    // 15-8, 13.334-9, 10.915-11, 9.229-13, 8-15
    protected float initialSpeed = 5.0f; // Ќачальна€ скорость вращени€
    protected float spinTime = 2.0f; // ¬рем€, в течение которого барабан будет замедл€тьс€ до остановки
    protected bool isSpinning; // ‘лаг дл€ проверки, вращаетс€ ли барабан
    protected bool firstSpin = true;
    public static bool isAnyReelSpinning = false;
}
