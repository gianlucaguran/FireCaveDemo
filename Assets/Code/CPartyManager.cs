using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPartyManager : MonoBehaviour
{
    public enum ECharacters
    {
        eSquall,
        eQuistis,
        eZell,
        eSelphie,
        eIrvine,
        eRinoa,
        eEdea,
        eCharactersSize,
    }

    public List<ECharacters> m_listECurrentChars;
    public List<ECharacters> m_listEReserveChars;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
