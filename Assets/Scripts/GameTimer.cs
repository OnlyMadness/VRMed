using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{

    public static bool stop;
    public static bool isDone;
    public static string result;
    public bool reverse;
    public enum TimerMode { minutes = 0, seconds = 1 };
    public TimerMode timerMode = TimerMode.minutes;
    public int startValue;
    public int endValue;
    public Text textOutput;
    public bool startAwake = true;
    private int min, sec;
    private string m, s;

    void Awake()
    {
        isDone = false;
        if (startAwake) stop = false; else stop = true;
        if (timerMode == TimerMode.minutes)
        {
            if (reverse) sec = 60;
            min = startValue;
        }
        else
        {
            sec = startValue;
        }
        if (!reverse)
        {
            if (endValue < startValue)
            {
                Debug.Log("Game Timer: В этом режиме, параметр 'End Value' не может быть меньше, чем 'Start Value'");
                stop = true;
            }
        }
        else
        {
            if (endValue > startValue)
            {
                Debug.Log("Game Timer: В этом режиме, параметр 'End Value' не может быть больше, чем 'Start Value'");
                stop = true;
            }
        }
    }

    void Start()
    {
        StartCoroutine(RepeatingFunction());
    }

    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            if (!stop && !isDone) TimeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void TimeCount()
    {
        if (reverse)
        {
            if (timerMode == TimerMode.minutes)
            {
                if (sec < 0)
                {
                    sec = 59;
                    min--;
                }
                if (min == endValue)
                {
                    isDone = true;
                }
            }
            else
            {
                if (sec == endValue)
                {
                    isDone = true;
                }
            }

            CurrentTime();

            sec--;
        }
        else
        {
            if (timerMode == TimerMode.minutes)
            {
                if (sec > 59)
                {
                    sec = 0;
                    min++;
                }
                if (min == endValue)
                {
                    isDone = true;
                }
            }
            else
            {
                if (sec == endValue)
                {
                    isDone = true;
                }
            }

            CurrentTime();

            sec++;
        }
    }

    void CurrentTime()
    {
        if (sec < 10) s = "0" + sec; else s = sec.ToString();
        if (min < 10) m = "0" + min; else m = min.ToString();
    }

    void OnGUI()
    {
        switch (timerMode)
        {
            case TimerMode.minutes:
                result = m;
                break;

            case TimerMode.seconds:
                result = s;
                break;
        }

        textOutput.text = result;
    }
}
