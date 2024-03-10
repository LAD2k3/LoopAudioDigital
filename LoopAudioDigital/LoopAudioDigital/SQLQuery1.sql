create database LoopAudioDigital
go
use LoopAudioDigital
go
create table ARTIST
(
	artistid int identity(1,1) not null ,
	artistname nvarchar(20) not null,
	artistimgURL char(50),
	email char(30) not null,
	password nchar(30) not null,
	date_participate date,
	description nvarchar(100),
	primary key(artistid)
)
create table SONG
(
	songid int identity(1,1) not null ,
	artistid nchar(50) not null ,
	artistname nvarchar(20) not null,
	songname nvarchar(20) not null,
	listen_count int,
	date_upload date,
	imageURL char(100),
	songURL char(100),
	status bit,
	primary key(songid,artistid),
	CONSTRAINT FK_artistid_upload FOREIGN KEY(artistid) REFERENCES IdentityUser(id),
)/*
create table IdentityRole 
(
	id char(50) primary key not null,
	name char(20) not null,
	normalizedName char(20) not null,
)
create table IdentityUser
(
	id nchar(50) not null,
	userName nvarchar(20) not null,
	email char(30) unique not null,
	NormalizedUserName char(20),
	NormalizedEmail char(30) unique not null,
	PasswordHash char(20),
	EmailConfirmed char(30) null,
	SecurityStamp char(10) null,
	ConcurrencyStamp char(10) null,
	PhoneNumber char(10) null,
	PhoneNumberConfirmed char(10) null,
	TwoFactorEnabled char(10) null,
	LockoutEnd date null,
	LockoutEnabled char(10) null,
	AccessFailedCount int null,
	Primary key(id)
)
create table IdentityUserRole
(
	UserId nchar(50) not null,
	RoleId char(50) not null,
	primary key(UserId,RoleId),
	CONSTRAINT FK_UserId FOREIGN KEY(UserId) REFERENCES IdentityUser(id),
	CONSTRAINT FK_RoleId FOREIGN KEY(RoleId) REFERENCES IdentityRole(id),
)*/
drop table SONG
drop table ARTIST
drop database LoopAudioDigital
