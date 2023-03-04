CREATE TABLE categories(
	category_id INT PRIMARY KEY IDENTITY(1,1), 
	category_name NVARCHAR(150) NOT NULL);

CREATE TABLE manufacturers(
	manufacturer_id int PRIMARY KEY IDENTITY(1,1), 
	manufacturer_name NVARCHAR(150) NOT NULL);

CREATE TABLE warehouses(
	stock_id INT PRIMARY KEY IDENTITY(1,1),
	stock_address NVARCHAR(200) NOT NULL);

CREATE TABLE products(
	product_id INT PRIMARY KEY IDENTITY(1,1),
	product_name NVARCHAR(255) NOT NULL,
	stock_id INT NOT NULL,
	manufacturer_id INT NOT NULL,    
	category_id INT NOT NULL,
	product_count INT default 0,
	product_price DECIMAL(9,2) default 0,
FOREIGN KEY (stock_id) REFERENCES warehouses (stock_id),
FOREIGN KEY (category_id) REFERENCES categories (category_id),
FOREIGN KEY (manufacturer_id) REFERENCES manufacturers (manufacturer_id));



CREATE TABLE price_change(
	product_id INT NOT NULL,
	date_price_change DATE default CONVERT(date, GETDATE()),
	new_price DECIMAL(9,2) NOT NULL,
CONSTRAINT PK_PRICE_CHANGE PRIMARY KEY (product_id, date_price_change),  
FOREIGN KEY (product_id) REFERENCES products (product_id));

CREATE TABLE deliveries(
	product_id INT NOT NULL,
	stock_id INT NOT NULL,
	delivery_date DATE NOT NULL,
	product_count INT NOT NULL,
FOREIGN KEY (product_id) REFERENCES products (product_id),
FOREIGN KEY (stock_id) REFERENCES warehouses (stock_id));

CREATE TABLE customers(
	customer_id INT PRIMARY KEY IDENTITY(1,1),
	customer_phone NVARCHAR(20) NOT NULL,
	customer_password NVARCHAR(50) NOT NULL,
	customer_first_name NVARCHAR(50) NULL,
	customer_last_name NVARCHAR(50) NULL,
	customer_address NVARCHAR(200) NULL);

CREATE TABLE purchases(
	purchase_id INT PRIMARY KEY IDENTITY(1,1),
	customer_id INT NOT NULL,
	purchase_date DATETIME default GETDATE(),
FOREIGN KEY (customer_id) REFERENCES customers (customer_id));

CREATE TABLE purchase_items(
	purchase_id INT NOT NULL,
	product_id INT NOT NULL,
	product_count INT NOT NULL,
	product_price DECIMAL(9,2) NOT NULL,
CONSTRAINT PK_PURCHASE_ITEMS PRIMARY KEY (purchase_id, product_id),  
FOREIGN KEY (product_id) REFERENCES products (product_id),
FOREIGN KEY (purchase_id) REFERENCES purchases (purchase_id));

CREATE TABLE shopping_cart(
	customer_id INT NOT NULL,
	product_id INT NOT NULL,
	product_count INT default 0,
	product_price DECIMAL(9,2) default 0.00,
FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
FOREIGN KEY (product_id) REFERENCES products (product_id));

CREATE TABLE status_of_purchase(
	purchase_id INT NOT NULL,
	purchase_status NVARCHAR(20) default 'in process',
FOREIGN KEY (purchase_id) REFERENCES purchases (purchase_id));

CREATE TABLE filters(
	category_id INT NOT NULL,
	filter_id int identity(1,1),
	filter_name NVARCHAR(100) NOT NULL,
CONSTRAINT PK_FILTERS PRIMARY KEY (category_id, filter_id),
FOREIGN KEY (category_id) REFERENCES categories (category_id));