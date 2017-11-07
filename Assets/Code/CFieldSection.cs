using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFieldSection : MonoBehaviour
{
    [SerializeField]
    private CCamera.ECameraStates m_eCamState;
    [SerializeField]
    private Vector3 m_v3Offset;

    //Vector for camera positioning when idle
    private Vector3 m_trSnapCameraPosition;
    private Quaternion m_qtSnapCameraRotation;

    private void Start()
    {
        //Gets camera position from child 
        Transform trChild = this.transform.GetChild(0);
        if (null != trChild && Constants.k_CameraSnapName.Equals(trChild.name))
        {
            m_trSnapCameraPosition = this.transform.GetChild(0).position;
            m_qtSnapCameraRotation = this.transform.GetChild(0).rotation;
        }
        else
        {
            m_trSnapCameraPosition = Vector3.zero;
            m_qtSnapCameraRotation = new Quaternion(1, 1, 1, 1);
        }
    }

    public void SetCameraMode()
    {
        CCamera.GetInstance().ECurrentState = m_eCamState;

        switch (m_eCamState)
        {
            case CCamera.ECameraStates.eFollow:
                {
                    CCamera.GetInstance().V3Offset = m_v3Offset;
                }
                break;

            case CCamera.ECameraStates.eIdle:
                {
                    CCamera.GetInstance().transform.position = m_trSnapCameraPosition;
                    CCamera.GetInstance().transform.rotation = m_qtSnapCameraRotation;
                }
                break;

            default:
                {

                }
                break;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        SetCameraMode();
    }


}
