# TestSoftwareDeveloper

Proyecto de prueba técnica desarrollado en .NET 6, con arquitectura en capas, base de datos SQL Server, una API REST y una aplicación WPF con validación visual reactiva.

## 🧪 Tecnologías Utilizadas

- **Backend**: .NET 6 — Repository Design Pattern — API REST
- **Frontend**: WPF (Windows Presentation Foundation)
- **Testing & Validación**: Postman

---

## 📁 Estructura del Proyecto

| Proyecto                | Descripción                                                  |
|-------------------------|--------------------------------------------------------------|
| `Directorio.Data`       | Modelos de datos y contexto `DbContext` con Entity Framework.|
| `DirectorioRestService` | API RESTful para operaciones CRUD sobre la entidad `Persona`.|
| `Directorio.UI`         | Aplicación WPF para gestionar personas de forma visual.      |

---

## 🧱 Base de Datos

Ejecuta el siguiente script en SQL Server para crear la base de datos y sus tablas:

```sql
CREATE DATABASE DirectorioDb;
USE DirectorioDb;

CREATE TABLE Personas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    ApellidoPaterno NVARCHAR(100) NOT NULL,
    ApellidoMaterno NVARCHAR(100),
    Identificacion NVARCHAR(50) NOT NULL
);

CREATE TABLE Facturas (
    Id INT PRIMARY KEY IDENTITY,
    PersonaId INT FOREIGN KEY REFERENCES Personas(Id),
    Monto DECIMAL(18,2),
    Fecha DATE
);
```

---

## ⚙️ Configuraciones a Cambiar

### 🔌 Cadena de Conexión

En el archivo `appsettings.json` dentro del proyecto `DirectorioRestService`, cambia la cadena de conexión actual:

```csharp
"Server=VLAD;Database=DirectorioDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

Por la cadena correspondiente a tu instancia de SQL Server.

---

### 🌐 URL de la API

En el proyecto WPF (`Directorio.UI`), abre el archivo `App.config` y modifica la clave `ApiBaseUrl` con la URL donde se ejecuta la API:

```xml
<configuration>
  <appSettings>
    <add key="ApiBaseUrl" value="http://localhost:5125/api/" />
  </appSettings>
</configuration>
```

---

## 🚀 Cómo ejecutar

1. Establece `DirectorioRestService` como proyecto de inicio y ejecútalo.
2. Luego, ejecuta `Directorio.UI` (la app WPF).
3. Desde la app WPF puedes:
   - Registrar nuevas personas (valida automáticamente los campos requeridos).
   - Eliminar personas seleccionadas.
   - Ver en tiempo real la lista de personas registradas.

---

## 💡 Notas adicionales

- El botón **Registrar** solo se habilita si todos los campos requeridos están completos (`Nombre`, `Apellido Paterno`, `Identificación`).
- Las validaciones se muestran en pantalla de forma visual y reactiva.
- La entidad `Factura` ya está integrada en la base de datos y se eliminan las facturas relacionadas al eliminar un usuario. Está lista para futuras mejoras.

---

👤 **Desarrollado por:** Omar García
