drop table if exists trade;

create table trade (
	Id 			   bigint       not null primary key generated always as identity,
	PokemonsP1     varchar(200)	not null,
	PokemonsP2     varchar(200)	not null,
	BaseExpP1 int				not null,
	BaseExpP2 int				not null,
	Status		   smallint     not null 
);