using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image img;
    [SerializeField] [Range(0, 5)] float speed;

    public Color[] newColor;
    public Color blinkColor;

    float t = 0;
    int rndmIndex;
    void ChangeColorRndm()
    {
       
    }

    public void Update()
    {
        if (img != null)
        {
            img.color = Color.Lerp(img.color, newColor[rndmIndex], speed * Time.deltaTime);

            t = Mathf.Lerp(t, 1f, speed * Time.deltaTime);

            if (t > .9f)
            {
                t = 0;
                rndmIndex = Random.Range(0, newColor.Length);
            }

        }

    }

    public IEnumerator Blink()
    {
        float blinkTime = 1f;
        float t = 0;
       
        while (t < blinkTime)
        {

            img.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.1f);
            img.transform.localScale = new Vector3(1, 1, 1);
            t += 0.1f;
        }


        Destroy(img.gameObject);
        yield return null;
    }

    public void StartBlink()
    {
        StartCoroutine(Blink());
    }
}
