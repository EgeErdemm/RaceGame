using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour
{
    public static ButtonHandler Instance { get; private set; }

    private Movement movement;

    public bool GasPressed { get; private set; }


    private void Awake()
    {
        if(Instance !=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        movement = Movement.Instance;
    }




    public void OnPointerDown()
    {
        GasPressed = true;
    }

    public void OnPointerUp()
    {
        GasPressed = false;
    }




}
