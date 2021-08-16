using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
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
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        else
        {
            _controller.LogStringWithReturn($"There is no {noun} in the room");
            return null;
        }
    }
}
