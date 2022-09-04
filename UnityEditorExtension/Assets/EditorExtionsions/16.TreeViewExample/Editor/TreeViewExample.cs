using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorExtensions
{
    public class TreeViewExample : EditorWindow
    {
        [MenuItem("EditorExtensions/12.TreeView/Open")]
        private static void Open()
        {
            GetWindow<TreeViewExample>().Show();
        }

        [SerializeField]
        private TreeViewState treeViewState;
        private SimpleTreeView simpleTreeView;
        private SearchField searchField;

        private void OnEnable()
        {
            this.treeViewState ??= new TreeViewState();

            this.simpleTreeView = new SimpleTreeView(this.treeViewState);
            this.searchField = new SearchField();
            this.searchField.downOrUpArrowKeyPressed += this.simpleTreeView.SetFocusAndEnsureSelectedItem;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            this.simpleTreeView.searchString = this.searchField.OnToolbarGUI(this.simpleTreeView.searchString);
            GUILayout.EndHorizontal();

            var rect = GUILayoutUtility.GetRect(0, 100000, 0, 100000);
            this.simpleTreeView.OnGUI(rect);
        }

        public class SimpleTreeView : TreeView
        {
            public SimpleTreeView(TreeViewState state) : base(state)
            {
                this.Reload();
            }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem(0, -1, "Root");
                var allItems = new List<TreeViewItem>()
                {
                    new TreeViewItem(1,0,"Animals"),
                    new TreeViewItem(2,1,"Mammals"),
                    new TreeViewItem(3,2,"Tiger"),
                    new TreeViewItem(4,2,"Elephant"),
                    new TreeViewItem(5,2,"Okapi"),
                    new TreeViewItem(6,2,"Armadillo"),
                    new TreeViewItem(7,1,"Reptiles"),
                    new TreeViewItem(8,2,"Crocodile"),
                    new TreeViewItem(9,2,"Lizard"),
                };

                SetupParentsAndChildrenFromDepths(root, allItems);

                return root;
            }
        }
    }
}