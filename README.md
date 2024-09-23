# Projeto de Autenticação em Angular & .NET
Este projeto é um teste técnico visando uma aplicação Angular com um backend em .NET que implementa um sistema de autenticação baseado em JWT (JSON Web Token). Ele inclui funcionalidades de login, registro, verificação de e-mail e controle de acesso baseado na verificação de e-mail (usando guards no Angular). 

### Funcionalidades
- Login e Registro: Usuários podem se registrar e logar com suas credenciais.
- Verificação de E-mail: Após o registro, o usuário precisa verificar seu e-mail antes de acessar determinadas páginas.
- Controle de Acesso: Algumas rotas são protegidas por um guard que verifica se o e-mail do usuário foi verificado.
- Exibição de Erros: Um componente toast é utilizado para exibir erros de forma centralizada e estilizada.
- Armazenamento de Token: O token JWT é armazenado no localStorage para persistir a sessão do usuário.

### Tecnologias Utilizadas
- Frontend: Angular
- Reactive Forms
- Guards (Auth Guard)
- Toast Component (para feedback de erros)
- jwt-decode para manipular o token JWT
- Backend: .NET
- API REST com endpoints de autenticação e verificação de e-mail.
- Integração CORS para permitir comunicação entre frontend e backend.
- JWT gerado no backend e enviado ao frontend após login.
- Mailtrap para envio de e-mails.

### Como Funciona
##### Fluxo de Autenticação
- Registro de Usuário: O usuário preenche o formulário de registro. Após submeter, o backend cria o usuário e envia um e-mail de verificação. O token JWT é liberado, mas sem a propriedade ```IsEmailVerified```. Somente essa prop preenchida que dá acesso a rota /home.

- Login de Usuário: O usuário fornece seu e-mail e senha. Após a autenticação, o backend envia um JWT para o frontend. O token contém informações, como se o e-mail do usuário foi verificado. Caso não tenha sido verificado o usuário cai numa página de confirmação de e-mail.

- Guarda de Rotas: Algumas rotas são protegidas por um AuthGuard, que verifica se o usuário está autenticado e se seu e-mail foi verificado. Se não, o usuário é redirecionado para a página de verificação de e-mail ou para o login caso não tenho token salvo no localstorage.

- Toast Component: Quando há erros, como falhas de login ou de registro, o componente de toast é exibido na tela, informando o usuário sobre o problema.

- Swagger: swagger para teste de routas está disponível em localhost:5000/swagger.

##### Testes
- Foram feitos testes unitários e e2e no projeto de backend:
    ```dotnet test```



### Como Rodar o Projeto
##### Requisitos
Node.js (versão 20 ou superior)
Angular CLI
.NET 8 ou superior
SQL Server (docker foi utilizado)
Frontend (Angular)
Domínio para envio de emails

### Instalar dependências:
```
cd /frontend
npm install
```

### Configurar user-secrets dotnet para token do mailtrap:
- configure um user-secret com o token da sua conta Mailtrap com nome `mailtrap_api`
- configure os registros DNS do seu domínio par ao envio de e-mails com Mailtrap (https://mailtrap.io/home)

### Rodar a aplicação:
```
docker start sqlserver
cd backend
dotnet run
cd ../frontend
ng serve
```

A aplicação estará disponível em http://localhost:4200.

