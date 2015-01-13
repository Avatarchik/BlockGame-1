using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace plugin_BlockGame
{
	public class UISlider : MonoBehaviour
	{
		List<GameObject> listOfUI = new List<GameObject>();
        GameObject[] displayListOfUI = new GameObject[9];

		int startIndex = 0;

		public void PushObject(GameObject obj)
		{
			// 실제 UI 퍼즐 사이즈
            obj.transform.localScale = new Vector3(1.62f, 1.62f, 1.62f);
			listOfUI.Add(obj);
		}

		public void Init()
		{
			startIndex = 0;

			transform.Rotate( 50.0f, 225.0f, 180.0f );
			transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

			BuildUI();
		}

		public void BuildUI()
		{
			transform.localPosition = new Vector3(4.5f, 13.5f, -8.0f);
			// 0 1 2 3 4 5 6 <- input
			// 6 0 1 2 3 4 5 <- display
			for ( int i = 0; i < listOfUI.Count; ++i )
			{
				int index = (listOfUI.Count + startIndex - 1 + i) % listOfUI.Count;
				displayListOfUI[i] = listOfUI[index];

				displayListOfUI[i].transform.parent = gameObject.transform;
				displayListOfUI[i].transform.localPosition = new Vector3(0.0f, 0.0f, (float)(i) * 3.0f);

				foreach( MeshRenderer mr in displayListOfUI[i].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = true;
				}
			}
		}

		bool slideFlag = false;
		Vector3 startScreenPos;
		
        public void UpdateMouseButtonDown()
        {
            if (!slideFlag)
            {
                slideFlag = true;
                startScreenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }

            Vector2 nowScreenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (nowScreenPos.y > startScreenPos.y)
            {
                Vector3 nowPos = transform.position;
                nowPos.y += Time.deltaTime * 30.0f;
                transform.position = nowPos;

                startScreenPos = nowScreenPos;

                if (transform.position.y > 17.5f)
                {
                    ++startIndex;
                    BuildUI();
                }
            }
            else if (nowScreenPos.y < startScreenPos.y)
            {
                Vector3 nowPos = transform.position;
                nowPos.y -= Time.deltaTime * 30.0f;
                transform.position = nowPos;

                startScreenPos = nowScreenPos;

                if (transform.position.y < 9.5f)
                {
                    --startIndex;
                    startIndex = (listOfUI.Count + startIndex) % listOfUI.Count;

                    BuildUI();
                }
            }
        }

		public void UpdateMouseButtonUp()
		{
			slideFlag = false;
		}

		void Update ()
		{
			if (Input.GetMouseButtonUp(0))
			{
				slideFlag = false;

				foreach( MeshRenderer mr in displayListOfUI[0].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = false;
				}
				foreach( MeshRenderer mr in displayListOfUI[5].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = false;
				}
			}

			if ( !slideFlag )
			{
				if ( transform.position.y > 13.7f )
				{
					Vector3 nowPos = transform.position;
					nowPos.y -= Time.deltaTime * 30.0f;
					transform.position = nowPos;
				}
				else if (transform.position.y < 13.3f )
				{
					Vector3 nowPos = transform.position;
					nowPos.y += Time.deltaTime * 30.0f;
					transform.position = nowPos;
				}
				else
				{
					transform.localPosition = new Vector3(4.5f, 13.5f, -8.0f);
				}
			}
		}
	}
}