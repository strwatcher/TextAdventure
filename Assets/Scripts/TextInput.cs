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

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = input.Split(delimiterCharacters);

        foreach (var inputAction in _controller.inputActions)
        {
            if (inputAction.keyWord.Equals(separatedInputWords[0]))
            {
                inputAction.RespondToInput(_controller, separatedInputWords);
            }
        }
        
        InputComplete();
    }

    void InputComplete()
    {
        _controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
