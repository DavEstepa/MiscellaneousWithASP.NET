USE master
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MuestrasRadiologicas')
BEGIN
    CREATE DATABASE MuestrasRadiologicas;
    PRINT 'Database created: MuestrasRadiologicas';
END
ELSE
BEGIN
    PRINT 'Database already exists: MuestrasRadiologicas';
END
GO
USE MuestrasRadiologicas;

IF NOT EXISTS (SELECT schema_name FROM information_schema.schemata WHERE schema_name = 'clientes')
BEGIN
    EXEC('CREATE SCHEMA clientes');
    PRINT 'Schema created: clientes';
END
ELSE
BEGIN
    PRINT 'Schema already exists: clientes';
END