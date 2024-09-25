CREATE DATABASE TechShop;
USE TechShop;

CREATE TABLE Customers(
	CustomerID int identity primary key,
	FirstName VARCHAR(50) not null,
	LastName VARCHAR(50) not null,
	Email VARCHAR(50)  not null unique,
	Phone VARCHAR(15),
	Address VARCHAR(100)
);

CREATE TABLE Products(
	ProductID int identity primary key,
	ProductName VARCHAR(50) not null,
	Description Text not null,
	Price Decimal (10,2) not null,
);

CREATE TABLE Orders(
	OrderID int identity primary key,
	CustomerID int not null,
	OrderDate DATETIME not null,
	TotalAmount decimal (10,2) not null,
	Foreign key (CustomerID) references Customers(CustomerID)
);

CREATE TABLE OrderDetails(
	OrderDeatilID int identity primary key,
	OrderID int not null,
	ProductID int not null,
	Quantity int not null,
	Foreign key (OrderID) references Orders(OrderID),
	Foreign key (ProductID) references Products(ProductID)
);

CREATE TABLE Inventory(
	InventoryID int identity primary key,
	ProductID int not null,
	QuantityInStock int not null,
	LastStockUpdate datetime not null,
	Foreign key (ProductID) references Products(ProductID)
);

Insert into Customers(FirstName,LastName,Email,Phone,Address) Values
('Ritik', 'Jha', 'ritik.jha@example.com', '555-1234', 'Jaipur'),
('Riya', 'Sharma', 'riya.sharma@example.com', '555-5678', 'Ajmer'),
('Alice', 'Johnson', 'alice.johnson@example.com', '555-8765', 'Bikaner'),
('Bhanu', 'Bhatt', 'bhanu.bhatt@example.com', '555-4321', 'Pune'),
('Charles', 'Davis', 'charles.davis@example.com', '555-1357', 'Jodhpur'),
('Drishti', 'Goyal', 'drishti.goyal@example.com', '555-2468', 'Mumbai'),
('Priya', 'Sen', 'priya.sen@example.com', '555-3698', 'Delhi'),
('Vinod', 'Gupta', 'vinod.gupta@example.com', '555-1597', 'Noida'),
('Hari', 'Singh', 'hari.singh@example.com', '555-9514', 'Jaipur'),
('Hank', 'Lopez', 'hank.lopez@example.com', '555-7531', 'Bikaner');

Insert into Products(ProductName, Description, Price) Values
('Laptop', 'High performance laptop', 999.99),
('Smartphone', 'Latest model smartphone', 699.99),
('Headphones', 'Noise cancelling headphones', 199.99),
('Smartwatch', 'Waterproof smartwatch', 249.99),
('Tablet', 'Lightweight tablet', 399.99),
('Keyboard', 'Mechanical keyboard', 89.99),
('Mouse', 'Wireless mouse', 49.99),
('Monitor', '27-inch 4K monitor', 499.99),
('Router', 'High-speed router', 149.99),
('Printer', 'Wireless printer', 129.99);

Insert into Orders(CustomerID, OrderDate, TotalAmount) Values
(1, GETDATE(), 1149.97),
(2, GETDATE(), 699.99),
(3, GETDATE(), 199.99),
(4, GETDATE(), 249.99),
(5, GETDATE(), 399.99),
(6, GETDATE(), 89.99),
(7, GETDATE(), 49.99),
(8, GETDATE(), 499.99),
(9, GETDATE(), 149.99),
(10,GETDATE(), 129.99);

Insert into OrderDetails (OrderID, ProductID, Quantity) VALUES
(1, 1, 1),
(1, 3, 1),
(2, 2, 1),
(3, 3, 1),
(4, 4, 1),
(5, 5, 1),
(6, 6, 1),
(7, 7, 1),
(8, 8, 1),
(9, 9, 1);

INSERT INTO Inventory (ProductID, QuantityInStock,LastStockUpdate) VALUES
(1, 50, GETDATE()),
(2, 100, GETDATE()),
(3, 75, GETDATE()),
(4, 60, GETDATE()),
(5, 30, GETDATE()),
(6, 150, GETDATE()),
(7, 200, GETDATE()),
(8, 25, GETDATE()),
(9, 80, GETDATE()),
(10, 90, GETDATE());

select * from Customers;
select * from Products;
select * from Orders;
select * from OrderDetails;
select * from Inventory;
