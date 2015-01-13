using UnityEngine;
using System.Collections;

namespace plugin_BlockGame
{
    public class Plane : MonoBehaviour
    {
        public float sensitivity = 700;
        float planeRotationY;
        float planeDeltaY;

        public void Start()
        {

        }

        public void UpdateRotate()
        {
            iTween.Stop(gameObject);

            float mouseMoveValueX = Input.GetAxis("Mouse X");
            planeDeltaY += mouseMoveValueX * sensitivity * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, planeDeltaY + planeRotationY, 0);

            planeRotationY %= 360;

            if (planeDeltaY <= -90.0f)
            {
                planeRotationY = planeRotationY - 90;
                planeDeltaY = 0.0f;
            }
            else if (90.0f < planeDeltaY)
            {
                planeRotationY = planeRotationY + 90;
                planeDeltaY = 0.0f;
            }
        }

        public void UpdateSmoothMoving()
        {
            if (-45.0f <= planeDeltaY && planeDeltaY < 45.0f)
            {
                Hashtable iTweenHash = new Hashtable();

                iTweenHash.Add("time", 0.5f);
                iTweenHash.Add("rotation", new Vector3(0.0f, planeRotationY, 0.0f));
                iTweenHash.Add("easetype", iTween.EaseType.easeOutExpo);
                iTweenHash.Add("looptype", iTween.LoopType.none);

                iTween.RotateTo(gameObject, iTweenHash);

            }
            else if (-90.0f < planeDeltaY && planeDeltaY < -45.0f)
            {
                Hashtable iTweenHash = new Hashtable();

                iTweenHash.Add("time", 1.0f);
                iTweenHash.Add("rotation", new Vector3(0.0f, planeRotationY - 90.0f, 0.0f));
                iTweenHash.Add("easetype", iTween.EaseType.easeOutExpo);
                iTweenHash.Add("looptype", iTween.LoopType.none);

                iTween.RotateTo(gameObject, iTweenHash);

                planeRotationY = planeRotationY - 90;
            }
            else if (45.0f <= planeDeltaY && planeDeltaY < 90.0f)
            {
                Hashtable iTweenHash = new Hashtable();

                iTweenHash.Add("time", 1.0f);
                iTweenHash.Add("rotation", new Vector3(0.0f, planeRotationY + 90.0f, 0.0f));
                iTweenHash.Add("easetype", iTween.EaseType.easeOutExpo);
                iTweenHash.Add("looptype", iTween.LoopType.none);

                iTween.RotateTo(gameObject, iTweenHash);

                planeRotationY = planeRotationY + 90;
            }

            planeDeltaY = 0.0f;
        }
    }
}