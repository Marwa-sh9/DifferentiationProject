use Differentiation;
create table University
(
University_Id int primary key identity,
University_Name nvarchar(50) not null 
);
create table Factuly
(
Factuly_Id int primary key identity,
Factuly_Name nvarchar(255) not null,
Capacity int not null,
Min_Mark_Total int not null,
University_Id int foreign key references University(University_Id)
);
create table Student_Imported_Data
(
Id_Number bigint primary key ,
IPO_Number int not null ,
Student_Full_Name nvarchar(255) not null,
Student_Mother_Name nvarchar(255)not null,
Gender nvarchar(50)not null,
Date_Of_Birth nvarchar(50) not null ,
Student_Nationality nvarchar(50) not null,
[year] int not null,
[Source] nvarchar(255) not null,
[Address] nvarchar(max),
Phone nvarchar(50),
Email nvarchar(50) ,
[Password] nvarchar(50),
isAdmin bit ,

);
create table Mark
(
mark_Id int primary key identity,
Maths int not null,
physics int not null,
chemistry int not null,
English int not null,
French int not null,
Arabic int not null,
[National] int not null,
Religious int not null,
Science int not null,
Mark_Total int,
Id_Number bigint foreign key references Student_Imported_Data(Id_Number),
);
create table Factuly_mark
(
Factuly_Id int foreign key references Factuly(Factuly_Id),
mark_Id int foreign key references Mark(mark_Id),
Min_Mark_Total int,
Def_Language nvarchar(25),
);
create table Desires
(
Factuly_Id int foreign key references Factuly(Factuly_Id),
Id_Number bigint  foreign key references Student_Imported_Data(Id_Number),
Desire_Sequence int,
Desire_Id int identity,
Accepted nvarchar(50) not null default 0,
);
ALTER DATABASE [Differentiation] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
ALTER DATABASE [Differentiation] COLLATE ARABIC_CI_AS;
GO
ALTER DATABASE [Differentiation] SET MULTI_USER;
GO