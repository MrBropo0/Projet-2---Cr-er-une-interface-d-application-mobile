using UnityEngine;
using UnityEngine.UIElements;

public class LoginPage : MonoBehaviour
{
    [SerializeField] UIDocument document;
    VisualElement root;
    TextField email;
    TextField password;
    Label emailError;
    Label passwordError;
    Button loginButton;

    [SerializeField] VisualTreeAsset characterSelection;
    CharacterSelector characterSelector;

    private void OnEnable()
    {
        root = document.rootVisualElement;

        email = root.Q<TextField>("EmailTextField");
        password = root.Q<TextField>("PasswordTextField");

        emailError = root.Q<Label>("EmailError");
        passwordError = root.Q<Label>("PasswordError");

        email.RegisterCallback<FocusInEvent>(evt => { emailError.style.display = DisplayStyle.None; });
        password.RegisterCallback<FocusInEvent>(evt => { passwordError.style.display = DisplayStyle.None; });

        loginButton = root.Q<Button>("LoginButton");
        loginButton.clicked += OnButtonClicked;

        characterSelector = GetComponent<CharacterSelector>();
    }


    public void OnButtonClicked()
    {
        if (string.IsNullOrEmpty(email.text))
        {
           emailError.style.display = DisplayStyle.Flex;
        }
        if (string.IsNullOrEmpty(password.text))
        {
            passwordError.style.display = DisplayStyle.Flex;
        }

        if (!string.IsNullOrEmpty(email.text) && !string.IsNullOrEmpty(password.text))
        {
            document.visualTreeAsset = characterSelection;
            characterSelector.enabled = true;
        }
    
    }

}
