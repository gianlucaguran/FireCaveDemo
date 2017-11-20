using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDialogueStruct
{
    [SerializeField]
    private string m_strText;
    [SerializeField]
    private string m_strCharacter;


    public CDialogueStruct ( string strText , string strName = null)
    {
        m_strText = strText;
        m_strCharacter = strName;
    }


    public string StrText
    {
        get
        {
            return m_strText;
        }

        set
        {
            m_strText = value;
        }
    }

    public string StrCharacter
    {
        get
        {
            return m_strCharacter;
        }

        set
        {
            m_strCharacter = value;
        }
    }
}
