
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif

public class UdonHighPassFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioHighPassFilter filter;

    [SerializeField] private Slider cutoffFrequency;
    [SerializeField] private Text cutoffFrequencyText;
    [SerializeField] private Slider highpassResonanceQ;
    [SerializeField] private Text highpassResonanceQText;


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
        filter.highpassResonanceQ = highpassResonanceQ.value;
        highpassResonanceQText.text = filter.highpassResonanceQ.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        cutoffFrequency.value = filter.cutoffFrequency;
        highpassResonanceQ.value = filter.highpassResonanceQ;
        cutoffFrequencyText.text = filter.cutoffFrequency.ToString("N1");
        highpassResonanceQText.text = filter.highpassResonanceQ.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(highpassResonanceQ);
        EditorUtility.SetDirty(highpassResonanceQText);
        EditorUtility.SetDirty(cutoffFrequency);
        EditorUtility.SetDirty(cutoffFrequencyText);
#endif
    }
}
