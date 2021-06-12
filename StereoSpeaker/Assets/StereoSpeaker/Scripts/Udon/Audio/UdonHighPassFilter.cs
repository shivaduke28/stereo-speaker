
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
        filter.highpassResonanceQ = highpassResonanceQ.value;
        highpassResonanceQText.text = filter.highpassResonanceQ.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        toggle.isOn = filter.enabled;

        cutoffFrequency.value = filter.cutoffFrequency;
        highpassResonanceQ.value = filter.highpassResonanceQ;
        cutoffFrequencyText.text = Mathf.CeilToInt(filter.cutoffFrequency).ToString();
        highpassResonanceQText.text = filter.highpassResonanceQ.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(toggle);
        EditorUtility.SetDirty(highpassResonanceQ);
        EditorUtility.SetDirty(highpassResonanceQText);
        EditorUtility.SetDirty(cutoffFrequency);
        EditorUtility.SetDirty(cutoffFrequencyText);
#endif
    }
}
