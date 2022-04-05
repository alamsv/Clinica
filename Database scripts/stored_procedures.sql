
use ClinicaDB
go

create procedure SelectTrabajador 
as
select * from trabajadores;
go

create procedure InsertTrabajador 
	@Nombre varchar(50), @Apellido varchar(50)
as
begin transaction
insert into trabajadores (nombre, apellido)
values (@Nombre, @Apellido)
commit transaction
go

create procedure UpdateTrabajador
	@Id int, @Nombre varchar(50), @Apellido varchar(50)
as
begin transaction
update trabajadores
set nombre = @Nombre, apellido = @Apellido
where id = @Id
commit transaction
go

create procedure DeleteTrabajador
	@Id int
as
begin transaction
delete trabajadores
where id = @Id
commit transaction
go

create procedure SelectEspecialidad 
as
select * from especialidades;
go

create procedure InsertEspecialidad 
	@NombreEspecialidad varchar(50)
as
begin transaction
insert into especialidades (NombreEspecialidad)
values (@NombreEspecialidad)
commit transaction
go

create procedure UpdateEspecialidad
	@Id int, @NombreEspecialidad varchar(50)
as
begin transaction
update especialidades
set NombreEspecialidad = @NombreEspecialidad
where id = @Id
commit transaction
go

create procedure DeleteEspecialidad
	@Id int
as
begin transaction
delete especialidades
where id = @Id
commit transaction
go

create procedure SelectDoctor 
as
select * from doctores;
go

create procedure InsertDoctor 
	@IdTrabajador int, @IdEspecialidad int
as
begin transaction
insert into doctores (IdTrabajador, IdEspecialidad)
values (@IdTrabajador, @IdEspecialidad)
commit transaction
go

create procedure UpdateDoctor
	@Id int, @IdTrabajador int, @IdEspecialidad int
as
begin transaction
update doctores
set IdTrabajador = @IdTrabajador, IdEspecialidad = @IdEspecialidad
where id = @Id
commit transaction
go

create procedure DeleteDoctor
	@Id int
as
begin transaction
delete doctores
where id = @Id
commit transaction
go

create procedure SelectPaciente 
as
select * from pacientes;
go

create procedure InsertPaciente 
	@Nombre varchar(50), @Apellido varchar(50), @FechaNacimiento datetime
as
begin transaction
insert into pacientes (nombre, apellido, FechaNacimiento)
values (@Nombre, @Apellido, @FechaNacimiento)
commit transaction
go

create procedure UpdatePaciente
	@Id int, @Nombre varchar(50), @Apellido varchar(50), @FechaNacimiento datetime
as
begin transaction
update pacientes
set nombre = @Nombre, apellido = @Apellido, FechaNacimiento = @FechaNacimiento
where id = @Id
commit transaction
go

create procedure DeletePaciente
	@Id int
as
begin transaction
delete pacientes
where id = @Id
commit transaction
go

create procedure SelectCita 
as
select * from citas;
go;

create procedure InsertCita
	@FechaHora datetime, @IdDoctor int, @IdPaciente int
as
begin transaction
insert into citas (FechaHora, IdDoctor, IdPaciente)
values (@FechaHora, @IdDoctor, @IdPaciente)
commit transaction
go;

create procedure UpdateCita
	@Id int, @FechaHora datetime, @IdDoctor int, @IdPaciente int
as
begin transaction
update especialidades
set FechaHora = @FechaHora, IdDoctor = @IdDoctor, IdPaciente = @IdPaciente
where id = @Id
commit transaction
go;

create procedure DeleteCita
	@Id int
as
begin transaction
delete citas
where id = @Id
commit transaction
go;
