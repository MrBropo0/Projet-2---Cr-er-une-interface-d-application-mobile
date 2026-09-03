using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSelector : MonoBehaviour
{
    UIDocument document;
    VisualElement root;

    VisualElement mainPanel;

    VisualElement spritePos;
    [SerializeField] Sprite[] sprites;

    int selectedCharacter= 0;

    int[,] stats = new int[4, 6];
    Label[] attributes = new Label[6];

    [SerializeField] string[] characterName;
    Label chName;

    Button[] switchButtons = new Button[2];
    Button[] increaseStatButton = new Button[6];
    Button[] decreaseStatButton = new Button[6];

    Button createButton;


    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        root = document.rootVisualElement;
        mainPanel = root.Q<VisualElement>("MainPanel");

        spritePos = root.Q<VisualElement>("SpritePos");
        spritePos.style.backgroundImage = new StyleBackground(sprites[0]);

        for (int i = 0; i < 6; i++)
        {
            attributes[i] = root.Q<Label>($"Value{i}");
        }

        chName = root.Q<Label>("CharacterName");
        Debug.Log(chName == null ? "NON trouvé !" : "trouvé : " + chName.name);

        chName.text = characterName[0];

        switchButtons[0] = root.Q<Button>("PreviousButton");
        switchButtons[1] = root.Q<Button>("NextButton");

        switchButtons[0].clicked += NextCharacter;
        switchButtons[1].clicked += PreviousCharacter;

        for (int i = 0; i < 6; i++)
        {
            increaseStatButton[i] = root.Q<Button>($"Increase{i}");

            int statIndex = i;
            increaseStatButton[i].clicked += () => IncreaseStat(statIndex);
        }

        for (int i = 0; i < 6; i++)
        {
            decreaseStatButton[i] = root.Q<Button>($"Decrease{i}");

            int statIndex = i;
            decreaseStatButton[i].clicked += () => DecreaseStat(statIndex);
        }



        for (int i = 0; i < 4 ; i++)
        {
            for (int j = 0; j < 6 ; j++)
            {
                stats[i, j] = UnityEngine.Random.Range(0, 99);
            }
        }

        createButton = root.Q<Button>("CreateButton");
        createButton.clicked += OnCreateButtonClicked;

        SwitchCharacter(0);
    }

    void SwitchCharacter(int add)
    {
        selectedCharacter += add;

        if (selectedCharacter >= sprites.Length)
        {
            selectedCharacter = 0;
        }
        if (selectedCharacter < 0)
        {
            selectedCharacter = sprites.Length -1;
        }

        spritePos.style.backgroundImage = new StyleBackground(sprites[selectedCharacter]);

        chName.text = characterName[selectedCharacter];

        int index = 0;

        foreach (var stat in attributes)
        {
            stat.text = stats[selectedCharacter, index].ToString();
            index++;
        }
    }

    void NextCharacter()
    {
        SwitchCharacter(1);
    }

    void PreviousCharacter()
    {
        SwitchCharacter(-1);
    }

    void IncreaseStat(int atb)
    {
        int newStat = Mathf.Clamp(int.Parse(attributes[atb].text) + 1, 0, 99);

        attributes[atb].text = newStat.ToString();
        stats[selectedCharacter, atb] = newStat;
    }

    void DecreaseStat(int atb)
    {
        int newStat = Mathf.Clamp(int.Parse(attributes[atb].text) - 1, 0, 99);

        attributes[atb].text = newStat.ToString();
        stats[selectedCharacter, atb] = newStat;
    }

    void OnCreateButtonClicked()
    {
        mainPanel.style.display = DisplayStyle.None;
    }
}
