# Hotel Booking Manager API 🏨
Software de booking de várias redes de hotéis no formato de uma RESTful API com operações de CRUD, autenticação, autorização e cálculo de distância dos hotéis.
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
6)  Extra: você pode usar o comando `docker ps` no terminal para verificar se ambos os containeres estão rodando.

### A aplicação roda por padrão na porta 8080. Portanto certifique-se de que essa porta está livre no seu computador.
### Para fazer requisições à API (usando Postman, Thunder Client ou qualquer serviço semelhante), use o endereço: http://localhost:8080

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
  
## Documentação 📑
## Status
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/753afe50-6566-43c7-b8a6-1a4f95640d35)<br>

## User
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/f3e35903-4cb8-466f-b882-e599b9e7bfea)<br>
### POST
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/5e810837-ef25-45fe-903d-18a4e20c7138)

O corpo da requisição deve seguir o formato:
```
{
	"Name":"Alan Turing",
	"Email": "alan.turing@hotelapi.com",
	"Password": "123456"
}
```
<br>

## Login
### POST
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/d1ecd197-2bbf-4a7b-894e-35ee33e4d2f8)

O corpo da requisição deve seguir o formato:
```
{
	"Email": "alan.turing@hotelapi.com",
	"Password": "123456"
}
```

## Hotel
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/49ba1cee-532c-433e-9e7f-71b12597e25a)<br>
### POST (requer role = admin)
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/406f2252-1f22-4fbb-a07a-7bc43a84b086)

O corpo da requisição deve seguir o formato:
```
{
	"Name":"USS Enterprise Hotel",
	"Address":"Avenida Atlântica, 1400",
	"CityId": 2
}
```
<br>

## City
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/0fbefbb8-27d9-46ca-baf3-b07e43b1240e)<br>
### POST
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/e8095def-f421-4b1e-a864-a7e7e5b5560c)

O corpo da requisição deve seguir o formato:
```
{
	"Name": "São Paulo",
	"State": "SP"
}
```
<br>

### PUT
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/ebbd8152-5f31-4a39-b095-e369b430cb25)<br>

O corpo da requisição deve seguir o formato:
```
{
	"CityId": 1,
	"Name": "São Paulo",
	"State": "SP"
}
```
<br>

## Room
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/454609a9-d20f-4379-a0cc-70058e966ed4)<br>

### POST (requer role = admin)
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/30da28f2-4111-46c8-a29e-e89971269656)

O corpo da requisição deve ter o seguinte formato:
```
{
	"Name":"Suite básica",
	"Capacity":2,
	"Image":"image suite",
	"HotelId": 1
}
```
<br>

### DELETE (requer role = admin)
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/e13670f7-f6ee-4bb9-84dd-b220c327b1ab)
<br>

## Booking
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/77380704-97db-47b9-85ae-73d372943af6)<br>

### POST
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/f30ad0bb-b530-4689-9c61-a286b1f1325e)

O corpo da requisição deve ter o seguinte formato:
```
{
	"CheckIn":"2030-08-27",
	"CheckOut":"2030-08-28",
	"GuestQuant":"1",
	"RoomId":1
}
```
<br>

## GEO/STATUS
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/ce20f2c2-31c8-4da4-b860-079a0a0b2614)<br>

## GEO/ADDRESS
### GET
![image](https://github.com/leomartinsdev/hotel-booking-manager-api/assets/117598788/184c89ee-47ad-40a0-b023-e4f56f5ffa2d)


## Rodando os testes:
1)  Para rodar os testes: `dotnet test`
