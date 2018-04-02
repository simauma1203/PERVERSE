﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageClear1 : MonoBehaviour {

	public GameObject gameobj;
	public GameObject text;
	public GameObject tweetbtn;
	public GameObject replay;
	public GameObject next;
    public bool maingame;
	movetheballautomatic script;

	// Use this for initialization
	void Start () {
		script = gameobj.GetComponent<movetheballautomatic>();//scriptしゅとく
		text.SetActive(false);
		tweetbtn.SetActive(false);
		replay.SetActive(false);
		next.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        if (maingame)
        {
            if (script.clearflag == true)
            {
                text.SetActive(true);
                tweetbtn.SetActive(true);
                replay.SetActive(true);
                next.SetActive(true);

            }
        }
        else
        {
            if (script.gameoverflag == true)
            {
                text.SetActive(true);
                tweetbtn.SetActive(true);
                replay.SetActive(true);
                next.SetActive(true);
            }
        }
	}
}
