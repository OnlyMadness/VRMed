using System.Collections;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    public Texture2D[] slides;
    public float timeInterval = 1f;
    public Renderer targetRenderer;
    public Transform TerminalTarget1;
    public Transform TerminalTarget2;

    private int currentSlide = 0;


    private void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        StartCoroutine(ChangeSlides());
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = TerminalTarget1.position;
            transform.localEulerAngles = TerminalTarget1.transform.localEulerAngles;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = TerminalTarget2.position;
            transform.localEulerAngles = TerminalTarget2.transform.localEulerAngles;
        }
    }


    IEnumerator ChangeSlides()
    {
        if (slides == null || slides.Length == 0)
        {
            yield return null;
        }
        else
        {
            if (currentSlide == slides.Length - 1)
                currentSlide = 0;
            else
                currentSlide++;

            targetRenderer.material.SetTexture("_MainTex", slides[currentSlide]);
            targetRenderer.material.SetTexture("_EmissionMap", slides[currentSlide]);

            yield return new WaitForSeconds(timeInterval);

            StartCoroutine(ChangeSlides());
        }
    }
}