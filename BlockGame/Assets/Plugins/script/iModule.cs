using UnityEngine;
using System.Collections;

namespace civ
{
	public class iModule
	{

		public virtual void Init(iViewer viewer)
		{
			// 컨텐츠 초기화, 실행
			/*
			GameObject root = GameObject.Find("external_module");

			GameObject pf1 = Resources.Load<GameObject>("prefab/Cube");
			GameObject pf2 = Resources.Load<GameObject>("prefab/Cylinder");
			GameObject pf3 = Resources.Load<GameObject>("prefab/Sphere");

			GameObject go1 = (GameObject)GameObject.Instantiate(pf1);
			go1.transform.parent = root.transform;
			GameObject go2 = (GameObject)GameObject.Instantiate(pf2);
			go2.transform.parent = root.transform;
			GameObject go3 = (GameObject)GameObject.Instantiate(pf3);
			go3.transform.parent = root.transform;
			*/

		}
		public virtual void UnInit()
		{
			// 강제 복귀

		}
	}
}