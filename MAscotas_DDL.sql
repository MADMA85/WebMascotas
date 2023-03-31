
--Mascotas DDL
USE master;  
GO  
CREATE DATABASE Mascotas  
ON   
( NAME = Sales_dat,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Mascotas.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = Sales_log,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Mascotas.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
GO 


Use Mascotas
CREATE TABLE Mascota
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50)  NOT NULL,
    FechaRegistr DATETIME NOT NULL,
    Pedigri bit  NULL,    
	FechaNacimiento DATETIME NULL, 
	Raza VARCHAR(20) NOT NULL,
	EmailResponsable VARCHAR(100) null
);
Go
