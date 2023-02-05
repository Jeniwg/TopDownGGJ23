using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private float introTime;
    [SerializeField]
    private AudioSource loopPart;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine("AudioLoopSetter");
        }
        
    }

    public void StartSound()
    {
        GetComponentInParent<AudioSource>().Play();
        StartCoroutine("AudioLoopSetter");
    }

    public void Stopsound()
    {
        GetComponentInParent<AudioSource>().enabled = false;
        loopPart.enabled = false;
    }

    private IEnumerator AudioLoopSetter()
    {
        yield return new WaitForSeconds(introTime);
        loopPart.Play();
    }
}
