using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CDialogueWindow.QueueMessage(new CDialogueStruct("Hi! I'm a test text. \n How do you like me? ", "Some PG"));
        }
    }
}
