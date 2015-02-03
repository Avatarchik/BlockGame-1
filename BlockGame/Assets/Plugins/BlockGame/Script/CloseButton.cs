using UnityEngine;
using System.Collections;

namespace plugin_BlockGame
{
	public class CloseButton : MonoBehaviour
	{
		GameObject goCamera;
		Camera scCamera;

		void Start()
		{
			goCamera = GameObject.Find( "BlockGame Camera" );
			scCamera = goCamera.GetComponent<Camera>();
		}

		void Update()
		{
			if ( Input.GetMouseButton( 0 ) )
			{
				Ray ray = scCamera.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;

				if ( Physics.Raycast( ray , out hit ) )
				{
					if ( hit.transform.name.Contains( "CloseButton" ) )
					{
						ButtonClicked();
					}
				}
			}
		}

		void ButtonClicked()
		{
			// Debug.Log( "Clicked!" );
			BlockGame.Instance().UnInit();
		}
	}
}