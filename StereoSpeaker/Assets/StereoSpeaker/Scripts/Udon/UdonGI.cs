
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace StereoSpeaker.Udon
{
    public class UdonGI : UdonSharpBehaviour
    {
        [SerializeField] private Renderer giRenderer;

        private void Update()
        {
            RendererExtensions.UpdateGIMaterials(giRenderer);
        }
    }
}