using System.IO;
using Capibutler.Editor.Utils;
using UnityEditor;
using UnityEngine.UIElements;

namespace Capibutler.Editor.UI
{
    public class VoodooSettingsTab
    {
        private Toggle eventListenerInlineEditorState;
        private TextField path;
        private Toggle referenceInlineEditorState;

        public void CreateGUI(VisualElement rootVisualElement)
        {
            path = rootVisualElement.Q<TextField>("path");
            referenceInlineEditorState = rootVisualElement.Q<Toggle>("referenceInlineEditor");
            eventListenerInlineEditorState = rootVisualElement.Q<Toggle>("eventListenerInlineEditor");

            path.value = SettingsUtils.GetString("SavePath", PathUtils.DefaultSavePath);

            referenceInlineEditorState.value = SettingsUtils.GetBool(nameof(referenceInlineEditorState));
            eventListenerInlineEditorState.value = SettingsUtils.GetBool(nameof(eventListenerInlineEditorState));

            rootVisualElement.Q<Button>("selectPath").clicked += OnPathSelect;
            path.RegisterValueChangedCallback(status => SettingsUtils.SetString("SavePath", status.newValue));
            referenceInlineEditorState.RegisterValueChangedCallback(status => SettingsUtils.SetBool(nameof(referenceInlineEditorState), status.newValue));
            eventListenerInlineEditorState.RegisterValueChangedCallback(status => SettingsUtils.SetBool(nameof(eventListenerInlineEditorState), status.newValue));
        }

        private void OnPathSelect()
        {
            var currentPath = Path.GetFullPath(string.IsNullOrWhiteSpace(path.value) ? PathUtils.DefaultSavePath : path.value);
            var newPath = EditorUtility.OpenFolderPanel("Select " + path.label, currentPath, "");
            path.value = string.IsNullOrWhiteSpace(newPath) ? path.value : Path.GetFullPath(newPath);
        }

        public void OnReferenceInlineEditorStateChanged(bool value)
        {
            referenceInlineEditorState.SetValueWithoutNotify(value);
        }

        public void OnEventListenerInlineEditorStateChanged(bool value)
        {
            eventListenerInlineEditorState.SetValueWithoutNotify(value);
        }
    }
}