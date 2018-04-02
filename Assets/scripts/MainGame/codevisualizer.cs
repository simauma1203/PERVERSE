﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codevisualizer : MonoBehaviour
{
    public static string strcode;
    public GameObject movetheball;
    public int width;
	public  movetheballautomatic script;
    private static List<char> rokujuuyonnlist = new List<char>(){//256進数！！
   'Σ','Τ','Υ','Φ','Χ','Ψ','Ω','α','β','γ','δ','ε','ζ','η','θ','ι','κ','λ','μ','ν','ξ','ο','π','ρ','σ','τ','υ','φ','χ','ψ','ω', '0','≠',
        '≦','≧','＜','＞','≪','≫','∞','∽','∝','∴','∵','∈','∋','⊆','⊇','⊂','⊃','∪','∩','∧','∨','￢',
        '⇒','⇔','∀','∃','∠','⊥','⌒','∂','∇','≡','√','∫','∬','─','│','┌','┐','┘','└','├','┬','┤',
        '┴','┼','━','┃','┏','┓','┛','┗','┣','┳','┫','┻','╋','┠','┯','┨','┷','┿','┝','┰','┥','┸',
        '╂','＃','＆','＊','＠','§','※','〓','♯','♭','♪','†','‡','¶','仝','々','〆','ー','～','￣','＿','―','‐','∥',
        '｜','／','＼' ,'1', '2', '3', '4', '5', '6', '7', '8', '9','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j','k', 'l', 'm', 'n'
        , 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N','O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X','Y', 'Z', '+', '/',
        'Α','Β','Γ','Δ','Ε','Ζ','Η','Θ','Ι','Κ','Λ','Μ','Ν','Ξ','Ο','Π','Ρ','А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й',
        'К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я','а','б','в','г','д','е'
        ,'ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',
        '＋','－','±','×','÷','＝','≒'
	};

	void Start(){
		Debug.Log ("beatbeat!");
		Debug.Log (codevisualizer.strcode);
	}

    int goalx, goaly;
    public static string Base256tobinary(string base256)
    {	
		//Debug.Log ("beatbeat");
		//Debug.Log (codevisualizer.strcode);
		
        string binaryNum = "";

        for (int i = 0; i < base256.Length; i++)
        {
            for (int listNo = 0; listNo < rokujuuyonnlist.Count; listNo++)
            {
                if (base256[i] == rokujuuyonnlist[listNo])
                {
                    binaryNum += System.Convert.ToString(listNo, 2).PadLeft(8, '0');
                    break;
                }
            }
        }
        return binaryNum;
    }
    public void goalcount(char point)
    {
        for (int i = 0; i < rokujuuyonnlist.Count; i++)
        {
            if (point == rokujuuyonnlist[i])
            {
                goalx = i % 13;
                goaly = i / 13;
                goalx = goalx * 2 + 1;
                goaly = goaly * 2 + 1;

            }
        }
    }

    int[,] map = new int[50, 50];
    public int[,] Lockoff()
    {
        strcode = MainStages.mapCode[CreateButton.sendStageNum];
        string level = strcode.Substring(0, 1);
        if (level == "1")
        {
            width = 10;
            script.nannido = int.Parse(level);
            script.startdownintx = 3;
            script.startdowninty = 5;
            script.startupintx = 7;
            script.startupinty = 5;
            script.nowdownx = 3;
            script.nowdowny = 5;
            script.nowupx = 7;
            script.nowupy = 5;
        }
        if (level == "2")
        {
            width = 16;
            script.nannido = int.Parse(level);
            script.startdownintx = 7;
            script.startdowninty = 9;
            script.startupintx = 9;
            script.startupinty = 7;
            script.nowdownx = 7;
            script.nowdowny = 9;
            script.nowupx = 9;
            script.nowupy = 7;
        }
        if (level == "3")
        {
            width = 24;
            script.nannido = int.Parse(level);
            script.startdownintx = 11;
            script.startdowninty = 13;
            script.startupintx = 13;
            script.startupinty = 11;
            script.nowdownx = 11;
            script.nowdowny = 13;
            script.nowupx = 13;
            script.nowupy = 11;
        }
        for (int i = 0; i < width + 1; i++)
        {
            map[i, 0] = 1; map[0, i] = 1; map[width, i] = 1; map[i, width] = 1;
        }

        int sharp = strcode.IndexOf("#");
        string mapcode = strcode.Substring(1, sharp - 1);
        string binarimapcode = Base256tobinary(mapcode);
        Debug.Log(binarimapcode);
        int count = 0;
        Debug.Log(map[0, 0]);
        for (int i = 1; i < width; i++)
        {
            for (int j = 1; j < width; j++)
            {
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        map[i, j] = (int)binarimapcode[count] - (int)'0'; count++;
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        map[i, j] = (int)binarimapcode[count] - (int)'0'; count++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        Debug.Log(count);
        Debug.Log(binarimapcode.Length);
        for (int i = 1; i < width; i++)
        {
            for (int j = 1; j < width; j++)
            {
                if (map[i, j] == 1)
                {
                    if (i % 2 == 1 && j % 2 == 0)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            map[i - 1 + z, j] = 1;
                        }
                    }
                    else if (i % 2 == 0 && j % 2 == 1)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            map[i, j - 1 + z] = 1;
                        }
                    }
                }
            }
        }
        string goal = strcode.Substring(sharp + 1, 2);
        bool hogeflag = true;
        for (int i = 0; i < 2; i++)
        {
            goalcount(goal[i]);
            map[goaly, goalx] = 2;
            if (hogeflag)
            {
                hogeflag = false;
                script.goaldownx = goalx;
                script.goaldowny = goaly;
            }
            else
            {
                script.goalupx = goalx;
                script.goalupy = goaly;
            }
        }
        string shougaibutuCode = strcode.Remove(0, 1 + mapcode.Length + 1 + 2);
        int len = shougaibutuCode.Length;
        for (int i = 0; i < len; i++)
        {
            goalcount(shougaibutuCode[i]);
            map[goaly, goalx] = 3;
        }
        Debug.Log(map[0, 0]);
        Debug.Log("  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7");
        for (int i = 1; i < 17; i++)
        {
            string a = ""; a += i.ToString(); a += " ";
            for (int j = 1; j < 17; j++)
            {
                a += map[i, j];
                a += " ";
            }
            Debug.Log(a);
        }
        return map;
    }
}
