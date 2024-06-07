-- Sample data for Areas table
INSERT INTO Areas (AreaName, Capacity)
VALUES
    ('Main Dining Area', 50),
    ('Outdoor Patio', 30);


-- Sample data for Members table
INSERT INTO Members (FirstName, LastName, Email, Password, Phone, RegistrationDate)
VALUES
    ('John', 'Doe', 'john@example.com', 'password123', '1234567890', '2024-01-01'),
    ('Jane', 'Smith', 'jane@example.com', 'password456', '0987654321', '2024-01-02');

-- Sample data for Reservations table
INSERT INTO Reservations (SittingId, GuestName, Email, Phone, StartTime, NumOfGuests, ReservationSource, Notes, ReservationStatus, TableId, MemberId)
VALUES
    ( 'John Doe', 'john@example.com', '1234567890', '2024-06-15 12:00:00', 4, 'Online', NULL, 0, 1, NULL),
    ( 'Jane Smith', 'jane@example.com', '0987654321', '2024-06-15 18:30:00', 2, 'Phone', 'Special dietary requirements: None', 1, 2, NULL);

-- Sample data for RestaurantTables table
INSERT INTO RestaurantTables (TableName, AreaId, TableStatus)
VALUES
    ('Table 1', 1, 'Available'),
    ('Table 2', 1, 'Available'),
    ('Table 3', 2, 'Booked');

-- Sample data for SittingSchedules table
INSERT INTO SittingSchedules (SittingTime, AreaId)
VALUES
    (1, 1),
    (2, 1),
    (3, 2);


SELECT SittingId FROM SittingSchedules;


SELECT DISTINCT SittingId FROM Reservations WHERE SittingId NOT IN (SELECT SittingId FROM SittingSchedules);

ALTER TABLE SittingSchedules
ADD SittingId INT IDENTITY(1,1) PRIMARY KEY;


use master;