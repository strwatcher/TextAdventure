using Environment;
using UnityEngine;

namespace Player
{
    public class Initialisation: MonoBehaviour
    {
        [SerializeField] private RoomPackager startRoomPackager;
        [SerializeField] private Console.Output cout;
        
        private void Start()
        {
            cout.LogRoom(startRoomPackager);
            cout.DisplayLog();
        }
    }
}