using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class PlayersConfig : ScriptableObject
    {
        [SerializeField] private string[] players;

        public string[] Players => players;

        public GameObject GetPlayer(string playerName)
        {
            var objectName = players.FirstOrDefault(p => p == playerName );
            return string.IsNullOrEmpty(objectName) ? null : LoadObject(playerName);
        }

        private GameObject LoadObject(string playerName)
        {
            return Resources.Load<GameObject>($"Players/{playerName}");
        }

#if UNITY_EDITOR
        private void Reset()
        {
            var objects = Resources.LoadAll<GameObject>("Players");
            
            players = new string[objects.Length];
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = objects[i].name;
            }
        }
#endif
    }
}