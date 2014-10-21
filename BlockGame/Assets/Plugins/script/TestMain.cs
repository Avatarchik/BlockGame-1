using UnityEngine;
using System.Collections;

using civ;
using plugin_BlockGame;

public class TestMain : MonoBehaviour {

	public static iViewer sViewer = null;
    public static BlockGame sModule = null;
	//public static iModule sModule = null;

	public GameObject mExternRoot;

	private bool bPlayModule = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {

		int w = Screen.width;
		int h = Screen.height;

		if (!bPlayModule)
		{
			if (GUI.Button(new Rect(0,0,w/4,w/16), "Execute"))
			{
				ExecuteExternalModule();
			}
		}

		if (bPlayModule)
		{
			if (GUI.Button(new Rect(3*w/4,0,w/4,w/16), "Return"))
			{
				ReturnToViewer();
			}
		}
	}

	void ExecuteExternalModule()
	{
		bPlayModule = true;

		sViewer = new iViewer();
		//sModule = new iModule();
        sModule = new BlockGame();
		sViewer.PlayModule(sModule);
	}

	void ReturnToViewer()
	{
		bPlayModule = false;

        sModule.UnInit();

        /*
		if (mExternRoot != null)
		{
			for (int i = mExternRoot.transform.childCount-1; i >= 0; i--)
			{
				Transform t = mExternRoot.transform.GetChild(i);
				t.parent = null;
				DestroyImmediate(t.gameObject);
			}
		}
        */
	}

}
