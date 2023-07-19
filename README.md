#Descrição

Este é um projeto de catálogo de veículos que utiliza React no frontend e .NET Core no backend. 
O frontend foi desenvolvido com o auxílio do React Router para lidar com a navegação entre páginas,
e o backend foi construído como uma API RESTful para gerenciar os veículos e a autenticação administrativa utilizando tokens JWT.
O banco de dados SQLite é utilizado para armazenar os veículos e as credenciais dos usuários.

git clone https://github.com/Zampiva/catologo-c-.git
cd catologo-veiculos/CatalogoVeiculos.API

Configure o banco de dados SQLite:

  Abra o arquivo appsettings.json no diretório CatalogoVeiculos.API.
  Verifique e atualize a string de conexão do banco de dados, se necessário.


Execute o backend:
dotnet run

Configuração do Frontend

  No diretório raiz do projeto, instale as dependências do frontend:
  cd catologo-veiculos
  npm install

Execute o frontend:
  npm start

O frontend será executado em http://localhost:3000

Uso

    Abra o navegador e acesse http://localhost:3000.
    Você será redirecionado para a página de login.
    Faça o login como administrador (com credenciais previamente cadastradas no banco de dados) para acessar as funcionalidades do catálogo de veículos.
    Após o login, você será redirecionado para a página de listagem de veículos.
    Na página de listagem de veículos, você pode visualizar, criar, editar e excluir registros de veículos.
    Para fazer logout, clique no botão "Logout" na parte superior da página.

Instalar as dependências do backend:
 cd catologo-veiculos/CatalogoVeiculos.API
 dotnet restore

Executar o backend:
 dotnet run


Como o Backend se Relaciona com o Frontend

O frontend é uma aplicação React que se comunica com o backend por meio de chamadas HTTP para a API RESTful. 
O backend é desenvolvido com .NET Core e fornece os endpoints necessários para o frontend realizar operações no banco de dados SQLite,
como listagem, criação, edição e exclusão de veículos.

Quando o usuário faz login no frontend, as credenciais são enviadas para o backend, onde são verificadas no banco de dados. 
Se as credenciais estiverem corretas, o backend gera um token JWT e o retorna ao frontend. 
Esse token é armazenado no armazenamento local (localStorage) do navegador e é incluído em todas as chamadas subsequentes do frontend para o backend como uma forma de autenticação.

Assim, o frontend e o backend trabalham juntos para fornecer um catálogo de veículos funcional, 
com autenticação administrativa e persistência de dados usando o banco de dados SQLite no backend.

