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
			obj.transform.localScale = new Vector3( 1.15f , 1.15f , 1.15f );
			listOfUI.Add( obj );
		}

		public void Init()
		{
			startIndex = 0;

			transform.Rotate( 50.0f , 225.0f , 180.0f );
			transform.localScale = new Vector3( 1.0f , 1.0f , 1.0f );

			BuildUI();
		}

		public void BuildUI()
		{
			transform.localPosition = new Vector3( -7.5f , -6.5f , 30.0f );

			// 0 1 2 3 4 5 6 <- input
			// 6 0 1 2 3 4 5 <- display
			for ( int i = 0 ; i < listOfUI.Count ; ++i )
			{
				int index = ( listOfUI.Count + startIndex - 1 + i ) % listOfUI.Count;
				displayListOfUI[i] = listOfUI[index];

				displayListOfUI[i].transform.parent = gameObject.transform;
				displayListOfUI[i].transform.localPosition = new Vector3( (float)( i ) * 3.0f , 0.0f , 0.0f );

				foreach ( MeshRenderer mr in displayListOfUI[i].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = true;
				}
			}
		}

		bool slideFlag = false;
		Vector3 startScreenPos;

		public void UpdateMouseButtonDown()
		{
			if ( !slideFlag )
			{
				slideFlag = true;
				startScreenPos = new Vector2( Input.mousePosition.x , Input.mousePosition.y );
			}

			Vector2 nowScreenPos = new Vector2( Input.mousePosition.x , Input.mousePosition.y );

			if ( nowScreenPos.x > startScreenPos.x )
			{
				Vector3 nowPos = transform.localPosition;
				nowPos.x += Time.deltaTime * 10.0f;
				transform.localPosition = nowPos;

				startScreenPos = nowScreenPos;

				if ( transform.localPosition.x > -4.5f )
				{
					--startIndex;
					startIndex = ( listOfUI.Count + startIndex ) % listOfUI.Count;

					BuildUI();
				}
			}
			else if ( nowScreenPos.x < startScreenPos.x )
			{
				Vector3 nowPos = transform.localPosition;
				nowPos.x -= Time.deltaTime * 10.0f;
				transform.localPosition = nowPos;

				startScreenPos = nowScreenPos;

				if ( transform.localPosition.x < -10.5f )
				{
					++startIndex;
					
					BuildUI();
				}
			}
		}

		public void UpdateMouseButtonUp()
		{
			slideFlag = false;
		}

		void Update()
		{
			if ( Input.GetMouseButtonUp( 0 ) )
			{
				slideFlag = false;

				foreach ( MeshRenderer mr in displayListOfUI[0].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = false;
				}
				foreach ( MeshRenderer mr in displayListOfUI[5].GetComponentsInChildren<MeshRenderer>() )
				{
					mr.enabled = false;
				}
			}

			if ( !slideFlag )
			{
				if ( transform.localPosition.x > -7.3f )
				{
					Vector3 nowPos = transform.localPosition;
					nowPos.x -= Time.deltaTime * 10.0f;
					transform.localPosition = nowPos;
				}
				else if ( transform.localPosition.x < -7.7f )
				{
					Vector3 nowPos = transform.localPosition;
					nowPos.x += Time.deltaTime * 10.0f;
					transform.localPosition = nowPos;
				}
				else
				{
					transform.localPosition = new Vector3( -7.5f , -6.5f , 30.0f );
				}
			}
		}
	}
}