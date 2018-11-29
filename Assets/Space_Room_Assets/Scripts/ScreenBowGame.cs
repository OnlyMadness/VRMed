using System.Collections;
using UnityEngine;

public class ScreenBowGame : MonoBehaviour
{
    public GameObject[] LivesCount;
    public GameObject[] StarsCount;
    public GameObject Lose;
    public GameObject Win;

    public Texture LiveY;
    public Texture LiveN;
    public Texture HitY;
    public Texture HitN;

    public int Lives;
    public int Hits;

    public float SecondsForRestart = 5.0f;

    private void Restart()
    {
        Lives = 5;
        Hits = 0;

        foreach (GameObject goL in LivesCount)
            goL.GetComponent<MeshRenderer>().material.mainTexture = LiveY;
        foreach (GameObject goS in StarsCount)
            goS.GetComponent<MeshRenderer>().material.mainTexture = HitN;
        Lose.SetActive(false);
        Win.SetActive(false);
    }

    public void ShootMiss()
    {
        Debug.Log("ShootMiss");
        if (Lives != 0)
        {
            LivesCount[Lives - 1].GetComponent<MeshRenderer>().material.mainTexture = LiveN;
            Lives--;
        }
        if (Lives == 0)
        {

            Lose.SetActive(true);
            StartCoroutine(RestartGame());
        }
    }

    public void ShootHit()
    {
        Debug.Log("ShootHit");
        if (Hits != 5)
        {
            StarsCount[Hits].GetComponent<MeshRenderer>().material.mainTexture = HitY;
            Hits++;
        }
        if (Hits == 5)
        {
            Win.SetActive(true);
            StartCoroutine(RestartGame());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            ShootMiss();
            other.gameObject.tag = "Untagged";
        }
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(SecondsForRestart);
        Restart();
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    public void OnEnable()
    {
        Restart();
    }
}