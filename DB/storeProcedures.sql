CREATE PROCEDURE usp_GetPerson(
	@Id as INT
) AS
BEGIN
	SELECT PersonId, FirstName, LastName, Age, Phone, Email, IsEnabled FROM Person WHERE Person.PersonId = @Id AND IsEnabled = 1
END

CREATE PROCEDURE usp_GetAllPerson AS
BEGIN
	SELECT PersonId, FirstName, LastName, Age, Phone, Email, IsEnabled FROM Person WHERE IsEnabled = 1
END


CREATE PROCEDURE usp_SavePerson (
	@JsonData as VARCHAR(MAX)
) AS
BEGIN
	INSERT INTO Person (FirstName, LastName, Age, Phone, Email, IsEnabled)
	VALUES (
		JSON_VALUE(@JsonData, '$.FirstName'),
		JSON_VALUE(@JsonData, '$.LastName'),
		JSON_VALUE(@JsonData, '$.Age'),
		JSON_VALUE(@JsonData, '$.Phone'),
		JSON_VALUE(@JsonData, '$.Email'),
		JSON_VALUE(@JsonData, '$.IsEnabled')
	);
END


CREATE PROCEDURE usp_UpdatePerson (
	@JsonData AS VARCHAR(MAX),
	@Id AS INT
) AS
BEGIN
	UPDATE Person
	SET
		FirstName = JSON_VALUE(@JsonData, '$.FirstName'),
		LastName = JSON_VALUE(@JsonData, '$.LastName'),
		Age = JSON_VALUE(@JsonData, '$.Age'),
		Phone = JSON_VALUE(@JsonData, '$.Phone'),
		Email = JSON_VALUE(@JsonData, '$.Email'),
		IsEnabled = JSON_VALUE(@JsonData, '$.IsEnabled')
	WHERE PersonId = @Id;
END

CREATE PROCEDURE usp_DeletePerson (
	@Id AS INT
) AS
BEGIN
	UPDATE Person
	SET
		IsEnabled = 0
	WHERE PersonId = @Id;
END