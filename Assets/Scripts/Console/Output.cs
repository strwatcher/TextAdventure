using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class Output : MonoBehaviour
    {
        private const string endl = "\n";
        
        private Text _cout;

        private List<string> _log = new List<string>();

        private void Awake()
        {
            _cout = GetComponent<Text>();
        }

        private void LogOutput(string text)
        {
            _log.Add(text + endl);
        }

        public void Display(string text)
        {
            LogOutput(text);
            
            string combinedText = "";
            
            foreach (var line in _log)
            {
                combinedText += line + endl;
            }

            _cout.text = combinedText;
        }

    }
}
