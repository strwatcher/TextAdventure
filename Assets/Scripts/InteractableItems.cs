using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemList;

    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
    private Dictionary<string, ActionResponse> _useDictionary = new Dictionary<string, ActionResponse>();
    
    [HideInInspector] public List<string> nounsInRoom = new List<string>();
    private List<string> _nounsInInventory = new List<string>();

    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public string GetNotInventoriedItem(InteractableObject item)
    {

        if (!_nounsInInventory.Contains(item.noun))
        {
            nounsInRoom.Add(item.noun);
            return item.description;
        }

        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        foreach (var noun in _nounsInInventory)
        {
            InteractableObject item = GetInteractableObjectFromUsableList(noun);
            if (item == null) continue;

            foreach (var interaction in item.interactions)
            {
               if (interaction.ActionResponse == null) continue;

               if (!_useDictionary.ContainsKey(noun))
               {
                   _useDictionary.Add(noun, interaction.ActionResponse);
               }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        foreach (var item in usableItemList)
        {
            if (item.noun.Equals(noun))
            {
                return item;
            }
        }

        return null;
    }

    public void DisplayInventory()
    {
        _controller.LogStringWithReturn("You look in your backpack, inside you have: ");

        foreach (var item in _nounsInInventory)
        {
            _controller.LogStringWithReturn("\t" + item);
        }
    }
    
    public void ClearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }


    public Dictionary<string, string> Take(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        if (nounsInRoom.Contains(noun))
        {
            _nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        
        _controller.LogStringWithReturn($"There is no {noun} in the room");
        return null;
    }

    public void UseItem(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        if (_nounsInInventory.Contains(noun))
        {
            if (_useDictionary.ContainsKey(noun))
            {

                bool actionResult = _useDictionary[noun].DoActionResponse(_controller);
                if (!actionResult)
                {
                    _controller.LogStringWithReturn("Hmm... Nothing happens.");
                }
            }
            else
            {
                _controller.LogStringWithReturn($"You can't use the {noun}");
            }
        }
        else
        {
            _controller.LogStringWithReturn($"There is no {noun} in your inventory");
        }
    }
}
