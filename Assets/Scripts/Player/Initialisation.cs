using Environment;
using UnityEngine;

namespace Player
{
    public class Initialisation: MonoBehaviour
    {
        [SerializeField] private CurrentRoom startRoom;
        [SerializeField] private Console.Output cout;
        
        private void Start()
        {
            cout.LogRoom(startRoom);
            cout.DisplayLog();
        }
    }
}