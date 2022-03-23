# Poke Trader

## Calculadora de trocas de pokemon

#### O projeto foi construido com base na Api - https://pokeapi.co/docs/v2 de Pokémon. Ela busca informações sobre nome, id, fotos, base experience.
#### Ele foi publicado no heroku - https://poketradeapi.herokuapp.com/index.html. 
#### Como foi construído com ASP.NET Core 3.1 e o heroku não consegue subir diretamente o projeto, foi realizada a tentativa de construir um conntainer com docker, porém há uma abordagem muito mais simples usando buildpacks.
#### A aplicação foi construída utilizando a abordagem DDD, Dependency Injection, Generic Repository e Swagger.

#### A API analisa se a troca entre os jogadores pode ser considerada justa. Uma troca consiste em dois jogadores ofertarem entre 1 e 6 pokemons de cada lado. Qualquer combinação é válida.
##### Ex: Jogador 1 tenta trocar 3 pokemons com 2 pokemons do jogador 2. 

##### Se a diferença do "base experience" de menor valor for 15% menor ao outro, a troca é injusta.

</br>

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)

</br>


![Request MakeTrade](https://images2.imgbox.com/61/92/yQ9wP59S_o.png)


![Request GetHistory](https://images2.imgbox.com/54/d0/gbVz5OFa_o.png)