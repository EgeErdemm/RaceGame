using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shifting : MonoBehaviour
{
    private ButtonHandler buttonHandler;
    private Movement movement;

    [SerializeField] private RectTransform rpmClock;

    [SerializeField] private float rpmIncreasePower;

    [SerializeField] private float[] shiftingLineBorder;
    public int ShiftCount { get; private set; }

    private int maxShiftCount = 4;



    void Start()
    {
        buttonHandler = ButtonHandler.Instance;
        movement = Movement.Instance;

        ShiftCount = 1;

    }


    void Update()
    {
        if(buttonHandler != null)
        {
            if (buttonHandler.GasPressed)
            {
                IncreaseRpm();
            }
            else
            {
                DecreaseRpm();
            }
        }


        if (rpmClock.anchoredPosition.y > 700f)
        {
            movement.StopAcceleration();
        }

    }




    public void ChangeShift()
    {
        if (ShiftCount >= maxShiftCount)
            return;
        ShiftCount++;
        ShiftingDetection();
        movement.SetAccelerationPower(ShiftCount);
        if(rpmClock.anchoredPosition.y > 350f)
        {
            Vector3 rpm =new Vector3(0f,rpmClock.anchoredPosition.y/2f,0);
            rpmClock.anchoredPosition = rpm;
        }
        Debug.Log(ShiftCount);
    }

    private void ShiftingDetection()
    {
        int lastBorder =0;

        foreach (float border in shiftingLineBorder)
        {
            if(rpmClock.anchoredPosition.y < border)
            {
                break;
            }

            lastBorder++;

        }

        movement.VelocityReward(lastBorder);

        Debug.Log(lastBorder);
    }


    private void IncreaseRpm()
    {

        Vector3 rpmPos = rpmClock.anchoredPosition;
        rpmPos.y = rpmClock.anchoredPosition.y + Time.deltaTime * rpmIncreasePower;
        if (rpmClock.anchoredPosition.y >= 870) rpmPos.y = 870f;

        rpmClock.anchoredPosition = rpmPos;
    }

    private void DecreaseRpm()
    {

        Vector3 rpmPos = rpmClock.anchoredPosition;
        rpmPos.y = rpmClock.anchoredPosition.y - Time.deltaTime *rpmIncreasePower/10f;
        if (rpmClock.anchoredPosition.y <= 0) rpmPos.y = 0f;
        rpmClock.anchoredPosition = rpmPos;
        
    }

}
