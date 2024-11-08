using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift_Opponent : MonoBehaviour
{
    private Movement_Opponent movement_Opponent;


    public int ShiftCount { get; private set; }

    private int maxShiftCount = 4;

    [SerializeField] private float opponentLevel; // every level = 1/2 sec
    private float shiftingTime;
    private float baseShiftingTime = 1f;
    private float shiftingRpmValue;

    void Start()
    {
        movement_Opponent = Movement_Opponent.Instance;

        ShiftCount = 1;
        shiftingRpmValue = ShiftingRpm(); // Assume level = 1 and baseTime = 1, (level / 2 + baseTime) * 200 = 300
    }



    private void Update()
    {
        shiftingTime -= Time.deltaTime;
        if (shiftingTime <= 0)
        {
            Shift();
            ShiftingRpm();
            movement_Opponent.VelocityReward(shiftingRpmValue);
        }
    }

    private float ShiftingRpm()
    {
        shiftingTime = baseShiftingTime + opponentLevel / 2f;
        return shiftingTime * 200;
    }

    public void Shift()
    {
        if (ShiftCount >= maxShiftCount) return;

        ShiftCount++;
        movement_Opponent.SetAccelerationPower(ShiftCount);


    }


}
