using UnityEngine;
using System.Collections;

namespace plugin_BlockGame
{
    public class BlockManager : MonoBehaviour
    {

        static BlockManager _instance = null;

        GameObject goPlane;
        GameObject goBlockNum1;
        GameObject goBlockNum2;
        GameObject goBlockNum3;
		GameObject goBlockNum4;
		GameObject goBlockNum5;
        GameObject goCompleteBlock;
        Transform tfGhostBlockNum1;
        Transform tfGhostBlockNum2;
        Transform tfGhostBlockNum3;
		Transform tfGhostBlockNum4;
		Transform tfGhostBlockNum5;

        public static BlockManager Instance()
        {
            return _instance;
        }

        void Start()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);

            goPlane = GameObject.Find("Plane");

            goCompleteBlock = GameObject.Find("CompleteBlock");
            tfGhostBlockNum1 = goCompleteBlock.transform.FindChild("GhostBlockNum1");
            tfGhostBlockNum2 = goCompleteBlock.transform.FindChild("GhostBlockNum2");
            tfGhostBlockNum3 = goCompleteBlock.transform.FindChild("GhostBlockNum3");
			tfGhostBlockNum4 = goCompleteBlock.transform.FindChild("GhostBlockNum4");
			tfGhostBlockNum5 = goCompleteBlock.transform.FindChild("GhostBlockNum5");

            tfGhostBlockNum2.gameObject.SetActive(false);
            tfGhostBlockNum3.gameObject.SetActive(false);
			tfGhostBlockNum4.gameObject.SetActive(false);
			tfGhostBlockNum5.gameObject.SetActive(false);

            GameObject pfBlockNum1 = Resources.Load<GameObject>("Prefab/BlockNum1");
            GameObject pfBlockNum2 = Resources.Load<GameObject>("Prefab/BlockNum2");
            GameObject pfBlockNum3 = Resources.Load<GameObject>("Prefab/BlockNum3");
			GameObject pfBlockNum4 = Resources.Load<GameObject>("Prefab/BlockNum4");
			GameObject pfBlockNum5 = Resources.Load<GameObject>("Prefab/BlockNum5");

            goBlockNum1 = (GameObject)GameObject.Instantiate(pfBlockNum1);
            goBlockNum1.transform.parent = goPlane.transform;
            goBlockNum1.name = "BlockNum1";
            goBlockNum1.SetActive(false);

            goBlockNum2 = (GameObject)GameObject.Instantiate(pfBlockNum2);
            goBlockNum2.transform.parent = goPlane.transform;
            goBlockNum2.name = "BlockNum2";
            goBlockNum2.SetActive(false);

            goBlockNum3 = (GameObject)GameObject.Instantiate(pfBlockNum3);
            goBlockNum3.transform.parent = goPlane.transform;
            goBlockNum3.name = "BlockNum3";
            goBlockNum3.SetActive(false);

			goBlockNum4 = (GameObject)GameObject.Instantiate(pfBlockNum4);
			goBlockNum4.transform.parent = goPlane.transform;
			goBlockNum4.name = "BlockNum4";
			goBlockNum4.SetActive(false);

			goBlockNum5 = (GameObject)GameObject.Instantiate(pfBlockNum5);
			goBlockNum5.transform.parent = goPlane.transform;
			goBlockNum5.name = "BlockNum5";
			goBlockNum5.SetActive(false);

        }

        public GameObject GetBlock(string BlockUIName, Vector3 pos)
        {
            switch (BlockUIName)
            {
			case "BlockNum1UI":
				goBlockNum1.transform.position = pos;
				goBlockNum1.SetActive(true);
				return goBlockNum1;
			case "BlockNum2UI":
				goBlockNum2.transform.position = pos;
				goBlockNum2.SetActive(true);
				return goBlockNum2;
			case "BlockNum3UI":
				goBlockNum3.transform.position = pos;
				goBlockNum3.SetActive(true);
				return goBlockNum3;
			case "BlockNum4UI":
				goBlockNum4.transform.position = pos;
				goBlockNum4.SetActive(true);
				return goBlockNum4;
			case "BlockNum5UI":
				goBlockNum5.transform.position = pos;
				goBlockNum5.SetActive(true);
				return goBlockNum5;
			default:
				return null;
            }
        }

        public bool CheckAssembleBlockLogic(string hitBlockName)
        {
            switch (hitBlockName)
            {
			case "GhostBlockNum1":

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(true);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);

				return true;
			case "GhostBlockNum2":

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(true);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);

				return true;
			case "GhostBlockNum3":

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(true);
				tfGhostBlockNum5.gameObject.SetActive(false);

				return true;

			case "GhostBlockNum4":
				
				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(true);
				
				return true;

			case "GhostBlockNum5":
				
				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				
				return true;

			default:
				return false;
            }
        }
    }
}

