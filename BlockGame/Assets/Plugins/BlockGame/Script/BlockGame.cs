using UnityEngine;
using System.Collections;

using civ;

namespace plugin_BlockGame 
{
    public class BlockGame : iModule
    {
        GameObject goPlugin;
        GameObject root;

        public virtual void Init(iViewer viewer)
        {
            goPlugin = GameObject.Find("plugin");
            if (goPlugin == null)
            {
                GameObject pfPlugin = Resources.Load<GameObject>("Prefab/plugin");
                goPlugin = (GameObject)GameObject.Instantiate(pfPlugin);
                goPlugin.transform.name = "plugin";
            }

            root = GameObject.Find("BlockGame");
            if (root == null)
            {
                GameObject pfRoot = Resources.Load<GameObject>("Prefab/BlockGame");
                root = (GameObject)GameObject.Instantiate(pfRoot);
                root.transform.parent = goPlugin.transform;
                root.name = "BlockGame";
            }

            GameObject pfCamera = Resources.Load<GameObject>("Prefab/Camera");
            GameObject pfLight = Resources.Load<GameObject>("Prefab/Directional light");
            GameObject pfPlayer = Resources.Load<GameObject>("Prefab/Player");
            GameObject pfPlane = Resources.Load<GameObject>("Prefab/Plane");
            GameObject pfBlockManager = Resources.Load<GameObject>("Prefab/BlockManager");
            GameObject pfCompleteBlock = Resources.Load<GameObject>("Prefab/CompleteBlock");
            GameObject pfGhostCompleteBlock = Resources.Load<GameObject>("Prefab/GhostCompleteBlock");

            GameObject pfBlockNum1 = Resources.Load<GameObject>("Prefab/BlockNum1");
            GameObject pfBlockNum2 = Resources.Load<GameObject>("Prefab/BlockNum2");
            GameObject pfBlockNum3 = Resources.Load<GameObject>("Prefab/BlockNum3");
			GameObject pfBlockNum4 = Resources.Load<GameObject>("Prefab/BlockNum4");
			GameObject pfBlockNum5 = Resources.Load<GameObject>("Prefab/BlockNum5");

            GameObject goCamera = (GameObject)GameObject.Instantiate(pfCamera);
            goCamera.transform.parent = root.transform;
            goCamera.name = "BlockGame Camera";
            //Camera scCamera = goCamera.GetComponent<Camera>();
            //Camera.SetupCurrent(scCamera);

            GameObject goLight = (GameObject)GameObject.Instantiate(pfLight);
            goLight.transform.parent = root.transform;
            goLight.name = "Directional light";

            GameObject goPlayer = (GameObject)GameObject.Instantiate(pfPlayer);
            goPlayer.transform.parent = root.transform;
            goPlayer.name = "Player";

            GameObject goPlane = (GameObject)GameObject.Instantiate(pfPlane);
            goPlane.transform.parent = root.transform;
            goPlane.transform.position = new Vector3(0, 0, 0);
            goPlane.transform.eulerAngles = new Vector3(0, 0, 0);
            goPlane.transform.localScale = new Vector3(1, 1, 1);
            goPlane.name = "Plane";

            GameObject goBlockManager = (GameObject)GameObject.Instantiate(pfBlockManager);
            goBlockManager.transform.parent = root.transform;
            goBlockManager.name = "BlockManager";

            GameObject goCompleteBlock = (GameObject)GameObject.Instantiate(pfGhostCompleteBlock);
            goCompleteBlock.transform.parent = goPlane.transform;
            goCompleteBlock.transform.position = new Vector3(0, 0, 0);
            goCompleteBlock.transform.eulerAngles = new Vector3(0, 0, 0);
            goCompleteBlock.transform.localScale = new Vector3(1, 1, 1);
            goCompleteBlock.name = "CompleteBlock";

            GameObject goCompleteBlockUI = (GameObject)GameObject.Instantiate(pfCompleteBlock);
            goCompleteBlockUI.transform.parent = root.transform;
            goCompleteBlockUI.transform.position = new Vector3(-3, 0, 8);
            goCompleteBlockUI.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            goCompleteBlockUI.name = "CompleteBlockUI";



			GameObject goSliderUI = new GameObject();
			goSliderUI.transform.parent = root.transform;
			goSliderUI.AddComponent<UISlider>();
			goSliderUI.name = "SliderUI";

			UISlider slider = goSliderUI.transform.GetComponent<UISlider>();

			GameObject goBlockNum1UI = (GameObject)GameObject.Instantiate(pfBlockNum1);
			goBlockNum1UI.name = "BlockNum1UI";
			slider.PushObject(goBlockNum1UI);

            GameObject goBlockNum2UI = (GameObject)GameObject.Instantiate(pfBlockNum2);
			goBlockNum2UI.name = "BlockNum2UI";
			slider.PushObject(goBlockNum2UI);

            GameObject goBlockNum3UI = (GameObject)GameObject.Instantiate(pfBlockNum3);
			goBlockNum3UI.name = "BlockNum3UI";
			slider.PushObject(goBlockNum3UI);

			GameObject goBlockNum4UI = (GameObject)GameObject.Instantiate(pfBlockNum4);
			goBlockNum4UI.name = "BlockNum4UI";
			slider.PushObject(goBlockNum4UI);

			GameObject goBlockNum5UI = (GameObject)GameObject.Instantiate(pfBlockNum5);
			goBlockNum5UI.name = "BlockNum5UI";
			slider.PushObject(goBlockNum5UI);

			GameObject goBlockNum6UI = (GameObject)GameObject.Instantiate(pfBlockNum1);
			goBlockNum6UI.name = "BlockNum6UI";
			slider.PushObject(goBlockNum6UI);

			GameObject goBlockNum7UI = (GameObject)GameObject.Instantiate(pfBlockNum2);
			goBlockNum7UI.name = "BlockNum7UI";
			slider.PushObject(goBlockNum7UI);

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


