using UnityEngine;

public class MiniGames_Game7_Controller : MonoBehaviour {

    public TextMesh _question;
    public TextMesh _answer;

    public int FirstNumber;

    public int SecondNumber;

    public int UserDifference;
    public int RightDifference;

    public int _iterations;
    public int _bugCount;

    public GameObject Stats_Manager;

    private void OnEnable()
    {
        UserDifference = FirstNumber;
        RightDifference = FirstNumber;
        _iterations = 0;
        _bugCount = 0;

        _question.text = FirstNumber.ToString() + "-" + SecondNumber.ToString() + " = ";
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
        if (_iterations < 5 && _answer.text != "" && UserDifference > int.Parse(_answer.text))
        {
            RightDifference -= SecondNumber;
            UserDifference = int.Parse(_answer.text);

            if (RightDifference != UserDifference)
            {
                RightDifference = UserDifference;
                _bugCount++;
            }

            _question.text = _answer.text + "-" + SecondNumber.ToString() + " = ";
            _iterations++;
            _answer.text = "";
        }
    }

    private void OnDisable()
    {
        if (Stats_Manager) Stats_Manager.GetComponent<MiniGamesStats>().MiniGames_Stats[6] = 1.0f * (_iterations - _bugCount);

        _question.text = "";
        _answer.text = "";
    }
}
