using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace plugin_BlockGame
{
    public class BlockManager : MonoBehaviour
    {
		static BlockManager _instance = null;

        const string PrefabPath = "Plugins/BlockGame/Prefab/";
        const string MaterialPath = "Plugins/BlockGame/Material/";

        GameObject goPlane;
		GameObject goCompleteBlock;

		List<GameObject> goBlockList = new List<GameObject>();
		List<GameObject> goBlockUIList = new List<GameObject>();

		List<Transform> tfGhostBlockList = new List<Transform>();

		GameObject goDummy;
		List<Transform> tfDummyList = new List<Transform>();

		Material disableMat;
		Material enableMat;
		Material assembledMat;
		GameObject goCompleteBlockUI;

		List<GameObject> goGhostBlockUIList = new List<GameObject>();

		int assembleStep = 0;

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
			goCompleteBlockUI = GameObject.Find("CompleteBlockUI");

			goDummy = GameObject.Find("CompleteBlockDummy");

			disableMat = Resources.Load<Material>(MaterialPath + "Disabled");
			enableMat = Resources.Load<Material>(MaterialPath + "GhostMaterial");
			assembledMat = Resources.Load<Material>(MaterialPath + "Assembed");
			
			for ( int i = 0; i < BlockGame.BlockCount; ++i )
			{
				GameObject pfBlock = Resources.Load<GameObject>(PrefabPath + "BlockNum" + (i + 1).ToString());
				
				if ( pfBlock != null )
				{
					GameObject goBlock = (GameObject)GameObject.Instantiate(pfBlock);
					
					goBlock.transform.parent = goPlane.transform;
					goBlock.name = "BlockNum" + (i + 1).ToString();
					goBlock.SetActive(false);
					
					goBlockList.Add (goBlock);
				}
				
				GameObject goBlockUI = GameObject.Find ("BlockNum" + (i + 1).ToString() + "UI");
				
				if ( goBlockUI != null )
					goBlockUIList.Add (goBlockUI);

				GameObject goGhostBlockUI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum" + (i + 1).ToString()).gameObject;

				if ( goGhostBlockUI != null )
					goGhostBlockUIList.Add (goGhostBlockUI);

				foreach( MeshRenderer mr in goGhostBlockUI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = disableMat;
				}

				Transform tfGhost = goCompleteBlock.transform.FindChild("GhostBlockNum" + (i + 1).ToString());
				
				if ( tfGhost != null )
				{
					tfGhostBlockList.Add(tfGhost);
					tfGhost.gameObject.SetActive(false);
				}

				Transform tfDummy = goDummy.transform.FindChild("CompleteBlockNum" + (i + 1).ToString());

				if ( tfDummy != null )
				{
					tfDummyList.Add (tfDummy);
					tfDummy.gameObject.SetActive(false);
				}
			}

			tfGhostBlockList[0].gameObject.SetActive(true);

			foreach( MeshRenderer mr in goGhostBlockUIList[0].GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = enableMat;
			}
		}
		
		public GameObject GetBlock(string blockUIName, Vector3 pos)
        {
			for ( int i = 0; i < BlockGame.BlockCount; ++i )
			{
				if ( blockUIName.Equals("BlockNum" + (i + 1).ToString() + "UI" ) )
				{
					if ( assembleStep > i )
						return null;

					goBlockList[i].transform.position = pos;
					goBlockList[i].SetActive(true);
					
					return goBlockList[i];
				}
			}

			return null;
        }

        public bool CheckAssembleBlockLogic(string hitBlockName)
        {
			for ( int i = 0; i < BlockGame.BlockCount; ++i )
			{
				if ( hitBlockName.Equals("GhostBlockNum" + (i + 1).ToString()) )
				{
					foreach( MeshRenderer mr in goBlockUIList[i].GetComponentsInChildren<MeshRenderer>() )
					{
						mr.material = disableMat;
					}

					assembleStep = i + 1;
					
					foreach(Transform tr in tfGhostBlockList)
					{
						tr.gameObject.SetActive(false);
					}

					if ( i < tfGhostBlockList.Count - 1)
					{
						tfGhostBlockList[i + 1].gameObject.SetActive(true);
					}
					
					foreach( MeshRenderer mr in goGhostBlockUIList[i].GetComponentsInChildren<MeshRenderer>() )
					{
						mr.material = assembledMat;
					}

					if ( i < goGhostBlockUIList.Count - 1)
					{
						foreach( MeshRenderer mr in goGhostBlockUIList[i + 1].GetComponentsInChildren<MeshRenderer>() )
						{
							mr.material = enableMat;
						}
					}

					tfDummyList[i].gameObject.SetActive(true);
					
					return true;
				}
			}

			return false;
        }
    }
}

