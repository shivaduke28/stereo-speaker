
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif

public class UdonLowPassFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioLowPassFilter filter;

    [SerializeField] private Slider cutoffFrequency;
    [SerializeField] private Text cutoffFrequencyText;
    [SerializeField] private Slider lowPassResonanceQ;
    [SerializeField] private Text lowPassResonanceQText;

    private void Start()
    {
        CopyFilterToUI();
    }

    public void OnCutoffFrequencyChange()
    {
        filter.cutoffFrequency = cutoffFrequency.value;
        cutoffFrequencyText.text = filter.cutoffFrequency.ToString("N1");
    }

    public void OnLowpassResonanceQChange()
    {
        filter.lowpassResonanceQ = lowPassResonanceQ.value;
        lowPassResonanceQText.text = filter.lowpassResonanceQ.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        cutoffFrequency.value = filter.cutoffFrequency;
        lowPassResonanceQ.value = filter.lowpassResonanceQ;
        cutoffFrequencyText.text = filter.cutoffFrequency.ToString("N1");
        lowPassResonanceQText.text = filter.lowpassResonanceQ.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(lowPassResonanceQ);
        EditorUtility.SetDirty(lowPassResonanceQText);
        EditorUtility.SetDirty(cutoffFrequency);
        EditorUtility.SetDirty(cutoffFrequencyText);
#endif
    }
}
