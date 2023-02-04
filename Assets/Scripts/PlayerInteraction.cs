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

    //bools
    private bool haveLocket = false;
    private bool haveLetter = false;
    private bool haveRing = false;
    private bool haveScar = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY");
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
                        Debug.Log("PACIFIER");
                    }
                    break;

                case "Letter":
                    if (!haveLetter)
                    {
                        haveLetter = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                        Debug.Log("PACIFIER");
                    }
                    break;

                    case "Scar":
                    if (!haveScar)
                    {
                        haveScar = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                        Debug.Log("PACIFIER");
                    }
                    break;

                    case "Ring":
                    if (!haveRing)
                    {
                        haveRing = true;
                        StartCoroutine(textDelay(var.Phrase, itemText, var.Found, var.Icon));
                        Debug.Log("PACIFIER");
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
