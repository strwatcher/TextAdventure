using System.Collections.Generic;
using Environment;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class Output : MonoBehaviour
    {
        private const string endl = "\n";
        private const string actionSign = ">\t";
        
        private Text _cout;

        private readonly List<string> _log = new List<string>();

        private void Awake()
        {
            _cout = GetComponent<Text>();
        }

        public void LogOutput(string text)
        {
            _log.Add(endl + text);
        }

        public void LogRoom(CurrentRoom room)
        {
            string roomDescription = endl + room.room.GetDescription;

            foreach (string interaction in room.interactions)
            {
                roomDescription += endl + actionSign + interaction;
            }
            
            _log.Add(roomDescription + endl);
        }

        public void DisplayLog()
        {
            string combinedText = " ";
            
            foreach (var line in _log)
            {
                combinedText += line + endl;
            }

            _cout.text = combinedText;
        }

    }
}
