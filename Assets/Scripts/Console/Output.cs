using System.Collections.Generic;
using Environment;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class Output : MonoBehaviour
    {
        private const string Endl = "\n";
        private const string ActionSign = ">\t";
        
        private Text _cout;

        private readonly List<string> _log = new List<string>();

        private void Awake()
        {
            _cout = GetComponent<Text>();
        }

        public void LogOutput(string text)
        {
            _log.Add(Endl + text);
        }

        public void LogRoom(RoomPackager env)
        {
            string roomDescription = Endl + env.savedEnvironment.room.GetDescription;

            foreach (string interaction in env.interactions)
            {
                roomDescription += Endl + ActionSign + interaction;
            }
            
            _log.Add(roomDescription + Endl);
        }

        public void DisplayLog()
        {
            string combinedText = " ";
            
            foreach (var line in _log)
            {
                combinedText += line + Endl;
            }

            _cout.text = combinedText;
        }

    }
}
