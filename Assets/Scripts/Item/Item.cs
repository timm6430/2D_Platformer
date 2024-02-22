using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject 
{
    [SerializeField] string id;
    public string ID {get {return id;}}
    public string ItemName;
    public Sprite Icon;
    public UnityEvent consumableEvent;

    private void OnValidate() 
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public void Use()
    {
      Debug.Log("Using Item" + ItemName);
      consumableEvent.Invoke();
    }

    public Item GetCopy()
	{
		return this;
	}
}
