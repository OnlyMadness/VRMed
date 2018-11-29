using UnityEngine;

public class MiniGames_Game1_Controller : MonoBehaviour {

    public Collider[] PointsCollider;
    public GameObject Stats_Manager;

    private void OnEnable()
    {
        foreach (Collider _col in PointsCollider)
        {
            _col.enabled = false;
        }
        PointsCollider[0].enabled = true;
    }

    private void OnDisable()
    {
        if (PointsCollider[PointsCollider.Length - 1].enabled && Stats_Manager)
            Stats_Manager.GetComponent<MiniGamesStats>().MiniGames_Stats[0] = 1.0f;

        foreach (Collider _col in PointsCollider)
        {
            _col.enabled = false;
        }
    }
}
