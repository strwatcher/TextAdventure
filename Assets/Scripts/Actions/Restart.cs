using Console;
using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Restart")]
    public class Restart : InputAction
    {
        [SerializeField] private SavedEnvironment defaultEnv;
        [SerializeField] private ItemState[] defaultStates;
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            env.savedEnvironment.items = defaultEnv.items;
            env.savedEnvironment.room = defaultEnv.room;
            for (int i = 0; i < defaultEnv.items.Length; ++i)
            {
                defaultEnv.items[i].state = defaultStates[i];
            }
            env.SwitchRoom(defaultEnv.room);
            cout.LogRoom(env);
        }
    }
}