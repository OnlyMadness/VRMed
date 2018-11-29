using UnityEngine;
using System.Collections;

public class MiniGames_Game6_Controller : MonoBehaviour {

    public bool Started;
    public AudioSource _audio;
    public int _counter;
    public GameObject Stats_Manager;

    private void OnEnable()
    {
        Started = false;
        _counter = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            transform.localScale = new Vector3(0.012f, 0.012f, 0.012f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);

            if (!Started)
            {
                _audio.Play();
                Started = true;
            }
            else _counter += 1;

            StartCoroutine(ResetCollider());
        }
    }


    private IEnumerator ResetCollider()
    {
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(0.25f);

        GetComponent<Collider>().enabled = true;
    }


    private void OnDisable()
    {
        _audio.Stop();

        if (_counter == 10 || _counter == 11 || _counter == 12)
        {
            Stats_Manager.GetComponent<MiniGamesStats>().MiniGames_Stats[5] = 1.0f;
        }
    }
}
