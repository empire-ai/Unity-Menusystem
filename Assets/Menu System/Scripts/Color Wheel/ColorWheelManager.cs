using MenuSystem.Colors;
using MenuSystem.Menus;
using UnityEngine;

namespace MenuSystem.ColorWheel
{
    public class ColorWheelManager : MonoBehaviour
    {
        public static ColorWheelManager Instance;
        private void Awake() => Instance = this;

        [SerializeField] private ColorWheelSettings _colorWheelSettings = null;

        private ColorWheelHandler _picked;
        public Menu PreviousMenu;

        public static void OpenColorWheel(Itshe itshe, ColorWheelHandler picked)
        {
            Instance._picked = picked;
            Instance._colorWheelSettings.SetItsh(itshe);
            Instance.PreviousMenu = MenuContainer.Instance.Current;
            MenuContainer.ShowMenu(Instance._colorWheelSettings);
        }

        public static void ValuePicked(Itshe itshe)
        {
            Instance._picked?.Invoke(itshe);
        }
    }

    public delegate void ColorWheelHandler(Itshe itshe);
}