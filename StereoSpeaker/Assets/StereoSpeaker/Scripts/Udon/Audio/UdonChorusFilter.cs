
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif


public class UdonChorusFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioChorusFilter filter;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider dryMix;
    [SerializeField] private Text dryMixText;
    [SerializeField] private Slider wetMix1;
    [SerializeField] private Text wetMix1Text;
    [SerializeField] private Slider wetMix2;
    [SerializeField] private Text wetMix2Text;
    [SerializeField] private Slider wetMix3;
    [SerializeField] private Text wetMix3Text;
    [SerializeField] private Slider delay;
    [SerializeField] private Text delayText;
    [SerializeField] private Slider rate;
    [SerializeField] private Text rateText;
    [SerializeField] private Slider depth;
    [SerializeField] private Text depthText;

    public void Start()
    {
        CopyFilterToUI();
    }

    public void OnToggle()
    {
        filter.enabled = toggle.isOn;
    }

    public void OnDryMixChange()
    {
        filter.dryMix = dryMix.value;
        dryMixText.text = filter.dryMix.ToString("N1");
    }
    public void OnWetMix1Change()
    {
        filter.wetMix1 = wetMix1.value;
        wetMix1Text.text = filter.wetMix1.ToString("N1");
    }

    public void OnWetMix2Change()
    {
        filter.wetMix2 = wetMix2.value;
        wetMix2Text.text = filter.wetMix2.ToString("N1");
    }

    public void OnWetMix3Change()
    {
        filter.wetMix3 = wetMix3.value;
        wetMix3Text.text = filter.wetMix3.ToString("N1");
    }

    public void OnDelayChange()
    {
        filter.delay = delay.value;
        delayText.text = filter.delay.ToString("N1");
    }

    public void OnRateChange()
    {
        filter.rate = rate.value;
        rateText.text = filter.rate.ToString("N1");
    }

    public void OnDepthChange()
    {
        filter.depth = depth.value;
        depthText.text = filter.depth.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        toggle.isOn = filter.enabled;
        dryMix.value = filter.dryMix;
        wetMix1.value = filter.wetMix1;
        wetMix2.value = filter.wetMix2;
        wetMix3.value = filter.wetMix3;
        delay.value = filter.delay;
        rate.value = filter.rate;
        depth.value = filter.depth;

        dryMixText.text = filter.dryMix.ToString("N1");
        wetMix1Text.text = filter.wetMix1.ToString("N1");
        wetMix2Text.text = filter.wetMix2.ToString("N1");
        wetMix3Text.text = filter.wetMix3.ToString("N1");
        delayText.text = filter.delay.ToString("N1");
        rateText.text = filter.rate.ToString("N1");
        depthText.text = filter.depth.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(toggle);
        EditorUtility.SetDirty(dryMix);
        EditorUtility.SetDirty(wetMix1);
        EditorUtility.SetDirty(wetMix2);
        EditorUtility.SetDirty(wetMix3);
        EditorUtility.SetDirty(delay);
        EditorUtility.SetDirty(rate);
        EditorUtility.SetDirty(depth);
        EditorUtility.SetDirty(dryMixText);
        EditorUtility.SetDirty(wetMix1Text);
        EditorUtility.SetDirty(wetMix2Text);
        EditorUtility.SetDirty(wetMix3Text);
        EditorUtility.SetDirty(delayText);
        EditorUtility.SetDirty(rateText);
        EditorUtility.SetDirty(depthText);
#endif
    }
}
