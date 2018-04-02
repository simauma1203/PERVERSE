using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialSystem : MonoBehaviour {

	public GameObject me;
	public GameObject text;
	public GameObject text2;
	public GameObject acc;
	public GameObject touch;
	public int step=0;
	public int stepCount=0;	
	public int touchInfo;
	public int accInfo;

	public static int wantAcc=- 999;
    void Awake()
    {
        CreateButton.sendStageNum = 0;
    }
	// Use this for initialization
	void Start () {
		Config.ctrlCfg = true;
	}
	//2    1     0    1    2
	//うえ、みぎ、した、みぎ、うえ
	// Update is called once per frame
	void Update () {
		touchInfo= touch.GetComponent<touch> ().GetTouch() ;
		accInfo = acc.GetComponent<GetAcc> ().getDirection() ;
		switch (step) {
		case 0:
			if(stepCount==1)messege ("チュートリアルをはじめます", "");
			if(stepCount==60)messege("チュートリアルをはじめます", "画面をタップしてください");
			if (touchInfo == -1 && stepCount>70) {
				stepStep();
			}
			break;
		case 1:
			if (stepCount == 1) {
				messege ("画面をフリックしてキューブをうごかせます", "");
			}
			if (touchInfo == -1 && stepCount > 20) {
				stepStep ();
			}
			break;
		case 2:
			if (stepCount == 1) {
				messege ("ゴールは赤い球です", "");
			}
			if (stepCount == 40) {
				messege ("ゴールは赤い球です", "二つのキューブがゴールに着けばクリアです");
			}
			if (touchInfo == -1 && stepCount > 60) {
				stepStep ();
			}
			break;
		case 3:
			if (stepCount == 1) {
				messege ("画面を上にフリックしてみよう", "");
				wantAcc = 2;
			}
			if (accInfo == wantAcc && stepCount>20) {
				stepStep();
			}
			break;
		case 4:
			if (stepCount == 1) {
				messege ("右にフリックしてみよう", "");
				wantAcc = 1;
			}
			if (accInfo == wantAcc && stepCount>20) {
				stepStep();
			}
			break;
		case 5:
			if (stepCount == 1) {
				messege ("このように緑色のキューブはフリックした方向に、", "");
			}
			if (stepCount == 90) {
				messege ("緑色のキューブはフリックした方向に、", "赤色のキューブはその逆の方向に動きます");
			}
			if (touchInfo == -1 && stepCount > 100) {
				stepStep ();
			}
			break;
		case 6:
			if (stepCount == 1) {
				messege ("それではゴールをめざしてみましょう", "");
			}
			if (touchInfo == -1 && stepCount > 20) {
				stepStep ();
			}
			break;
		case 7:
			if (stepCount == 1) {
				messege ("ゴールまでキューブをはこんでみよう", "");
			}
			if (stepCount == 40) {
				messege ("ゴールまでキューブをはこんでみよう", "下にフリックしてみよう");
				wantAcc = 0;
			}
			if (accInfo == wantAcc && stepCount>60) {
				stepStep();
			}
			break;
		case 8:
			if (stepCount == 1) {
				messege ("ゴールまでキューブをはこんでみよう", "");
			}
			if (stepCount == 40) {
				messege ("ゴールまでキューブをはこんでみよう", "右にかたむけてみよう");
				wantAcc = 1;
			}
			if (accInfo == wantAcc && stepCount>60) {
				stepStep();
			}
			break;
		case 9:
			if (stepCount == 1) {
				messege ("ゴールまでキューブをはこんでみよう", "");
			}
			if (stepCount == 40) {
				messege ("ゴールまでキューブをはこんでみよう", "上にフリックしてみよう");
				wantAcc = 2;
			}
			if (accInfo == wantAcc && stepCount > 60) {
				stepStep ();
			}
			break;
		default:
			messege ("","");
			break;
		}
		stepCount++;
		//if(clearCount!=-1)clearCount++;
	}


	void messege(string text_,string text2_){
		//text = text.GetComponent<Text> ();
		text.GetComponent<Text> ().text = text_;
		//text2 = text2.GetComponent<Text> ();
		text2.GetComponent<Text> ().text = text2_;
	}

	void stepStep(){
		step++;
		stepCount = 0;
	}
}
	
