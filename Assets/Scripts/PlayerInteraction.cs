using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private Text itemText;

    //bools
    private bool havePacifier = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY");
        }

        if (col.CompareTag("Memory"))
        {
            string name = col.GetComponent<Memory>().memoryName;
            switch (name)
            {
                case "Pacifier":
                    if (!havePacifier)
                    {
                        havePacifier = true;
                        StartCoroutine(textDelay("PACIFIER!", itemText));
                        Debug.Log("PACIFIER");
                    }
                    break;
            }

        }
    }

    private IEnumerator textDelay(string newText, Text target)
    {
        target.text = newText;
        yield return new WaitForSeconds(3f);
        target.text = "";
    }
}
