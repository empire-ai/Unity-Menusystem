using MenuSystem.Colors;
using UnityEngine;
using UnityEngine.UI;
using VoyagerController.UI;

namespace VoyagerApp
{
    /* This is a demo script to show how to use the components and get their values in code */

    public class DemoScript : MonoBehaviour
    {
        // These text objects are currently used to display the components data in the Demo Scene

        [SerializeField] Text ButtonText;
        [SerializeField] Text IntText;
        [SerializeField] Text ToggleText;
        [SerializeField] Text ColorText;
        [SerializeField] Text ListText;
        [SerializeField] Text PasswordText;
        [SerializeField] Text RegularText;

        /* Int Field and List Picker need to be referenced in code in order to use them properly
         * other components do not */

        [SerializeField] IntField intField;
        [SerializeField] ListPicker listPicker;

        int buttonClickCount = 0;

        public void Start()
        {
            /* To get updates when changes are made to the Int Field
             * It is neccesary to listen to the OnChanged event of the Int Field.
             * Here we are calling the OnIntChanged method every time the Int Field is changed */
            intField.OnChanged += OnIntChanged;
        }

        /* On each button component there is an OnClick event
         * that can be used to call methods in other scripts that need to run on a button press
         * this method is currently called when the button is pressed */
        public void OnButtonClick()
        {
            buttonClickCount++;
            ButtonText.text = "Button Clicked " + buttonClickCount + " times";
        }

        /* This method runs with the new int value every time the Int Field is changed 
         * this happens because we are using this method to listen to changes made to the int field */
        public void OnIntChanged(int value)
        {
            IntText.text = "Current int value is " + value;
        }

        /* This method runs every time the toggle is clicked.
         * The method which needs to run on a toggle click can be changed on 
         * the Toggle GameObject similarily to setting the Button Event */
        public void OnToggleChanged(bool value)
        {
            ToggleText.text = value == true ? "Toggle is currently on" : "Toggle is currently off";
        }

        /* This method runs every time the color is changed on the Color Wheel.
         * The method which needs to run on a color change can be changed on 
         * the Color Picker GameObject similarily to setting the Button Event */
        public void OnItsheChanged(Itshe value)
        {
            ColorText.text = "Color is currently " + value;
        }

        /* This method runs every time the List Picker is Opened.
         * The method which needs to run on opening the List Picker can be changed on 
         * the List Picker GameObject similarily to setting the Button Event */
        public void OnListPickerOpened()
        {
            ListText.text = "ListPicker is Opened";
        }

        /* This method runs every time the List Picker value is Changed.
         * The method which needs to run when a new selection is made on the List Picker can be changed on 
         * the List Picker GameObject similarily to setting the Button Event */
        public void OnListPickerChanged()
        {
            ListText.text = "ListPicker value is " + listPicker.Selected;
        }

        /* This method runs every time the Password value is Changed.
         * The method which needs to run when the Password value is changed can be changed on 
         * the Password GameObject similarily to setting the Button Event */
        public void OnPasswordValueChanged(string value)
        {
            PasswordText.text = "Password value is " + value;
        }

        /* This method runs every time the Text value is Changed.
         * The method which needs to run when the Text value is changed can be changed on 
         * the Password GameObject similarily to setting the Button Event */
        public void OnTextValueChanged(string value)
        {
            RegularText.text = "Text value is " + value;
        }
    }
}