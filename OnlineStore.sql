create database OnlineStore
go
create table Category(
CategoryId int primary key identity(1,1),
Code int,
Title Nvarchar(20))
go
create table product(
ProductId int primary key identity(1,1),
ProductName Nvarchar(20),
ProductCode int,
Amount int,
UnitPrice money,
Price As Amount * UnitPrice,

CategoryId int FOREIGN KEY REFERENCES Category(CategoryId))
go