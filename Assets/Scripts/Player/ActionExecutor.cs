using Actions;
using Environment;
using UnityEngine;

namespace Player
{

    public delegate void ActionAssigned();
    public class ActionExecutor : MonoBehaviour
    {
        [SerializeField] private RoomPackager roomPackager;
        [SerializeField] private InputAction[] availableActions;
        [SerializeField] private Console.Output cout;
        private string[] _command;

        private event ActionAssigned OnActionAssigned;

        private void OnEnable()
        {
            OnActionAssigned += DoAction;
        }

        private void DoAction()
        {
            foreach (InputAction action in availableActions)
            {
                if (action.GetKey.Equals(_command[0]))
                {
                    action.RespondToInput(roomPackager, cout, _command);
                }
            }
            cout.DisplayLog();
        }

        public void SetAction(string[] command)
        {
            _command = command;
            OnActionAssigned?.Invoke();
        }
    }
}