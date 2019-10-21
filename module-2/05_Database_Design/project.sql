use master
go

Drop Database if exists ProjectOrganizer

Create Database ProjectOrganizer
GO

Use ProjectOrganizer
Go

create table Department(
DepartmentId int primary key,
DepartmentName nvarchar(30) not null,
NumberOfEmployees int not null,
)

create table Employee(
EmployeeId int primary key,
EmployeeTitle nvarchar(30) not null,
LastName nvarchar(30) not null,
FirstName nvarchar(30) not null,
Gender nvarchar(30) not null,
DOB date not null,
DOH date not null,
DepartmentId int not null,
constraint FK_Employee_Department Foreign Key (DepartmentId) references Department(DepartmentId),
)

create table ProjectIdAndName
(
ProjectId int primary key,
ProjectName nvarchar(30) not null,
)

create table Project (
ProjectId int not null,
EmployeeId int not null,
ProjectStartDate date not null,
constraint FK_Project_Employee_Id Foreign Key (EmployeeId) references Employee(EmployeeId),
constraint FK_Project_Id Foreign Key (ProjectId) references ProjectIdAndName(ProjectId)
)

INSERT INTO Department (DepartmentId, DepartmentName, NumberOfEmployees) VALUES (1, 'Sales', 3);
INSERT INTO Department (DepartmentId, DepartmentName, NumberOfEmployees) VALUES (2, 'Accounting', 3);
INSERT INTO Department (DepartmentId, DepartmentName, NumberOfEmployees) VALUES (3, 'Human Resources', 2);

INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (1, 'Sales Associate', 'Fryman', 'Travis', 'Male', '1989-08-20', '2019-10-21', 1);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (2, 'Sales Associate', 'Thome', 'Jim', 'Male', '1989-08-20', '2019-10-21', 1);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (3, 'Sales Associate', 'Haffner', 'Travis', 'Male', '1989-08-20', '2019-10-21', 1);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (4, 'Accountant', 'Thome', 'Tammy', 'Female', '1989-08-20', '2019-10-21', 2);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (5, 'Accountant', 'Sexton', 'Ritchie', 'Male', '1989-08-20', '2019-10-21', 2);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (6, 'Accountant', 'Plunk', 'Pam', 'Female', '1989-08-20', '2019-10-21', 2);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (7, 'Human Resources', 'Fryman', 'Amy', 'Female', '1989-08-20', '2019-10-21', 3);
INSERT INTO Employee (EmployeeId, EmployeeTitle, LastName, FirstName, Gender, DOB, DOH, DepartmentId) VALUES (8, 'Human Resources', 'Giles', 'Gabby', 'Female', '1989-08-20', '2019-10-21', 3);

INSERT INTO ProjectIdAndName( ProjectId, ProjectName) VALUES (1,'Project Tribe')
INSERT INTO ProjectIdAndName( ProjectId, ProjectName) VALUES (2,'Project Wahoo')
INSERT INTO ProjectIdAndName( ProjectId, ProjectName) VALUES (3,'Project Indians')
INSERT INTO ProjectIdAndName( ProjectId, ProjectName) VALUES (4,'Project Windians')

INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (1, 1, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (1, 2, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (2, 3, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (2, 4, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (3, 5, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (3, 6, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (4, 7, '2019-10-21')
INSERT INTO Project (ProjectId, EmployeeId, ProjectStartDate) VALUES (4, 8, '2019-10-21')