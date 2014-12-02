using UnityEngine;
using System.Collections;

namespace plugin_BlockGame
{
    public class BlockManager : MonoBehaviour
    {
		static BlockManager _instance = null;

        const string PrefabPath = "Plugins/BlockGame/Prefab/";
        const string MaterialPath = "Plugins/BlockGame/Material/";

        GameObject goPlane;
        GameObject goBlockNum1;
        GameObject goBlockNum2;
        GameObject goBlockNum3;
		GameObject goBlockNum4;
		GameObject goBlockNum5;
		GameObject goBlockNum6;
		GameObject goBlockNum7;
        GameObject goCompleteBlock;
        Transform tfGhostBlockNum1;
        Transform tfGhostBlockNum2;
        Transform tfGhostBlockNum3;
		Transform tfGhostBlockNum4;
		Transform tfGhostBlockNum5;
		Transform tfGhostBlockNum6;
		Transform tfGhostBlockNum7;

		GameObject goDummy;
		Transform tfDummyNum1;
		Transform tfDummyNum2;
		Transform tfDummyNum3;
		Transform tfDummyNum4;
		Transform tfDummyNum5;
		Transform tfDummyNum6;
		Transform tfDummyNum7;

		Material disableMat;
		Material enableMat;
		Material assembledMat;
		GameObject goCompleteBlockUI;
		GameObject goGhostBlockNum1UI;
		GameObject goGhostBlockNum2UI;
		GameObject goGhostBlockNum3UI;
		GameObject goGhostBlockNum4UI;
		GameObject goGhostBlockNum5UI;
		GameObject goGhostBlockNum6UI;
		GameObject goGhostBlockNum7UI;

		enum AssembleState
		{
			ASSEM_NONE,
			ASSEM_1,
			ASSEM_2,
			ASSEM_3,
			ASSEM_4,
			ASSEM_5,
			ASSEM_6,
			ASSEM_7,
		}

		AssembleState assem = AssembleState.ASSEM_NONE;

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
			tfGhostBlockNum6 = goCompleteBlock.transform.FindChild("GhostBlockNum6");
			tfGhostBlockNum7 = goCompleteBlock.transform.FindChild("GhostBlockNum7");

            tfGhostBlockNum2.gameObject.SetActive(false);
            tfGhostBlockNum3.gameObject.SetActive(false);
			tfGhostBlockNum4.gameObject.SetActive(false);
			tfGhostBlockNum5.gameObject.SetActive(false);
			tfGhostBlockNum6.gameObject.SetActive(false);
			tfGhostBlockNum7.gameObject.SetActive(false);

            GameObject pfBlockNum1 = Resources.Load<GameObject>(PrefabPath + "BlockNum1");
            GameObject pfBlockNum2 = Resources.Load<GameObject>(PrefabPath + "BlockNum2");
            GameObject pfBlockNum3 = Resources.Load<GameObject>(PrefabPath + "BlockNum3");
            GameObject pfBlockNum4 = Resources.Load<GameObject>(PrefabPath + "BlockNum4");
            GameObject pfBlockNum5 = Resources.Load<GameObject>(PrefabPath + "BlockNum5");
			GameObject pfBlockNum6 = Resources.Load<GameObject>(PrefabPath + "BlockNum6");
			GameObject pfBlockNum7 = Resources.Load<GameObject>(PrefabPath + "BlockNum7");
			
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

			goBlockNum6 = (GameObject)GameObject.Instantiate(pfBlockNum6);
			goBlockNum6.transform.parent = goPlane.transform;
			goBlockNum6.name = "BlockNum6";
			goBlockNum6.SetActive(false);

			goBlockNum7 = (GameObject)GameObject.Instantiate(pfBlockNum7);
			goBlockNum7.transform.parent = goPlane.transform;
			goBlockNum7.name = "BlockNum7";
			goBlockNum7.SetActive(false);

            disableMat = Resources.Load<Material>(MaterialPath + "Disabled");
            enableMat = Resources.Load<Material>(MaterialPath + "GhostMaterial");
            assembledMat = Resources.Load<Material>(MaterialPath + "Assembed");

			goCompleteBlockUI = GameObject.Find("CompleteBlockUI");
			goGhostBlockNum1UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum1").gameObject;
			goGhostBlockNum2UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum2").gameObject;
			goGhostBlockNum3UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum3").gameObject;
			goGhostBlockNum4UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum4").gameObject;
			goGhostBlockNum5UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum5").gameObject;
			goGhostBlockNum6UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum6").gameObject;
			goGhostBlockNum7UI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum7").gameObject;

			foreach( MeshRenderer mr in goGhostBlockNum1UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = enableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum2UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum3UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum4UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum5UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum6UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			foreach( MeshRenderer mr in goGhostBlockNum7UI.GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = disableMat;
			}

			goDummy = GameObject.Find("CompleteBlockDummy");
			tfDummyNum1 = goDummy.transform.FindChild("CompleteBlockNum1");
			tfDummyNum2 = goDummy.transform.FindChild("CompleteBlockNum2");
			tfDummyNum3 = goDummy.transform.FindChild("CompleteBlockNum3");
			tfDummyNum4 = goDummy.transform.FindChild("CompleteBlockNum4");
			tfDummyNum5 = goDummy.transform.FindChild("CompleteBlockNum5");
			tfDummyNum6 = goDummy.transform.FindChild("CompleteBlockNum6");
			tfDummyNum7 = goDummy.transform.FindChild("CompleteBlockNum7");

			tfDummyNum1.gameObject.SetActive(false);
			tfDummyNum2.gameObject.SetActive(false);
			tfDummyNum3.gameObject.SetActive(false);
			tfDummyNum4.gameObject.SetActive(false);
			tfDummyNum5.gameObject.SetActive(false);
			tfDummyNum6.gameObject.SetActive(false);
			tfDummyNum7.gameObject.SetActive(false);
		}
		
		public GameObject GetBlock(string BlockUIName, Vector3 pos)
        {
            switch (BlockUIName)
            {
			case "BlockNum1UI":
				if ( assem >= AssembleState.ASSEM_1 )
					return null;

				goBlockNum1.transform.position = pos;
				goBlockNum1.SetActive(true);
				return goBlockNum1;

			case "BlockNum2UI":
				if ( assem >= AssembleState.ASSEM_2 )
					return null;

				goBlockNum2.transform.position = pos;
				goBlockNum2.SetActive(true);
				return goBlockNum2;

			case "BlockNum3UI":
				if ( assem >= AssembleState.ASSEM_3 )
					return null;

				goBlockNum3.transform.position = pos;
				goBlockNum3.SetActive(true);
				return goBlockNum3;

			case "BlockNum4UI":
				if ( assem >= AssembleState.ASSEM_4 )
					return null;

				goBlockNum4.transform.position = pos;
				goBlockNum4.SetActive(true);
				return goBlockNum4;

			case "BlockNum5UI":
				if ( assem >= AssembleState.ASSEM_5 )
					return null;

				goBlockNum5.transform.position = pos;
				goBlockNum5.SetActive(true);
				return goBlockNum5;

			case "BlockNum6UI":
				if ( assem >= AssembleState.ASSEM_6 )
					return null;
				
				goBlockNum6.transform.position = pos;
				goBlockNum6.SetActive(true);
				return goBlockNum6;

			case "BlockNum7UI":
				if ( assem >= AssembleState.ASSEM_7 )
					return null;
				
				goBlockNum7.transform.position = pos;
				goBlockNum7.SetActive(true);
				return goBlockNum7;

			default:
				return null;
            }
        }

        public bool CheckAssembleBlockLogic(string hitBlockName)
        {
			GameObject goBlockNum1UI = GameObject.Find("BlockNum1UI");
			GameObject goBlockNum2UI = GameObject.Find("BlockNum2UI");
			GameObject goBlockNum3UI = GameObject.Find("BlockNum3UI");
			GameObject goBlockNum4UI = GameObject.Find("BlockNum4UI");
			GameObject goBlockNum5UI = GameObject.Find("BlockNum5UI");
			GameObject goBlockNum6UI = GameObject.Find("BlockNum6UI");
			GameObject goBlockNum7UI = GameObject.Find("BlockNum7UI");
			
			switch (hitBlockName)
            {
			case "GhostBlockNum1":

				// goBlockNum1UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum1UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_1;
				
				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(true);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(false);

				foreach( MeshRenderer mr in goGhostBlockNum1UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum2UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum1.gameObject.SetActive(true);

				return true;
			case "GhostBlockNum2":

				// goBlockNum2UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum2UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_2;

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(true);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(false);

				foreach( MeshRenderer mr in goGhostBlockNum2UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum3UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum2.gameObject.SetActive(true);

				return true;
			case "GhostBlockNum3":

				// goBlockNum3UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum3UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_3;

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(true);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(false);

				foreach( MeshRenderer mr in goGhostBlockNum3UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum4UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum3.gameObject.SetActive(true);

				return true;

			case "GhostBlockNum4":

				// goBlockNum4UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum4UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_4;

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(true);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(false);

				foreach( MeshRenderer mr in goGhostBlockNum4UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum5UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum4.gameObject.SetActive(true);

				return true;

			case "GhostBlockNum5":
				
				// goBlockNum5UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum5UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_5;
				
				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(true);
				tfGhostBlockNum7.gameObject.SetActive(false);
				
				foreach( MeshRenderer mr in goGhostBlockNum5UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum6UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum5.gameObject.SetActive(true);

				return true;

			case "GhostBlockNum6":
				
				// goBlockNum6UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum6UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_6;
				
				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(true);
				
				foreach( MeshRenderer mr in goGhostBlockNum6UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}
				
				foreach( MeshRenderer mr in goGhostBlockNum7UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				tfDummyNum6.gameObject.SetActive(true);

				return true;

			case "GhostBlockNum7":

				// goBlockNum5UI.gameObject.SetActive(false);
				foreach( MeshRenderer mr in goBlockNum7UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}
				assem = AssembleState.ASSEM_7;

				tfGhostBlockNum1.gameObject.SetActive(false);
				tfGhostBlockNum2.gameObject.SetActive(false);
				tfGhostBlockNum3.gameObject.SetActive(false);
				tfGhostBlockNum4.gameObject.SetActive(false);
				tfGhostBlockNum5.gameObject.SetActive(false);
				tfGhostBlockNum6.gameObject.SetActive(false);
				tfGhostBlockNum7.gameObject.SetActive(false);

				foreach( MeshRenderer mr in goGhostBlockNum7UI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = assembledMat;
				}

				tfDummyNum7.gameObject.SetActive(true);

				return true;

			default:
				return false;
            }
        }
    }
}

