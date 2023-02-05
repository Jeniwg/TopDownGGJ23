using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private Text itemText;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Audio m1;
    [SerializeField]
    private Audio m2;
    [SerializeField]
    private Audio m3;
    

    //bools
    private bool haveLocket = false;
    private bool haveLetter = false;
    private bool haveRing = false;
    private bool haveScar = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Music1"))
        {
            m1.StartSound();
        }

        if(col.CompareTag("Music2"))
        {
            m1.Stopsound();
            m2.StartSound();
        }
        if(col.CompareTag("Music3"))
        {
            m2.Stopsound();
            m3.StartSound();
        }

        if(col.CompareTag("FInal"))
        {
            SceneM bruh = new SceneM();
            bruh.LoadScene(0);
        }

        if (col.CompareTag("Memory"))
        {
            Memory var = col.GetComponent<Memory>();
            string name = var.MemoryName;
            switch (name)
            {
                case "Locket":
                    if (!haveLocket)
                    {
                        haveLocket = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                    }
                    break;

                case "Letter":
                    if (!haveLetter)
                    {
                        haveLetter = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                    }
                    break;

                    case "Scar":
                    if (!haveScar)
                    {
                        haveScar = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                    }
                    break;

                    case "Ring":
                    if (!haveRing)
                    {
                        haveRing = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                    }
                    break;
            }

        }
    }

    private IEnumerator textDelay(string newText, Text target, string found, Sprite icon)
    {
        target.text = newText;

        yield return new WaitForSeconds(6f);
        target.text = found;
        image.sprite = icon;
        image.enabled = true;

        yield return new WaitForSeconds(3f);

        image.enabled = false;
        target.text = "";
    }
}
