using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    public void Setup(string id, Action<string> callback)
    {
        text.text = id;
        
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(id);
        });
    }
    
    public void Setup(DirectoryInfo id, Action<DirectoryInfo> callback)
    {
        text.text = id.Name;
        
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(id);
        });
    }
}
