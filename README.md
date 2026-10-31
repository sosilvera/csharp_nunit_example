## Ejemplos NUNIT

Les dejo los ejemplos que vimos en clase sobre NUnit
Para correr los test, ejecutar 

```
dotnet test
```

En la solucion hay tres proyectos:
- ListaApp: contiene el source que se está probando, es una implementación de "Lista"
- TestProject1: Tiene casos para probar Lista, y casos de ejemplo mostrando distintos Asserts
- TestProject2: Es el ejemplo que se genera por default


## Guía: NUnit paso a paso

### 1. Requisitos e instalación de NUnit
Se necesita el [.NET SDK](https://dotnet.microsoft.com/download) instalado. Verificar con:

```
dotnet --version
```

La forma más simple de tener NUnit es crear el proyecto con la plantilla oficial, que ya trae los paquetes necesarios (`NUnit`, `NUnit3TestAdapter`, `Microsoft.NET.Test.Sdk`, `NUnit.Analyzers` y `coverlet.collector`):

```
dotnet new install NUnit3.DotNetNew.Template
```

Si se quiere agregar NUnit a un proyecto existente:

```
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

### 2. Crear el proyecto de casos de prueba
Desde la carpeta de la solución (donde está `ListaApp.sln`):

```
dotnet new nunit -n TestProject1
dotnet sln add TestProject1/TestProject1.csproj
```

El segundo comando agrega el proyecto de tests a la solución.

### 3. Linkear el proyecto de tests con ListaApp
El proyecto de tests necesita una referencia al proyecto que se prueba:

```
dotnet add TestProject1/TestProject1.csproj reference ListaApp/ListaApp.csproj
```

Esto agrega al `TestProject1.csproj`:

```xml
<ItemGroup>
  <ProjectReference Include="..\ListaApp\ListaApp.csproj" />
</ItemGroup>
```

Con eso, desde los tests se puede usar la clase `Lista` de ListaApp. Ejemplo mínimo:

```csharp
public class ListTest
{
    [Test]
    public void ListaNuevaEstaVacia()
    {
        var l = new Lista();
        Assert.That(l.isVoid(), Is.True);
    }
}
```

### 4. Correr los tests
Desde la carpeta de la solución o del proyecto de tests:

```
dotnet test
```

Opciones útiles:

```
dotnet test --filter "Name~ListaNueva"     # solo tests cuyo nombre contenga ese texto
dotnet test --logger "console;verbosity=detailed"   # salida detallada por test
```

### 5. Generar el reporte
**Reporte de resultados (archivo .trx):**

```
dotnet test --logger "trx;LogFileName=resultados.trx" --results-directory ./TestResults
```

**Reporte de cobertura de código** (usa `coverlet.collector`, ya incluido en el proyecto):

```
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
```

Esto genera un archivo `coverage.cobertura.xml` dentro de `TestResults/`.

**Reporte HTML de cobertura** (con ReportGenerator):

```
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"TestResults/html" -reporttypes:Html
```

Luego abrir `TestResults/html/index.html` en el navegador.
