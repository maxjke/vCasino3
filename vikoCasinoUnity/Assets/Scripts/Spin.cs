using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float initialSpeed = 5.0f; // Начальная скорость вращения
    public float spinTime = 2.0f; // Время, в течение которого барабан будет замедляться до остановки
    public float endPositionY; // Y-координата, при достижении которой спрайт переносится вверх
    public float resetPositionY; // Y-координата, куда спрайт перемещается для начала нового цикла
    private bool isSpinning; // Флаг для проверки, вращается ли барабан
    private bool firstSpin = true;
    public SlotMachineController controller;


    void Start()
    {
        controller = FindAnyObjectByType<SlotMachineController>();
    }

    public void StartSpinning()
    {
        if (!isSpinning)
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
            //controller.CheckWin(0, 0);
            //controller.CheckWin(0, 1);
            //controller.CheckWin(0, 2);
        }
    }
    private IEnumerator SpinReel()
    {
        isSpinning = true;
        float currentSpeed = initialSpeed;
        float timeSpinning = 0.0f;

        // Плавное замедление вращения от initialSpeed до 0 за время spinTime
        while (timeSpinning < spinTime)
        {
            // Замедление барабана со временем
            currentSpeed = Mathf.Lerp(initialSpeed, 0, timeSpinning / spinTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime, Space.World);
            timeSpinning += Time.deltaTime;

            //// Проверка, достиг ли барабан нижней границы
            //if (transform.position.y < endPositionY)
            //{
            //    // Перемещение барабана обратно вверх
            //    Vector3 newPosition = transform.position;
            //    newPosition.y = resetPositionY;
            //    transform.position = newPosition;
            //}

            yield return null;
        }

        // После замедления, остановить барабан
        isSpinning = false;
        controller.ReelStopped();
        

    }

    
}
