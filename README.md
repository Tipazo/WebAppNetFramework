# C# .NET Framework ASP WEB FORMS

Ejemplo de aplicación **C# .NET Framework ASP WEB FORMS** que consume una **API REST de PERFILES, S. A.**.

---

## 🚀 Requisitos
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)  
- API del proyecto [`WebApiDemo`](https://github.com/Tipazo/WebApiDemo.git) ejecutándose en local o en servidor  

---

## 🔧 Configuración en entorno local
Para probar la aplicación en **Visual Studio** o **Visual Studio Code**:

1. Localiza el archivo `Web.config` en el proyecto MVC.
2. Agrega o modifica la variable de entorno ApiPerfilesUrl:

```json
  <appSettings>
    <add key="ApiPerfilesUrl" value="https://localhost:7175/api" />
  </appSettings>
```

## 🌐 Despliegue en IIS (.NET Framework)
### Requisitos previos
- IIS habilitado en el servidor (Windows)
- .NET Framework instalado (ej. 4.8)
- Proyecto compilado en modo *Release*

---

### 🛠️ Pasos para el despliegue

1. **Publicar el proyecto**
   - En Visual Studio: `Build > Publish` o usa la opción de publicación manual.
   - Selecciona carpeta local como destino.

2. **Copiar archivos al servidor**
   - Copia el contenido de la carpeta publicada (`bin`, `.aspx`, `.dll`, `web.config`, etc.) a una carpeta en el servidor, por ejemplo:  
     `C:\inetpub\wwwroot\MiApp`

3. **Crear el sitio en IIS**
   - Abre el **Administrador de IIS**.
   - Haz clic derecho en “Sitios” > “Agregar sitio web”.
   - Asigna un nombre, selecciona la carpeta física del paso anterior y define el puerto (ej. 8080) o dominio.

4. **Configurar el grupo de aplicaciones**
   - Usa un grupo de aplicaciones con el **.NET CLR v4.0**.
   - Establece el modo de canalización en “Integrado”.

5. **Permisos**
   - Asegúrate de que el usuario `IIS_IUSRS` tenga permisos de lectura y ejecución sobre la carpeta del sitio.

6. **Probar la aplicación**
   - Navega a `http://localhost:8080` o al dominio configurado.
   - Verifica que la app cargue correctamente.
