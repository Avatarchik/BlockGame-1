using UnityEngine;
using System.Collections;

namespace plugin_BlockGame
{
	public class BlockRatio : MonoBehaviour
	{

		private Vector3 m_Scale;

		void Start()
		{
			// 원래 배율을 백업
			m_Scale = transform.localScale;
		}

		void Update()
		{
			transform.localScale = m_Scale * BlockGame.Instance().BlockRatio;
		}
	}
}