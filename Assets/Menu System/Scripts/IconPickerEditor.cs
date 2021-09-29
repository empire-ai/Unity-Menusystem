#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IconPicker))]
public class IconPickerEditor : Editor
{
    private IconPicker iconPicker;

    public override void OnInspectorGUI()
    {
        iconPicker = target as IconPicker;

        EditorGUI.BeginChangeCheck();

        iconPicker.SelectedIndex = EditorGUILayout.Popup(new GUIContent("Button Icon"), iconPicker.SelectedIndex, iconPicker.IconNames);
        
        if (EditorGUI.EndChangeCheck())
            iconPicker.IconChanged();

        EditorUtility.SetDirty(iconPicker);
    }
}
#endif