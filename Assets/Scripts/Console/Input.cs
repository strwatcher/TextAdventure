using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private Output cout;
        [SerializeField] private ActionExecutor player; 
        private InputField _inputField;
        
        private void Awake()
        {
            _inputField = GetComponent<InputField>();
            _inputField.onEndEdit.AddListener(TakeCommand);
        }

        public void TakeCommand(string userInput)
        {
            userInput = userInput.ToLower();
            char[] separators = { ' ' };
            string[] separatedCommand = userInput.Split(separators);
            player.SetAction(separatedCommand);
            ResetInputField();
        }
        
        private void ResetInputField()
        {
            _inputField.ActivateInputField();
            _inputField.text = null;
        }
    }
}
