
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEditor;

public class Schulte_scripts_UI : MonoBehaviour
{
    private const int EXISTING_CANVAS_COUNT = 4;
    public GameObject Scale_Table;
    public GameObject Type_Table;
    public GameObject Type_Game;
    public GameObject Next_Symbol;
    public GameObject Text_Timer;
    public GameObject VisibleSettings;
  

    public GameObject Text_Timer_Finish;
    public GameObject Text_Finish;

    private int[] TableNumbers;
    private string[] TableLetters;

    public string symb = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public string symb_original = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    private bool Game = false;
    private int count_click;
    private int size;
    private GameObject Table_Buttons;
    private GameObject StartStop;

    public static byte Size_static;
    public static byte Type_Table_static;

private void Start()
{
    Size_static = 5;
    Type_Table_static = 0;
}

    private void OnEnable()
    {
        for (int i = 1; i < 6; i++)
        {
            GameObject.Find("Numb_Resolution_" + i.ToString()).transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring") as Material;
        }
        GameObject.Find("Numb_Resolution_3".ToString()).transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;

        GameObject.Find("Numb_Type_1").transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring") as Material;
        GameObject.Find("Numb_Type_2").transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
       
    }

    private void OnDisable()
    {
        count_click = 0;
        symb = symb_original;
        Next_Symbol.GetComponent<Text>().text = "";
        Destroy(Table_Buttons);
        GameController.Game = false;
        
        Text_Timer_Finish.SetActive(false);
        Text_Finish.SetActive(false);
        VisibleSettings.SetActive(true);

        Size_static = 5;
        Type_Table_static = 0;
        
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

    private void ArrayFillNumbers(int size, int[] table)
    {
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
        for (int i = 0; i < size * size; i++)
        {
            int NewRandom = rand.Next(symb.Length - 1);
            table[i] = symb[NewRandom].ToString();
            symb = symb.Remove(NewRandom, 1);
        }

    }

    public void Start_Game()
    {
        VisibleSettings.SetActive(false);
       // StartStop = GameObject.Find("TextBtnStart");

       // Scale_Table.GetComponent<Dropdown>().interactable = false;
      //  Type_Game.GetComponent<Toggle>().interactable = false;

        Text_Timer_Finish.SetActive(false);
        Text_Finish.SetActive(false);


        if (!GameController.Game)
        {
            GameTimer.stop = false;
            GameController.Game = true;
            //StartStop.GetComponent<Text>().text = "Stop";

            size = Size_static;
            GameObject Table_Canvas = GameObject.Find("TableSchulte");
            int ButtonCount = 0;

            float Table_Heigh = Table_Canvas.GetComponent<RectTransform>().sizeDelta.y;
            float Table_Width = Table_Canvas.GetComponent<RectTransform>().sizeDelta.x;

            float Button_Height = Table_Heigh / size;
            float Button_Width = Table_Width / size;

            float X = Button_Width / 2;
            float Y = -Button_Height / 2;

            int[] TableNumbers = new int[size * size];
            string[] TableLetters = new string[size * size];

            if (Type_Table_static == 0)
            {
                Next_Symbol.GetComponent<Text>().text = "0";
                ArrayFillNumbers(size, TableNumbers);
            }
            else
            {
                Next_Symbol.GetComponent<Text>().text = "А";
                ArrayFillLetters(size, TableLetters);
            }


            Table_Buttons = new GameObject("Buttons_Table", typeof(RectTransform));
            var newButtonsRT = Table_Buttons.GetComponent<RectTransform>();
            Table_Buttons.transform.SetParent(Table_Canvas.transform);
            Table_Buttons.layer = 0;


            newButtonsRT.position = new Vector3(0f, 0f, 0f);
            newButtonsRT.localScale = new Vector3(1f, 1f, 1f);
            newButtonsRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            newButtonsRT.localPosition = new Vector3(0f, 0f, 0f);
            newButtonsRT.sizeDelta = new Vector2(300, 120);
                
            newButtonsRT.localEulerAngles = new Vector3(0f, 0f, 0f);
            GameObject Buttons_Table = GameObject.Find("Buttons_Table");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var newButton = new GameObject("Button_" + ButtonCount, typeof(RectTransform));
                    newButton.transform.SetParent(Buttons_Table.transform);
                    newButton.layer = 0;
                    var Button = newButton.AddComponent<Button>();


                    Button.onClick.AddListener(() => Next_Symbol_Click(Button));

                    var ButtonRT = Button.GetComponent<RectTransform>();
                    ButtonRT.position = new Vector3(0f, 0f, 0f);
                    ButtonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
                    ButtonRT.localPosition = new Vector3(X + (Button_Width * j), Y, 0f);
                    ButtonRT.sizeDelta = new Vector2(Button_Width, Button_Height);
                    ButtonRT.localScale = new Vector3(1f, 1f, 1f);
                    ButtonRT.localEulerAngles = new Vector3(0f, 0f, 0f);
                    ButtonRT.anchorMin = new Vector3(0, 1);
                    ButtonRT.anchorMax = new Vector3(0, 1);

                    newButton.tag = "ButtonsSchulte";
                    newButton.AddComponent<Image>();
                    newButton.AddComponent<BoxCollider>();
                    newButton.GetComponent<BoxCollider>().isTrigger = true;
                    newButton.GetComponent<BoxCollider>().size = new Vector3(Button_Width, Button_Height, 1);

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

                    if (Type_Table_static == 0)
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
            Stop_Finish();
        }
    }

    private void Stop_Finish()
    {
        count_click = 0;
        symb = symb_original;

       // Scale_Table.GetComponent<Dropdown>().interactable = true;
       // Type_Game.GetComponent<Toggle>().interactable = true;

        Next_Symbol.GetComponent<Text>().text = "";
        Destroy(Table_Buttons);
        GameController.Game = false;
       // StartStop.GetComponent<Text>().text = "Start";
    }

    public void Next_Symbol_Click(Button Btn)
    {
        if (count_click != size * size - 1)
        {
            if (Btn.transform.GetChild(0).GetComponent<Text>().text == Next_Symbol.GetComponent<Text>().text)
            {
                count_click++;
                Btn.onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().interactable = false;
                if (Type_Table_static == 0)
                    Next_Symbol.GetComponent<Text>().text = (Convert.ToInt32(Next_Symbol.GetComponent<Text>().text) + 1).ToString();
                else
                    Next_Symbol.GetComponent<Text>().text = symb_original[count_click].ToString();

            }
        }
        else
        {
            Text_Timer_Finish.SetActive(true);
            Text_Finish.SetActive(true);
            Text_Timer_Finish.GetComponent<Text>().text = GameTimer.result;
            Stop_Finish();
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
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            Debug.Log("jkhgfd");
            gameObject.GetComponent<Button>().onClick.Invoke();
            if(gameObject.tag == "StartSchulte")
            {
                Console.Write("start");
            }
                
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            transform.localScale = new Vector3(1.0f, 1.05f, 1.0f);
        }
    }
}
