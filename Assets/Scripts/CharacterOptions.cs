using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterOptions : MonoBehaviour
    {
        [SerializeField] private PlayerButton baseButton;
        [HideInInspector] public MaterialInfo player;
        [HideInInspector] public string playerName; 
            
        public void Info()
        {
            var materialsPath = Path.Combine(Application.streamingAssetsPath, $"{playerName}Hairs");
            var directories = Directory.GetDirectories(materialsPath);

            foreach (var directory in directories)
            {
                var button = Instantiate(baseButton, baseButton.transform.parent);
                var materials = Directory.GetFiles("*.tga");
                button.Setup(materials[0], OnChangeColor);
            }
        }

        private void OnChangeColor(string material)
        {
            var texture = new Texture2D(20,20);
            var bytes = File.ReadAllBytes(material);
            texture.LoadImage(bytes);
            player.ChangeColor(texture);
        }
    }
}