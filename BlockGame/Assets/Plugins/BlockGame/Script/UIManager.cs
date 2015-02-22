using UnityEngine;
using System.Collections;
namespace plugin_BlockGame
{
	public enum ControlState
	{
		CONTROL_NONE ,
		CONTROL_1 ,
		CONTROL_2 ,
		CONTROL_3 ,
		CONTROL_MAX
	}

	public class UIManager : MonoBehaviour
	{

		const string PrefabPath = "Plugins/BlockGame/Prefab/";

		private GameObject m_StateSprite1 = null;
		private GameObject m_StateSprite2 = null;
		private GameObject m_StateSprite3 = null;

		private GameObject m_BackGround = null;
		private GameObject m_CloseButton = null;
		private GameObject m_PlusButton = null;
		private GameObject m_MinusButton = null;

		private static UIManager _instance = null;
		public static UIManager GetInstance()
		{
			return _instance;
		}

		void Start()
		{
			if ( _instance == null )
			{
				_instance = this;

				GameObject pfStateSprite1 = Resources.Load<GameObject>( PrefabPath + "state1" );
				GameObject pfStateSprite2 = Resources.Load<GameObject>( PrefabPath + "state2" );
				GameObject pfStateSprite3 = Resources.Load<GameObject>( PrefabPath + "state3" );
				GameObject pfBackGround = Resources.Load<GameObject>( PrefabPath + "background1" );
				GameObject pfClosebutton = Resources.Load<GameObject>( PrefabPath + "CloseButton" );
				GameObject pfPlusButton = Resources.Load<GameObject>( PrefabPath + "PlusButton" );
				GameObject pfMinusButton = Resources.Load<GameObject>( PrefabPath + "MinusButton" );

				m_StateSprite1 = (GameObject)GameObject.Instantiate( pfStateSprite1 );
				m_StateSprite1.transform.parent = gameObject.transform;
				m_StateSprite2 = (GameObject)GameObject.Instantiate( pfStateSprite2 );
				m_StateSprite2.transform.parent = gameObject.transform;
				m_StateSprite3 = (GameObject)GameObject.Instantiate( pfStateSprite3 );
				m_StateSprite3.transform.parent = gameObject.transform;

				m_BackGround = (GameObject)GameObject.Instantiate( pfBackGround );
				m_BackGround.transform.parent = gameObject.transform;

				m_CloseButton = (GameObject)GameObject.Instantiate( pfClosebutton );
				m_CloseButton.transform.parent = gameObject.transform;

				m_PlusButton = (GameObject)GameObject.Instantiate( pfPlusButton );
				m_PlusButton.transform.parent = gameObject.transform;

				m_MinusButton = (GameObject)GameObject.Instantiate( pfMinusButton );
				m_MinusButton.transform.parent = gameObject.transform;

				ChangeState( ControlState.CONTROL_1 );
			}
			else
			{
				Destroy( gameObject );
			}
		}


		public void ChangeState(ControlState state)
		{
			switch ( state )
			{
				case ControlState.CONTROL_1:
					m_StateSprite1.SetActive( true );
					m_StateSprite2.SetActive( false );
					m_StateSprite3.SetActive( false );
					break;
				case ControlState.CONTROL_2:
					m_StateSprite1.SetActive( false );
					m_StateSprite2.SetActive( true );
					m_StateSprite3.SetActive( false );
					break;
				case ControlState.CONTROL_3:
					m_StateSprite1.SetActive( false );
					m_StateSprite2.SetActive( false );
					m_StateSprite3.SetActive( true );
					break;
			}
		}


	}
}