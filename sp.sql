USE Refreshment_Tour
GO

IF OBJECT_ID('sp_InsertMember', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertMember
GO

CREATE PROCEDURE sp_InsertMember
    @Name NVARCHAR(50),
    @RollNo NVARCHAR(20),
    @CourseId INT,
    @Amount DECIMAL(18,2),
    @PaymentDone BIT,
    @Image NVARCHAR(200) = NULL,
    @EventId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Members (Name, RollNo, CourseId, Amount, PaymentDone, Image, EventId)
    VALUES (@Name, @RollNo, @CourseId, @Amount, @PaymentDone, @Image, @EventId);

    SELECT SCOPE_IDENTITY() AS MemberId;
END
GO


IF OBJECT_ID('sp_UpdateMember', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateMember
GO

CREATE PROCEDURE sp_UpdateMember
    @MemberId INT,
    @Name NVARCHAR(50),
    @RollNo NVARCHAR(20),
    @CourseId INT,
    @Amount DECIMAL(18,2),
    @PaymentDone BIT,
    @Image NVARCHAR(200) = NULL,
    @EventId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Members
    SET Name = @Name,
        RollNo = @RollNo,
        CourseId = @CourseId,
        Amount = @Amount,
        PaymentDone = @PaymentDone,
        Image = @Image,
        EventId = @EventId
    WHERE MemberId = @MemberId;
END
GO

IF OBJECT_ID('sp_DeleteMember', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteMember
GO

CREATE PROCEDURE sp_DeleteMember
    @MemberId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Members
    WHERE MemberId = @MemberId;
END
GO