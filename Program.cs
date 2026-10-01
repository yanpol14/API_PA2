var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS para permitir peticiones desde tu Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("PermitirTodo");

// Endpoint de prueba de vida
app.MapGet("/", () =>
{
    return "API Sistema de Gestión - Canchas Deportivas";
});

// Endpoint principal: 10 Registros de Horarios de Canchas
app.MapGet("/api/horarios", () =>
{
    return Results.Ok(new[]
    {
        new { id = 1, fecha = "2026-10-02", horaInicio = "08:00", horaFin = "09:00", disponible = true, tipoCancha = "Grass Sintético", precio = 60.00, duracionMinutos = 60 },
        new { id = 2, fecha = "2026-10-02", horaInicio = "09:00", horaFin = "10:00", disponible = false, tipoCancha = "Grass Sintético", precio = 60.00, duracionMinutos = 60 },
        new { id = 3, fecha = "2026-10-02", horaInicio = "10:00", horaFin = "11:00", disponible = true, tipoCancha = "Fútbol 7", precio = 90.00, duracionMinutos = 60 },
        new { id = 4, fecha = "2026-10-02", horaInicio = "11:00", horaFin = "12:00", disponible = true, tipoCancha = "Fútbol 7", precio = 90.00, duracionMinutos = 60 },
        new { id = 5, fecha = "2026-10-02", horaInicio = "14:00", horaFin = "15:00", disponible = false, tipoCancha = "Grass Sintético", precio = 70.00, duracionMinutos = 60 },
        new { id = 6, fecha = "2026-10-02", horaInicio = "15:00", horaFin = "16:00", disponible = true, tipoCancha = "Grass Sintético", precio = 70.00, duracionMinutos = 60 },
        new { id = 7, fecha = "2026-10-02", horaInicio = "16:00", horaFin = "17:00", disponible = true, tipoCancha = "Fútbol 7", precio = 100.00, duracionMinutos = 60 },
        new { id = 8, fecha = "2026-10-02", horaInicio = "18:00", horaFin = "19:00", disponible = false, tipoCancha = "Fútbol 7", precio = 120.00, duracionMinutos = 60 },
        new { id = 9, fecha = "2026-10-02", horaInicio = "19:00", horaFin = "20:00", disponible = true, tipoCancha = "Grass Sintético", precio = 110.00, duracionMinutos = 60 },
        new { id = 10, fecha = "2026-10-02", horaInicio = "20:00", horaFin = "21:00", disponible = true, tipoCancha = "Grass Sintético", precio = 110.00, duracionMinutos = 60 }
    });
});

// Endpoint secundario: Servicios Adicionales
app.MapGet("/api/servicios", () =>
{
    return Results.Ok(new[]
    {
        new { id = 1, nombre = "Alquiler de Balón Profesional", descripcion = "Balón oficial N° 5 para césped sintético", precio = 10.00 },
        new { id = 2, nombre = "Iluminación Nocturna", descripcion = "Reflectores LED de alta potencia", precio = 20.00 },
        new { id = 3, nombre = "Chalecos / Casacas", descripcion = "Juego de 10 chalecos numerados", precio = 15.00 }
    });
});

app.Run();