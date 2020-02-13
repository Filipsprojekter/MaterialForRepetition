USE MockExam3DB
CREATE TABLE Meassurement(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Pressure INT NOT NULL,
Humidity INT NOT NULL, 
Temperature INT NOT NULL,
Time varchar(40) NOT NULL)

INSERT INTO Meassurement VALUES (50,50,40,getdate())
INSERT INTO Meassurement VALUES (40,40,30,getdate())
INSERT INTO Meassurement VALUES (30,30,20,getdate())
INSERT INTO Meassurement VALUES (20,20,10,getdate())
