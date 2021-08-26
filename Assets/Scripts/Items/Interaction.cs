using Actions;
using Actions.ActionResponses;
using UnityEngine;

namespace Items
{
    [System.Serializable]
    public class Interaction
    {
        [SerializeField] private InputAction action;
        [SerializeField] [TextArea] private string responseDescription;
        [SerializeField] private ActionResponse actionResponse;

        public string GetResponseDescription => responseDescription;
        public InputAction GetAction => action;
        public ActionResponse GetActionResponse => actionResponse;
    }
}