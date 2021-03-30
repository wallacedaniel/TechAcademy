-- Library Manager database drill --queries exercise
--1 How many copies of the book titled The Lost Tribe are owned by the library branch whose name is"Sharpstown"?

SELECT B.Title, BC.No_Of_Copies, LB.BranchName
FROM Book AS B INNER JOIN Book_Copies AS BC
ON B.BookID = BC.BookID
INNER JOIN Library_Branch AS LB
ON BC.BranchID = LB.BranchID
WHERE B.Title = 'The Lost Tribe' AND LB.BranchName = 'Sharpstown'

--2 How many copies of the book titled The Lost Tribe are owned by each library branch?
SELECT LB.BranchName, B.Title, BC.No_Of_Copies
FROM Library_Branch AS LB INNER JOIN Book_Copies AS BC
ON LB.BranchID = BC.BranchID
INNER JOIN Book AS B
ON BC.BookID = B.BookID
WHERE B.Title = 'The Lost Tribe' 

--3 Retrieve the names of all borrowers who do not have any books checked out.
SELECT * 
FROM Borrower AS BO LEFT JOIN Book_Loans AS BL
ON BO.CardNo = BL.CardNo
WHERE BL.BookID IS NULL

--4 For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, --retrieve the book title, the borrower's name, and the borrower's address.
SELECT B.Title, BO.Name, BO.[Address]
FROM 
Book_Loans AS BL INNER JOIN Borrower AS BO
ON BL.CardNo = BO.CardNo
INNER JOIN Book AS B
ON BL.BookID = B.BookID
WHERE BL.BranchID = 001 AND BL.DueDate = '12/27/2016'

--5 For each library branch, retrieve the branch name and the total number of books loaned out from that branch.

SELECT DISTINCT LB.BranchName, COUNT(BL.BranchId) AS QtyPerBranch
FROM Library_Branch AS LB INNER JOIN Book_Loans AS BL
ON LB.BranchID = BL.BranchID
GROUP BY LB.BranchName, BL.BranchId

--6 Retrieve the names, addresses, and number of books checked out for all borrowers who have more

than five books checked out.
SELECT BO.Name, BO.[Address], COUNT(BL.CardNO) AS QtyBooksOut
FROM Borrower AS BO INNER JOIN Book_Loans AS BL
ON BO.CardNo = BL.CardNo
GROUP BY BO.Name, BO.[Address]
HAVING COUNT(BL.CardNO) > 5;

--7 For each book authored (or co-authored) by "Stephen King", retrieve the title 
--and the number of copies owned by the library branch whose name is "Central"

SELECT B.Title, LB.BranchName, BC.No_Of_Copies
FROM Book AS B INNER JOIN Book_Authors AS BA
ON B.BookID = BA.BookID
INNER JOIN Book_Copies AS BC
ON B.BookID = BC.BookID
INNER JOIN Library_Branch AS LB
ON BC.BranchID = LB.BranchID
WHERE BA.AuthorName = 'Stephen King' AND LB.BranchName = 'Central'





















