using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotValue
{
    Crown,
    Diamond,
    Seven,
    Cherry,
    Bar
}
public class Slot : MonoBehaviour
{

    private int randomValue;
    [HideInInspector]public float timeInterval;
    [HideInInspector] public SlotValue randItem;
    private float speed;
    public SlotValue stoppedSlot;
    private SlotMachine sm;

    private void Start()
    {
        sm = gameObject.GetComponentInParent<SlotMachine>();
    }
    public IEnumerator Spin()
    {
        timeInterval = sm.timeInterval;
        randomValue = Random.Range(0, 90);
        speed = 30f + randomValue;
        while(speed >= 10f)//for (int i = 0; i < 30+randomValue; i++)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -2.5f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 2.17f);
            }

            yield return new WaitForSeconds(timeInterval);
        }
        StartCoroutine("EndSpin");
        yield return null;
    }
    public IEnumerator CheatSpin()
    {
        timeInterval = sm.timeInterval;
        randomValue = Random.Range(0, 90);
        speed = 30f + randomValue;
        while (speed >= 15f)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -2.5f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 2.17f);
            }

            yield return new WaitForSeconds(timeInterval);
        }
        while (speed >= 2f)
        {
            if (randItem == SlotValue.Crown)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -2.5f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -2.5f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Diamond)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1.55f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1.55f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Seven)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -0.6f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -0.6f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Cherry)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 0.4f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 0.4f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Bar)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 1.35f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 1.35f))
                {
                    speed = 0;
                }
            }
            speed = speed / 1.01f;
            yield return new WaitForSeconds(timeInterval);
        }
        speed = 0;
        CheckResults();
        yield return null;
    }
    private IEnumerator EndSpin()
    {
        while (speed >= 2f)
        {
            if (transform.localPosition.y < -1.55f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -2.5f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -2.5f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -0.6f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1.55f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1.55f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < 0.4f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -0.6f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -0.6f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < 1.35f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 0.4f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 0.4f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < 2.17f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 1.35f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 1.35f))
                {
                    speed = 0;
                }
            }
            speed = speed / 1.01f;
            yield return new WaitForSeconds(timeInterval);
        }
        speed = 0;
        CheckResults();
        yield return null;
    }
    private void CheckResults()
    {
        if (transform.localPosition.y == -2.5f)
        {
            stoppedSlot = SlotValue.Crown;
        }
        else if (transform.localPosition.y == -1.55f)
        {
            stoppedSlot = SlotValue.Diamond;
        }
        else if (transform.localPosition.y == -0.6f)
        {
            stoppedSlot = SlotValue.Seven;
        }
        else if (transform.localPosition.y == 0.4f)
        {
            stoppedSlot = SlotValue.Cherry;
        }
        else if (transform.localPosition.y == 1.35f)
        {
            stoppedSlot = SlotValue.Bar;
        }

        sm.WaitResults();
    }
}
