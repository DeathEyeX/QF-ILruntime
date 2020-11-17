using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework
{
	public partial class ILUIPanelTester
	{
		void OnStart()
		{
			var panelName = SceneManager.GetActiveScene().name.Replace("Test", string.Empty);

            panelName = "UIHallPanel";
            ResKit.Init();
			ILUIKit.OpenPanel(panelName);
		}

		void OnDestroy()
		{
			
		}
		

	}
}
