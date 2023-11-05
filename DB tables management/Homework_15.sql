CREATE DATABASE "Shop"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE Customers
(
	ID serial NOT NULL
	, FirstName VARCHAR (50) NOT NULL
	, LastName VARCHAR (50) NOT NULL
	, Age INT NOT NULL
	, CONSTRAINT pk_Customers PRIMARY KEY (ID)
);

CREATE TABLE Products
(
	ID serial NOT NULL
	, Name VARCHAR (50) NOT NULL
	, Description TEXT
	, StockQuantity INT
	, PRICE MONEY
	, CONSTRAINT pk_Products PRIMARY KEY (ID)
);

CREATE TABLE Orders
(
	ID serial NOT NULL
	, CustomerID serial
	, ProductID serial
	, Quantity INT
	, CONSTRAINT pk_Orders PRIMARY KEY (ID)
	, CONSTRAINT fk_Orders_Customers FOREIGN KEY (CustomerID)
		REFERENCES Customers (ID) MATCH SIMPLE
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
		NOT VALID
	, CONSTRAINT fk_Orders_Products FOREIGN KEY (ProductID)
		REFERENCES Products (ID) MATCH SIMPLE
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
		NOT VALID
);

INSERT INTO 
	Customers (FirstName, LastName, Age)
VALUES
	('John', 'White', 23)
	, ('Eve', 'Smith', 27)
	, ('Adam', 'Black', 31)
	, ('Silvia', 'Brown', 35)
	, ('Bill', 'Doe', 39)
	, ('Elena', 'Petrova', 43)
	, ('Eric', 'Svensen', 47)
	, ('Yuri', 'Tanaka', 51)
	, ('Hans', 'Ostwald', 55)
	, ('Maria', 'Cordero', 59)

INSERT INTO
	Products (Name, Description, StockQuantity, PRICE)
VALUES
	('Beer','Blue Ribbon Beer 6 Pack, 16 fl oz Cans, Lager, 4.7% ABV', 657, 6.98)
	, ('Bread','Great Value Pre-Sliced Cinnamon Raisin Bread, 16 oz', 1056, 2.38)
	, ('Electronic watch', 'Apple Watch SE (1st Gen) GPS', 95, 129.00)
	, ('T-shirt', 'Gildan - Heavy Cotton Long Sleeve T-Shirt, White - Size: M', 140, 5.98)
	, ('Vitamins', 'Nature''s Way Elderberry Immune Gummies, with Vitamins C, D3, & Zinc, 60 Ct', 177 , 15.72)
	, ('Chicken', 'Foster Farms Fresh & Natural, Young Whole Chicken, 4.2 - 6.3 lb', 246, 8.16)
	, ('Cookies', 'OREO Double Stuf Chocolate Sandwich Cookies, Family Size, 20 oz', 784, 10.45)
	, ('Ketchup', 'Heinz Ketchup and Seemingly Ranch, 19 oz Bottle', 532, 4.12)
	, ('Soda pop', 'Pepsi Soda, 16.9 Fl Oz, 6 Count', 971, 3.78)
	, ('Laundry detergent', 'Tide Liquid Laundry Detergent, 64 Loads 92 fl oz', 327, 12.97)

INSERT INTO
	Orders (CustomerID, ProductID, Quantity)
VALUES
	(1,3,2)
	, (1,4,1)
	, (2,5,3)
	, (2,6,2)
	, (3,7,4)
	, (3,8,3)
	, (4,9,5)
	, (4,10,4)
	, (5,1,6)
	, (5,2,5)
	, (6,3,7)
	, (6,5,6)
	, (7,4,8)
	, (7,6,7)
	, (8,7,9)
	, (8,9,8)
	, (9,9,10)
	, (9,1,9)
	, (10,2,1)
	, (10,4,10)

CREATE
	INDEX Customers_age_idx
	ON Customers (Age)

SELECT
	t1.ID as CustomerID
	, t1.FirstName
	, t1.LastName
	, t2.ID AS ProductID
	, t3.Quantity AS ProductQuantity
	, t2.Price AS ProductPrice
FROM
	Customers AS t1
JOIN
	Orders AS t3
	ON t1.ID = t3.CustomerID
JOIN
	Products AS t2
	ON t2.ID = t3.ProductID
WHERE
	t1.Age > 30
	AND t2.ID = 1