using MenuSystem.Components;
using UnityEngine;

namespace MenuSystem.ColorWheel
{
    public class ColorWheelAdjustmentList : MonoBehaviour
    {
        [SerializeField] ListPicker MovementSelection;

        public void OnSelectionChanged()
        {
            string selected = MovementSelection.Selected;

            switch (selected)
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
}
