Create table Customers
(
	customerID int primary key identity,
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
	phoneNumber nvarchar(MAX) not null,
	address nvarchar(MAX) not null,
	createdAt datetime not null
)

Create table Orders
(
	orderID int primary key identity,
	customerID int not null foreign key references Customers(customerID),
	status nvarchar(50) not null check (status in('processing', 'transit', 'delivered')),
	price int not null,
	createdAt datetime not null
)

--insert into Customer(firstName, lastName, phoneNumber, adress) values ('Gonca','Þilik', '5316129966', 'Kaðýthane')
--insert into Customer(firstName, lastName, phoneNumber, adress) values ('Erbil','Þilik', '5316960033', '4.Levent')

--insert into Ordering(customerID, status, price) values (1, 'Teslim Edildi', 15)
--insert into Ordering(customerID, status, price) values (2, 'Teslim Edildi', 10)


















