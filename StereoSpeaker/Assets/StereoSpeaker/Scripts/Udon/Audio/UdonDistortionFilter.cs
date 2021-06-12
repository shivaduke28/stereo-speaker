
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif

public class UdonDistortionFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioDistortionFilter filter;

    [SerializeField] private Slider distotionLevel;
    [SerializeField] private Text distortionLevelText;

    public void Start()
    {
        CopyFilterToUI();
    }

    public void OnDistortionLevelChange()
    {
        filter.distortionLevel = distotionLevel.value;
        distortionLevelText.text = filter.distortionLevel.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        distotionLevel.value = filter.distortionLevel;
        distortionLevelText.text = filter.distortionLevel.ToString("N1");
#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(distotionLevel);
        EditorUtility.SetDirty(distortionLevelText);
#endif
    }
}
