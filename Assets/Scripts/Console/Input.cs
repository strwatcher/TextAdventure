using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private Output cout;
        private InputField _inputField;

        private void Awake()
        {
            _inputField = GetComponent<InputField>();
            _inputField.onEndEdit.AddListener(PrintBack);
        }

        private void PrintBack(string userInput)
        {
            cout.Display(userInput);
            _inputField.ActivateInputField();
            _inputField.text = null;
        }
    }
}
