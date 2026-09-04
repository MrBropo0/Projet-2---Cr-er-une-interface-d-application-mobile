using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    [SerializeField] UIDocument document;
    VisualElement root;
    List<Button> buttonToggle = new List<Button>();

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        root = document.rootVisualElement;
        buttonToggle = root.Query<Button>("ButtonToggle").ToList();

        foreach (var button in buttonToggle)
        {
            button.clicked += () => OnToggleButtonClicked(button);
        }
    }

    void OnToggleButtonClicked(Button button)
    {
        if (button.ClassListContains("Panel_Button_Selected"))
        {
            button.RemoveFromClassList("Panel_Button_Selected");
        }
        else
            button.AddToClassList("Panel_Button_Selected");
    }
}
