IConstruye Demo Hotel es una aplicaci�n ficticia cuya funcionalidad es consultar una API Rest publica con datos de hoteles ficticios. Actualmente la aplicaci�n web contiene la funcionalidad de buscar y presentar los resultados. 
El objetivo de este ejercicio es replicar la funcionalidad de b�squeda (actualmente implementada en el proyecto web) al proyecto API y consumir dicha API desde el proyecto Angular
Requerimientos:
-	dotnet core 3.1 
-	Visual Studio 2019 
La soluci�n actual consta de 3 proyectos:
IConstruye.Demo.Hotel.Api: Proyecto Api en blanco con el artefactos b�sicos para implementar la funcionalidad de b�squeda
IConstruye.Demo.Hotel.Web: Proyecto en Razor Pages totalmente funcional, b�sicamente un cuadro de b�squeda que al enviar el formulario muestra resultados el criterio especificado.
IConstruye.Demo.Hotel.Angular: Proyecto Angular base para implementar componentes de b�squeda y servicios para consumir el API. Se debe reemplazar la variable apiUrl en Environment.ts con el valor del endpoint del proyecto API. Los artefactos deseables de implementar serian: Componentes para el listado de resultados, Servicios para consumir el api, Reactive Form para envi� de formularios, Data Binding para presentar los resultados
