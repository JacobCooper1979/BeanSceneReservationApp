-- Insert areas into Areas table
INSERT INTO Areas (AreaName, Capacity) VALUES
('Main', 100),
('Outdoors', 50),
('Balcony', 30);


-- Insert tables for Main Area
INSERT INTO RestaurantTables (TableName, TableStatus, AreaID) VALUES
    ('M1', 'Available', 1),
    ('M2', 'Available', 1),
    ('M3', 'Available', 1),
    ('M4', 'Available', 1),
    ('M5', 'Available', 1),
    ('M6', 'Available', 1),
    ('M7', 'Available', 1),
    ('M8', 'Available', 1),
    ('M9', 'Available', 1),
    ('M10', 'Available', 1);

-- Insert tables for Outdoors Area
INSERT INTO RestaurantTables (TableName, TableStatus, AreaID) VALUES
    ('O1', 'Available', 2),
    ('O2', 'Available', 2),
    ('O3', 'Available', 2),
    ('O4', 'Available', 2),
    ('O5', 'Available', 2),
    ('O6', 'Available', 2),
    ('O7', 'Available', 2),
    ('O8', 'Available', 2),
    ('O9', 'Available', 2),
    ('O10', 'Available', 2);

-- Insert tables for Balcony Area
INSERT INTO RestaurantTables (TableName, TableStatus, AreaID) VALUES
    ('B1', 'Available', 3),
    ('B2', 'Available', 3),
    ('B3', 'Available', 3),
    ('B4', 'Available', 3),
    ('B5', 'Available', 3),
    ('B6', 'Available', 3),
    ('B7', 'Available', 3),
    ('B8', 'Available', 3),
    ('B9', 'Available', 3),
    ('B10', 'Available', 3);


INSERT INTO Members (FirstName, LastName, Email, Phone, Password, RegistrationDate) VALUES
('John', 'Doe', 'john@example.com', '1234567890', 'password123', GETDATE()),
('Jane', 'Doe', 'jane@example.com', '0987654321', 'password456', GETDATE());


INSERT INTO SittingSchedules (SType, StartDateTime, EndDateTime, SCapacity, Status) VALUES
('Breakfast', '2024-05-28 08:00:00', '2024-05-28 10:00:00', 50, 'Active'),
('Lunch', '2024-05-28 12:00:00', '2024-05-28 14:00:00', 80, 'Active'),
('Dinner', '2024-05-28 18:00:00', '2024-05-28 21:00:00', 100, 'Active');


INSERT INTO Reservations (SittingID, GuestName, Email, Phone, StartTime, Duration, NumOfGuests, ReservationSource, Notes, ReservationStatus, TableID, MemberID) VALUES
(2, 'John Doe', 'john@example.com', '1234567890', '2024-05-28 12:30:00', 120, 4, 'Online', 'Prefer window seat', 'Confirmed', 1, 1),
(2, 'Jane Doe', 'jane@example.com', '0987654321', '2024-05-28 13:00:00', 120, 3, 'Mobile', 'No special requests', 'Confirmed', 2, 2);

INSERT INTO Staffs (StaffType, FirstName, LastName, Email, Phone, Password) VALUES
('Waiter', 'Michael', 'Smith', 'michael@example.com', '1112223333', 'staff123'),
('Chef', 'Emily', 'Johnson', 'emily@example.com', '4445556666', 'chef456');


