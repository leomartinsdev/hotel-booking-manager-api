# Hotel Booking Manager API 🏨
Software de booking de várias redes de hóteis no formato de uma RESTful API com operações de CRUD.
<br><br>
O projeto foi feito utilizando C#, ASP.NET Core, .NET 6.0, SQL Server, Entity Framework Core (ORM) para gerenciamento do banco de dados e dockerizado para fácil execução em qualquer máquina.<br><br>
A autenticação e autorização foi feita com JWT. Os testes estão sendo desenvolvidos usando xUnit.<br><br>


## Feito com 👨‍💻:
- C#
- .NET 6.0
- ASP.NET Core
- Entity Framework Core
- MySQL (o código para migração para MS SQL Server está no projeto)
- Docker
- JWT
- Testes de integração com xUnit
- Arquitetura em Camadas

## Como rodar o projeto:
1)  Clone o repositório;
2)  Entre no diretório do projeto;
3)  Inicie o container do banco de dados: `docker-compose up -d --build`;
4)  Pronto! Toda a aplicação está configurada em um docker de maneira que, ao rodar o comando acima, o Docker: cria um container para o banco de dados, um container para a api (baseada no build da imagem do Dockerfile em src/HotelManagerAPI/), executa as migrations do banco de dados e popula ela usando os Seeders.

5)  Extra: você pode usar o comando `docker ps` no terminal para verificar se ambos os containeres estão rodando.

## Como conectar ao banco no Azure Data Studio (ou outro Database Manager que aceite SQL Server):
- Server: localhost
- user: sa
- password: HotelManager01!

Com isso você pode rodar comandos SQL e visualizar o funcionamento do banco de dados de maneira mais clara.

## Tabelas:
![drawSQL-hotel-manager-api-export-2024-01-16](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/0ee92086-8d1e-4824-85a6-718bc43b8780)
- Cities: armazena um conjunto de cidades nas quais os hotéis estão localizados. Uma cidade pode ter vários hotéis.
- Hotels: armazena os hotéis da aplicação. Um hotel pode ter vários quartos.
- Rooms: armazena os quartos de cada hotel. Um quarto pode ter várias reservas.
- Users: armazena as pessoas usuárias do sistema. Um usuário pode ter várias reservas.
- Bookings: armazena as reservas dos quartos de hotéis.
  
## Documentação (em desenvolvimento):
![Screenshot from 2024-01-16 16-34-00](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/d4e17cfb-c617-4514-8858-f6d4431a0b8b)

## Rodando os testes:
1)  Para rodar os testes: `dotnet test`
