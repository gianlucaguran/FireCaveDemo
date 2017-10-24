using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CCamera : MonoBehaviour
{
    //States section
    public enum ECameraStates
    {
        eIdle,
        eFollow,
        eCinematic,
        eCameraStatesSize,
    }
    private ECameraStates eCurrentState;

    public ECameraStates ECurrentState
    {
        get
        {
            return eCurrentState;
        }

        set
        {
            eCurrentState = value;
        }
    }
    //

    //Singleton section 
    private static CCamera sm_cInstance;

    public static CCamera GetInstance()
    {
        return sm_cInstance;
    }

    private CCamera()
    { }
    //

    [SerializeField]
    private Transform m_trFollowedCharacter;
    [SerializeField]
    private Vector3 m_v3Offset;

    private Transform m_trSelf;

    //private Vector3 m_v3TargetPosition;
    

    // Use this for initialization
    void Start()
    {
        sm_cInstance = this;
        ECurrentState = ECameraStates.eFollow;

        m_trSelf = this.transform;
    }



    private void LateUpdate()
    {
        switch (ECurrentState)
        {
            case ECameraStates.eIdle:
                {

                }
                break;

            case ECameraStates.eFollow:
                {
                    m_trSelf.position = m_trFollowedCharacter.position + m_v3Offset;
                    m_trSelf.LookAt(m_trFollowedCharacter);
                }
                break;

            case ECameraStates.eCinematic:
                {

                }
                break;

            default:
                {
                    Assert.IsFalse(true, "You should not be here, check current state");
                }
                break;
        }
    }


}
