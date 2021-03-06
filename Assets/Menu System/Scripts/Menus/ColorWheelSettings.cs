using MenuSystem.Colors;
using MenuSystem.ColorWheel;
using MenuSystem.Components;
using UnityEngine;

namespace MenuSystem.Menus
{
    public class ColorWheelSettings : Menu
    {
        [SerializeField] private CanvasGroup _colorWheelCanvasGroup = null;
        [SerializeField] private GameObject _showHideMenu = null;
        [Space(3)]
        [SerializeField] private IntField _intensitySlider = null;
        [SerializeField] private IntField _temperatureSlider = null;
        [SerializeField] private IntField _saturationSlider = null;
        [SerializeField] private IntField _hueSlider = null;
        [Space(3)]
        [SerializeField] private ColorWheelEventSystem _wheel = null;

        private Itshe _beginning;
        private Itshe _itshe;
        private bool _approved;
        private bool _changed;

        public void SetItsh(Itshe itshe)
        {
            _beginning = new Itshe(itshe.I, itshe.T, itshe.S, itshe.H, itshe.E);
            _itshe = itshe;

            if (_intensitySlider != null)
                _intensitySlider.SetValue(itshe.I);

            if (_temperatureSlider != null)
                _temperatureSlider.SetValue(itshe.T);

            if (_saturationSlider != null)
                _saturationSlider.SetValue(itshe.S);

            if (_hueSlider != null)
                _hueSlider.SetValue(itshe.H);

            _wheel.SetFromItsh(itshe);
        }

        public void Approve() => _approved = true;

        public override void Start()
        {
            base.Start();

            var rect = _colorWheelCanvasGroup.GetComponent<RectTransform>();
            rect.offsetMin = new Vector2(0.0f, 0.0f);
            rect.offsetMax = new Vector2(0.0f, 0.0f);

            HideColorWheel();
        }

        internal override void OnShow()
        {
            _showHideMenu.SetActive(false);

            ShowColorWheel();
            SubscribeSliders();
            SubscribeWheel();

            InvokeRepeating(nameof(UpdateLoop), 0.0f, 0.2f);
        }

        internal override void OnHide()
        {
            _showHideMenu.SetActive(true);

            HideColorWheel();
            UnsubscribeSliders();
            UnsubscribeWheel();

            StopAllCoroutines();
        }

        private void UpdateLoop()
        {
            if (!_changed) return;

            ColorWheelManager.ValuePicked(_itshe);
            _changed = false;
        }

        #region Sliders

        private void SubscribeSliders()
        {
            if (_intensitySlider != null)
                _intensitySlider.OnChanged += SliderChanged;

            if (_temperatureSlider != null)
                _temperatureSlider.OnChanged += SliderChanged;

            if (_saturationSlider != null)
                _saturationSlider.OnChanged += SliderChanged;

            if (_hueSlider != null)
                _hueSlider.OnChanged += SliderChanged;
        }

        private void UnsubscribeSliders()
        {
            if (_intensitySlider != null)
                _intensitySlider.OnChanged -= SliderChanged;

            if (_temperatureSlider != null)
                _temperatureSlider.OnChanged -= SliderChanged;

            if (_saturationSlider != null)
                _saturationSlider.OnChanged -= SliderChanged;

            if (_hueSlider != null)
                _hueSlider.OnChanged -= SliderChanged;
        }

        private void SliderChanged(int value)
        {
            float i = 1.0f;
            float t = 1.0f;
            float s = 1.0f;
            float h = 1.0f;

            if (_intensitySlider != null)
                i = _intensitySlider.Normalized;

            if (_temperatureSlider != null)
                t = _temperatureSlider.Normalized;

            if (_saturationSlider != null)
                s = _saturationSlider.Normalized;

            if (_hueSlider != null)
                h = _hueSlider.Normalized;

            _itshe = new Itshe(i, t, s, h, 1.0f);

            UnsubscribeWheel();
            _wheel.SetFromItsh(_itshe);
            SubscribeWheel();

            _changed = true;
        }

        #endregion

        #region Wheel

        private void SubscribeWheel()
        {
            _wheel.OnHueSaturationChanged += WheelHueSaturationChanged;
        }

        private void UnsubscribeWheel()
        {
            _wheel.OnHueSaturationChanged -= WheelHueSaturationChanged;
        }

        private void WheelHueSaturationChanged(float hue, float saturation)
        {
            _itshe.S = saturation;
            _itshe.H = hue;

            UnsubscribeSliders();

            if (_saturationSlider != null)
                _saturationSlider.SetValue(saturation);

            if (_hueSlider != null)
                _hueSlider.SetValue(hue);

            SubscribeSliders();

            _changed = true;
        }
        #endregion

        private void ShowColorWheel()
        {
            _colorWheelCanvasGroup.alpha = 1.0f;
            _colorWheelCanvasGroup.interactable = true;
            _colorWheelCanvasGroup.blocksRaycasts = true;

            _approved = false;
        }

        public void HideMenu()
        {
            MenuContainer.ShowMenu(ColorWheelManager.Instance.PreviousMenu);
            ColorWheelManager.Instance.PreviousMenu = null;
        }

        public void HideColorWheel()
        {
            _colorWheelCanvasGroup.alpha = 0.0f;
            _colorWheelCanvasGroup.interactable = false;
            _colorWheelCanvasGroup.blocksRaycasts = false;

            if (!_approved)
                ColorWheelManager.ValuePicked(_beginning);
        }
    }
}