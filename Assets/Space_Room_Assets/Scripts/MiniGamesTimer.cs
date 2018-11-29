using UnityEngine;

public class MiniGamesTimer : MonoBehaviour {

    public float totalTime;
    private float _timeUpdate;
    public TextMesh timer;
    public bool StartTimer;

    private void Start()
    {
        if (!timer) timer = GetComponent<TextMesh>();
    }

    private void OnEnable()
    {
        StartTimer = false;
        timer.text = "01:00";
    }

    private void OnDisable()
    {
        StartTimer = false;
        timer.text = "01:00";
    }

    private void Update()
    {
        if (!StartTimer) _timeUpdate = totalTime;
        else
        {
            _timeUpdate -= Time.deltaTime;
            UpdateLevelTimer(_timeUpdate);
        }
    }

    public void UpdateLevelTimer(float AllSeconds)
    {
        int minutes = Mathf.FloorToInt(AllSeconds / 60f);
        int seconds = Mathf.RoundToInt(AllSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds < 0) seconds = 0;
        if (minutes < 0) minutes = 0;

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
