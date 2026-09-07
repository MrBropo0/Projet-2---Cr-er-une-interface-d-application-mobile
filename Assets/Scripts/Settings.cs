using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    [SerializeField] UIDocument document;
    VisualElement root;

    List<Button> buttonToggle = new List<Button>();

    Label camTextLabel;
    List<Button> camButtons = new List<Button>();
    [SerializeField] List<string> camText = new List<string>();
    int camTextIndex = 1;

    Label hudTextLabel;
    List<Button> hudButtons = new List<Button>();
    [SerializeField] List<string> hudText = new List<string>();
    int hudTextIndex = 1;

    Label msgTextLabel;
    List<Button> msgButtons = new List<Button>();
    [SerializeField] List<string> msgText = new List<string>();
    int msgTextIndex = 1;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        root = document.rootVisualElement;
        buttonToggle = root.Query<Button>("ButtonToggle").ToList();

        foreach (var button in buttonToggle)
        {
            button.clicked += () => OnToggleButtonClicked(button);
        }

        camTextLabel = root.Q<Label>("DifficultyText");
        camButtons.Add(root.Q<Button>("CamButton1"));
        camButtons.Add(root.Q<Button>("CamButton2"));

        camButtons[0].clicked += () => OnListButtonClicked(camTextLabel, camText, ref camTextIndex, -1);
        camButtons[1].clicked += () => OnListButtonClicked(camTextLabel, camText, ref camTextIndex, 1);

        OnListButtonClicked(camTextLabel, camText, ref camTextIndex, 0);

        hudTextLabel = root.Q<Label>("HUDText");
        hudButtons.Add(root.Q<Button>("HUDButton1"));
        hudButtons.Add(root.Q<Button>("HUDButton2"));

        hudButtons[0].clicked += () => OnListButtonClicked(hudTextLabel, hudText, ref hudTextIndex, -1);
        hudButtons[1].clicked += () => OnListButtonClicked(hudTextLabel, hudText, ref hudTextIndex, 1);

        OnListButtonClicked(hudTextLabel, hudText, ref hudTextIndex, 0);

        msgTextLabel = root.Q<Label>("MsgText");
        msgButtons.Add(root.Q<Button>("MsgButton1"));
        msgButtons.Add(root.Q<Button>("MsgButton2"));

        msgButtons[0].clicked += () => OnListButtonClicked(msgTextLabel, msgText, ref msgTextIndex, -1);
        msgButtons[1].clicked += () => OnListButtonClicked(msgTextLabel, msgText, ref msgTextIndex, 1);

        OnListButtonClicked(msgTextLabel, msgText, ref msgTextIndex, 0);
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

    void OnListButtonClicked(Label lbl, List<string> txt, ref int index, int add)
    {
        index += add;

        if (index >= txt.Count)
            index = 0;

        if (index < 0)
            index = txt.Count - 1;

        lbl.text = txt[index];
    }
}
