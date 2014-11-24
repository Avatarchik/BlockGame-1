using UnityEngine;
using System.Collections;

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
        GameObject goBlockNum1UI;
        GameObject goBlockNum2UI;
        GameObject goBlockNum3UI;
		GameObject goBlockNum4UI;
		GameObject goBlockNum5UI;
		GameObject goBlockNum6UI;
		GameObject goBlockNum7UI;

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
            goBlockNum1UI = GameObject.Find("BlockNum1UI");
            goBlockNum2UI = GameObject.Find("BlockNum2UI");
            goBlockNum3UI = GameObject.Find("BlockNum3UI");
			goBlockNum4UI = GameObject.Find("BlockNum4UI");
			goBlockNum5UI = GameObject.Find("BlockNum5UI");
			goBlockNum6UI = GameObject.Find("BlockNum6UI");
			goBlockNum7UI = GameObject.Find("BlockNum7UI");

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
            goBlockNum1UI.transform.eulerAngles = goPlane.transform.eulerAngles;
            goBlockNum2UI.transform.eulerAngles = goPlane.transform.eulerAngles;
            goBlockNum3UI.transform.eulerAngles = goPlane.transform.eulerAngles;
			goBlockNum4UI.transform.eulerAngles = goPlane.transform.eulerAngles;
			goBlockNum5UI.transform.eulerAngles = goPlane.transform.eulerAngles;
			goBlockNum6UI.transform.eulerAngles = goPlane.transform.eulerAngles;
			goBlockNum7UI.transform.eulerAngles = goPlane.transform.eulerAngles;
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
                    pickedBlock.transform.position = hit.transform.position;
                    pickedBlock.SetActive(true);
                    return;
                }
            }
        }
    }

}