using UnityEngine;

namespace DefaultNamespace
{
    public class MaterialInfo : MonoBehaviour
    {
        [SerializeField] private GameObject Hair;
        
        public void ChangeColor(Texture mainTexture)
        {
            var renderer = Hair.GetComponent<SkinnedMeshRenderer>();
            renderer.sharedMaterial.mainTexture = mainTexture;
        }
    }
}