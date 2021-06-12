using UnityEngine;
using VRC.Udon;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UdonSharpEditor;
using UnityEditor.SceneManagement;

namespace StereoSpeaker.EditorOnly
{

    public class AudioFilterController : MonoBehaviour
    {

        [SerializeField] private UdonBehaviour udonLowPassFilter;
        [SerializeField] private UdonBehaviour udonHighPassFilter;
        [SerializeField] private UdonBehaviour udonEchoFilter;
        [SerializeField] private UdonBehaviour udonDistortionFilter;
        [SerializeField] private UdonBehaviour udonChorusFilter;
        [SerializeField] private UdonBehaviour udonReverbFilter;

        [ContextMenu("Copy Filters to UI")]
        public void Apply()
        {
            // fixme: CoypyFilterToUI changes sliders and texts, but not make them dirty.
            ((UdonLowPassFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonLowPassFilter)).CopyFilterToUI();
            ((UdonHighPassFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonHighPassFilter)).CopyFilterToUI();
            ((UdonEchoFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonEchoFilter)).CopyFilterToUI();
            ((UdonDistortionFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonDistortionFilter)).CopyFilterToUI();
            ((UdonChorusFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonChorusFilter)).CopyFilterToUI();
            ((UdonReverbFilter)UdonSharpEditorUtility.GetProxyBehaviour(udonReverbFilter)).CopyFilterToUI();
        }
    }
}

#endif