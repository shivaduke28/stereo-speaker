
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

    [SerializeField] private Toggle toggle;
    public void OnToggle()
    {
        filter.enabled = toggle.isOn;
    }

    private void Start()
    {
        CopyFilterToUI();
    }

    public void OnCutoffFrequencyChange()
    {
        filter.cutoffFrequency = cutoffFrequency.value;
        cutoffFrequencyText.text = Mathf.CeilToInt(filter.cutoffFrequency).ToString();
    }

    public void OnLowpassResonanceQChange()
    {
        filter.lowpassResonanceQ = lowPassResonanceQ.value;
        lowPassResonanceQText.text = filter.lowpassResonanceQ.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        toggle.isOn = filter.enabled;

        cutoffFrequency.value = filter.cutoffFrequency;
        lowPassResonanceQ.value = filter.lowpassResonanceQ;
        cutoffFrequencyText.text = Mathf.CeilToInt(filter.cutoffFrequency).ToString();
        lowPassResonanceQText.text = filter.lowpassResonanceQ.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(toggle);
        EditorUtility.SetDirty(lowPassResonanceQ);
        EditorUtility.SetDirty(lowPassResonanceQText);
        EditorUtility.SetDirty(cutoffFrequency);
        EditorUtility.SetDirty(cutoffFrequencyText);
#endif
    }
}
