CREATE DATABASE InterviewPerson;
GO

USE InterviewPerson;
GO

CREATE TABLE Person(
	PersonId INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age VARCHAR(5) NOT NULL,
	Phone VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	IsEnabled BIT NOT NULL
);
