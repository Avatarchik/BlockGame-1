using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace plugin_BlockGame
{
    enum PLAYER_STATE
    {
        IDLE = 0,
        PICKUP_BLOCK,
        ROTATION_PLANE,
        SLIDE_UI,
    }

    public class Player : MonoBehaviour
    {
		GameObject pickedBlock = null;

        GameObject goUISlider;
        GameObject goCamera;
        GameObject goPlane;
        GameObject goCompleteBlockUI;

		List<GameObject> goUIList = new List<GameObject>();

        Plane scPlane;
        Camera scCamera;
        UISlider scUISlider;

        PLAYER_STATE playerState = PLAYER_STATE.IDLE;

        float screenTouchDividePosition;

        void Start()
        {
            goCamera = GameObject.Find("BlockGame Camera");
			goPlane = GameObject.Find("Plane");
            goUISlider = GameObject.Find("SliderUI");
            goCompleteBlockUI = GameObject.Find("CompleteBlockUI");

			for ( int i = 0; i < BlockGame.BlockCount; ++i )
			{
				string blockName = "BlockNum" + (i + 1).ToString() + "UI";
				GameObject go = GameObject.Find (blockName);

				if ( go != null )
					goUIList.Add (go);
			}

            scCamera = goCamera.GetComponent<Camera>();
            scPlane = goPlane.GetComponent<Plane>();
            scUISlider = goUISlider.GetComponent<UISlider>();

            screenTouchDividePosition = Screen.width / 4 * 3;
        }

        void Update()
        {
            switch (playerState) 
            {
            case PLAYER_STATE.IDLE:

                //if(Input.GetButtonDown("Fire1"))
                if (Input.GetMouseButton(0))
                {
                    Ray ray = scCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    
                    if (Physics.Raycast(ray, out hit))
                    {
						pickedBlock = BlockManager.Instance().GetBlock(hit.transform.name, Input.mousePosition);

                        if (pickedBlock)
                            playerState = PLAYER_STATE.PICKUP_BLOCK;
						else
							return;
                    }
                    else
                    {
                        if (Input.mousePosition.x < screenTouchDividePosition)
                            playerState = PLAYER_STATE.ROTATION_PLANE;
                        else
                            playerState = PLAYER_STATE.SLIDE_UI;
                    }
                }
                break;

            case PLAYER_STATE.PICKUP_BLOCK:
                if (Input.GetMouseButton(0))
                    UpdateBlockOnMousePoint();
                else
                {
                    CheckAssembleBlock();
                    pickedBlock = null;
                    playerState = PLAYER_STATE.IDLE;
                }
                break;

            case PLAYER_STATE.ROTATION_PLANE:

                scPlane.UpdateRotate();

                if (Input.GetMouseButtonUp(0))
                {
                    scPlane.UpdateSmoothMoving();
                    playerState = PLAYER_STATE.IDLE;
                }
                break;

            case PLAYER_STATE.SLIDE_UI:

                scUISlider.UpdateMouseButtonDown();

                if (Input.GetMouseButtonUp(0))
				{
                    playerState = PLAYER_STATE.IDLE;
					scUISlider.UpdateMouseButtonUp();
				}
                break;
            }

            TurnUIWithPlane();
        }

        void UpdateBlockOnMousePoint()
        {
            Vector3 mousePos;
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            mousePos.z = 10;

            pickedBlock.transform.position = (scCamera.ScreenToWorldPoint(mousePos));
        }

        void TurnUIWithPlane()
        {
            goCompleteBlockUI.transform.eulerAngles = goPlane.transform.eulerAngles;

			foreach(GameObject go in goUIList)
			{
				go.transform.eulerAngles = goPlane.transform.eulerAngles;
			}
        }

        void CheckAssembleBlock()
        {
            pickedBlock.SetActive(false);
            Ray ray = scCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Ghost" + pickedBlock.name)
            {
                if(BlockManager.Instance().CheckAssembleBlockLogic(hit.transform.name))
				{
					pickedBlock.SetActive(false);
                    return;
                }
            }
        }
    }

}