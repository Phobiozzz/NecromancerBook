using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip click, ambient, cardPicking, cardDropping, rigthCardSignal, wrongCardSignal, bubbles, chains, pnevmo, secondAmbient;
    public AudioSource source1;
    public AudioSource Noisesource1;
    public AudioSource pnevmosource;
    public AudioSource source2;
    public AudioSource bubblesSource;
    public GameObject manager;
    public float speed;
    private void Start()
    {
        manager = this.gameObject;
        source1.clip = ambient;
        Noisesource1.clip = secondAmbient;
        source2.clip = click;
        bubblesSource.clip = bubbles;
        bubblesSource.pitch = 0.9f;
        pnevmosource.clip = pnevmo;
        source1.PlayDelayed(1f);
        Noisesource1.PlayDelayed(7f);
        Coroutine coroutine = StartCoroutine(FadeOut(speed));
        DontDestroyOnLoad(manager);
        StartCoroutine("PnevmoSound");
    }

    public void Click()
    {
        source2.clip = click;
        source2.Play();
        
    }

    public void CardPick()
    {
        source2.clip = cardPicking;
        source2.Play();
    }

    public void CardDrop()
    {
        source2.clip = cardDropping;
        source2.Play();
    }

    public void CardSignal(bool _isRigthCard)
    {
        
        if (_isRigthCard)
        {
            source2.clip = rigthCardSignal;
            source2.Play();
        }
        else if (!_isRigthCard)
        {
            source2.clip = wrongCardSignal;
            source2.Play();
        }
    }

    public void Bubbles()
    {

        bubblesSource.Play();
    }

    public void Chains()
    {
        source2.clip = chains;
        if (source2.isPlaying == false)
        {
            source2.Play();
        } 
    }

    private void Update()
    {
       
    }

    public IEnumerator FadeOut(float _speed)
    {
        source1.volume = 0;

        while(source1.volume < 0.5f)
        {
            yield return new WaitForSeconds(_speed);
            source1.volume += 0.03f;
            //Debug.Log("Volume of track is " + source1.volume);
        }
        
        yield return null;
        
    }


    public IEnumerator PnevmoSound()
    {
        int rndmTime = Random.Range(5, 30);
        pnevmosource.Play();
        WaitForSeconds wait = new WaitForSeconds(rndmTime);
        yield return wait;
        StartCoroutine("PnevmoSound");
       
    }
    
}
