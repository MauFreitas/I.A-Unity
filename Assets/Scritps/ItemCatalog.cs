using UnityEngine;

public class ItemCatalog : MonoBehaviour
{
    [SerializeField]
    private Item[] _items = null;
    public Item[] Items
    {
        get
        {
            return _items;
        }
    }
}
