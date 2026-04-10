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
/// 4. Запуск
app.Run();

record Product(int Id, string Name, decimal Price, bool InStock);