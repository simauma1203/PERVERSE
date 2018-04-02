using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Inputcode : MonoBehaviour
{
    static string text;
    InputField inputfield;

    public void codeinput()
    {
        inputfield = GetComponent<InputField>();
        text = inputfield.text;

        int first, second;
        first = text.IndexOf("【");
        second = text.IndexOf("】");
        string code;
        if (first == -1) { code = text; }
        else { code = text.Substring(first + 1, second - first - 1); }
        MainStages.mapCode[16] = code;
        CreateButton.sendStageNum = 16;
        codevisualizer.strcode = code;
        if (code[0] == '1')
        {
            SceneManager.LoadScene("maineasy");
        }
        if (code[0] == '2')
        {
            SceneManager.LoadScene("mainnormal");
        }
        if (code[0] == '3')
        {
            SceneManager.LoadScene("mainhard");
        }
    }
}
