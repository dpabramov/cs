using Microsoft.Extensions.FileProviders;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//добавляем midlewere
//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"Hello");
//});

//русский язык
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
//    await response.WriteAsync("Привет Дима");
//});

//отправляем html-страницу
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2>Hello Dima</h2><h3>Welcome to ASP.NET Core</h3>");
//});

//выведем все заголовки поступившего запроса
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//получим заголовок accept
//app.Run(async (context) =>
//{
//    var acceptHeaderValue = context.Request.Headers.Accept;
//    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
//});


//Выведем путь в запросе
//app.Run(async (context) => 
//    await context.Response.WriteAsync($"Path: {context.Request.Path}"));

//разные действия в зависимость от пути в запросе
//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var now = DateTime.Now;
//    var response = context.Response;

//    if (path == "/date")
//        await response.WriteAsync($"Date: {now.ToShortDateString()}");
//    else if (path == "/time")
//        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
//    else
//        await response.WriteAsync("Hello METANIT.COM");
//});

//получим строку запросов (параметров)
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//получим переданные параметры в виде словаря:
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//получим значения отдельных параметров
//app.Run(async (context) =>
//{
//    string name = context.Request.Query["name"];
//    string age = context.Request.Query["age"];
//    await context.Response.WriteAsync($"{name} - {age}");
//});

//отправка файлов для загрузки
//app.Run(async (context) => await context.Response.SendFileAsync("c:\\1\\lada2105.jpg"));
//app.Run(async (context) => await context.Response.SendFileAsync("jpg\\bmv_m4.jpg"));

//отправка страницы из проекта
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html\\htmlpage.html");
//});

//две страницы  в зависимости от пути
//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var fullPath = $"html/{path}";
//    var response = context.Response;

//    response.ContentType = "text/html; charset=utf-8";
//    if (File.Exists(fullPath))
//    {
//        await response.SendFileAsync(fullPath);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsync("<h2>Not Found</h2>");
//    }
//});

//заргузка файла на диск
//app.Run(async (context) =>
//{
//    //здесь в строке имя файла под которым его будет скачивать клиент
//    context.Response.Headers.ContentDisposition = @"attachment; filename=jpg\bmv_m4.jpg";
//    //здесь в строке имя файла для отправки клиенту
//    await context.Response.SendFileAsync(@"jpg\bmv_m4.jpg");
//});

//та же отправка файла клиенту для загрузки, но файл задаем в виде структуры IFileInfo
//app.Run(async (context) =>
//{
//    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + @"\jpg");

//    var fileinfo = fileProvider.GetFileInfo("bmv_m4.jpg");

//    context.Response.Headers.ContentDisposition = "attachment; filename=bmv_m4.jpg";
//    await context.Response.SendFileAsync(fileinfo);
//});

//отправка форм клиенту для ввода данных и их получения
//с массивом
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    // если обращение идет по адресу "/postuser", получаем данные с формы
//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];

//        string resLang = string.Empty;
//        string[] lang = form["languages"];
//        foreach (string item in lang)
//        {
//            resLang += $" {item}";
//        }

//        await context
//                .Response
//                .WriteAsync($"<div><p>Name: {name}</p>" +
//                $"<p>Age: {age}</p>" +
//                $"<p>Languages: {resLang}</p></div>");

//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

//пример переадресации
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    if (context.Request.Path == "/htmlpage")
//    {
//        //context.Response.Redirect("metanit");
//        context.Response.Redirect("https://metanit.com/sharp/aspnet6/2.9.php");
//    }
//    else if (context.Request.Path == "/metanit")
//    {
//        await context.Response.SendFileAsync("html/metanit.html");

//    }
//    else
//        await context.Response.SendFileAsync("html/index.html");
//});

//Отправляем клиенту json
//app.Run(async (context) =>
//{
//    Person tom = new("Tom", 22);
//    await context.Response.WriteAsJsonAsync(tom);
//});

//можно отправлять json клиенту старым способом
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentType = "application/json; charset=utf-8";
//    await response.WriteAsync("{'name':'Tom', 'age':37}");
//});

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/api/user")
    {
        var message = "Некорректные данные";   // содержание сообщения по умолчанию
        try
        {
            // пытаемся получить данные json
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null) // если данные сконвертированы в Person
                message = $"Name: {person.Name}  Age: {person.Age}";
        }
        catch { }
        // отправляем пользователю данные
        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index2.html");
    }
});


//запускаем приложение
app.Run();

public record Person(string Name, int Age);
