-- With Json
DECLARE @json NVARCHAR(MAX) = N'{
    "FirstName": "test",
    "LastName": "Doe",
    "Age": 25,
    "Phone": "(123) 456-7890",
    "Email": "johndoe@example.com",
    "IsEnabled": true
}';

EXECUTE usp_SavePerson @JsonData = @json;

-- Inserts
INSERT INTO Person (FirstName, LastName, Age, Phone, Email, IsEnabled) VALUES
('Juan', 'Pérez', '30', '555-1234', 'juanperez@example.com', 1),
('María', 'García', '25', '555-5678', 'mariagarcia@example.com', 1),
('Pedro', 'López', '40', '555-9012', 'pedrolopez@example.com', 0);