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
    IF @ClubId IS NULL
    BEGIN
        RAISERROR('ClubId is required', 16, 1)
    END
    ELSE
    BEGIN
        -- B) Make sure the Club exists
        IF NOT EXISTS(SELECT ClubId FROM Club WHERE ClubId = @ClubId)
        BEGIN
            RAISERROR('That club does not exist', 16, 1)
        END
        ELSE
        BEGIN
            -- Transaction:
            BEGIN TRANSACTION -- Starts the transaction - everything is temporary
            -- 1) Remove members of the club (from Activity)
            DELETE FROM Activity WHERE ClubId = @ClubId
            IF @@ERROR <> 0 -- then there's a problem with the delete
            BEGIN
                ROLLBACK TRANSACTION -- Ending/undoing any temporary DML statements
                RAISERROR('Unable to remove members from the club', 16, 1)
            END
            ELSE
            BEGIN
                -- 2) Remove the club
                DELETE FROM Club WHERE ClubId = @ClubId
                IF @@ERROR <> 0 OR @@ROWCOUNT = 0 -- there's a problem
                BEGIN
                    ROLLBACK TRANSACTION
                    RAISERROR('Unable to delete the club', 16, 1)
                END
                ELSE
                BEGIN
                    COMMIT TRANSACTION -- Finalize all the temporary DML statements
                END
            END
        END
    END
RETURN
GO
-- To test the stored procedure, look for clubs and members
SELECT * FROM Club AS C LEFT OUTER JOIN Activity AS A ON C.ClubId = A.ClubId
-- I found the CIPS club with no members and the ACM club with lots of members
EXEC DissolveClub 'CIPS' -- Should succeed
EXEC DissolveClub 'ACM'  -- Should succeed
EXEC DissolveClub 'CIPS' -- Should fail, because the club does not exist
EXEC DissolveClub NULL   -- Should fail, because a club id is required

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
    BEGIN
        BEGIN TRANSACTION -- Temporary until committed
        -- Insert into StudentPaymentArchive()
        INSERT INTO StudentPaymentArchive(StudentID, FirstName, LastName, PaymentDate, PaymentMethod, Amount)
        SELECT  S.StudentID, FirstName, LastName, PaymentDate, PaymentTypeDescription, Amount
        FROM    Student AS S
            INNER JOIN Payment AS P
                ON S.StudentID = P.StudentID
            INNER JOIN PaymentType AS PT
                ON P.PaymentTypeID = PT.PaymentTypeID
        IF @@ERROR > 0
        BEGIN
            ROLLBACK TRANSACTION -- backing out of transaction
            RAISERROR('Unable to archive student payments', 16, 1)
        END
        ELSE
        BEGIN
            -- Delete from Payment
            DELETE FROM Payment
            IF @@ERROR > 0
            BEGIN
                ROLLBACK TRANSACTION -- back out and undo any changes since beginning
                RAISERROR('Unable to delete payments after archiving', 16, 1)
            END
            ELSE
            BEGIN
                COMMIT TRANSACTION -- Accept & finalize all changes to DB
            END
        END
    END
RETURN
GO

-- Test the Stored Procedure
SELECT * FROM Payment
SELECT * FROM StudentPaymentArchive
-- Run the stored procedure
EXEC ArchivePayments
-- See what data is in AFTER running the stored procedure
SELECT * FROM Payment
SELECT * FROM StudentPaymentArchive
