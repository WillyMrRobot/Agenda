# Dapper in .net Core

Presentación de Dapper y su ejemplo de funcionamiento en .Net Core

#### Sitio web de Dapper http://dapper-tutorial.net/
#### Sitio web .net Core https://dotnet.github.io/

## Es Dapper un ORM?
¡Si y no! La gente todavía está discutiendo al respecto. Dapper se ha ganado el título de rey de los Micro ORM para C# pero es considerado por varias personas como un simple mapeador de objetos para .NET.

### ¿Dapper es mejor que Entity Framework?
¡Si y no! La gente preferirá Dapper cuando quiera escribir la consulta SQL con un rendimiento óptimo.

![versus](https://user-images.githubusercontent.com/32500709/45932659-16be0280-bf45-11e8-9215-2a5c7a741dfa.gif)

### ¿Son seguras las inyecciones de Dapper SQL?
Sí, es 100% seguro si usa consultas parametrizadas como siempre debería hacer.

![injection](https://user-images.githubusercontent.com/32500709/45932607-46b8d600-bf44-11e8-9173-45c8ede0a577.gif)

### ¿Dapper es compatible con mi proveedor de base de datos?
Probablemente sí, ya que Dapper proporciona extensiones a la interfaz IDbConnection. Es su trabajo escribir el SQL compatible con su proveedor de base de datos.

<img width="247" alt="support" src="https://user-images.githubusercontent.com/32500709/45932491-8ed6f900-bf42-11e8-93c3-7f737c40d4b8.png">
