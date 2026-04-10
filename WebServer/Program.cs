/// 1.Создание билдера
var builder = WebApplication.CreateBuilder(args);

/// 2. Сборка приложения
var app = builder.Build();

/// 3. Регистрация маршрута
app.MapGet("/", () => "Привет от ИСП-233! Автор: <Ринат>");

/// 4. Запуск
app.Run();
