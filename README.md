# WebAppMVC Demo

Ejemplo de aplicación **ASP WEB FORMS** que consume una **API REST de PERFILES, S. A.**.

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

## 🌐 Despliegue en IIS