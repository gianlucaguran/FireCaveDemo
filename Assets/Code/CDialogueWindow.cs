using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//Class used to implement dialogue windows
//Uses singleton to have unique handling of dialogues
public class CDialogueWindow : MonoBehaviour
{
    private Image m_internalImage;
    private Text m_internalText;

    [SerializeField]
    private Queue<CDialogueStruct> m_listDialoguesQueue;

    private bool m_bShowing;

    //Singleton things
    private static CDialogueWindow ms_cInstance;

    public static CDialogueWindow GetInstance()
    {
        return ms_cInstance;
    }

    private CDialogueWindow()
    { }

    // Use this for initialization
    private void Start()
    {

        Assert.raiseExceptions = true;
        Assert.AreEqual(null, ms_cInstance, "Singleton initialized more times!");

        ms_cInstance = this;

        m_internalImage = this.GetComponent<Image>();
        m_internalText = this.transform.GetChild(0).GetComponent<Text>();

        m_internalText.text = "";
        this.gameObject.SetActive(false);

        m_listDialoguesQueue = new Queue<CDialogueStruct>();
        m_bShowing = false;
    }

    //end of singleton things


  private void ShowDialogue(CDialogueStruct cDStruct)
    {
        m_bShowing = true;

        GetInstance().gameObject.SetActive(true);

        Text ownText = GetInstance().m_internalText;

        ownText.text = "";

        if (null != cDStruct.StrCharacter)
        {
            ownText.text += cDStruct.StrCharacter + "\n";
        }

        ownText.text += "\"" + cDStruct.StrText + "\"";
    }

    public static void QueueMessage (CDialogueStruct cDStruct)
    {
        GetInstance().m_listDialoguesQueue.Enqueue(cDStruct);
    }

    private void Update()
    {
        if ( 0 != m_listDialoguesQueue.Count && !m_bShowing )
        {
            ShowDialogue(m_listDialoguesQueue.Dequeue());
        }
        else
        {

        }
    }

    public static bool IsShowing()
    {
        return GetInstance().m_bShowing;
    }

    // TODO : Check bool logic about showing.
}
