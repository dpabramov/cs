using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace Reminder.Storage.WebApi.Client
{
    public class ReminderStorageWebApiClient : IReminderStorage
    {
        //базовая часть урла, что-то типа "https://localhost:5001"
        private readonly string _baseWebApiUrl;

        //для отправки HTTP-запросов и получения HTTP-ответов 
        private HttpClient _httpClient;

        public ReminderStorageWebApiClient(string baseWebApiUrl)
        {
            _baseWebApiUrl = baseWebApiUrl;

            //инициализируем переменную через фабрику по созданию инстансов HttpClient
            _httpClient = HttpClientFactory.Create();
        }

        public Guid Add(DateTimeOffset date,
                        string message,
                        string contactId,
                        ReminderItemStatus status)
        {
            string method = "POST";
            //конечная часть урла
            string relativeUrl = "/api/reminders";

            var reminderItemAddModel = new ReminderItemAddModel(date,
                                                                message,
                                                                contactId);

            //в строку записываем объект который будем передавать на web-сервер в теле http-запроса
            string contentToServer = JsonConvert.SerializeObject(reminderItemAddModel);

            //отправляем на сервер
            var result = SendHttpRequest(method, relativeUrl, contentToServer);

            //анализируем ответ
            ThrowExceptionIfStatusCodeOtherThen(HttpStatusCode.Created, result);

            string contentFromServer = result.Content.ReadAsStringAsync().Result;

            var reminderItemGetModel = JsonConvert.DeserializeObject<ReminderItemGetModel>(contentFromServer);

            return reminderItemGetModel.Id;
        }

        public ReminderItem Get(Guid guid)
        {
            string method = "GET";
            //конечная часть урла
            string relativeUrl = $"/api/reminders/{guid}";

            HttpResponseMessage result = SendHttpRequest(method, relativeUrl, null);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return null;

            ThrowExceptionIfStatusCodeOtherThen(HttpStatusCode.OK, result);

            string content = result.Content.ReadAsStringAsync().Result;

            ReminderItemGetModel GetModel = JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

            return new ReminderItem(GetModel.Id,
                                    GetModel.Date,
                                    GetModel.Message,
                                    GetModel.ContactId,
                                    GetModel.Status);

        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            string method = "GET";
            //конечная часть урла
            string relativeUrl = $"/api/reminders?[filter]status={status}";

            HttpResponseMessage response = SendHttpRequest(method, relativeUrl, null);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            ThrowExceptionIfStatusCodeOtherThen(HttpStatusCode.OK, response);

            string content = response.Content.ReadAsStringAsync().Result;

            var GetModel = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

            if (GetModel == null)
                return new List<ReminderItem>{ new ReminderItem()};

            return GetModel.Select(x => new ReminderItem(x.Id,
                                                         x.Date,
                                                         x.Message,
                                                         x.ContactId,
                                                         x.Status))
                           .ToList();
        }

        public void Update(Guid id, ReminderItemStatus status)
        {
            string method = "PATCH";
            //конечная часть урла
            string relativeUrl = "/api/reminders";

            //в строку записываем объект который будем передавать на web-сервер в теле http-запроса
            string content = JsonConvert.SerializeObject(new ReminderItemUpdateModel
            {
                Id = id,
                Status = status
            });

            HttpResponseMessage result = SendHttpRequest(method, relativeUrl, content);

            ThrowExceptionIfStatusCodeOtherThen(HttpStatusCode.OK, result);
        }

        private HttpResponseMessage SendHttpRequest(string method, string relativeUrl, string content)
        {

            //представляет собой сообщение HTTP-запроса
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method),
                                                            _baseWebApiUrl + relativeUrl);

            //прописываем заголовок Accept
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            //прописываем тело запроса, кодировку и формат тела запроса
            if (content != null)
            {
                request.Content = new StringContent(
                        content,
                        Encoding.UTF8,
                        "application/json");
            }

            //отправляем на сервер сформированный запрос и возвращает ответ
            return _httpClient.SendAsync(request).Result;
        }

        private void ThrowExceptionIfStatusCodeOtherThen(HttpStatusCode httpStatusCode, 
                                                        HttpResponseMessage response)
        {
            if (response.StatusCode != httpStatusCode)
            {
                throw new Exception($"Status code: {response.StatusCode}" +
                    $"Content: {response.Content.ReadAsStringAsync().Result}");
            }
        }
    }
}
