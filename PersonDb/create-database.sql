-- CREATE DATABASE [product-db]
-- GO
-- 
-- USE [product-db];
-- GO
-- 
-- CREATE TABLE product (
--  Id INT NOT NULL IDENTITY,
--  Name TEXT NOT NULL,
--  Description TEXT NOT NULL,
--  PRIMARY KEY (Id)
-- );
-- GO
-- 
-- INSERT INTO [product] (Name, Description)
-- VALUES 
-- ('T-Shirt Blue', 'Its blue'),
-- ('T-Shirt Black', 'Its black'); 
-- GO



CREATE DATABASE [Persons]
GO

USE [Persons];
GO

CREATE TABLE [dbo].[Persons]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[FirstName] NVARCHAR (MAX) NOT NULL,
	[LastName] NVARCHAR (MAX) NOT NULL,
	[SSN] NVARCHAR (MAX) NOT NULL,
	[InsertDte_sys] DATETIME2 (7) NOT NULL,
	[DOB_sys] DATE NOT NULL,
	[WorkStartsAt_sys] TIME (7) NOT NULL,
	[CurrentTime_sys] DATETIMEOFFSET (7) NOT NULL,
	CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO Persons
	(
	--[Id]
	[FirstName],[LastName],[SSN],[InsertDte_sys],[DOB_sys],[WorkStartsAt_sys],[CurrentTime_sys]
	)

VALUES
	('kevin', 'bowe', '111001111', '2024-06-12 13:53:36.9589110', '1957-08-22', '13:53:36.9589180', '2024-06-25 11:07:03.6201110 -04:00'),
	('nevik', 'ewob', '000110000', '2024-06-12 13:53:36.9589110', '2024-08-17', '13:53:36.9589180', '2024-06-25 11:07:03.6201110 -04:00'),
	('kkk', 'bbb', '333224444', '2024-06-12 13:53:36.9589110', '1900-01-01', '13:53:36.9589180', '2024-06-25 11:07:03.6201110 -04:00');
GO