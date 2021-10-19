CREATE DATABASE Student_Election;
Go
CREATE TABLE Student (
    rollno int identity(1,1),
    studentname varchar(255),
    DOB datetime2 null,
    branch varchar(255),
    yearofjoining datetime2 null,
	mobilenumber int null,
	password  int Not null
);
ALTER TABLE Student
ADD PRIMARY KEY (rollno);
CREATE TABLE Admin (
    id int identity(1,1),
    userid varchar(255),
	password varchar(255)
);
Go

INSERT INTO Student (studentname, DOB, branch,yearofjoining,mobilenumber, password)
VALUES ('student1' ,1999-03-29, 'Branch1',null,null,12345);
Go

INSERT INTO Student (studentname, DOB, branch,yearofjoining,mobilenumber, password)
VALUES ('student2' ,null, 'Branch2',2020,null,12345);
Go


CREATE TABLE Candidate(
  id int identity(1,1),
  Name varchar(255),
  PRIMARY KEY (id),
)
Go
INSERT INTO Candidate (Name)
VALUES ('Candidate 1');
Go
INSERT INTO Candidate (Name)
VALUES ('Candidate 2');
Go
INSERT INTO Candidate (Name)
VALUES ('Candidate 3');
Go
INSERT INTO Candidate (Name)
VALUES ('Candidate 4');
Go
CREATE TABLE Election(
  id int identity(1,1),
  Name varchar(255),
  PRIMARY KEY (id),
)
Go
INSERT INTO Election (Name)
VALUES ('Election 1');
Go
INSERT INTO Election (Name)
VALUES ('Election 2');
Go

CREATE TABLE ElectionCandidates (
    id int identity(1,1),
	ElectionId int,
	CandidatId int,
	PRIMARY KEY (id),
    FOREIGN KEY (CandidatId) REFERENCES Candidate(id),
	FOREIGN KEY (ElectionId) REFERENCES Election(id)
);
Go

INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (1,1);
Go
INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (1,2);
INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (1,3);
Go
INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (2,1);
Go
INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (2,2);
INSERT INTO ElectionCandidates(ElectionId,CandidatId)
VALUES (2,3);
Go

CREATE TABLE ElectionVotes (
    id int identity(1,1),
	ElectionId INT,
	CandidatId int,
	StudentRollNumber int
    PRIMARY KEY (id),
	FOREIGN KEY (CandidatId) REFERENCES ElectionCandidates(id),
	FOREIGN KEY (ElectionId) REFERENCES Election(id),
	FOREIGN KEY (StudentRollNumber) REFERENCES Student(rollno)
);
Go





Update student set DOB = GETDATE(), yearofjoining=GETDATE(), mobilenumber= 123456

ALTER TABLE student ALTER COLUMN DOB datetime2 NOT NULL;

ALTER TABLE student ALTER COLUMN yearofjoining datetime2 NOT NULL;

ALTER TABLE student ALTER COLUMN mobilenumber Int NOT NULL;

Go