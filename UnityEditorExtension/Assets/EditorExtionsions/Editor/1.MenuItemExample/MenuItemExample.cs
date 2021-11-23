using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public static class MenuItemExample
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        /// <summary>
        /// 在浏览器中打开
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            Application.OpenURL("https://bilibili.com");
        }

        /// <summary>
        /// 在资源管理中打开
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath")]
        static void OpenPersistentDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        /// <summary>
        /// 在资源管理器中打开
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/04.Open Designer Folder")]
        static void OpenDesignerFolder()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets", "Library"));
        }

        /// <summary>
        /// 是否启用快捷键的 bool 变量
        /// </summary>
        private static bool isOpenShotCut = false;

        /// <summary>
        /// 启用与关闭快捷键菜单
        /// 设置勾选状态
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/05.ToggleShotCut")]
        static void ToggleShotCut()
        {
            isOpenShotCut = !isOpenShotCut;

            //设置勾选状态
            Menu.SetChecked("EditorExtensions/01.Menu/05.ToggleShotCut", isOpenShotCut);
        }

        /// <summary>
        /// 快捷键 无组合键；下划线后跟快捷键
        /// MenuItem 复用，直接调用其它菜单，在外部访问其他Editor类的方法时很好用
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c")]
        static void HelloEditorWithShotCut()
        {
            //MenuItem 复用，参数为其他菜单的路径
            UnityEditor.EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor");
        }

        /// <summary>
        /// 快捷键 Ctrl（或Command）； % 后跟快捷键
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e")]
        static void OpenBilibiliWithShotCut()
        {
            UnityEditor.EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/02.Open Bilibili");
        }

        /// <summary>
        /// 快捷键 Shift； # 后跟快捷键
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentData Path With Shot Cut %#t")]
        static void OpenPersistentDataPahtWithShotCut()
        {
            UnityEditor.EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath");
        }

        /// <summary>
        /// 快捷键 Alt ； & 后跟快捷键
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/09.Open Designer Folder With Shot Cut &r")]
        static void OpenDesignerFolderWithShotCut()
        {
            UnityEditor.EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/04.Open Designer Folder");
        }

        /*
            ↓↓↓验证方法↓↓↓ 
            对快捷键菜单方法做一个可用验证

            说明：当 MenuItem 的 validate 字段为 true ，则该方法为验证方法
            它会在同名菜单方法调用前被调用，根据返回的 bool 类型结果来验证菜单方法能否被调用
            具体可查看 MenuItem 类
            （验证方法的方法名没有要求，只要求有 menuItem 字段即菜单路径相同的方法存在）
        */

        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c", validate = true)]
        static bool HelloEditorWithShotCutValiDate()
        {
            return isOpenShotCut;
        }

        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e", validate = true)]
        static bool OpenBilibiliWithShotCutValiDate()
        {
            return isOpenShotCut;
        }

        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentData Path With Shot Cut %#t", validate = true)]
        static bool OpenPersistentDataPahtWithShotCutValiDate()
        {
            return isOpenShotCut;
        }

        [MenuItem("EditorExtensions/01.Menu/09.Open Designer Folder With Shot Cut &r", validate = true)]
        static bool OpenDesignerFolderWithShotCutValiDate()
        {
            return isOpenShotCut;
        }

        /// <summary>
        /// 静态构造方法，每次编译后，第一次选中此菜单项后会执行一次该方法
        /// </summary>
        static MenuItemExample()
        {
            //每次编译后重新设置一次勾选状态，避免菜单中显示已勾选，但仍不能使用快捷键的问题
            Menu.SetChecked("EditorExtensions/01.Menu/05.ToggleShotCut", isOpenShotCut);
        }
    }
}