USE [LibraryManager]
GO

/****** Object:  StoredProcedure [dbo].[GetAuthorByBranch]    Script Date: 1/4/2017 4:21:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetAuthorByBranch] @Author VARCHAR(100), @BranchName VARCHAR(25)
AS
	SELECT B.Title, LB.BranchName, BC.No_Of_Copies
	FROM Book AS B INNER JOIN Book_Authors AS BA
	ON B.BookID = BA.BookID
	INNER JOIN Book_Copies AS BC
	ON B.BookID = BC.BookID
	INNER JOIN Library_Branch AS LB
	ON BC.BranchID = LB.BranchID
	WHERE BA.AuthorName = @Author AND LB.BranchName = @BranchName


GO


