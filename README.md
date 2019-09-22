# Su Satış Otomasyonu

## Su Satış Otomasyonu Nedir?

C#, Entity Framework ve Winform ile geliştirilen bir su satış yönetim uygulamasıdır. 

## Tablo (Entity) Yapısı

![Image of Yaktocat](https://github.com/goncasilik/su-satis-otomasyonu/blob/master/veritabanı.png

## SQL Sorguları
```
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
```

## Uygulama Görüntüleri
![Image of Yaktocat](https://github.com/goncasilik/su-satis-otomasyonu/blob/master/musteri.png)
![Image of Yaktocat](https://github.com/goncasilik/su-satis-otomasyonu/blob/master/SuSatis-MüsteriEkle.png)
![Image of Yaktocat](https://github.com/goncasilik/su-satis-otomasyonu/blob/master/siparis.png)
