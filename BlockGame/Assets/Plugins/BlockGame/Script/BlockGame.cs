using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using civ;

namespace plugin_BlockGame 
{
    public class BlockGame : iModule
    {
        GameObject goPlugin;
        GameObject root;

		/// <summary>
		/// Total block count
		/// </summary>
		static int blockCount = 0;
		public static int BlockCount
		{
			get
			{
				return blockCount;
			}
		}

        const string PrefabPath = "Plugins/BlockGame/Prefab/";

        public virtual void Init(iViewer viewer)
        {
            goPlugin = GameObject.Find("plugin");
            if (goPlugin == null)
            {
                GameObject pfPlugin = Resources.Load<GameObject>(PrefabPath + "plugin");
                goPlugin = (GameObject)GameObject.Instantiate(pfPlugin);
                goPlugin.transform.name = "plugin";
            }

            root = GameObject.Find("BlockGame");
            if (root == null)
            {
                GameObject pfRoot = Resources.Load<GameObject>(PrefabPath + "BlockGame");
                root = (GameObject)GameObject.Instantiate(pfRoot);
                root.transform.parent = goPlugin.transform;
                root.name = "BlockGame";
            }

            GameObject pfCamera = Resources.Load<GameObject>(PrefabPath + "Camera");
            GameObject pfLight = Resources.Load<GameObject>(PrefabPath + "Directional light");
            GameObject pfPlayer = Resources.Load<GameObject>(PrefabPath + "Player");
            GameObject pfPlane = Resources.Load<GameObject>(PrefabPath + "Plane");
            GameObject pfBlockManager = Resources.Load<GameObject>(PrefabPath + "BlockManager");
            GameObject pfCompleteBlock = Resources.Load<GameObject>(PrefabPath + "CompleteBlock");
            GameObject pfGhostCompleteBlock = Resources.Load<GameObject>(PrefabPath + "GhostCompleteBlock");

            GameObject pfUIManager = Resources.Load<GameObject>(PrefabPath + "UIManager");

			List<GameObject> goList = new List<GameObject>();

			blockCount = 0;
			while(true)
			{
				string blockName = "BlockNum" + (blockCount + 1).ToString();
				GameObject pfBlock = Resources.Load<GameObject>(PrefabPath + blockName );

				if ( pfBlock != null )
					goList.Add (pfBlock);
				else
					break;

				++blockCount;
			}

            GameObject goUIManager = (GameObject)GameObject.Instantiate(pfUIManager);
            goUIManager.transform.parent = root.transform;
            goUIManager.name = "UIManager";

			GameObject goCamera = (GameObject)GameObject.Instantiate(pfCamera);
            goCamera.transform.parent = root.transform;
            goCamera.name = "BlockGame Camera";

            GameObject goLight = (GameObject)GameObject.Instantiate(pfLight);
            goLight.transform.parent = root.transform;
            goLight.name = "Directional light";

            GameObject goPlayer = (GameObject)GameObject.Instantiate(pfPlayer);
            goPlayer.transform.parent = root.transform;
            goPlayer.name = "Player";

            GameObject goPlane = (GameObject)GameObject.Instantiate(pfPlane);
            goPlane.transform.parent = root.transform;
			goPlane.transform.position = new Vector3(-3.75f, 0, 0);
            goPlane.transform.eulerAngles = new Vector3(0, 0, 0);
            goPlane.transform.localScale = new Vector3(1, 1, 1);
            goPlane.name = "Plane";

            GameObject goBlockManager = (GameObject)GameObject.Instantiate(pfBlockManager);
            goBlockManager.transform.parent = root.transform;
            goBlockManager.name = "BlockManager";

            GameObject goCompleteBlockUI = (GameObject)GameObject.Instantiate(pfCompleteBlock);
            goCompleteBlockUI.transform.parent = root.transform;
			goCompleteBlockUI.transform.position = new Vector3(-2.5f, 1.0f, 9.0f);
            goCompleteBlockUI.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            goCompleteBlockUI.name = "CompleteBlockUI";

			GameObject goCompleteBlock = (GameObject)GameObject.Instantiate(pfGhostCompleteBlock);
			goCompleteBlock.transform.parent = goPlane.transform;
			goCompleteBlock.transform.position = new Vector3(-3.75f, 0.1f, 0);
			goCompleteBlock.transform.eulerAngles = new Vector3(0, 0, 0);
			goCompleteBlock.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
			goCompleteBlock.name = "CompleteBlock";

			GameObject goCompleteBlockDummy = (GameObject)GameObject.Instantiate(pfCompleteBlock);
			goCompleteBlockDummy.transform.parent = goPlane.transform;
			goCompleteBlockDummy.transform.position = new Vector3(-3.75f, 0.1f, 0);
			goCompleteBlockDummy.transform.eulerAngles = new Vector3(0, 0, 0);
			goCompleteBlockDummy.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
			goCompleteBlockDummy.name = "CompleteBlockDummy";


			GameObject goSliderUI = new GameObject();
			goSliderUI.transform.parent = root.transform;
			goSliderUI.AddComponent<UISlider>();
			goSliderUI.name = "SliderUI";

			UISlider slider = goSliderUI.transform.GetComponent<UISlider>();

            // Debug.Log("UI Loading : " + goList.Count.ToString());

			for ( int i = 0; i < goList.Count; ++i )
			{
				GameObject goBlockUI = (GameObject)GameObject.Instantiate(goList[i]);

				goBlockUI.name = "BlockNum" + (i + 1).ToString() + "UI";
				slider.PushObject(goBlockUI);
			}

			slider.Init();
        }

        public virtual void UnInit()
        {
            GameObject.DestroyImmediate(root);
            
            /*
            if (root != null)
            {
                for (int i = root.transform.childCount - 1; i >= 0; i--)
                {
                    Transform t = root.transform.GetChild(i);
                    t.parent = null;
                    GameObject.DestroyImmediate(t.gameObject);
                }
            }
            */
        }
    }
}


