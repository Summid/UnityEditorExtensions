using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(2)]
    public class GUIBaseExample : EditorWindow
    {
        public class Lable : GUIBase
        {
            private string text;
            public Lable(string text)
            {
                this.text = text;
            }

            public override void OnGUI(Rect position)
            {
                GUILayout.Label(this.text);
            }

            protected override void OnDispose()
            {
                this.text = null;
            }
        }

        private Lable lable1 = new Lable("123");
        private Lable lable2 = new Lable("456");

        private void OnGUI()
        {
            this.lable1.OnGUI(default);
            this.lable2.OnGUI(default);
        }
    }

}
