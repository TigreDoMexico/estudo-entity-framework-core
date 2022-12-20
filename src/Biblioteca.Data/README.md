# Projeto Biblioteca.Data

## Responsabilidade
Manter as Migrations, os Contexts, a Modelagem e a Manipulação dos dados no Banco de Dados

### Estrutura do Projeto
- /src/Configuration: Configurações de conexão com os Bancos de Dados
- /src/Context: Contextos de conexão com os Bancos de Dados
- /src/Models: Contém os Modelos de Dados do Banco
- /src/Repository: O que é exposto para que outros serviços possam consumir

## Entidades
- Livro
- Autor

## Comandos importantes
- Criar Migration `dotnet ef migrations add Nome_Migration -p [Projeto] -c [Contexto] -o [Pasta]`
- Crar script SQL `dotnet ef migrations script -p [Projeto] -o [Pasta] -i`
- Executar Migration `dotnet ef database update -p [Projeto] -v`
- Remover Migration `dotnet ef migrations remove -p [Projeto]`

## Pacotes/Tools instalados para Migration
```
dotnet tool install --global dotnet-ef --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
```