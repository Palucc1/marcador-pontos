# Cadastro de Pontos de Basquete - Aplicação

Esta aplicação permite o cadastro de pontos realizados em uma partida de basquete e o acompanhamento de resultados. Ela utiliza Angular 18.2 no frontend, .NET 9 no backend e SQL Server 2022 como banco de dados.

## Requisitos

### Para rodar a aplicação, você precisará de:

- **Node.js** (versão 16 ou superior) - Para rodar o Angular no frontend.
- **Angular CLI** (versão 18.2 ou superior) - Ferramenta para rodar o frontend.
- **.NET SDK** (versão 9.0 ou superior) - Para rodar o backend.
- **SQL Server 2022** - Para o banco de dados.
- **SQL Server Management Studio (SSMS)** (opcional) - Para gerenciar e consultar o banco de dados.

## Download do projeto e configuração

### 1. Clonar projetos

#### Passo 1: Clonar os projetos
Abra o cmd do git e clone o projeto com o comando: git clone https://github.com/Palucc1/marcador-pontos.git

## Instalação

### 1. Instalar Dependências do Frontend (Angular)

#### Passo 1: Instalar o Node.js
Baixe e instale o [Node.js](https://nodejs.org/).

#### Passo 2: Instalar o Angular CLI
Abra o terminal e execute o seguinte comando para instalar o Angular CLI globalmente:

bash
npm install -g @angular/cli@18.2

#### Passo 3: Instalar as demais dependências do projeto
Abra o terminal dentro da pasta 'Frontend\marcador-pontos' e rode o seguinte comando:

npm install --save

#### Passo 4: Rodar o projeto
Para iniciar o servidor de desenvolvimento angular, execute no terminal do seu editor de códigos(VSCode, por exemplo):

ng serve -o

Isso iniciará o frontend na URL http://localhost:4200.

### 2. Instalar Dependências do Backend (.NET)

#### Passo 1: Instalar o .NET SDK
Baixe e instale o .NET SDK 9.0.

#### Passo 2: Restaurar as Dependências do Backend
Na pasta do projeto rode o seguinte comando: 

dotnet restore

#### Passo 3: Abrir projeto
Para buildar o projeto (via linha de comando), executar o comando:

dotnet run

Ou utilize a IDE de sua preferência. Isso iniciará o backend na URL http://localhost:5062 
(outras configurações de portas utilizadas estão no arquivo 'launchSettings.json', na pasta 'Properties').

### 3. Baixar e configurar o banco de dados (SQL Server)

### Passo 1: Instalar o SQL Server 2022
Baixe e instale o SQL Server 2022 ou use uma versão anterior compatível.

### Passo 2: Configuração do Banco de Dados
No backend, a string de conexão está configurada para realizar um acesso usando credenciais padrão para um banco local. 
Caso necessite de configurações adicionais, ajustar a connection string no arquivo 'appSettings.json'.

### Passo 3: Aplicação das migrations e criação do banco de dados
Também no backend, abrir o 'Package Manager Console' (Tools > Nuget Package Manager > Package Manager Console). Uma vez
aberto, mudar o 'Default Project' para o projeto 'Repository' e executar o seguinte comando:

update-database

Esse comando criará a base 'RegistroPartidas' e aplicará as migrations do projeto, criando a tabela 'Partidas'

## Estrutura do Projeto

### Frontend (Angular)

- src/app/components: Contém os componentes 'apps' utilizados como raíz da interface do usuário.

- src/app/services: Contém serviços que se comunicam com o backend.

- src/app/entities: Contém as definições de modelos de dados para a aplicação.

- src/app/dtos: Contém as definições de 'Data Transfer Objects' para a aplicação.

- src/app/utils: Contém os arquivos com funções de uso geral.

- src/app/pages: Contém os componentes de interface.

### Backend (.NET)

- Presentation: Contém os controladores que gerenciam as requisições HTTP, além de arquivos de configuração.

- Application: Contém classes e interfaces que tratam de regras envolvendo mais de uma entidade.

- Domain: Classe de domínio, contém as principais regras do projeto, os modelos de dados, de serviço e também de testes.

- Repository: Contém as configurações de acesso ao banco de dados, incluindo migrations, classes de contexto, repositório e a classe que trata da gestão de dependências.

### Banco de Dados (SQL Server)

- Tabela de Partidas: Armazena os dados das partidas de basquete.