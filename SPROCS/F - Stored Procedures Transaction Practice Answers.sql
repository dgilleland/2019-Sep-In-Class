--  Stored Procedures (Sprocs)
-- Practice using Transactions in a Stored Procedure

USE [A01-School]
GO

/*
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'SprocName')
    DROP PROCEDURE SprocName
GO
CREATE PROCEDURE SprocName
    -- Parameters here
AS
    -- Body of procedure here
RETURN
GO
*/

-- 1. Create a stored procedure called DissolveClub that will accept a club id as its parameter. Ensure that the club exists before attempting to dissolve the club. You are to dissolve the club by first removing all the members of the club and then removing the club itself.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'DissolveClub')
    DROP PROCEDURE DissolveClub
GO
CREATE PROCEDURE DissolveClub
    -- Parameters here
    @ClubId     varchar(10)
AS
    -- Body of procedure here
    -- Validatation:
    -- A) Make sure the ClubId is not null
    -- B) Make sure the Club exists
    -- Transaction:
    -- 1) Remove members of the club (from Activity)
    -- 2) Remove the club
RETURN
GO

GO
-- 2. Create a stored procedure called ArchivePayments. This stored procedure must transfer all payment records to the StudentPaymentArchive table. After archiving, delete the payment records.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudentPaymentArchive')
    DROP TABLE StudentPaymentArchive

CREATE TABLE StudentPaymentArchive
(
    ArchiveId       int
        CONSTRAINT PK_StudentPaymentArchive
        PRIMARY KEY
        IDENTITY(1,1)
                                NOT NULL,
    StudentID       int         NOT NULL,
    FirstName       varchar(25) NOT NULL,
    LastName        varchar(35) NOT NULL,
    PaymentMethod   varchar(40) NOT NULL,
    Amount          money       NOT NULL,
    PaymentDate     datetime    NOT NULL
)
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'ArchivePayments')
    DROP PROCEDURE ArchivePayments
GO
CREATE PROCEDURE ArchivePayments
    -- Parameters here
AS
    -- Body of procedure here
RETURN
GO
