using UnityEngine;

[System.Serializable]
public class Exit
{
    [SerializeField] private string key;
    [TextArea][SerializeField] private string description;
    [SerializeField] private Room leadsTo;

    public string GetKey => key;
    public string GetDescription => description;
    public Room GetLeadsTo => leadsTo;
}