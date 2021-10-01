using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VoyagerController.UI;

public class ColorWheelAdjustmentButtons : MonoBehaviour
{
    [SerializeField] ToggleGroup MovementGroup;

    public void OnToggleChanged()
    {
        Toggle activeToggle = MovementGroup.ActiveToggles().First();

        switch (activeToggle.name)
        {
            case "Snap":
                ColorWheelEventSystem.Movement = MovementType.Snap;
                break;
            case "Joystick":
                ColorWheelEventSystem.Movement = MovementType.Joystick;
                break;
            case "Free Movement":
                ColorWheelEventSystem.Movement = MovementType.Free;
                break;
        }
    }
}
