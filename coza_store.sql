-- create database
USE master
CREATE DATABASE coza_store
GO
-- 
USE coza_store
GO
-- create tables -----------------------------------------
CREATE TABLE MENU
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NAME NVARCHAR(20),
    LINK NVARCHAR(MAX),
    META NVARCHAR(50),
    HIDE BIT,
    [ORDER] INT,
    DATE_BEGIN SMALLDATETIME,
)

CREATE TABLE CATEGORY
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NAME NVARCHAR(50),
    LINK NVARCHAR(MAX),
    META NVARCHAR(50),
    HIDE BIT,
    [ORDER] INT,
    DATE_BEGIN SMALLDATETIME,
)

CREATE TABLE PRODUCT
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NAME NVARCHAR(50),
    PRICE MONEY,
    IMG NVARCHAR(MAX),
    DESCRIPTION NTEXT,
    COLOR NVARCHAR(20),
    META NVARCHAR(50),
    HIDE BIT,
    [ORDER] INT,
    DATE_BEGIN SMALLDATETIME,
    CATE_ID INT,

    CONSTRAINT FK_PRODUCT_CATEGORY FOREIGN KEY (CATE_ID) REFERENCES CATEGORY(ID),
)

CREATE TABLE BLOG
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NAME NVARCHAR(MAX),
    IMG NVARCHAR(MAX),
    DESCRIPTION NVARCHAR(MAX),
    LINK NVARCHAR(MAX),
    DETAIL NTEXT,
    META NVARCHAR(50),
    HIDE BIT,
    [ORDER] INT,
    DATE_BEGIN SMALLDATETIME,
)


-- insert data --------------------------------------------
INSERT INTO MENU
VALUES
    ('HOME',  NULL, 'home', 0, 1, GETDATE()),
    ('PRODUCT',  NULL, 'product', 0, 1, GETDATE()),
    ('BLOG',  NULL, 'blog', 0, 1, GETDATE()),
    ('ABOUT',  NULL, 'about', 0, 1, GETDATE()),
    ('CONTACT',  NULL, 'contact', 0, 1, GETDATE()),
	('News',NULL,'NEWS',1,1,GETDATE())

-- 

INSERT INTO CATEGORY
VALUES
    ('All Products', NULL, 'all-products', 0, 1, GETDATE()),
    ('Women', NULL, 'women', 0, 1, GETDATE()),
    ('Men', NULL, 'men', 0, 1, GETDATE()),
    ('Bag', NULL, 'bag', 0, 1, GETDATE()),
    ('Shoes', NULL, 'shoes', 0, 1, GETDATE()),
    ('Watches', NULL, 'watches', 0, 1, GETDATE())
-- 

INSERT INTO PRODUCT
VALUES
    ('T-SHIRT 1', 1000, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'RED', 't-shirt-1', 0, 0, GETDATE(), 2),
    ('T-SHIRT 2', 1500, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'YELLOW', 't-shirt-2', 0, 0, GETDATE(), 3),
    ('WATCH 1', 350, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'BLACK', 'watch-1', 0, 0, GETDATE(), 6),
    ('PANT 1', 200, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'BROWN', 'pant-1', 0, 0, GETDATE(), 3),
    ('SHOES 1', 700, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'RED', 'shoes-1', 0, 0, GETDATE(), 5),
    ('SHOES 2', 400, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'BLUE', 'shoes-2', 0, 0, GETDATE(), 5),
    ('WATCH 2', 1000, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'WHITE', 'watch-2', 0, 0, GETDATE(), 6),
    ('T-SHIRT 3', 600, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'BLUE', 't-shirt-3', 0, 0, GETDATE(), 2),
    ('SHIRT 1', 450, NULL,
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ullamcorper mauris sed erat luctus, non molestie felis mattis. Nulla gravida et urna ac vulputate. In consectetur tortor ac ornare vestibulum. Nullam maximus sagittis neque rhoncus rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur eu euismod mauris, malesuada gravida elit. Suspendisse in laoreet eros. In pharetra velit et nunc ultrices pellentesque nec id eros. Etiam non posuere nisl, quis convallis nibh. Vestibulum lacus leo, efficitur et suscipit quis, mattis quis orci. Etiam aliquam, sem quis viverra tincidunt, elit dui condimentum quam, eu finibus libero sem in massa. Pellentesque feugiat tortor a malesuada hendrerit. Maecenas mattis et dolor a cursus. Etiam non mauris malesuada, consequat arcu eu, condimentum leo.',
    'RED', 'shirt-1', 0, 0, GETDATE(), 2)
-- 

SELECT * FROM PRODUCT

SELECT * FROM MENU