
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

#if UNITY_EDITOR && !COMPILER_UDONSHARP
using UnityEditor;
#endif

public class UdonReverbFilter : UdonSharpBehaviour
{
    [SerializeField] private AudioReverbFilter filter;
    [SerializeField] private Slider dryLevel;
    [SerializeField] private Text dryLevelText;
    [SerializeField] private Slider room;
    [SerializeField] private Text roomText;
    [SerializeField] private Slider roomHF;
    [SerializeField] private Text roomHFText;
    [SerializeField] private Slider roomLF;
    [SerializeField] private Text roomLFText;
    [SerializeField] private Slider decayTime;
    [SerializeField] private Text decayTimeText;
    [SerializeField] private Slider decayHFRatio;
    [SerializeField] private Text decayHFRatioText;
    [SerializeField] private Slider reflectionsLevel;
    [SerializeField] private Text reflectionsLevelText;
    [SerializeField] private Slider reflectionsDelay;
    [SerializeField] private Text reflectionsDelayText;
    [SerializeField] private Slider reverbLevel;
    [SerializeField] private Text reverbLevelText;
    [SerializeField] private Slider reverbDelay;
    [SerializeField] private Text reverbDelayText;
    [SerializeField] private Slider hfReference;
    [SerializeField] private Text hfReferenceText;
    [SerializeField] private Slider lfReference;
    [SerializeField] private Text lfReferenceText;
    [SerializeField] private Slider diffusion;
    [SerializeField] private Text diffusionText;
    [SerializeField] private Slider density;
    [SerializeField] private Text densityText;

    [SerializeField] private Toggle toggle;
    public void OnToggle()
    {
        filter.enabled = toggle.isOn;
    }

    public void OnDryLevelChange()
    {
        filter.dryLevel = dryLevel.value;
        dryLevelText.text = Mathf.CeilToInt(filter.dryLevel).ToString();
    }

    public void OnRoomChange()
    {
        filter.room = room.value;
        roomText.text = Mathf.CeilToInt(filter.room).ToString();
    }

    public void OnRoomHFChange()
    {
        filter.roomHF = roomHF.value;
        roomHFText.text = Mathf.CeilToInt(filter.roomHF).ToString();
    }

    public void OnRoomLFChange()
    {
        filter.roomLF = roomLF.value;
        roomLFText.text = Mathf.CeilToInt(filter.roomLF).ToString();
    }

    public void OnDecayTimeChange()
    {
        filter.decayTime = decayTime.value;
        decayTimeText.text = filter.decayTime.ToString("N1");
    }

    public void OnDecayHFRatioChange()
    {
        filter.decayHFRatio = decayHFRatio.value;
        decayHFRatioText.text = filter.decayHFRatio.ToString("N1");
    }

    public void OnReflectionsLevelChange()
    {
        filter.reflectionsLevel = reflectionsLevel.value;
        reflectionsLevelText.text = Mathf.CeilToInt(filter.reflectionsLevel).ToString();
    }

    public void OnReflectionsDelayChange()
    {
        filter.reflectionsDelay = reflectionsDelay.value;
        reflectionsDelayText.text = filter.reflectionsDelay.ToString("N1");
    }

    public void OnReverbLevelChange()
    {
        filter.reverbLevel = reverbDelay.value;
        reverbLevelText.text = Mathf.CeilToInt(filter.reverbLevel).ToString();
    }

    public void OnReverbDelayChange()
    {
        filter.reverbDelay = reverbDelay.value;
        reverbDelayText.text = filter.reverbDelay.ToString("N1");
    }

    public void OnHfReferenceChange()
    {
        filter.hfReference = hfReference.value;
        hfReferenceText.text = Mathf.CeilToInt(filter.hfReference).ToString();
    }

    public void OnLfReferenceChange()
    {
        filter.lfReference = lfReference.value;
        lfReferenceText.text = Mathf.CeilToInt(filter.lfReference).ToString();
    }

    public void OnDiffusionChange()
    {
        filter.diffusion = diffusion.value;
        diffusionText.text = filter.diffusion.ToString("N1");
    }

    public void OnDensityChange()
    {
        filter.density = density.value;
        densityText.text = filter.density.ToString("N1");
    }

    public void CopyFilterToUI()
    {
        toggle.isOn = filter.enabled;
        dryLevel.value = filter.dryLevel;
        room.value = filter.room;
        roomHF.value = filter.roomHF;
        roomLF.value = filter.roomLF;
        decayTime.value = filter.decayTime;
        decayHFRatio.value = filter.decayHFRatio;
        reflectionsLevel.value = filter.reflectionsLevel;
        reflectionsDelay.value = filter.reflectionsDelay;
        reverbLevel.value = filter.reverbLevel;
        reverbDelay.value = filter.reverbDelay;
        hfReference.value = filter.hfReference;
        lfReference.value = filter.lfReference;
        diffusion.value = filter.diffusion;
        density.value = filter.density;

        dryLevelText.text = Mathf.CeilToInt(filter.dryLevel).ToString();
        roomText.text = Mathf.CeilToInt(filter.room).ToString();
        roomHFText.text = Mathf.CeilToInt(filter.roomHF).ToString();
        roomLFText.text = Mathf.CeilToInt(filter.roomLF).ToString();
        decayTimeText.text = filter.decayTime.ToString("N1");
        decayHFRatioText.text = filter.decayHFRatio.ToString("N1");
        reflectionsLevelText.text = Mathf.CeilToInt(filter.reflectionsLevel).ToString();
        reflectionsDelayText.text = filter.reflectionsDelay.ToString("N1");
        reverbLevelText.text = Mathf.CeilToInt(filter.reverbLevel).ToString();
        reverbDelayText.text = filter.reverbDelay.ToString("N1");
        hfReferenceText.text = Mathf.CeilToInt(filter.hfReference).ToString();
        lfReferenceText.text = Mathf.CeilToInt(filter.lfReference).ToString();
        diffusionText.text = filter.diffusion.ToString("N1");
        densityText.text = filter.density.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
        EditorUtility.SetDirty(toggle);
        EditorUtility.SetDirty(dryLevel);
        EditorUtility.SetDirty(room);
        EditorUtility.SetDirty(roomHF);
        EditorUtility.SetDirty(roomLF);
        EditorUtility.SetDirty(decayTime);
        EditorUtility.SetDirty(decayHFRatio);
        EditorUtility.SetDirty(reflectionsLevel);
        EditorUtility.SetDirty(reflectionsDelay);
        EditorUtility.SetDirty(reverbLevel);
        EditorUtility.SetDirty(reverbDelay);
        EditorUtility.SetDirty(hfReference);
        EditorUtility.SetDirty(lfReference);
        EditorUtility.SetDirty(diffusion);
        EditorUtility.SetDirty(density);

        EditorUtility.SetDirty(dryLevelText);
        EditorUtility.SetDirty(roomText);
        EditorUtility.SetDirty(roomHFText);
        EditorUtility.SetDirty(roomLFText);
        EditorUtility.SetDirty(decayTimeText);
        EditorUtility.SetDirty(decayHFRatioText);
        EditorUtility.SetDirty(reflectionsLevelText);
        EditorUtility.SetDirty(reflectionsDelayText);
        EditorUtility.SetDirty(reverbLevelText);
        EditorUtility.SetDirty(reverbDelayText);
        EditorUtility.SetDirty(hfReferenceText);
        EditorUtility.SetDirty(lfReferenceText);
        EditorUtility.SetDirty(diffusionText);
        EditorUtility.SetDirty(densityText);
#endif
    }
}
