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
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            env.savedEnvironment = Instantiate(defaultEnv);
            //Так блин делать нельзя, надо как-то переработать систему айтемов, чтобы обновление состояние айтема не меняло сам so
            foreach (var item in defaultEnv.items)
            {
                item.state = ItemState.Default;
            }
            env.SwitchRoom(defaultEnv.room);
            cout.LogRoom(env);
        }
    }
}