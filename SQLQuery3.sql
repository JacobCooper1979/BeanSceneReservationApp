USE master;
GO

-- Drop the database if it exists
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BeanSeanReservationSystemsDBTest3')
    DROP DATABASE BeanSeanReservationSystemsDBTest3;
GO

-- Create the database
CREATE DATABASE BeanSeanReservationSystemsDBTest3;
GO

-- Switch to the new database context
USE BeanSeanReservationSystemsDBTest3;
GO


-- Create the Areas table
CREATE TABLE Areas (
    AreaID INT PRIMARY KEY IDENTITY(1,1),
    AreaName VARCHAR(50) NOT NULL,
    Capacity INT NOT NULL,
    CONSTRAINT chk_AreaName CHECK (AreaName IN ('Main', 'Outdoors', 'Balcony'))
);

-- Insert areas into Areas table
INSERT INTO Areas (AreaName, Capacity) VALUES
('Main', 100),
('Outdoors', 50),
('Balcony', 30);

