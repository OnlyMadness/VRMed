namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;

    public class Interactions : MonoBehaviour
    {

        private const int EXISTING_CANVAS_COUNT = 4;
        public GameObject TextFinish;
        public GameObject TextExplain;
        public GameObject ButtonExplain;
        public GameObject ButtonNext;
        public GameObject Canvas;
        public GameObject Statistics_Canvas;

        public GameObject Restart;

        public GameObject Image;
        public GameObject[] Buttons;
        public GameObject[] Buttons_answer;
        public Sprite sprite;

        public GameObject ApplyBtn;
        private int ApplyNumberImage;
        private int TestNumber = 1;

        private void OnDisable()
        {
            Restart_Test();
        }
        

        public void Button_Red()
        {
            VRTK_Logger.Info("Red Button Clicked");
        }

        public void ChoiceImage(int i)
        {
            for (int j = 0; j < 4; j++)
                Buttons[j].GetComponent<Image>().color = Color.white;
            Buttons[i].GetComponent<Image>().color = Color.black;
            ApplyNumberImage = i;
            ApplyBtn.SetActive(true);
        }

        public void ApplyImage()
        {
            Debug.Log("EAEwe");
            for (int i = 0; i < 4; i++)
                Buttons[i].SetActive(false);
            Image.SetActive(false);
            TextExplain.SetActive(true);
            ButtonExplain.SetActive(true);
            ApplyBtn.SetActive(false);
        }

        public void Answer_1()
        {
            StatiscticsList.Image_Number[StatiscticsList.NumberGroupEntry-1] = ApplyNumberImage;
            StatiscticsList.Why[StatiscticsList.NumberGroupEntry-1] = GameObject.Find("Answer_1").transform.GetChild(0).GetComponent<Text>().text;
            StatiscticsList.NumberGroupEntry++;
            NextImage();
        }
        public void Answer_2()
        {
            StatiscticsList.Image_Number[StatiscticsList.NumberGroupEntry-1] = ApplyNumberImage;
            StatiscticsList.Why[StatiscticsList.NumberGroupEntry-1] = GameObject.Find("Answer_2").transform.GetChild(0).GetComponent<Text>().text;
            StatiscticsList.NumberGroupEntry++;
            NextImage();
        }
        public void Answer_3()
        {
            StatiscticsList.Image_Number[StatiscticsList.NumberGroupEntry-1] = ApplyNumberImage;
            StatiscticsList.Why[StatiscticsList.NumberGroupEntry-1] = GameObject.Find("Answer_3").transform.GetChild(0).GetComponent<Text>().text;
            StatiscticsList.NumberGroupEntry++;
            NextImage();
        }
        public void Answer_4()
        {
            StatiscticsList.Image_Number[StatiscticsList.NumberGroupEntry-1] = ApplyNumberImage;
            StatiscticsList.Why[StatiscticsList.NumberGroupEntry-1] = GameObject.Find("Answer_4").transform.GetChild(0).GetComponent<Text>().text;
            StatiscticsList.NumberGroupEntry++;
            NextImage();
        }

        public void Restart_Test()
        {
            StatiscticsList.Reset = true;
            StatiscticsList.Image_Number = new int [StatiscticsList.CountGroupImageStatic];
            StatiscticsList.Why = new string [StatiscticsList.CountGroupImageStatic];
            StatiscticsList.deleteTable = StatiscticsList.NumberGroupEntry;
            StatiscticsList.NumberGroupEntry = 1;
            NextImage();
            Restart.SetActive(false);
            Statistics_Canvas.GetComponent<Canvas>().enabled = false;

        }

        public void NextImage()
        {
            ButtonExplain.SetActive(false);
            TextExplain.SetActive(false);
            switch (StatiscticsList.NumberGroupEntry)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer1[i];
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer2[i];
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer3[i];
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer4[i];
                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer5[i];
                    break;
                case 6:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer6[i];
                    break;
                case 7:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer7[i];
                    break;
                case 8:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer8[i];
                    break;
                case 9:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer9[i];
                    break;
                case 10:
                    for (int i = 0; i < 4; i++)
                        Buttons_answer[i].GetComponent<Text>().text = Answers.Answer10[i];
                    break;
            }
            if (StatiscticsList.NumberGroupEntry == 11)
            {
                Statistics_Canvas.GetComponent<Canvas>().enabled = true;
                StatiscticsList.ShowStat = true;
                //Restart.SetActive(true);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    Buttons[i].SetActive(true);
                Image.SetActive(true);       
                Image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images4test/_" + StatiscticsList.NumberGroupEntry);
            }
        }

        public void Button_Pink()
        {
            VRTK_Logger.Info("Pink Button Clicked");
        }

        public void Toggle(bool state)
        {
            VRTK_Logger.Info("The toggle state is " + (state ? "on" : "off"));
        }

        public void Dropdown(int value)
        {
            VRTK_Logger.Info("Dropdown option selected was ID " + value);
        }

        public void SetDropText(BaseEventData data)
        {
            var pointerData = data as PointerEventData;
            var textObject = GameObject.Find("ActionText");
            if (textObject)
            {
                var text = textObject.GetComponent<Text>();
                text.text = pointerData.pointerDrag.name + " Dropped On " + pointerData.pointerEnter.name;
            }
        }

        public void CreateCanvas()
        {
            StartCoroutine(CreateCanvasOnNextFrame());
        }

        private IEnumerator CreateCanvasOnNextFrame()
        {
            yield return null;

            var canvasCount = FindObjectsOfType<Canvas>().Length - EXISTING_CANVAS_COUNT;
            var newCanvasGO = new GameObject("TempCanvas");
            newCanvasGO.layer = 5;
            var canvas = newCanvasGO.AddComponent<Canvas>();
            var canvasRT = canvas.GetComponent<RectTransform>();
            canvasRT.position = new Vector3(-4f, 2f, 3f + canvasCount);
            canvasRT.sizeDelta = new Vector2(300f, 400f);
            canvasRT.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            canvasRT.eulerAngles = new Vector3(0f, 270f, 0f);

            var newButtonGO = new GameObject("TempButton", typeof(RectTransform));
            newButtonGO.transform.SetParent(newCanvasGO.transform);
            newButtonGO.layer = 5;

            var buttonRT = newButtonGO.GetComponent<RectTransform>();
            buttonRT.position = new Vector3(0f, 0f, 0f);
            buttonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            buttonRT.localPosition = new Vector3(0f, 0f, 0f);
            buttonRT.sizeDelta = new Vector2(180f, 60f);
            buttonRT.localScale = new Vector3(1f, 1f, 1f);
            buttonRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            newButtonGO.AddComponent<Image>();
            var canvasButton = newButtonGO.AddComponent<Button>();
            var buttonColourBlock = canvasButton.colors;
            buttonColourBlock.highlightedColor = Color.red;
            canvasButton.colors = buttonColourBlock;

            var newTextGO = new GameObject("BtnText", typeof(RectTransform));
            newTextGO.transform.SetParent(newButtonGO.transform);
            newTextGO.layer = 5;

            var textRT = newTextGO.GetComponent<RectTransform>();
            textRT.position = new Vector3(0f, 0f, 0f);
            textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            textRT.localPosition = new Vector3(0f, 0f, 0f);
            textRT.sizeDelta = new Vector2(180f, 60f);
            textRT.localScale = new Vector3(1f, 1f, 1f);
            textRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            var txt = newTextGO.AddComponent<Text>();
            txt.text = "New Button";
            txt.color = Color.black;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            newCanvasGO.AddComponent<VRTK_UICanvas>();
        }
    }
}