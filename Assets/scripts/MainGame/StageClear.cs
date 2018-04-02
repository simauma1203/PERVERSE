using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{

    public GameObject gameobj;
    public GameObject text;
    public GameObject tweetbtn;
    public GameObject replay;
    public GameObject next;

    movetheballautomatic script;

    // Use this for initialization
    void Start()
    {
        script = gameobj.GetComponent<movetheballautomatic>();//scriptしゅとく
        text.SetActive(false);
        tweetbtn.SetActive(false);
        replay.SetActive(false);
        next.SetActive(false);

    }
    public void clear()
    {

        text.SetActive(true);
        tweetbtn.SetActive(true);
        replay.SetActive(true);

        if (CreateButton.sendStageNum != 0 && CreateButton.sendStageNum < 15)
            next.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {


    }
}
