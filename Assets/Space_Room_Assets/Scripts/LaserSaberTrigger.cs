using UnityEngine;
using System.Collections;

public class LaserSaberTrigger : MonoBehaviour {

    public Material _mat;
    private float i;
    private bool _stay;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            _stay = true;
            StartCoroutine(MaterialFade(true));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            _stay = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            _stay = false;
            StartCoroutine(MaterialFade(false));
        }
    }

    IEnumerator MaterialFade(bool fade)
    {
        yield return new WaitForSeconds(0.1f);

        if (_stay) yield break;

        if (fade)
        {
            if (i < 0.5f) i = 0.0f;
            else i = 1.0f;

            while (i > 0.0f)
            {
                yield return new WaitForEndOfFrame();
                i -= 0.075f;
                _mat.SetFloat("_DistortionBlend", Mathf.Clamp(i, 0.0f, 1.0f));
            }
        }

        else
        {
            if (i > 0.5f) i = 1.0f;
            else i = 0.0f;

            while (i < 1.0f)
            {
                yield return new WaitForEndOfFrame();
                i += 0.075f;
                _mat.SetFloat("_DistortionBlend", Mathf.Clamp(i, 0.0f, 1.0f));
            }
        }
    }
}
