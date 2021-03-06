using System;
using MenuSystem.Colors;
using MenuSystem.ColorWheel;
using MenuSystem.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MenuSystem.Components
{
    public class ItshePicker : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image = null;
        [SerializeField] private Itshe _itshe = null;
        
        // ReSharper disable once InconsistentNaming
        public ItshEvent OnValueChanged;

        private void Start()
        {
            Value = _itshe;
        }

        public Itshe Value
        {
            get => _itshe;
            set
            {
                _image.color = value.ToColor();
                _itshe = value;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ColorWheelManager.OpenColorWheel(Value, OnItshPicked);
        }

        public void OnItshPicked(Itshe itshe)
        {
            Value = itshe;
            OnValueChanged?.Invoke(itshe);
        }
    }

    [Serializable]
    public class ItshEvent : UnityEvent<Itshe> { }
}