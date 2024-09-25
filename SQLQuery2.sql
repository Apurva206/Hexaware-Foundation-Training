-- Task2:
Use TechShop;
-- 1. Query to retrieve the names and emails of all customers
Select FirstName, LastName, Email from Customers;

--2. Query to list all orders with their order dates and corresponding customer names
Select OrderID, OrderDate, FirstName, LastName
from Orders, Customers
Where
Orders.CustomerID=Customers.CustomerID;

--3. Query to insert a new customer record into the "Customers" table.
Insert into Customers(FirstName, LastName,Email,Phone,Address) values
('Sonu','Singh','sonu.singh@example.com','555-456','Jaipur');
Select * from Customers;

--4. Query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
update Products
set price=price*1.10
select Price from Products;

--5. query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" 
Declare @OrderID int = 5

Delete from Orders
where OrderID=@OrderID;

Delete from OrderDetails
where OrderID=@OrderID;

Select * from Orders;
select * from OrderDetails;

--6. Query to insert a new order into the "Orders" table.
Insert into Orders Values (1, GETDATE(), 349.99);
select * from Orders;

--7. query to update the contact information (e.g., email and address) of a specific customer in the "Customers"
Update Customers
set Email = 'alice.johnson123@example.com'
where CustomerID=3
select * from Customers;

--8. query to recalculate
UPDATE Orders
SET TotalAmount = (
    SELECT SUM(Quantity * Price)
    FROM OrderDetails
    JOIN Products ON OrderDetails.ProductID = Products.ProductID
    WHERE OrderDetails.OrderID = Orders.OrderID
);
select * from Orders

--9. L query to delete all orders and their associated order details for a specific customer
declare @CustomerID int = 4

delete from Orders
where CustomerID = @CustomerID

delete from OrderDetails
where OrderID in (select OrderID from Orders where CustomerID = @CustomerID)

select * from Orders;
select * from OrderDetails;

--10.  query to insert a new electronic gadget product into the "Products" 
insert into Products values ('Apple Watch','waterproof','20000.99');
select * from Products;

--11. query to update the status of a specific order
ALTER TABLE Orders
ADD Status VARCHAR(20);

UPDATE Orders
SET Status = 'Shipped'

update Orders
set status = 'pending'
where OrderID = 7
select * from Orders

