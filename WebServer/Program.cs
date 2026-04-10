/// 1.Создание билдера
var builder = WebApplication.CreateBuilder(args);

/// 2. Сборка приложения
var app = builder.Build();
/*
// Middleware 1: Логирование запросов
app.Use(async (context, next) => {
    Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
    await next(context);
    Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");
});
// Middleware 2: Добавлен заголовок в ответ
app.Use(async (context, next) => {
    context.Response.Headers.Append("X-Powered-By", "ASP.NET Core Lab27");
    await next(context);
});
// Middleware 3:
/*
app.Use(async (context, next) => {

});
*/
/// 3. Регистрация маршрута
//app.MapGet("/", () => "Привет от ИСП-233! Автор: <Ринат>");
/*
// Маршрут 1: Главная страница
// app.MapGet("/", () => "Добро пожаловать на сервер!");
// Маршрут 2: О нас
app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");
// Маршрут 3: Текущее время о нас
app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");
// Маршрут 4: Параметр пути
app.MapGet("/hello/{name}", (string name) => $"Привет, {name}!");
// Маршрут 5: Возвращаем JSON - обЪект
app.MapGet("/student", () => new {
    Name = "Rinat Abdulin",
    Group = "ISP-233",
    Year = 3,
    IsActive = true
});
// Маршрут 6: JSON - массив
app.MapGet("/subjects", () => new[] {
    "RPM",
    "RMP",
    "ISRPO",
    "SP",
});
// Маршрут 7: JSON с использованием класса
app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,
    Name: $"Товар #{id}",
    Price: id * 99.99m,
    InStock: id % 2 == 0
));
*/

// step 9
// midle

app.Use(async (context, next) => {
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"-> {method} {path}");
    await next(context);
});

// маршруты
app.MapGet("/", () => Results.Ok(new {
    Message = "Добро пожаловать!",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));
app.MapGet("/me", () => Results.Ok(new {
    Name = "Abdulin Rinat",
    Group = "ISP-233",
    Course = 3,
    Skills = new[] { "С#", "HTML", "CSS", "JS", "ASP.NET" }
}));
app.MapGet("/calc/{a}/{b}", (double a, double b) => Results.Ok(new {
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));
app.MapFallback(() => Results.NotFound(new {
    Error = "Маршрут не найден",
    Code = 404
}));

/// 4. Запуск
app.Run();

record Product(int Id, string Name, decimal Price, bool InStock);