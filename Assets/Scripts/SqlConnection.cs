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
using System.Xml;

public class SqlConnection : MonoBehaviour
{

    private string username = ""; //Переменная для хранения имени
    private string pswd = ""; //Переменная для хранения пароля
    private string email = ""; //Переменная для хранения почтового ящика
    private string url = "https://vrmed.000webhostapp.com/index1.php"; //Переменная для хранения адреса
    public int[] MarksTests = new int[Session.GameList.Length];
    public int[] nScoreGame = new int[Session.GameList.Length];

    string Action;
    string AnswerServerSelect;
    public List<PatientsAdd> PatientList = new List<PatientsAdd>(); //здесь будет результат
    public List<RecommendationsGame> RecommendationsGamesList = new List<RecommendationsGame>(); //здесь будет результат
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

    public class PatientJson {
        public string id_patient;       
        public string Type;
        public int[] id_exercise;
        public string[] MarksJson;
        public string[] CommentsJson;
    }
    public class GameJson
    {
        public int id_patient;
        public int id_game;
        public int Mark;
        public string Comment;
        public string Type;
    }
    //public async Task SelectPatient()
    //{
    //    await SelectPatientAsync(url);
    //    // Debug.Log(PatientList[0].Lastname);
    //    //for (int i = 0; i < PatientList.Count - 1; i++)
    //    //    Debug.Log(PatientList[i].Id + " " + PatientList[i].FirstName + " " + PatientList[i].Lastname);
    //}
    public void InsertPatient()
    {
        PostInsertAsync(url);
    }
    public async void PostInsertMarksCommentsTestAsync(string[] marks, string[] comments)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST"; // для отправки используется метод Post
                                 // данные для отправки
       // PatientJsonList.Add(new PatientJson { Type = "InsertMarksComments" });
        var patientJson = new PatientJson();
        patientJson.id_patient = Session.Id_Patient.ToString();
        patientJson.Type = "InsertExerciseTest";
        patientJson.id_exercise = new int[Session.TestList.Length];
        patientJson.MarksJson = new string[marks.Length];
        patientJson.CommentsJson = new string[comments.Length];
        for(int i =0;i< marks.Length; i++)
        {
            patientJson.id_exercise[i] = Session.TestList[i];
            patientJson.MarksJson[i] = marks[i];
            patientJson.CommentsJson[i] = comments[i];          
        }
        var Json = JsonUtility.ToJson(patientJson);
       // var data = new { Type = "InsertMarksComments", password = "password" };
        // преобразуем данные в массив байтов
        Debug.Log(Json);
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(Json);
        // устанавливаем тип содержимого - параметр ContentType
        request.ContentType = "application/json";
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

        //WebRequest request = WebRequest.Create(url);
        //var patientJson = new PatientJson { Type = "InsertMarksComments" };
        //var testJson = JsonUtility.ToJson(patientJson);

        //request.Method = "POST";
        //request.ContentType = "application/json";

        //using (var requestStream = await request.GetRequestStreamAsync())
        //using (var writer = new StreamWriter(requestStream))
        //{
        //    writer.Write(testJson);
        //}
        //using (var httpResponse = await request.GetResponseAsync())
        //using (var responseStream = httpResponse.GetResponseStream())
        //using (var reader = new StreamReader(responseStream))
        //{
        //    string response = reader.ReadToEnd();
        //}
        //Debug.Log("Запрос выполнен...");

        //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //httpWebRequest.ContentType = "application/json";
        //httpWebRequest.Method = "POST";

        //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //{
        //    string json = "{\"user\":\"test\"," +
        //                  "\"password\":\"bla\"}";

        //    streamWriter.Write(json);
        //    streamWriter.Flush();
        //    streamWriter.Close();
        //}

        //var httpResponse = await httpWebRequest.GetResponseAsync();
        //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //{
        //    var result = streamReader.ReadToEnd();
        //}
        //httpResponse.Close();
        //Debug.Log("Запрос выполнен...");
    }
    public async Task PostInsertMarksCommentsGameAsync(int id_patient, int id_game, int mark, string comment)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST"; // для отправки используется метод Post
                                 // данные для отправки
                                 // PatientJsonList.Add(new PatientJson { Type = "InsertMarksComments" });
        var _GameJson = new GameJson();
        _GameJson.id_patient = id_patient;
        _GameJson.id_game = Session.GameList[id_game-1];
        _GameJson.Type = "InsertExerciseGame";
        _GameJson.Mark = mark;
        _GameJson.Comment = comment;

        var Json = JsonUtility.ToJson(_GameJson);
        // var data = new { Type = "InsertMarksComments", password = "password" };
        // преобразуем данные в массив байтов
       // Debug.Log(testJson);
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(Json);
        // устанавливаем тип содержимого - параметр ContentType
        request.ContentType = "application/json";
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

        //WebRequest request = WebRequest.Create(url);
        //var patientJson = new PatientJson { Type = "InsertMarksComments" };
        //var testJson = JsonUtility.ToJson(patientJson);

        //request.Method = "POST";
        //request.ContentType = "application/json";

        //using (var requestStream = await request.GetRequestStreamAsync())
        //using (var writer = new StreamWriter(requestStream))
        //{
        //    writer.Write(testJson);
        //}
        //using (var httpResponse = await request.GetResponseAsync())
        //using (var responseStream = httpResponse.GetResponseStream())
        //using (var reader = new StreamReader(responseStream))
        //{
        //    string response = reader.ReadToEnd();
        //}
        //Debug.Log("Запрос выполнен...");

        //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //httpWebRequest.ContentType = "application/json";
        //httpWebRequest.Method = "POST";

        //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //{
        //    string json = "{\"user\":\"test\"," +
        //                  "\"password\":\"bla\"}";

        //    streamWriter.Write(json);
        //    streamWriter.Flush();
        //    streamWriter.Close();
        //}

        //var httpResponse = await httpWebRequest.GetResponseAsync();
        //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //{
        //    var result = streamReader.ReadToEnd();
        //}
        //httpResponse.Close();
        //Debug.Log("Запрос выполнен...");
    }
    public async Task SelectMarksPatientAsync(int id_patient)
    {    
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST";
        string data = "Type=SelectMarksPatient&id_patients="+id_patient;
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
                Debug.Log(reader.ReadToEnd());
              //  AddMarksPatient(reader.ReadToEnd());
            }
        }
        response.Close();
        Debug.Log("Запрос выполнен...");
    }
    public async Task SelectExercise()
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST";
        string data = "Type=SelectExercise";
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
                AddExercise(reader.ReadToEnd());
            }
        }
        response.Close();
        Debug.Log("Запрос выполнен...");
    }

    private void AddExercise(string AnswerServerSelect)
    {
        string[] lines = AnswerServerSelect.Split('\n');
        for (int i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i] == "")
                continue;
            string[] lineParts = lines[i].Split('\t');
            if (Convert.ToInt32(lineParts[2]) == 1)
                Session.AddTestsList(Convert.ToInt32(lineParts[0]), lineParts[1]);
            else
                Session.AddGamesList(Convert.ToInt32(lineParts[0]), lineParts[1]);
        }     
    }

    public async Task SelectPatientAsync()
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST";                                
        string data = "Type=SelectPatients";       
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
    public class RecommendationsGame
    {
        public int nScore { get; set; }
        public int MarkTest { get; set; }
        public RecommendationsGame(int nScore, int MarkTest)
        {
            this.nScore = nScore;
            this.MarkTest = MarkTest;
        }
    }
    private void AddMarksPatient(string AnswerServerSelect)
    {
        string[] lines = AnswerServerSelect.Split('\n');
        for (int i = 0; i < lines.Length -1 ; i++)
        {
            if (lines[i] == "")
                continue;
            string[] lineParts = lines[i].Split('\t');
            nScoreGame[Convert.ToInt32(lineParts[2]) - 1] = Convert.ToInt32(lineParts[3]);          
            MarksTests[Convert.ToInt32(lineParts[2])-1] += Convert.ToInt32(lineParts[4]);
        }
        if (lines[0] != "0 results")
        {
            for (int i = 0; i < MarksTests.Length; i++)
            {
                RecommendationsGamesList.Add(new RecommendationsGame(nScoreGame[i], MarksTests[i]));
            }
        }
    }
    public class PatientsAdd
    {
        public string Id { get; set; }
        public string Full_name { get; set; }
        public PatientsAdd(string Id, string Full_name)
        {
            this.Id = Id;
            this.Full_name = Full_name;
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
            PatientList.Add(new PatientsAdd(lineParts[0], lineParts[1]));
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