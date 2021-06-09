
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace StereoSpeaker
{
    public class GI : UdonSharpBehaviour
    {
        [SerializeField] private Renderer giRenderer;

        private void Update()
        {
            RendererExtensions.UpdateGIMaterials(giRenderer);
        }
    }
}