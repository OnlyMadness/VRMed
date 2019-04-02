using UnityEngine;

public class MiniGames_Game7_Controller : MonoBehaviour {

    public TextMesh _question;
    public TextMesh _answer;
    public TextMesh _finish;

    public int minRange;
    public int maxRange;

   // public int FirstNumber;

    public int SecondNumberMin;
    public int SecondNumberMax;
    private int SecondNumber;

    public int UserDifference;
    public int RightDifference;

    public int _iterations;
    public int MaxIterations;
    public int _bugCount;

    public GameObject Numbs;
    public GameObject Stats_Manager;

    private void OnEnable()
    {
        Numbs.SetActive(true);
        UserDifference = Random.Range(minRange, maxRange);
        RightDifference = UserDifference;
        SecondNumber = Random.Range(SecondNumberMin, SecondNumberMax);
        _iterations = 0;
        _bugCount = 0;

        _question.text = UserDifference.ToString() + "-" + SecondNumber.ToString() + " = ";
        _answer.text = "";
    }

    public void AddNumber(int num)
    {
        if (_answer.text.Length < 3) _answer.text = _answer.text.Insert(_answer.text.Length, num.ToString());
    }

    public void RemoveNumber()
    {
       if (_answer.text.Length > 0) _answer.text = _answer.text.Remove(_answer.text.Length - 1, 1);
    }

    public void Calculate()
    {
        if (_iterations < MaxIterations && _answer.text != "")
        {
            RightDifference -= SecondNumber;
            if (RightDifference != int.Parse(_answer.text))
                _bugCount++;
            UserDifference = Random.Range(minRange, maxRange);
            RightDifference = UserDifference;
            SecondNumber = Random.Range(SecondNumberMin, SecondNumberMax);
            _question.text = UserDifference + "-" + SecondNumber.ToString() + " = ";
            _iterations++;
            _answer.text = "";
            if(_iterations==MaxIterations)
            {
                _question.text = "";
                _answer.text = "";
                int trueanswer = MaxIterations - _bugCount;
                _finish.text = "Из " + MaxIterations + " примеров " + trueanswer + " правильных ответов";
                Numbs.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        if (Stats_Manager) Stats_Manager.GetComponent<MiniGamesStats>().MiniGames_Stats[6] = 1.0f * (_iterations - _bugCount);
        _finish.text = "";
        _question.text = "";
        _answer.text = "";
    }
}
