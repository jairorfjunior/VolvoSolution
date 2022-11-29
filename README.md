# VolvoSolution

Meu nome é Jairo Junior , sou candidato para vaga de Professional Software Engineer da Volvo

Primeiramente execute o comando para clonar o código fonte.

Abra o Prompt de Comando CMD e digite o código abaixo

mkdir C:\projetos

cd projetos

git clone https://github.com/jairorfjunior/VolvoSolution.git

Abra o projeto VolvoSolution.sln

No arquivo VolvoContext existe o comando  Database.EnsureCreated() para criar automaticamente a base de dados.


Outra forma seria utilizar os comandos do Migration

Package Manager Console

Selecione o Projeto Infrastructure

Execute o comando abaixo para criar a migração

PM> Add-Migration Initial

Use o comando a seguir para criar ou atualizar o esquema de banco de dados.

PM> Update-database


Para efetuar os testes continue com o Package Manage Console aberto

Selecione o projeto Tests e digite abaixo

PM> dotnet test

