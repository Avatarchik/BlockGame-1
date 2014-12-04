using UnityEngine;
using System.Collections;
namespace plugin_BlockGame
{
	public enum ControlState
	{
		CONTROL_NONE,
		CONTROL_1,
		CONTROL_2,
		CONTROL_3,
		CONTROL_MAX
	}

	public class UIManager : MonoBehaviour {

		[SerializeField]
		private GameObject m_StateSprite1 = null;
		[SerializeField]
		private GameObject m_StateSprite2 = null;
		[SerializeField]
		private GameObject m_StateSprite3 = null;


		private static UIManager _instance = null;
		public static UIManager GetInstance()
		{
			return _instance;
		}
		
		void Start()
		{
			if (_instance == null)
			{
				_instance = this;
				ChangeState( ControlState.CONTROL_1 );
			}		
			else
			{
				Destroy (gameObject);
			}
		}


		public void ChangeState( ControlState state )
		{
			switch(state)
			{
			case ControlState.CONTROL_1:
				m_StateSprite1.SetActive(true);
				m_StateSprite2.SetActive(false);
				m_StateSprite3.SetActive(false);
				break;
			case ControlState.CONTROL_2:
				m_StateSprite1.SetActive(false);
				m_StateSprite2.SetActive(true);
				m_StateSprite3.SetActive(false);
				break;
			case ControlState.CONTROL_3:
				m_StateSprite1.SetActive(false);
				m_StateSprite2.SetActive(false);
				m_StateSprite3.SetActive(true);
				break;
			}
		}


	}
}