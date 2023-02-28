WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseWelcomePage();

//app.Run(async (context) => await context.Response.WriteAsync("Dima, Hello!"));

int x = 1;

//app.Run(async (context) =>
//{
//    x += 1;

//    var responce = context.Response;

//    //устанавливаем заголовки
//    responce.Headers.ContentLanguage = "ru-RU";

//    responce.Headers.ContentType = "text/plain; charset=utf8";

//    //добавляем свой произвольный заголовок
//    responce.Headers.Append("secret-id", "256");

//    await context.Response.WriteAsync($"Результат: {x}");
//});

app.Run(async (context) =>
{
    var responce = context.Response;

    //устанавливаем заголовки
    responce.StatusCode = 404;

    await context.Response.WriteAsync($"Recource not found");
});

app.Run();
