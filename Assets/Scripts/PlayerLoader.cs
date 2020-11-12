using System;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerLoader : MonoBehaviour
    {
        [SerializeField] private PlayerButton baseButton;
        [SerializeField] private CharacterOptions characterOptions;
        
        private PlayersConfig config;
        private GameObject currentObject;
        
        private void Start()
        {
            config = Resources.Load<PlayersConfig>("Players");
            var names = config.Players;
            
            var countObject = names.Length;
            if (countObject == 0)
            {
                baseButton.gameObject.SetActive(false);
                return;
            }
            
            baseButton.Setup(names[0], OnPlayerButton);
            
            for(int i = 1; i < countObject; i++)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(names[i], OnPlayerButton);
            }
        }
        
        private void OnPlayerButton(string id)
        {
            if (currentObject != null)
            {
                characterOptions.gameObject.SetActive(false);
                characterOptions.DestroyOldButtons();
                Destroy(currentObject);
            }
            var asset = config.GetPlayer(id);
            var obj = Instantiate(asset);
            
            characterOptions.gameObject.SetActive(true);
            
            characterOptions.player = obj.GetComponent<MaterialInfo>();
            characterOptions.playerName = id;
            characterOptions.Info();
            
            currentObject = obj;
        }
    }
}