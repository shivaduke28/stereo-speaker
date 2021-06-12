
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif

public class UdonEchoFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioEchoFilter filter;
    [SerializeField] private Slider delay;
    [SerializeField] private Text delayText;
    [SerializeField] private Slider decayRatio;
    [SerializeField] private Text decayRatioText;
    [SerializeField] private Slider wetMix;
    [SerializeField] private Text wetMixText;
    [SerializeField] private Slider dryMix;
    [SerializeField] private Text dryMixText;

    [SerializeField] private Toggle toggle;
    public void OnToggle()
    {
        filter.enabled = toggle.isOn;
    }

    public void Start()
    {
        CopyFilterToUI();
    }

    public void OnDelayChange()
    {
        filter.delay = delay.value;
        delayText.text = Mathf.CeilToInt(filter.delay).ToString();
    }

    public void OnDecayRatioChange()
    {
        filter.decayRatio = decayRatio.value;
        decayRatioText.text = filter.decayRatio.ToString("N1");
    }

    public void OnWetMixChange()
    {
        filter.wetMix = wetMix.value;
        wetMixText.text = filter.wetMix.ToString("N1");
    }

    public void OnDryMixChange()
    {
        filter.dryMix = dryMix.value;
        dryMixText.text = filter.dryMix.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        toggle.isOn = filter.enabled;
        delay.value = filter.delay;
        decayRatio.value = filter.decayRatio;
        wetMix.value = filter.wetMix;
        dryMix.value = filter.dryMix;

        delayText.text = Mathf.CeilToInt(filter.delay).ToString();
        decayRatioText.text = filter.decayRatio.ToString("N1");
        wetMixText.text = filter.wetMix.ToString("N1");
        dryMixText.text = filter.dryMix.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(toggle);
        EditorUtility.SetDirty(delay);
        EditorUtility.SetDirty(decayRatio);
        EditorUtility.SetDirty(wetMix);
        EditorUtility.SetDirty(dryMix);
        EditorUtility.SetDirty(delayText);
        EditorUtility.SetDirty(decayRatioText);
        EditorUtility.SetDirty(wetMixText);
        EditorUtility.SetDirty(dryMixText);
#endif
    }
}
