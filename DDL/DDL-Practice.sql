/* **********************************************
 * Simple Table Creation - Columns and Primary Keys
 *
 * File: DDL-Practice.sql
 * Emergency Service & Product
 * Specification Document 1
 * Version 0.0.7
 *
 * Author: Dan Gilleland
 ********************************************** */
-- Select the CREATE DATABASE stement below to create the demo database.
-- CREATE DATABASE [ESP-A01]
USE [ESP-A01] -- this is a statement that tells us to switch to a particular database
-- Notice in the database name above, it is "wrapped" in square brackets because 
-- the name had a hypen in it. 
-- For all our other objects (tables, columns, etc), we won't use hypens or spaces, so
-- the use of square brackets are optional.
GO  -- this statement helps to "separate" various DDL statements in our script
    -- so that they are executed as "blocks" of code.

-- TIP: To refresh this script's knowledge of the DB, Press [ctrl] + [shift] + r

-- To create a database table, we use the CREATE TABLE statement.
-- Note that the order in which we create/drop tables is important
-- because of how the tables are related via Foreign Keys.
/* DROP TABLE statements (to "clean up" the database for re-creation)  */
/*   You should drop tables in the REVERSE order in which you created them */
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PaymentLogDetails')
    DROP TABLE PaymentLogDetails
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Payments')
    DROP TABLE Payments
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OrderDetails')
    DROP TABLE OrderDetails
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'InventoryItems')
    DROP TABLE InventoryItems
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders')
    DROP TABLE Orders
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Customers')
    DROP TABLE Customers

-- To create a database table, we use the CREATE TABLE statement.
-- Note that the order in which we create/drop tables is important
-- because of how the tables are related via Foreign Keys.
-- Note that square brackets around identifiers is a common standard
-- in writing SQL.
-- Databases in SQL group all their contents into something called
-- a "schema". Each database can have one or more schemas.
-- The default schema name is [dbo].
-- Schema names are applied to top-level objects, like tables names.
CREATE TABLE [dbo].[Customers]
(
    -- The body of a CREATE TABLE will identify a comma-separated list of
    -- Column Declarations and Table Constraints.
    [CustomerNumber]  int
        -- The following is a PRIMARY KEY constraint that has a specific name
        -- Primary Key constraints ensure a row of data being added to the table
        -- will have to have a unique value for the Primary Key column(s)
        CONSTRAINT PK_Customers_CustomerNumber
            PRIMARY KEY
        -- IDENTITY means the database will generate a unique whole-number
        -- value for this column
        IDENTITY(100, 1) -- The first number is the "seed",
                         -- and the last number is the "increment"
                                          NOT NULL, -- NOT NULL means the data is required
    [FirstName]       varchar(50)         NOT NULL,
    [LastName]        varchar(60)         NOT NULL,
    [Address]         varchar(40)         NOT NULL,
    [City]            varchar(35)         NOT NULL,
    [Province]        char(2)
        -- A DEFAULT constraint will supply a default value for a column
        -- whenever no value is supplied when adding a row of data
        CONSTRAINT DF_Customers_Province
            DEFAULT ('AB')
        -- A CHECK constraint ensures that only the specified value(s)
        -- will be accepted when adding a row of data
        CONSTRAINT CK_Customers_Province
           CHECK    (Province = 'AB' OR
                     Province = 'BC' OR
                     Province = 'SK' OR
                     Province = 'MB' OR
                     Province = 'QC' OR
                     Province = 'ON' OR
                     Province = 'NT' OR
                     Province = 'NS' OR
                     Province = 'NB' OR
                     Province = 'NL' OR
                     Province = 'YK' OR
                     Province = 'NU' OR
                     Province = 'PE')
                                          NOT NULL,
    [PostalCode]      char(6)
        CONSTRAINT CK_Customers_PostalCode
            CHECK (PostalCode LIKE '[A-Z][0-9][A-Z][0-9][A-Z][0-9]')
                                          NOT NULL,
    [PhoneNumber]     char(13)
        CONSTRAINT CK_Customers_PhoneNumber
            CHECK (PhoneNumber LIKE
                   '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')
                                              NULL  -- NULL means the data is optional
)

CREATE TABLE Orders
(
    OrderNumber     int
        CONSTRAINT PK_Orders_OrderNumber
            PRIMARY KEY
        IDENTITY(200, 1)                NOT NULL,
    CustomerNumber  int
        -- Foreign Key constraints ensure that when a row of data is being
        -- inserted or updated, there is a row in the referenced table
        -- that has the same value as its Primary Key
        CONSTRAINT FK_Orders_CustomerNumber_Customers_CustomerNumber
            FOREIGN KEY REFERENCES
            Customers(CustomerNumber)   NOT NULL,
    [Date]          datetime            NOT NULL,
    Subtotal        money               
        CONSTRAINT CK_Orders_Subtotal
            CHECK (Subtotal > 0)
                                        NOT NULL,
    GST             money
        CONSTRAINT CK_Orders_GST
            CHECK (GST >= 0)            
                                        NOT NULL,
    Total           AS Subtotal + GST   -- This is now a Computed Column
)

CREATE TABLE InventoryItems
(
    ItemNumber          varchar(5)
        CONSTRAINT PK_InventoryItems_ItemNumber
            PRIMARY KEY                     NOT NULL,
    ItemDescription     varchar(50)             NULL,
    CurrentSalePrice    money
        CONSTRAINT CK_InventoryItems_CurrentSalePrice
            CHECK (CurrentSalePrice > 0)    NOT NULL,
    InStockCount        int                 NOT NULL,
    ReorderLevel        int                 NOT NULL
)

CREATE TABLE OrderDetails
(
    OrderNumber     int
        CONSTRAINT FK_OrderDetails_OrderNumber_Orders_OrderNumber
            FOREIGN KEY REFERENCES
            Orders(OrderNumber)         NOT NULL,
    ItemNumber      varchar(5)
        CONSTRAINT FK_OrderDetails_ItemNumber_InventoryItems_ItemNumber
            FOREIGN KEY REFERENCES
            InventoryItems(ItemNumber)  NOT NULL,
    Quantity        int
        CONSTRAINT DF_OrderDetails_Quantity
            DEFAULT (1)
        CONSTRAINT CK_OrderDetails_Quantity
            CHECK   (Quantity > 0)
                                        NOT NULL,
    SellingPrice    money
        CONSTRAINT CK_OrderDetails_SellingPrice
            CHECK (SellingPrice >= 0)   NOT NULL,
    Amount          AS Quantity * SellingPrice  ,
    -- The following is a Table Constraint
    -- A composite primary key MUST be done as a Table Constraint
    -- because it involves two or more columns
    CONSTRAINT PK_OrderDetails_OrderNumber_ItemNumber
        PRIMARY KEY (OrderNumber, ItemNumber) -- Specify all the columns in the PK
)

/* ==================== Practice SQL Below =================== */
