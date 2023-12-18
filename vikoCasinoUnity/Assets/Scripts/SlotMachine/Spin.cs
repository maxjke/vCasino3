using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float initialSpeed = 5.0f; // ��������� �������� ��������
    public float spinTime = 2.0f; // �����, � ������� �������� ������� ����� ����������� �� ���������
    private bool isSpinning; // ���� ��� ��������, ��������� �� �������
    private bool firstSpin = true;
    public static bool isAnyReelSpinning = false;
    public SlotMachineController controller;


    void Start()
    {
        controller = FindAnyObjectByType<SlotMachineController>();
    }

    public void StartSpinning()
    {
        if (!isSpinning && !isAnyReelSpinning)
        {
            if (firstSpin)
            {
                StartCoroutine(SpinReel());
                firstSpin = false;
            }
            else 
            {
                controller.ResetReels();
                StartCoroutine(SpinReel());
            }
           
        }
    }
    private IEnumerator SpinReel()
    {
       
        isSpinning = true;
        float currentSpeed = initialSpeed;
        float timeSpinning = 0.0f;

        
        while (timeSpinning < spinTime)
        {
            
            currentSpeed = Mathf.Lerp(initialSpeed, 0, timeSpinning / spinTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime, Space.World);
            timeSpinning += Time.deltaTime;

            yield return null;
        }


        isSpinning = false;
        controller.ReelStopped();
       

    }

    
}