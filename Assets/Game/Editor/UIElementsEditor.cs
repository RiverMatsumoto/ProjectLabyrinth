using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


#if UNITY_EDITOR
public class UIElementsEditor : EditorWindow
{
    [MenuItem("Window/UI Toolkit/UIElementsEditor")]
    public static void ShowExample()
    {
        UIElementsEditor wnd = GetWindow<UIElementsEditor>();
        wnd.titleContent = new GUIContent("UIElementsEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement container = new VisualElement();
        VisualElement root = rootVisualElement;
        root.Add(container);

        Label title = new Label("New Label");
        Label biggerTitle = new Label("Bigger Title");
        
        container.Add(biggerTitle);
        container.Add(title);
        
        Debug.Log(container.panel);
    }
}
#endif