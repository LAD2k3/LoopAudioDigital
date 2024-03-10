create database LoopAudioDigital
go
use LoopAudioDigital
go
create table ARTIST
(
	artistid varchar(10) not null ,
	artistname nvarchar(20) not null,
	artistimgURL varchar,
	email nvarchar,
	date_participate date,
	description nvarchar,
	primary key(artistid)
)
drop table ARTIST
create table SONG
(
	songid varchar(10) not null ,
	artistid varchar(10) not null ,
	songname nvarchar(20) not null,
	listen_count int,
	date_upload date,
	imageURL varchar,
	songURL varchar,
	status bit,
	primary key(songid),
	CONSTRAINT FK_artist_upload FOREIGN KEY(artistid) REFERENCES ARTIST(artistid)
)
drop table SONG
