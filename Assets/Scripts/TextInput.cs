using UnityEngine;
using UnityEngine.UI;
public class TextInput : MonoBehaviour
{
    public InputField inputField;
    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptInput);
    }

    private void AcceptInput(string input)
    {
        input = input.ToLower();
        _controller.LogStringWithReturn(input);
        InputComplete();
    }

    void InputComplete()
    {
        _controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
