using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestDebugClass : MonoBehaviour
{
    public Transform trPos;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = trPos.position;
    }


}
