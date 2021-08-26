using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> items;

        public List<Item> GetItems => items;

        public void Add(Item item)
        {
            item.state = ItemState.InInventory;
            items.Add(item);
        }
    }
}