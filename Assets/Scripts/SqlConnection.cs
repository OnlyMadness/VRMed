using UnityEngine;
using System.Collections;

public class SqlConnection : MonoBehaviour
{

    private string username = ""; //Переменная для хранения имени
    private string pswd = ""; //Переменная для хранения пароля
    private string email = ""; //Переменная для хранения почтового ящика
    private string url = "https://vrmed.000webhostapp.com/index1.php"; //Переменная для хранения адреса

    //Создание метода, отвечающего за подключение и передачу данных
    public void Connect()
    {
        WWWForm form = new WWWForm(); //Создаём новую форму 
                                      //Добавляем в форму новые данные
        form.AddField("user", "New");
        //form.AddField("password", pswd);
       // form.AddField("email", email);
        //Создаём новое подключение
        WWW connect = new WWW(url, form);
        //Если удалось установить подключение
        if (connect.isDone)
        {
            //Выводим в консоль ответ сервера
            Debug.Log(connect.text);
        }
        //Если при подключении возникла ошибка
        else if (connect.error == null)
        {
            //Выводим в консоль текст Error
            Debug.Log("Error");
        }
    }

    //Создаём метод OnGUI()
    void OnGUI()
    {
        //Создаём текстовое поле для ввода имени пользователя
       // username = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 20), username, 12);
        //Создаём текстовое поле для ввода пароля
       // pswd = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 20), pswd, 12);
        //Создаём текстовое поле для ввода почтового ящика
       // email = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 20), email, 50);
        //Создаём кнопку для произведения подключения
       // if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 20), "Connect"))
       // {
       //     Connect();
      //  }
    }
}