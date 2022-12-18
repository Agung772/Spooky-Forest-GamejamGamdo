using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class OpeningManager : MonoBehaviour
{
    public string text1, text2, text3, text4, text5;
    public GameObject logo;
    public TextMeshProUGUI textUI;

    private IEnumerator Start()
    {
        textUI.gameObject.SetActive(false);
        logo.SetActive(true);

        yield return new WaitForSeconds(6);
        textUI.gameObject.SetActive(true);
        logo.SetActive(false);
        textUI.text = text1 + Environment.NewLine + text2;

        yield return new WaitForSeconds(3);
        textUI.text = text3 + Environment.NewLine + text4 + Environment.NewLine + text5;

        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(5);
        /*
        if (text1 != "")
        {
            yield return new WaitForSeconds(6);
            textUI.gameObject.SetActive(true);
            logo.SetActive(false);
            textUI.text = text1 + Environment.NewLine + text2;
            if (text2 != "")
            {
                yield return new WaitForSeconds(2);
                
                textUI.text = text2;
                if (text3 != "")
                {
                    yield return new WaitForSeconds(3);
                    textUI.text = text3;
                    if (text4 != "")
                    {
                        yield return new WaitForSeconds(3);
                        textUI.text = text4;
                        if (text5 != "")
                        {
                            yield return new WaitForSeconds(3);
                            textUI.text = text5;
                            yield return new WaitForSeconds(3);
                            SceneManager.LoadScene(5);
                        }
                    }
                }
            }

        }
        */

    }
}
