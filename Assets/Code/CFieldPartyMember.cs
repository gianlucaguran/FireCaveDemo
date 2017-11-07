using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFieldPartyMember : MonoBehaviour
{
    //Delegate section 
    //delegate definition
    private delegate void fdStateFunction();
    //delegate arrays
    private fdStateFunction[] m_afdUpdates;
    private fdStateFunction[] m_afdEnterstates;
    private fdStateFunction[] m_afdExitstates;

    //states section 
    //States definition
    enum EMovingStates
    {
        eIdle,
        eMove,
        eInteract,
        eMovingStatesSize,
    }

    //current state var
    private EMovingStates eCurrState;
    //current state getter / setter
    private EMovingStates ECurrState
    {
        get
        {
            return eCurrState;
        }

        set   //will call respective delegate for state switch
        {
            if (null != m_afdExitstates[(int)eCurrState])
            {
                m_afdExitstates[(int)eCurrState]();
            }

            eCurrState = value;

            if (null != m_afdEnterstates[(int)eCurrState])
            {
                m_afdEnterstates[(int)eCurrState]();
            }
        }
    }

    //Movement vars
    [SerializeField]
    private float m_fSpeed;
    private Vector3 m_v3Movement;
    private Rigidbody m_rbOwnBody;
    private Transform m_trOwnTransform;



    // Use this for initialization
    void Start()
    {
        eCurrState = EMovingStates.eIdle;

        m_v3Movement = Vector3.zero;

        m_rbOwnBody = this.GetComponent<Rigidbody>();

        m_trOwnTransform = this.GetComponent<Transform>();

        SetUpStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        if (null != m_afdUpdates[(int)eCurrState])
        {
            m_afdUpdates[(int)eCurrState]();
        }
    }

    private void SetUpStateMachine()
    {
        m_afdEnterstates = new fdStateFunction[(int) EMovingStates.eMovingStatesSize];
        m_afdUpdates = new fdStateFunction[(int)EMovingStates.eMovingStatesSize];
        m_afdExitstates = new fdStateFunction[(int)EMovingStates.eMovingStatesSize];

        for (int iLoop = 0; iLoop < (int)EMovingStates.eMovingStatesSize; iLoop++)
        {
            m_afdEnterstates[iLoop] = null;
            m_afdUpdates[iLoop] = null;
            m_afdExitstates[iLoop] = null;
        }

        m_afdUpdates[(int)EMovingStates.eIdle] += HandleInput;
        m_afdUpdates[(int)EMovingStates.eIdle] += UpdateIdle;

        m_afdUpdates[(int)EMovingStates.eMove] += HandleInput;
        m_afdUpdates[(int)EMovingStates.eMove] += UpdateMove;
    }


    private void HandleInput()
    {
        m_v3Movement = Vector3.zero;

        if ( Input.GetKey(KeyCode.W))
        {
            m_v3Movement += Camera.main.transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_v3Movement -= Camera.main.transform.forward;
        }

        if ( Input.GetKey(KeyCode.A))
        {
            m_v3Movement -= Camera.main.transform.right;
        }
        else  if (Input.GetKey(KeyCode.D))
        {
            m_v3Movement += Camera.main.transform.right;
        }

        m_v3Movement.Normalize();
    }

    //Move character if m_v3Movement is big enough
    private void Move()
    {
        if (0.001f > m_v3Movement.sqrMagnitude)
        {
            m_rbOwnBody.velocity = Vector3.zero;
            return;
        }

        Vector3 v3Up = m_trOwnTransform.up;
        Vector3.OrthoNormalize( ref v3Up, ref m_v3Movement);

       
       
        m_rbOwnBody.velocity = m_v3Movement * m_fSpeed;
        Debug.Log("Executing rotation");

    }

    //Update for idle state 
    //Changes to movement if movement vector is not 0
    void UpdateIdle()
    {
        if ( Vector3.zero != m_v3Movement)
        {
            ECurrState = EMovingStates.eMove;
        }
    }

    //Update for move state
    //Becomes idle is movement vector is small enough
    void UpdateMove()
    {
        if (Vector3.zero == m_v3Movement)
        {
            ECurrState = EMovingStates.eIdle;
        }

        Move();
    }
}
