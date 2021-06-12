
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

    public void OnDryLevelChange()
    {
        filter.dryLevel = dryLevel.value;
        dryLevelText.text = filter.dryLevel.ToString("N1");
    }

    public void OnRoomChange()
    {
        filter.room = room.value;
        roomText.text = filter.room.ToString("N1");        

    }

    public void OnRoomHFChange()
    {
        filter.roomHF = roomHF.value;
        roomHFText.text = filter.roomHF.ToString("N1");
    }

    public void OnRoomLFChange()
    {
        filter.roomLF = roomLF.value;
        roomLFText.text = filter.roomLF.ToString("N1");
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
        reflectionsLevelText.text = filter.reflectionsLevel.ToString("N1");
    }

    public void OnReflectionsDelayChange()
    {
        filter.reflectionsDelay = reflectionsDelay.value;
        reflectionsDelayText.text = filter.reflectionsDelay.ToString("N1");
    }

    public void OnReverbLevelChange()
    {
        filter.reverbLevel = reverbDelay.value;
        reverbLevelText.text = filter.reverbLevel.ToString("N1");
    }

    public void OnReverbDelayChange()
    {
        filter.reverbDelay = reverbDelay.value;
        reverbDelayText.text = filter.reverbDelay.ToString("N1");
    }

    public void OnHfReferenceChange()
    {
        filter.hfReference = hfReference.value;
        hfReferenceText.text = filter.hfReference.ToString("N1");
    }

    public void OnLfReferenceChange()
    {
        filter.lfReference = lfReference.value;
        lfReferenceText.text = filter.lfReference.ToString("N1");
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

        dryLevelText.text = filter.dryLevel.ToString("N1");
        roomText.text = filter.room.ToString("N1");
        roomHFText.text = filter.roomHF.ToString("N1");
        roomLFText.text = filter.roomLF.ToString("N1");
        decayTimeText.text = filter.decayTime.ToString("N1");
        decayHFRatioText.text = filter.decayHFRatio.ToString("N1");
        reflectionsLevelText.text = filter.reflectionsLevel.ToString("N1");
        reflectionsDelayText.text = filter.reflectionsDelay.ToString("N1");
        reverbLevelText.text = filter.reverbLevel.ToString("N1");
        reverbDelayText.text = filter.reverbDelay.ToString("N1");
        hfReferenceText.text = filter.hfReference.ToString("N1");
        lfReferenceText.text = filter.lfReference.ToString("N1");
        diffusionText.text = filter.diffusion.ToString("N1");
        densityText.text = filter.density.ToString("N1");

#if UNITY_EDITOR && !COMPILER_UDONSHARP
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
