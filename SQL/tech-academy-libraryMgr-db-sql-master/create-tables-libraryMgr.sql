-- Library Manager database drill Create Tables 

CREATE TABLE Book (
	BookID int PRIMARY KEY,
	Title varchar(255) NOT NULL,
	PublisherName varchar(100) NOT NULL
);

CREATE TABLE Book_Authors (
	BookID int PRIMARY KEY,
	AuthorName varchar(255) NOT NULL
);

CREATE TABLE Publisher (
	Name varchar(100) PRIMARY KEY,
	[Address] varchar(255) NULL,
	Phone varchar(20) NULL
);

CREATE TABLE Book_Copies (
	BookID int,
	BranchID int NOT NULL,
	No_Of_Copies int NULL
	CONSTRAINT pk_BookCopyID PRIMARY KEY (BookID, BranchID)
);

CREATE TABLE Book_Loans (
	BookID int NOT NULL,
	BranchID int NOT NULL,
	CardNo int NOT NULL,
	DateOut varchar(20) NOT NULL,
	DueDate varchar(20) NOT NULL
	CONSTRAINT pk_BookLoanID PRIMARY KEY (BookID, BranchID, CardNo)
);

CREATE TABLE Library_Branch (
	BranchID int PRIMARY KEY,
	BranchName varchar(100) NOT NULL,
	[Address] varchar(255) NOT NULL
);

CREATE TABLE Borrower (
	CardNo int PRIMARY KEY,
	Name varchar(100) NOT NULL,
	[Address] varchar(255) NOT NULL,
	Phone varchar(20) NOT NULL
);

SELECT * FROM Book
SELECT * FROM Book_Authors
SELECT * FROM Publisher
SELECT * FROM Book_Copies
SELECT * FROM Book_Loans
SELECT * FROM Library_Branch
SELECT * FROM Borrower