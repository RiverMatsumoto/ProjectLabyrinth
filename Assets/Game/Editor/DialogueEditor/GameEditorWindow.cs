using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Game.Editor.DialogueEditor
{
    public class GameEditorWindow : OdinMenuEditorWindow
    {
        
        [MenuItem("Tools/Game/Dialogue Editor")]
        private static void OpenWindow()
        {
            var window = GetWindow<GameEditorWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            
            var tree = new OdinMenuTree(true);
            
            var customMenuStyle = new OdinMenuStyle
            {
                BorderPadding = 0f,
                AlignTriangleLeft = true,
                TriangleSize = 16f,
                TrianglePadding = 0f,
                Offset = 20f,
                Height = 23,
                IconPadding = 0f,
                BorderAlpha = 0.323f
            };
            
            
            tree.DefaultMenuStyle = customMenuStyle;

            tree.Config.DrawSearchToolbar = true;
            
            tree.AddAllAssetsAtPath("Scriptable Objects in Game", "Game", typeof(ScriptableObject), true, false);

            return tree;
        }
    }
}
