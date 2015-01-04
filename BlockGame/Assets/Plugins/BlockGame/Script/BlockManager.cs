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
		GameObject goCompleteBlockUI;

		// 픽(Pick) 하면 보이는 이동 가능한 블록
		List<GameObject> goBlockList = new List<GameObject>();

		// 우측 슬라이더에 들어갈 UI 블록
		List<GameObject> goBlockUIList = new List<GameObject>();

		// 화면 중앙의 조립 중 다음 스텝 알려주는 블록 - 실제 내용물
		List<Transform> tfGhostBlockList = new List<Transform>();

		GameObject goDummy;
		List<Transform> tfDummyList = new List<Transform>();

		Material disableMat;
		Material enableMat;
		Material assembledMat;
		Material targetMat;

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

			// 화면 중앙의 조립 중 다음 스텝 알려주는 블록
            goCompleteBlock = GameObject.Find("CompleteBlock");

			// 좌측 상단의 Preview 블록
			goCompleteBlockUI = GameObject.Find("CompleteBlockUI");

			// 화면 중앙의 조립 된 결과물
			goDummy = GameObject.Find("CompleteBlockDummy");

			disableMat = Resources.Load<Material>(MaterialPath + "Disabled");
			targetMat = Resources.Load<Material>(MaterialPath + "GhostMaterial");
			assembledMat = Resources.Load<Material>(MaterialPath + "Assembed");
			enableMat = Resources.Load<Material>(MaterialPath + "Enabled");
			
			for ( int i = 0; i < BlockGame.BlockCount; ++i )
			{
				// 픽(Pick) 하면 보이는 이동 가능한 블록
				GameObject pfBlock = Resources.Load<GameObject>(PrefabPath + "BlockNum" + (i + 1).ToString());
				
				if ( pfBlock != null )
				{
					GameObject goBlock = (GameObject)GameObject.Instantiate(pfBlock);

					goBlock.transform.parent = goPlane.transform;
					goBlock.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);

					goBlock.name = "BlockNum" + (i + 1).ToString();
					goBlock.SetActive(false);
					
					goBlockList.Add (goBlock);
				}

				// 우측 슬라이더에 들어갈 UI 블록
				GameObject goBlockUI = GameObject.Find ("BlockNum" + (i + 1).ToString() + "UI");
				
				if ( goBlockUI != null )
					goBlockUIList.Add (goBlockUI);

				// Preview
				GameObject goGhostBlockUI = goCompleteBlockUI.transform.FindChild("CompleteBlockNum" + (i + 1).ToString()).gameObject;

				if ( goGhostBlockUI != null )
					goGhostBlockUIList.Add (goGhostBlockUI);

				foreach( MeshRenderer mr in goGhostBlockUI.GetComponentsInChildren<MeshRenderer>() )
				{
					mr.material = enableMat;
				}

				// 다음 스텝 지시
				Transform tfGhost = goCompleteBlock.transform.FindChild("GhostBlockNum" + (i + 1).ToString());
				
				if ( tfGhost != null )
				{
					tfGhostBlockList.Add(tfGhost);
					tfGhost.gameObject.SetActive(false);
				}

				// 조립 되어 보이는 결과물
				Transform tfDummy = goDummy.transform.FindChild("CompleteBlockNum" + (i + 1).ToString());

				if ( tfDummy != null )
				{
					tfDummyList.Add (tfDummy);
					tfDummy.gameObject.SetActive(false);
				}
			}

			// 첫 번째 블록을 조립하도록 지시
			tfGhostBlockList[0].gameObject.SetActive(true);

			// Preview도 첫 번째 블록을 강조
			foreach( MeshRenderer mr in goGhostBlockUIList[0].GetComponentsInChildren<MeshRenderer>() )
			{
				mr.material = targetMat;
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
					// UI 비활성화 된 것처럼 투명하게 바꾸고
					foreach( MeshRenderer mr in goBlockUIList[i].GetComponentsInChildren<MeshRenderer>() )
					{
						mr.material = disableMat;
					}

					// 다음 스텝 지시를 일단 모두 false
					foreach(Transform tr in tfGhostBlockList)
					{
						tr.gameObject.SetActive(false);
					}

					// 다음 번 조립 할 녀석만 지시를 활성화
					// 단, 마지막 블록이라면 오버플로우 되므로 바운더리 체크!
					if ( i < tfGhostBlockList.Count - 1)
					{
						tfGhostBlockList[i + 1].gameObject.SetActive(true);
					}

					// Preview에서 조립 된 것은 조립 된 모양으로 보여주고
					foreach( MeshRenderer mr in goGhostBlockUIList[i].GetComponentsInChildren<MeshRenderer>() )
					{
						mr.material = assembledMat;
					}

					// Preview에서 조립 할 것을 강조해서 보여주기
					// 단, 마지막 블록이라면 오버플로우 되므로 바운더리 체크!
					if ( i < goGhostBlockUIList.Count - 1)
					{
						foreach( MeshRenderer mr in goGhostBlockUIList[i + 1].GetComponentsInChildren<MeshRenderer>() )
						{
							mr.material = targetMat;
						}
					}

					// 조립 단계를 증가해주고, 실제 조립 된 결과물을 한 스텝씩 보여주기
					assembleStep = i + 1;
					tfDummyList[i].gameObject.SetActive(true);
					
					return true;
				}
			}

			return false;
        }
    }
}

