create database TP4BazanVaquera;
GO
use TP4BazanVaquera;
GO

create table clientesDB(
dni int primary key,
nombreCompleto varchar(70) not null,
)

create table turnosDB(
dni int not null,
nombreDoctor varchar(50) not null,
iDderivacion int not null,
fecha date not null,
hora int not null
)


insert into turnosDB (dni, nombreDoctor, idDerivacion, fecha, hora) values (12345678, 'Clair Buxcy', 5, '8/20/2022', 14);
insert into turnosDB (dni, nombreDoctor, idDerivacion, fecha, hora) values (12345677, 'Kleon Wolfindale', 2, '12/8/2021', 9);
insert into turnosDB (dni, nombreDoctor, idDerivacion, fecha, hora) values (12345676, 'Kellen Witherop', 2, '9/8/2022', 20);
insert into turnosDB (dni, nombreDoctor, idDerivacion, fecha, hora) values (12345675, 'Malynda Josephoff', 5, '3/17/2022', 11);


insert into clientesDB (dni, nombreCompleto) values (12345678, 'Saba Relf');
insert into clientesDB (dni, nombreCompleto) values (12345677, 'Claire Praton');
insert into clientesDB (dni, nombreCompleto) values (12345676, 'Anallese Momery');
insert into clientesDB (dni, nombreCompleto) values (12345675, 'Tucky Wellen');

select * from ClientesDB
select * from turnosDB

select clientesDB.dni,clientesDB.nombreCompleto,turnosDB.nombreDoctor,turnosDB.idDerivacion,turnosDB.fecha,turnosDB.hora
from clientesDB inner join turnosDB on clientesDB.dni = turnosDB.dni