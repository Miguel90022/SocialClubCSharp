create database clubSocial

go

use clubSocial

go

create table socio(

pkCedulaSocio int primary key,

tipoSuscripcionSocio varchar(10) not null,

fondosDisponiblesSocio float not null,

nombreSocio varchar(100) not null,

)

go

create table consumoSocio(

pkIdConsumo int identity primary key,

nombreConsumo varchar(100) not null,

precioConsumo float not null,

nombreResponsableConsumo varchar(100) not null,

fkCedulaSocioConsumo int foreign key references socio(pkCedulaSocio)not null

)

go

create table personaAutorizada(

pkCedulaPersonaAutorizada int primary key,

fkCedulaSocioResponsable int foreign key references socio(pkCedulaSocio) not null,

nombrePersonaAutorizada varchar(100) not null,

)

go

create table consumoPersonaAutorizada(

pkIdConsumo int identity primary key,

nombreConsumo varchar(100) not null,

precioConsumo float not null,

nombreResponsableConsumo varchar(100) not null,

fkCedulaPersonaAutorizadaConsumo int foreign key references personaAutorizada(pkCedulaPersonaAutorizada) not null

)create database clubSocial

go

use clubSocial

go

create table socio(

    pkCedulaSocio int primary key,

    tipoSuscripcionSocio varchar(10) not null,

    fondosDisponiblesSocio float not null,

    nombreSocio varchar(100) not null,

)

go

create table consumoSocio(

    pkIdConsumo int identity primary key,

    nombreConsumo varchar(100) not null,

    precioConsumo float not null,

    nombreResponsableConsumo varchar(100) not null,

    fkCedulaSocioConsumo int foreign key references socio(pkCedulaSocio)not null

)

go

create table personaAutorizada(

    pkCedulaPersonaAutorizada int primary key,

    fkCedulaSocioResponsable int foreign key references socio(pkCedulaSocio) not null,

    nombrePersonaAutorizada varchar(100) not null,

)

go

create table consumoPersonaAutorizada(

    pkIdConsumo int identity primary key,

    nombreConsumo varchar(100) not null,

    precioConsumo float not null,

    nombreResponsableConsumo varchar(100) not null,

    fkCedulaPersonaAutorizadaConsumo int foreign key references personaAutorizada(pkCedulaPersonaAutorizada) not null

)