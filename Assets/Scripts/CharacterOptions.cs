using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterOptions : MonoBehaviour
    {
        [SerializeField] private PlayerButton baseButton;
        [HideInInspector] public MaterialInfo player;
        [HideInInspector] public string playerName;

        private readonly List<PlayerButton> playerButtons = new List<PlayerButton>();
            
        public void Info()
        {
            baseButton.gameObject.SetActive(true);
            var materialsPath = Path.Combine(Application.streamingAssetsPath, $"{playerName}Hairs");
            var directories = Directory.GetDirectories(materialsPath);
            
            foreach (var directory in directories)
            {
                var button = Instantiate(baseButton, baseButton.transform.parent);
                playerButtons.Add(button);
                var materials = Directory.GetFiles(directory,"*.tga");
                var directoryInfo = new DirectoryInfo(materials[0]);
                button.Setup(directoryInfo, OnChangeColor);
            }
            baseButton.gameObject.SetActive(false);
        }

        public void DestroyOldButtons()
        {
            foreach (var button in playerButtons)
            {
                Destroy(button.gameObject);
            }   
            playerButtons.Clear();
        }
        private void OnChangeColor(DirectoryInfo material)
        {
            var texture = new Texture2D(1024,1024);
            Debug.Log(material.FullName);
            var bytes = File.ReadAllBytes(material.FullName);
            var bytesTGA = ImageConversion.EncodeArrayToJPG(bytes,GraphicsFormat.R8G8B8_SInt, 1024, 1024);
            texture.LoadImage(bytesTGA);
            player.ChangeColor(texture);
        }
    }
}