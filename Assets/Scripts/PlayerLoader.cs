using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerLoader : MonoBehaviour
    {
        [SerializeField] private PlayerButton baseButton;
        private PlayersConfig config;
        private GameObject currentObject;

        private void Start()
        {
            config = Resources.Load<PlayersConfig>("Players");
            Debug.Log(config);
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
            Debug.Log("Destroy");
            Destroy(baseButton.gameObject);
            
        }
        
        private void OnPlayerButton(string id)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            var asset = config.GetPlayer(id);
            var obj = Instantiate(asset);
            currentObject = obj;
        }
    }
}