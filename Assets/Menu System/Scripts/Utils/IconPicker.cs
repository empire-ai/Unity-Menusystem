using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class IconPicker : MonoBehaviour
{
    public int SelectedIndex;
    public Sprite[] Icons;
    public string[] IconNames;

    public void Start()
    {
        Icons = Resources.LoadAll<Sprite>("Icons");

        IconNames = new string[Icons.Length];

        for (int i = 0; i < Icons.Length; i++)
        {
            IconNames[i] = Icons[i].name;
        }

        gameObject.transform.Find("Icon").GetComponent<Image>().sprite = Icons[SelectedIndex];
    }

    public void IconChanged()
    {
        gameObject.transform.Find("Icon").GetComponent<Image>().sprite = Icons[SelectedIndex];
    }

    public void ChangeIcon(int index)
    {
        gameObject.transform.Find("Icon").GetComponent<Image>().sprite = Icons[index];
    }

    public void ChangeIcon(Sprite icon)
    {
        gameObject.transform.Find("Icon").GetComponent<Image>().sprite = icon;
    }
}
