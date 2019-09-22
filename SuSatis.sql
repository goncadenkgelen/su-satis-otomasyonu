Create table Customer
(
	CustomerID int primary key identity,
	firstName nvarchar(50),
	lastName nvarchar(50),
	phoneNumber nvarchar(MAX),
	adress nvarchar(MAX)
)

Create table Ordering
(
	orderID int primary key identity,
	CustomerID int not null foreign key references Customer(CustomerID),
	status nvarchar(50),
	price int
)

insert into Customer(firstName, lastName, phoneNumber, adress) values ('Gonca','Þilik', '5316129966', 'Kaðýthane')
insert into Customer(firstName, lastName, phoneNumber, adress) values ('Erbil','Þilik', '5316960033', '4.Levent')

insert into Ordering(customerID, status, price) values (1, 'Teslim Edildi', 15)
insert into Ordering(customerID, status, price) values (2, 'Teslim Edildi', 10)


















