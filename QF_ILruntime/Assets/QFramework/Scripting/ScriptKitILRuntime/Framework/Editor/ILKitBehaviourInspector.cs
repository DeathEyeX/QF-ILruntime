using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace QFramework
{
	[CustomEditor(typeof(ILKitBehaviour), true)]
	public class ILKitBehaviourInspector : Editor
	{
		class LocaleText
		{
			public static string ScriptName
			{
				get { return Language.IsChinese ? "生成脚本名:" : "Script name:"; }
			}

			public static string ScriptsFolder
			{
				get { return Language.IsChinese ? "脚本生成目录:" : "Scripts Generate Folder:"; }
			}

			public static string GeneratePrefab
			{
				get { return Language.IsChinese ? "生成 Prefab" : "Genreate Prefab"; }
			}

			public static string PrefabGenreateFolder
			{
				get { return Language.IsChinese ? "Prefab 生成目录:" : "Prefab Generate Folder:"; }
			}

			public static string Generate
			{
				get { return Language.IsChinese ? " 生成代码" : " Generate Code"; }
			}
		}


		private ILKitBehaviour mCodeGenerateInfo
		{
			get { return target as ILKitBehaviour; }
		}

		private VerticalLayout mRootLayout;

		private SerializedObject mSerializedObject;

		private TextView mScriptFolderView = null;

		private void OnEnable()
		{
			if (mSerializedObject.IsNull())
			{
				mSerializedObject = new SerializedObject(target);
			}

			mRootLayout = new VerticalLayout();

			if (mCodeGenerateInfo.Namespace.IsNullOrEmpty())
			{
				mCodeGenerateInfo.Namespace = UIKitSettingData.GetProjectNamespace();
			}

			if (mCodeGenerateInfo.ScriptsFolder.IsNullOrEmpty())
			{
				mCodeGenerateInfo.ScriptsFolder = "Assets" + UIKitSettingData.GetScriptsPath();
			}

			if (mCodeGenerateInfo.ScriptName.IsNullOrEmpty())
			{
				mCodeGenerateInfo.ScriptName = mCodeGenerateInfo.gameObject.name;
			}

			new HorizontalLayout()
				.AddChild(new LabelView(LocaleText.ScriptName).Width(150))
				.AddChild(new TextView(mCodeGenerateInfo.ScriptName).Do(v =>
				{
					v.Content.Bind((newValue) =>
					{
						mCodeGenerateInfo.ScriptName = newValue;
						EditorUtility.SetDirty(mCodeGenerateInfo);
					});
				}))
				.AddTo(mRootLayout);


			new HorizontalLayout()
				.AddChild(new LabelView(LocaleText.ScriptsFolder).Width(150))
				.AddChild(new TextView(mCodeGenerateInfo.ScriptsFolder).Do(v =>
				{
					v.Content.Bind((newValue) =>
					{
						mCodeGenerateInfo.ScriptsFolder = newValue;
						EditorUtility.SetDirty(mCodeGenerateInfo);
					});

					mScriptFolderView = v;
				}))
				.AddTo(mRootLayout);

			new CustomView(() =>
			{
				EditorGUILayout.Space();
				EditorGUILayout.LabelField("请将要生成脚本的文件夹拖到下边区域 或 自行填写目录到上一栏中");
				var sfxPathRect = EditorGUILayout.GetControlRect();
				sfxPathRect.height = 200;
				GUI.Box(sfxPathRect, string.Empty);
				EditorGUILayout.LabelField(string.Empty, GUILayout.Height(185));
				if (
					Event.current.type == EventType.DragUpdated
					&& sfxPathRect.Contains(Event.current.mousePosition)
				)
				{
					//改变鼠标的外表  
					DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
					if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
					{
						if (DragAndDrop.paths[0] != "")
						{
							var newPath = DragAndDrop.paths[0];
							mScriptFolderView.Content.Value = newPath;
							AssetDatabase.SaveAssets();
							AssetDatabase.Refresh();
							EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
						}
					}
				}

				var fileFullPath = mCodeGenerateInfo.ScriptsFolder + "/" + mCodeGenerateInfo.ScriptName + ".cs";
				if (File.Exists(mCodeGenerateInfo.ScriptsFolder + "/" + mCodeGenerateInfo.ScriptName + ".cs"))
				{
					if (GUILayout.Button("打开脚本",GUILayout.Height(30)))
					{
						var scriptFile = AssetDatabase.LoadAssetAtPath<MonoScript>(fileFullPath);
						AssetDatabase.OpenAsset(scriptFile);
					}
				}
			}).AddTo(mRootLayout);

			new ButtonView(LocaleText.Generate,
					() =>
					{
						if (mCodeGenerateInfo.GetComponent<UIDefaultPanel>())
						{
							CreateILBehaviourCode.DoCreateCodeFromScene(mCodeGenerateInfo.gameObject,true);
						}
						else
						{
							CreateILBehaviourCode.DoCreateCodeFromScene(mCodeGenerateInfo.gameObject);
						}
					})
				.Height(30)
				.AddTo(mRootLayout);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			mRootLayout.DrawGUI();
		}
	}
}