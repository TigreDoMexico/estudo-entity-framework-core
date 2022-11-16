# Estudo EntityFrameworkCore
## Projeto Biblioteca
Sistema Console feito em C# para criação, alteração e deleção de Livros e Autores

### Estrutura do Projeto
- /src/Context: Contém os DbContext e os mapeamentos de entidades para o EntityFrameworkCore
- /src/Models: Contém os modelos das entidades que fazem parte do Domínio
- /src/Services: Contém as lógicas de execução para criação, alteração e deleção dos Modelos

### Como Executar
`dotnet run`

### O que falta fazer
- [] - Transformar o código em Code First
- [] - Ajustar para diferentes bancos de dados
- [] - Inserir a ConnectionString como variável de ambiente
- [] - Desacoplar o Console/Service do Model

> Código desenvolvido e mantido por David Tigre Moraes