-- Tạo cơ sở dữ liệu KoiFarmShop
CREATE DATABASE KoiFarmShop;
GO

-- Sử dụng cơ sở dữ liệu KoiFarmShop
USE KoiFarmShop;
GO

-- Tạo bảng Employee
CREATE TABLE Employee (
    IdUser NVARCHAR(100) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Birthday DATE,
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Phone NVARCHAR(15),
    Functions NVARCHAR(50)
);
GO

-- Tạo bảng Customer
CREATE TABLE Customer (
    IdUser NVARCHAR(100) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Birthday DATE,
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Phone NVARCHAR(15)
);
GO

-- Tạo bảng Category
CREATE TABLE Category (
    CategoryID NVARCHAR(100) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO

-- Tạo bảng Product
CREATE TABLE Products (
    ProductID NVARCHAR(100) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Brand NVARCHAR(50),
    Weight FLOAT,
    CategoryID NVARCHAR(100),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);
GO

-- Tạo bảng Order
CREATE TABLE Orders (
    OrderID NVARCHAR(100) PRIMARY KEY,
    IdUser NVARCHAR(100),
    Address NVARCHAR(200),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    FOREIGN KEY (IdUser) REFERENCES Customer(IdUser)
);
GO

-- Tạo bảng OrderDetail
CREATE TABLE OrderDetail (
    OrderID NVARCHAR(100),
    ProductID NVARCHAR(100),
    ProductName NVARCHAR(100),
    Quantity INT,
    Price DECIMAL(18, 2),
    Total AS (Quantity * Price),
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- Tạo bảng KhoHang
CREATE TABLE KhoHang (
    CategoryID NVARCHAR(100),
    ProductID NVARCHAR(100),
    ProductName NVARCHAR(100),
    Quantity INT,
    PRIMARY KEY (CategoryID, ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO
INSERT INTO Employee (IdUser, Name, Birthday, Email, Address, Phone, Functions)
VALUES 
('NV001', 'Nguyen Ngoc Anh', '2005-11-15', 'anhnguyenngoc@gmail.com', '123 Đường A, Thành phố B', '0912345678', 'Manager'),
('NV002', 'Nguyen The Hiep', '1990-08-25', 'hiepnguyen@gmail.com', '456 Đường B, Thành phố C', '0938765432', 'Sales Staff'),
('NV003', 'Nguyen Tan Dat', '1987-12-10', 'dattan@gmail.com', '789 Đường C, Thành phố D', '0972348765', 'Technician');

INSERT INTO Category (CategoryID, CategoryName)
VALUES 
('CAT01', 'Cá Koi Nhật Bản'),
('CAT02', 'Cá Koi Trung Quốc'),
('CAT03', 'Phụ kiện hồ cá'),
('CAT04', 'Thức ăn cho cá');
INSERT INTO Products (ProductID, ProductName, Brand, Weight, CategoryID)
VALUES 
('P001', 'Cá Koi Nhật A', 'KoiBrand', 2.5, 'CAT01'),
('P002', 'Cá Koi Nhật B', 'KoiBrand', 3.0, 'CAT01'),
('P003', 'Cá Koi Trung Quốc A', 'KoiChina', 2.8, 'CAT02'),
('P004', 'Máy lọc nước', 'AquaBrand', 1.2, 'CAT03'),
('P005', 'Thức ăn cao cấp cho cá', 'FishFoodBrand', 0.5, 'CAT04');
INSERT INTO KhoHang (CategoryID, ProductID, ProductName, Quantity)
VALUES 
('CAT01', 'P001', 'Cá Koi Nhật A', 20),
('CAT01', 'P002', 'Cá Koi Nhật B', 15),
('CAT02', 'P003', 'Cá Koi Trung Quốc A', 10),
('CAT03', 'P004', 'Máy lọc nước', 25),
('CAT04', 'P005', 'Thức ăn cao cấp cho cá', 50);
select *from Category;
select *from Products;
select *from Employee;

