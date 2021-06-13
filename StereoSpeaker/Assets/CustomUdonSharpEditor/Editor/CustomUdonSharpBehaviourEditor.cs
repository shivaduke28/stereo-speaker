using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using VRC.Udon;
using VRC.Udon.Editor;
using UdonSharp;
using UdonSharpEditor;

namespace CustomUsharpEditor
{
    public class CustomUdonSharpBehaviourEditor<T> : Editor where T : UdonSharpBehaviour
    {
        protected T UdonSharpTarget { get; private set; }
        private UdonBehaviour udonTarget;

        private SerializedProperty programSourceProperty;
        private SerializedProperty serializedProgramAssetProperty;
        private SerializedObject udonBehaviourSerialzedObject;

        public override void OnInspectorGUI()
        {
            if (UdonSharpEditorUtility.IsProxyBehaviour(UdonSharpTarget))
            {
                OnUdonBehaviourEditorInspectorGUI();
            }
            else
            {
                if (UdonSharpGUI.DrawConvertToUdonBehaviourButton(targets))
                {
                    return;
                }
            }
            base.OnInspectorGUI();
        }

        private void OnEnable()
        {
            if (target == null) return;
            UdonSharpTarget = (T)target;
            SetUdonTarget();
        }

        private void SetUdonTarget()
        {
            var udonObj = UdonSharpTarget.gameObject.GetComponent(typeof(UdonBehaviour));
            if (udonObj != null)
            {
                udonTarget = (UdonBehaviour)UdonSharpTarget.gameObject.GetComponent(typeof(UdonBehaviour));
                udonBehaviourSerialzedObject = new SerializedObject(udonTarget);
                programSourceProperty = udonBehaviourSerialzedObject.FindProperty("programSource");
                serializedProgramAssetProperty = udonBehaviourSerialzedObject.FindProperty("serializedProgramAsset");
                UdonEditorManager.Instance.WantRepaint += Repaint;
            }
        }

        private void OnDisable()
        {
            if (udonTarget != null)
            {
                UdonEditorManager.Instance.WantRepaint -= Repaint;
            }
        }

        enum SyncTypes
        {
            Continuous,
            Manual
        }

        public void OnUdonBehaviourEditorInspectorGUI()
        {
            if (udonTarget == null) return;
            using (new EditorGUI.DisabledScope(Application.isPlaying))
            {
                bool dirty = false;

                EditorGUILayout.BeginVertical();
                {
                    var selected = (SyncTypes)EditorGUILayout.EnumPopup("Sync Type", udonTarget.Reliable ? SyncTypes.Manual : SyncTypes.Continuous);

                    bool shouldBeReliable = selected == SyncTypes.Manual;
                    if (udonTarget.Reliable != shouldBeReliable)
                    {
                        udonTarget.Reliable = shouldBeReliable;
                        dirty = true;
                    }
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
                EditorGUILayout.BeginVertical();
                using (new EditorGUI.DisabledScope(true))
                {
                    programSourceProperty.objectReferenceValue = EditorGUILayout.ObjectField(
                        "Program Source",
                        programSourceProperty.objectReferenceValue,
                        typeof(AbstractUdonProgramSource),
                        false
                        );
                    EditorGUILayout.ObjectField("Serialized Udon Program Asset ID: ",
                        serializedProgramAssetProperty.objectReferenceValue,
                        typeof(AbstractSerializedUdonProgramAsset),
                        false
                        );
                }
                var programSource = (AbstractUdonProgramSource)programSourceProperty.objectReferenceValue;
                var serializedUdonProgramAsset = programSource.SerializedProgramAsset;
                if (serializedProgramAssetProperty.objectReferenceValue != serializedUdonProgramAsset)
                {
                    serializedProgramAssetProperty.objectReferenceValue = serializedUdonProgramAsset;
                    udonBehaviourSerialzedObject.ApplyModifiedPropertiesWithoutUndo();
                }
                EditorGUILayout.EndVertical();
                if (dirty && !Application.isPlaying)
                {
                    EditorSceneManager.MarkSceneDirty(udonTarget.gameObject.scene);
                }
            }
        }
    }
}