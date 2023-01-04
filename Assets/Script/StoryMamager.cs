using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryMamager : MonoBehaviour
{
    public string text1, text2, text3, text4, text5;
    public TextMeshProUGUI textUI;

    private IEnumerator Start()
    {
        textUI.text = text1;
        if (text2 != "")
        {
            yield return new WaitForSeconds(10);
            textUI.text = text2;
            if (text3 != "")
            {
                yield return new WaitForSeconds(10);
                textUI.text = text3;
                if (text4 != "")
                {
                    yield return new WaitForSeconds(10);
                    textUI.text = text4;
                    if (text5 != "")
                    {
                        yield return new WaitForSeconds(8);
                        textUI.text = text5;
                        yield return new WaitForSeconds(10);
                        SceneManager.LoadScene(1);
                    }
                }
            }

        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SceneSawah");
        }
    }
}
