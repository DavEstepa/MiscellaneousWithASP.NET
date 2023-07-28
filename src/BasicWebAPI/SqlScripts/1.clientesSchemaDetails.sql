USE MuestrasRadiologicas

CREATE TABLE clientes.[BasicInformation]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL,
    [Document] NVARCHAR(20) NOT NULL,
    [Address] NVARCHAR(30) NOT NULL,
    [PdfBase64] NVARCHAR(MAX)             --Pdf encrypted in base64 result from API
);
GO

--Stored Procedures

CREATE PROCEDURE clientes.sp_clientes_BasicInformation_Insert
(
    @Name NVARCHAR(100),
    @Document NVARCHAR(20),
    @Address NVARCHAR(30),
    @PdfBase64 NVARCHAR(MAX) = NULL
)
AS
BEGIN

    DECLARE @Id GUID = NEWID()
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO clientes.[BasicInformation] ([Id], [Name], [Document], [Address], [PdfBase64])
        VALUES (@Id, @Name, @Document, @Address, @PdfBase64);

        COMMIT TRANSACTION;

        SELECT * FROM clientes.[BasicInformation]
        WHERE [Id] = @Id
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE clientes.sp_clientes_BasicInformation_GetByDocument
(
    @Document NVARCHAR(20)
)
AS
BEGIN
    SELECT * FROM clientes.[BasicInformation]
    WHERE [Document] = @Document
END;