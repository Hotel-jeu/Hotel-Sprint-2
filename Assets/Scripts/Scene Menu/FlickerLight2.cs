using System.Collections;
using UnityEngine;

public class FlickerLight2 : MonoBehaviour
{
    Light lumiere;

    void Start()
    {
        lumiere = GetComponent<Light>();
        StartCoroutine(ClignotementLumiere());
    }

    IEnumerator ClignotementLumiere()
    {
        while (true)
        {
            // Example of a flicker pattern
            yield return StartCoroutine(UnClignotement(2f, 1.5f, 1f));  
            yield return new WaitForSeconds(3f); 
            yield return StartCoroutine(UnClignotement(1.5f, 0.5f, 0.25f)); 
            yield return new WaitForSeconds(0.2f);
            yield return StartCoroutine(UnClignotement(0.5f, 1.5f, 0.25f)); 
            yield return new WaitForSeconds(0.2f);
            yield return StartCoroutine(UnClignotement(1.5f, 0.2f, 1f));
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(0.2f, 1f, 0.1f)); 
            yield return new WaitForSeconds(0.12f);
            yield return StartCoroutine(UnClignotement(1f, 0.05f, 0.5f)); 
            yield return new WaitForSeconds(0.6f);
            yield return StartCoroutine(UnClignotement(0.05f, 1.5f, 3f));
            yield return new WaitForSeconds(7f);
            yield return StartCoroutine(UnClignotement(1.5f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.7f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.7f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.7f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.7f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.7f, 0.3f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 0.7f, 0.15f));
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(UnClignotement(0.3f, 2f, 3f));
            yield return new WaitForSeconds(5f);





        }
    }

    IEnumerator UnClignotement(float intensiteDebut, float intensiteFin, float duree)
    {
        float tempsPasser = 0f;
        while (tempsPasser < duree)
        {
            tempsPasser += Time.deltaTime;
            lumiere.intensity = Mathf.Lerp(intensiteDebut, intensiteFin, tempsPasser / duree);
            yield return null;
        }
        lumiere.intensity = intensiteFin;
    }
}
