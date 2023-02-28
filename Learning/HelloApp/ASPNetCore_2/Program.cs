using Microsoft.Extensions.FileProviders;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//��������� midlewere
//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"Hello");
//});

//������� ����
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");    // ���������� ���������� ���������
//    await response.WriteAsync("������ ����");
//});

//���������� html-��������
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2>Hello Dima</h2><h3>Welcome to ASP.NET Core</h3>");
//});

//������� ��� ��������� ������������ �������
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

//������� ��������� accept
//app.Run(async (context) =>
//{
//    var acceptHeaderValue = context.Request.Headers.Accept;
//    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
//});


//������� ���� � �������
//app.Run(async (context) => 
//    await context.Response.WriteAsync($"Path: {context.Request.Path}"));

//������ �������� � ����������� �� ���� � �������
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

//������� ������ �������� (����������)
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//������� ���������� ��������� � ���� �������:
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>��������� ������ �������</h3><table>");
//    stringBuilder.Append("<tr><td>��������</td><td>��������</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//������� �������� ��������� ����������
//app.Run(async (context) =>
//{
//    string name = context.Request.Query["name"];
//    string age = context.Request.Query["age"];
//    await context.Response.WriteAsync($"{name} - {age}");
//});

//�������� ������ ��� ��������
//app.Run(async (context) => await context.Response.SendFileAsync("c:\\1\\lada2105.jpg"));
//app.Run(async (context) => await context.Response.SendFileAsync("jpg\\bmv_m4.jpg"));

//�������� �������� �� �������
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html\\htmlpage.html");
//});

//��� ��������  � ����������� �� ����
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

//�������� ����� �� ����
//app.Run(async (context) =>
//{
//    //����� � ������ ��� ����� ��� ������� ��� ����� ��������� ������
//    context.Response.Headers.ContentDisposition = @"attachment; filename=jpg\bmv_m4.jpg";
//    //����� � ������ ��� ����� ��� �������� �������
//    await context.Response.SendFileAsync(@"jpg\bmv_m4.jpg");
//});

//�� �� �������� ����� ������� ��� ��������, �� ���� ������ � ���� ��������� IFileInfo
//app.Run(async (context) =>
//{
//    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + @"\jpg");

//    var fileinfo = fileProvider.GetFileInfo("bmv_m4.jpg");

//    context.Response.Headers.ContentDisposition = "attachment; filename=bmv_m4.jpg";
//    await context.Response.SendFileAsync(fileinfo);
//});

//�������� ���� ������� ��� ����� ������ � �� ���������
//� ��������
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    // ���� ��������� ���� �� ������ "/postuser", �������� ������ � �����
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

//������ �������������
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

//���������� ������� json
//app.Run(async (context) =>
//{
//    Person tom = new("Tom", 22);
//    await context.Response.WriteAsJsonAsync(tom);
//});

//����� ���������� json ������� ������ ��������
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
        var message = "������������ ������";   // ���������� ��������� �� ���������
        try
        {
            // �������� �������� ������ json
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null) // ���� ������ ��������������� � Person
                message = $"Name: {person.Name}  Age: {person.Age}";
        }
        catch { }
        // ���������� ������������ ������
        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index2.html");
    }
});


//��������� ����������
app.Run();

public record Person(string Name, int Age);
