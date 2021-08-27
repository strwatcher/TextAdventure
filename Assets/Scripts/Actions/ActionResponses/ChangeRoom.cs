using Console;
using Environment;
using UnityEngine;

namespace Actions.ActionResponses
{
    [CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
    public class ChangeRoom : ActionResponse
    {
        [SerializeField] private Room newRoom;
        public override bool GetActionResponse(RoomPackager env, Output cout)
        {
            if (env.savedEnvironment.room.GetKey.Equals(GetFactor))
            { 
                env.SwitchRoom(newRoom);
                cout.LogRoom(env);
                return true;
            }

            return false;
        }
    }
}