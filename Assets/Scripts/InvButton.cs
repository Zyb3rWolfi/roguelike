using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvButton : MonoBehaviour
{
    [SerializeField] private ItemScriptable _item;
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called before the first frame update
    public static Action<ItemScriptable> OnItemClicked;
    void Start()
    {
        //_text.text = _item.name;
        Image img = GetComponent<Image>();
        img.sprite = _item.prefab.GetComponent<SpriteRenderer>().sprite;
    }
    public void SetItem(ItemScriptable item)
    {
        _item = item;
    }
    public void OnButtonPress()
    {
        print(_item is armourScritpable);
        OnItemClicked?.Invoke(_item);
    }
}
