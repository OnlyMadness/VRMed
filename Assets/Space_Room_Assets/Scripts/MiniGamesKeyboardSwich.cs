using UnityEngine;

public class MiniGamesKeyboardSwich : MonoBehaviour {

    public GameObject[] MiniGames;
    public GameObject TerminalScreenSleepMode;
    public GameObject TerminalScreenForGames;
    public GameObject BackroundTests;

    void Update ()
    {
        if (GameControllerTestsMark.GradingActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = true;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[0].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = true;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[1].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = true;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[2].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (MiniGames[2].activeSelf == false)
                {
                    foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                        canvas.ResetPaint();
                }

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[3].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[4].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[5].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[6].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[7].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[8].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[9].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(false);
                TerminalScreenForGames.SetActive(true);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
                MiniGames[10].SetActive(true);

            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                foreach (var canvas in FindObjectsOfType<Es.InkPainter.InkCanvas>())
                    canvas.ResetPaint();

                foreach (var brush in FindObjectsOfType<Es.InkPainter.Sample.MousePainter>())
                    brush.CanDraw = false;

                TerminalScreenSleepMode.SetActive(true);
                TerminalScreenForGames.SetActive(false);

                foreach (GameObject _obj in MiniGames)
                {
                    _obj.SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Application.LoadLevel(1);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameControllerTestsMark.GradingActive = true;
                BackroundTests.SetActive(true);
            }
        }
    }
}
