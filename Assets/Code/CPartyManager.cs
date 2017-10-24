using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
        Assert.raiseExceptions = true;

        m_listECurrentChars = new List<ECharacters>();
        m_listEReserveChars = new List<ECharacters>();
    }

    public void MoveFromReserveToParty(ECharacters eChar)
    {
        Assert.IsTrue(m_listEReserveChars.Contains(eChar));
        Assert.IsFalse(m_listECurrentChars.Contains(eChar));

        m_listEReserveChars.Remove(eChar);
        m_listECurrentChars.Add(eChar);
    }

    public void MoveFromPartyToReserve(ECharacters eChar)
    {
        Assert.IsTrue(m_listECurrentChars.Contains(eChar));
        Assert.IsFalse(m_listEReserveChars.Contains(eChar));

        m_listECurrentChars.Remove(eChar);
        m_listEReserveChars.Add(eChar);
    }


}
