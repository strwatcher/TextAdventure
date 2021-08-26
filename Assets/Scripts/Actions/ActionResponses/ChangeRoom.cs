using Console;
using Environment;
using UnityEngine;

namespace Actions.ActionResponses
{
    [CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
    public class ChangeRoom : ActionResponse
    {
        [SerializeField] private Room newRoom;
        public override void GetActionResponse(RoomPackager env, Output cout)
        {
            if (env.savedEnvironment.room.GetKey.Equals(GetFactor))
            { 
                cout.LogOutput(messages.GenerateMessage(messages.successTemplate, ""));
                env.SwitchRoom(newRoom);
                cout.LogRoom(env);
            }
        }
    }
}