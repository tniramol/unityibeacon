using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class register : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField PhoneInput;
    public Dropdown TypeInput;
    public Button RegisterButton;
    // Start is called before the first frame update
    void Start()
    {
        RegisterButton.onClick.AddListener(() => {
            StartCoroutine(register_main.Instance.Web.Register(UsernameInput.text, PasswordInput.text, PhoneInput.text, TypeInput.value));
            //SceneManager.LoadScene("Home");
        });
    }
}
