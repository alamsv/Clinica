
create database ClinicaDB
go

use ClinicaDB
go

create table Trabajadores (
Id int identity(1,1),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
)
go

create table Especialidades (
Id int identity(1,1),
NombreEspecialidad varchar(50) not null
)
go

create table Doctores (
Id int identity(1,1),
IdTrabajador int not null,
IdEspecialidad int not null
)
go

create table Pacientes (
Id int identity(1,1),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
FechaNacimiento datetime not null
)
go

create table Citas (
Id int identity(1,1),
FechaHora datetime not null,
IdDoctor int not null,
IdPaciente int not null
)
go