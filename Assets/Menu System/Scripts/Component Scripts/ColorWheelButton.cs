using MenuSystem.Colors;
using UnityEngine;
using UnityEngine.UI;

namespace VoyagerController.UI
{
    [RequireComponent(typeof(Button))]
    public class ColorWheelButton : MonoBehaviour
    {
        [SerializeField] private Image _previewColor = null;

        private Itshe _currentItshe;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Click);
            SelectionChanged();
        }

        private void SelectionChanged()
        {
            _previewColor.gameObject.SetActive(false);
            _button.interactable = false;
        }

        public void Click()
        {
            ColorWheelManager.OpenColorWheel(_currentItshe, ItsheChanged);
        }

        private void ItsheChanged(Itshe itshe)
        {
            _currentItshe = itshe;
            _previewColor.color = itshe.ToColor();
        }
    }
}