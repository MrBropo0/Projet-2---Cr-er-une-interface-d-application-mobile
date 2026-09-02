using UnityEngine;
using UnityEngine.UIElements;

public class LoginPage : MonoBehaviour
{
    [SerializeField] UIDocument document;
    VisualElement root;
    VisualElement mainPanel;
    TextField email;
    TextField password;
    Label emailError;
    Label passwordError;
    Button loginButton;

    private void Awake()
    {
        root = document.rootVisualElement;

        mainPanel = root.Q<VisualElement>("MainPanel");

        email = root.Q<TextField>("EmailTextField");
        password = root.Q<TextField>("PasswordTextField");

        emailError = root.Q<Label>("EmailError");
        passwordError = root.Q<Label>("PasswordError");

        email.RegisterCallback<FocusInEvent>(evt => { emailError.style.display = DisplayStyle.None; });
        password.RegisterCallback<FocusInEvent>(evt => { passwordError.style.display = DisplayStyle.None; });

        loginButton = root.Q<Button>("LoginButton");
        loginButton.clicked += OnButtonClicked;
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
            mainPanel.style.display = DisplayStyle.None;
        }
    
    }

}
