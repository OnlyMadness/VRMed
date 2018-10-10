namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using System;

    public class UI_Interactions : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;
        public GameObject Scale_Table;
        public GameObject Type_Table;
        public GameObject Type_Game;
        public GameObject Next_Symbol;

        private int[] TableNumbers;
        private string[] TableLetters;

        public string symb = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public string symb_original = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private bool Game = false;
        private int count_click;
        private int size;
        private GameObject Table_Buttons;
        private GameObject StartStop;

        public void Button_Red()
        {
            VRTK_Logger.Info("Red Button Clicked");
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

        private void ArrayFillNumbers(int size, int[]table) {
            bool alreadyThere = false;     
            System.Random rand = new System.Random();
            for (int i = 0; i < size * size;)
            {
                alreadyThere = false;
                int NewRandom = rand.Next(size * size);

                for (int j = 0; j < i; j++)
                {
                    if (table[j] == NewRandom)
                        alreadyThere = true;
                }

                if (!alreadyThere)
                {
                    table[i] = NewRandom;
                    i++;
                }
            }
        }

        public void ArrayFillLetters(int size, string[] table)
        {
            System.Random rand = new System.Random();
            symb = symb.Remove(size * size, symb.Length - size * size);
            for (int i = 0; i < size * size;i++)
            {    
                int NewRandom = rand.Next(symb.Length-1);
                table[i] = symb[NewRandom].ToString();
                symb = symb.Remove(NewRandom,1);
            }
            
        }

        public void Start_Game() {

            StartStop = GameObject.Find("TextBtnStart");
            count_click = 0;
            if (!GameController.Game)
            {
                GameTimer.stop = false;
                GameController.Game = true;
                StartStop.GetComponent<Text>().text = "Stop";


                size = Convert.ToInt32(Scale_Table.GetComponent<Text>().text.Split('x')[0]);
                int ButtonCount = 0;
                float X = -130f;
                float Y = 60f;

                float Table_Heigh = 160;
                float Table_Width = 300;
                float Button_Height = Table_Heigh / size;
                float Button_Width = Table_Width / size;

                int[] TableNumbers = new int[size * size];
                string[] TableLetters = new string[size * size];

                if (Type_Table.GetComponent<Dropdown>().value == 0)
                {
                    Next_Symbol.GetComponent<Text>().text = "0";
                    ArrayFillNumbers(size, TableNumbers);
                }
                else
                {
                    Next_Symbol.GetComponent<Text>().text = "А";
                    ArrayFillLetters(size, TableLetters);
                }

                GameObject Table_Canvas = GameObject.Find("Table");
                Table_Buttons = new GameObject("Buttons_Table", typeof(RectTransform));
                var newButtonsRT = Table_Buttons.GetComponent<RectTransform>();
                Table_Buttons.transform.SetParent(Table_Canvas.transform);
                Table_Buttons.layer = 5;

                newButtonsRT.position = new Vector3(0f, 0f, 0f);
                newButtonsRT.localScale = new Vector3(1f, 1f, 1f);
                newButtonsRT.anchoredPosition = new Vector3(0f, 0f, 0f);
                newButtonsRT.localPosition = new Vector3(0f, 0f, 0f);
                newButtonsRT.sizeDelta = new Vector2(300, 300);

                newButtonsRT.localEulerAngles = new Vector3(0f, 0f, 0f);
                GameObject Buttons_Table = GameObject.Find("Buttons_Table");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        var newButton = new GameObject("Button_" + ButtonCount, typeof(RectTransform));
                        newButton.transform.SetParent(Buttons_Table.transform);
                        newButton.layer = 5;
                        var Button = newButton.AddComponent<Button>();


                        Button.onClick.AddListener(() => Next_Symbol_Click(Button));

                        var ButtonRT = Button.GetComponent<RectTransform>();
                        ButtonRT.position = new Vector3(0f, 0f, 0f);
                        ButtonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
                        ButtonRT.localPosition = new Vector3(X + (Button_Width * j), Y, 0f);
                        ButtonRT.sizeDelta = new Vector2(Button_Width, Button_Height);
                        ButtonRT.localScale = new Vector3(1f, 1f, 1f);
                        ButtonRT.localEulerAngles = new Vector3(0f, 0f, 0f);



                        newButton.AddComponent<Image>();

                        var newText = new GameObject("Text", typeof(RectTransform));
                        newText.transform.SetParent(newButton.transform);
                        newText.layer = 5;

                        var textRT = newText.GetComponent<RectTransform>();
                        textRT.position = new Vector3(0f, 0f, 0f);
                        textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
                        textRT.localPosition = new Vector3(0f, 0f, 0f);
                        textRT.sizeDelta = new Vector2(Button_Width, Button_Height);
                        textRT.localScale = new Vector3(1f, 1f, 1f);
                        textRT.localEulerAngles = new Vector3(0f, 0f, 0f);


                        var txt = newText.AddComponent<Text>();

                        if (Type_Table.GetComponent<Dropdown>().value == 0)
                            txt.text = TableNumbers[ButtonCount].ToString();
                        else
                            txt.text = TableLetters[ButtonCount].ToString();

                        ButtonCount++;

                        txt.color = Color.black;
                        txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                        txt.resizeTextForBestFit = true;
                        txt.alignment = TextAnchor.MiddleCenter;

                        Button.targetGraphic = newButton.GetComponent<Image>();
                    }
                    Y -= Button_Height;
                }
            }
            else
            {
                GameTimer.stop = true;
                Destroy(Table_Buttons);
                GameController.Game = false;
                StartStop.GetComponent<Text>().text = "Start";
            }
        }    
        

        public void Next_Symbol_Click(Button Btn)
        {
            if (count_click != size * size -1)
            {
                if (Btn.transform.GetChild(0).GetComponent<Text>().text == Next_Symbol.GetComponent<Text>().text)
                {
                    count_click++;
                    Btn.onClick.RemoveAllListeners();
                    if (Type_Game.GetComponent<Toggle>().isOn)
                        Btn.GetComponent<Button>().interactable = false;
                    if (Type_Table.GetComponent<Dropdown>().value == 0)
                        Next_Symbol.GetComponent<Text>().text = (Convert.ToInt32(Next_Symbol.GetComponent<Text>().text) + 1).ToString();
                    else
                        Next_Symbol.GetComponent<Text>().text = symb_original[count_click].ToString();

                }
            }
            else
            {
                Destroy(Table_Buttons);
                GameController.Game = false;
                StartStop.GetComponent<Text>().text = "Start";
            }
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