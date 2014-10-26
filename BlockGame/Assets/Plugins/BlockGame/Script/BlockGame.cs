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

            GameObject goBlockNum1UI = (GameObject)GameObject.Instantiate(pfBlockNum1);
            goBlockNum1UI.transform.parent = root.transform;
            goBlockNum1UI.transform.position = new Vector3(5, 0, -7);
            goBlockNum1UI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            goBlockNum1UI.name = "BlockNum1UI";

            GameObject goBlockNum2UI = (GameObject)GameObject.Instantiate(pfBlockNum2);
            goBlockNum2UI.transform.parent = root.transform;
            goBlockNum2UI.transform.position = new Vector3(9, 0, -3);
            goBlockNum2UI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            goBlockNum2UI.name = "BlockNum2UI";

            GameObject goBlockNum3UI = (GameObject)GameObject.Instantiate(pfBlockNum3);
            goBlockNum3UI.transform.parent = root.transform;
            goBlockNum3UI.transform.position = new Vector3(1.5f, 0, -10.5f);
            goBlockNum3UI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            goBlockNum3UI.name = "BlockNum3UI";

			GameObject goBlockNum4UI = (GameObject)GameObject.Instantiate(pfBlockNum4);
			goBlockNum4UI.transform.parent = root.transform;
			goBlockNum4UI.transform.position = new Vector3(-2.5f, 0, -14.0f);
			goBlockNum4UI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			goBlockNum4UI.name = "BlockNum4UI";

			GameObject goBlockNum5UI = (GameObject)GameObject.Instantiate(pfBlockNum5);
			goBlockNum5UI.transform.parent = root.transform;
			goBlockNum5UI.transform.position = new Vector3(13.0f, 0, 1.0f);
			goBlockNum5UI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			goBlockNum5UI.name = "BlockNum5UI";

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


