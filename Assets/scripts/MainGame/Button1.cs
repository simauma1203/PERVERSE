using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour
{
    //かえた！

    public GameObject gameobj;
    public GameObject pause;
    public GameObject restart;
    public GameObject quit;
    public GameObject Resume;
    GameObject timee;
    public bool automaticmode = true;
    movetheballautomatic script;
    timelimitandmemory timescript;

	public AudioClip sound1;
	public AudioClip sound2;
	AudioSource audioSource;

    public void pausebottun()
    {
		audioSource.clip = sound1;
		audioSource.Play ();
        if (automaticmode)
        {
            timee = GameObject.Find("timecounter");
            timescript = timee.GetComponent<timelimitandmemory>();
            if (!timescript.gameoverflag)
            {
                script.pauseflag = true;
            }
        }
        else
        {
            if (!script.clearflag)
            {
                script.pauseflag = true;
            }
        }
    }
    public void restartbutton()
    {
		audioSource.clip = sound2;
		audioSource.Play ();
        script.restartflag = true;
        script.pauseflag = false;
    }
    public void next()
    {
        if (CreateButton.sendStageNum != 0 && CreateButton.sendStageNum <15)
        {
            CreateButton.sendStageNum++;
            int stgNum = CreateButton.sendStageNum;
            Destroy(GameObject.Find("timecounter"));
            if (stgNum <= 5)
            {
                SceneManager.LoadScene("maineasy");
            }
            else if (stgNum <= 10)
            {
                SceneManager.LoadScene("mainnormal");
            }
            else if (stgNum <= 15)
            {
                SceneManager.LoadScene("mainhard");
            }
        }
    }
    public void restartgameover()//オートマティックモードのときのみ
    {
		audioSource.clip = sound2;
		audioSource.Play ();
        timee = GameObject.Find("timecounter");
        script.clearflag = false;
        timescript = timee.GetComponent<timelimitandmemory>();
        timescript.pauseorquitflag = true;
    }
    public void quitbutton()
    {
		audioSource.clip = sound2;
		audioSource.Play ();
        if (automaticmode)
        {
            timee = GameObject.Find("timecounter");
            Destroy(timee);
        }
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "maineasy" || sceneName == "mainnormal" || sceneName == "mainhard") {
            Debug.Log(CreateButton.sendStageNum);
            if (CreateButton.sendStageNum <= 15)
            {
                GameObject.Destroy(GameObject.Find("timecounter")); Debug.Log("destroy");
                SceneManager.LoadScene("StageSelect");
            }
            else
            {
                GameObject.Destroy(GameObject.Find("timecounter")); Debug.Log("destroy");
                SceneManager.LoadScene("Title");
            }
		} else {
			SceneManager.LoadScene ("Title");
		}
    }
    public void Resumesuru()
    {
		audioSource.clip = sound1;
		audioSource.Play ();
        script.pauseflag = false;
    }

    // Use this for initialization
    void Start()
    {
        script = gameobj.GetComponent<movetheballautomatic>();
		audioSource = this.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.pauseflag == false)
        {
            restart.SetActive(false);
            quit.SetActive(false);
            pause.SetActive(true);
            Resume.SetActive(false);
        }
        else
        {
            restart.SetActive(true);
            quit.SetActive(true);
            pause.SetActive(false);
            Resume.SetActive(true);
        }

    }

}
