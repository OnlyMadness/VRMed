using UnityEngine;
using System.Collections;
using System.Net.Http;
using System.IO;
using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SqlConnection : MonoBehaviour
{

    private string username = ""; //Переменная для хранения имени
    private string pswd = ""; //Переменная для хранения пароля
    private string email = ""; //Переменная для хранения почтового ящика
    private string url = "https://vrmed.000webhostapp.com/index1.php"; //Переменная для хранения адреса


    string Action;
    string AnswerServerSelect;
    List<Patient> PatientList = new List<Patient>(); //здесь будет результат
    //Создание метода, отвечающего за подключение и передачу данных
    public void Connect()
    {
        //string urlAddress = url;
        //using (WebClient client = new WebClient())
        //{
        //    NameValueCollection postData = new NameValueCollection()
        //            {
        //              { "trial", "10" }
        //        };
        //    Debug.Log(urlAddress);
        //    Debug.Log(postData);

        //    string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
        //    Debug.Log(pagesource);
        //}
        
        
        //for (int i = 0; i < PatientList.Count - 1; i++)
         //   Debug.Log(PatientList[i].Id + " " + PatientList[i].FirstName + " " + PatientList[i].Lastname);
    }

    public void SelectPatient()
    {
        SelectPatientAsync(url);
        //for (int i = 0; i < PatientList.Count - 1; i++)
       //    Debug.Log(PatientList[i].Id + " " + PatientList[i].FirstName + " " + PatientList[i].Lastname);
    }
    public void InsertPatient()
    {
        PostInsertAsync(url);
    }

    private async void SelectPatientAsync(string url)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST";                                
        string data = "Type=Select";       
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);      
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        using (Stream dataStream = await request.GetRequestStreamAsync())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }
        WebResponse response = await request.GetResponseAsync();
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
              //  Debug.Log(reader.ReadToEnd());
                AddPatient(reader.ReadToEnd());         
            }
        }       
        response.Close();
        Debug.Log("Запрос выполнен...");
    }
    private async void PostInsertAsync(string url)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST"; // для отправки используется метод Post
                                 // данные для отправки
        string data = "Type=Insert&FirstName=IO&LastName=IOLOVICH";
        // преобразуем данные в массив байтов
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
        // устанавливаем тип содержимого - параметр ContentType
        request.ContentType = "application/x-www-form-urlencoded";
        // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
        request.ContentLength = byteArray.Length;

        //записываем данные в поток запроса
        using (Stream dataStream = await request.GetRequestStreamAsync())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }

        WebResponse response = await request.GetResponseAsync();
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                Debug.Log(reader.ReadToEnd());
            }
        }
        response.Close();
        Debug.Log("Запрос выполнен...");
    }
    class Patient
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public Patient(string Id, string FirstName, string Lastname)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.Lastname = Lastname;
        }
    }
    private void AddPatient(string AnswerServerSelect)
    {
        string[] lines = AnswerServerSelect.Split('\n');
        for (int i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i] == "")
                continue;
            string[] lineParts = lines[i].Split('\t');
            PatientList.Add(new Patient(lineParts[0], lineParts[1], lineParts[2]));
        }
    }
    //    WWWForm form = new WWWForm(); //Создаём новую форму 
    //                                  //Добавляем в форму новые данные
    //    form.AddField("user", "New");
    //    //form.AddField("password", pswd);
    //   // form.AddField("email", email);
    //    //Создаём новое подключение
    //    WWW connect = new WWW(url, form);
    //    //Если удалось установить подключение

    //    if (connect.isDone)
    //    {
    //        //Выводим в консоль ответ сервера
    //        Debug.Log(connect.text);
    //    }
    //    //Если при подключении возникла ошибка
    //    else if(connect.error == null)
    //    {
    //        //Выводим в консоль текст Error
    //        Debug.Log("Error");
    //    }
    //    Debug.Log(connect.text);
    //}

    //async static void GetRequest(string url)
    //{
    //    using (HttpClient client = new HttpClient())
    //}
}