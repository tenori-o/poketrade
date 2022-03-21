drop table if exists tradeitem;
drop table if exists trade;
drop table if exists tradestatus;
drop table if exists pokeowner;
drop table if exists pokemon;
drop table if exists pokeuser;

create table player (
	Id 			   bigint       not null primary key generated always as identity,
	Name 		   varchar(100) not null,
	Email 		   varchar(100) not null
);

create table pokemon (
	Id 			   bigint       not null primary key generated always as identity,
	IdPokeApi      bigint	    not null,
	Name		   varchar(100) not null,
	BaseExperience int			not null
);

create table tradestatus (
	Id 			   bigint       not null primary key generated always as identity,
	Description    varchar(50)  not null
);

create table trade (
	Id 			   bigint       not null primary key generated always as identity,
	InitDate       timestamp	not null default now(),
	CloseDate      timestamp	not null default now(),
	Status		   bigint       not null REFERENCES tradestatus(Id)
);

create table tradeitem (
	Id 			   bigint       not null primary key generated always as identity,
	IdTrade		   bigint       not null REFERENCES trade(Id),
	IdPokemon	   bigint       not null REFERENCES pokemon(Id),
	IdTrader	   bigint       not null REFERENCES player(Id),
);