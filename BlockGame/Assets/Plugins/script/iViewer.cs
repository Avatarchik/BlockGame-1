using UnityEngine;
using System.Collections;

using plugin_BlockGame;

namespace civ
{
	public class iViewer {

		public iViewer()
		{
		}
        /*
		public virtual void PlayModule(iModule module)
		{
			// 현재 뷰어 정리. GameObject hide등등
			module.Init (this);
		}
        */
        public virtual void PlayModule(BlockGame module)
        {
            // 현재 뷰어 정리. GameObject hide등등
            module.Init(this);
        }

		public virtual void ReturnToViewer()
		{
			// hide 되었던 GameObject등을 모두 되살림.
		}
	}
}