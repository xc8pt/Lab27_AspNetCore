/// 1.Создание билдера
var builder = WebApplication.CreateBuilder(args);

/// 2. Сборка приложения
var app = builder.Build();

/// 3. Регистрация маршрута
//app.MapGet("/", () => "Привет от ИСП-233! Автор: <Ринат>");

// Маршрут 1: Главная страница
app.MapGet("/", () => "Добро пожаловать на сервер!");
// Маршрут 2: О нас
app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");
// Маршрут 3: Текущее время о нас
app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");
// Маршрут 4: Параметр пути
app.MapGet("/hello/{name}", (string name) => $"Привет, {name}!");

/// 4. Запуск
app.Run();
