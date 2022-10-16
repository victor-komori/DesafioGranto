# DesafioGranto

Este é um projeto criador a partir de um desafio da Granto Seguros aonde foi necessário desenvolver uma API REST em C# que vai disponibilizar três endpoints.

O Projeto está separado em três camadas.
Camada dos Controllers que tem o objetivo de receber as requisições, tratar os dados e retornar a resposta a quem está consumindo a API.
Camada dos Services que é aonde fica a lógica de negócio do sistema.
Camada dos Repositories que tem o objetivo de fazer a ponte entre os services e o banco de dados, sem precisar se importar com a lógica de negócio.

1º Endpoint (POST) Cadastro de vendedor:

Para cadastrar o vendedor a API irá receber um Json contendo os dados desse vendedor. Em seguida esses dados serão mapeados para a entidade e serão gravados no banco de dados.

2º Endpoint (POST) Cadastro de oportunidades:

Para cadastrar uma oportunidade a API receber um Json contendo os dados da oportunidade, incluindo o CNPJ. Em seguida esse CNPJ será consultado na API publica que irá retornar os dados da empresa. Após retornado os dados através de um Json a entidade Oportunidade será preenchica mas não será gravada imediatamente, antes disso o sistema irá buscar uma lista contendo todos os vendedores que fazem parte da região da empresa/oportunidade e irá fazer um processo de roleta para escolher quem será o vendedor escolhido para a oportunidade, lembrando que o mesmo vendedor não pode pegar duas oportunidades seguidas e caso haja apenas um vendedor para aquela região o processo de roleta não irá ocorrer. Depois disso tudo a oportunidade será gravada no banco de dados.

3º Endpoint (GET) Busca de vendedor com suas oportunidades:

A API vai retornar a partir do email informado os dados de um vendedor junto com uma lista de todas as oportunidades dele no formato Json.

Principais técnologias utilizadas no projeto:

AutoMapper: Facilitar o mapeamento das Entidades com os DTO, já que as entidades não estão sendo expostas para quem precisar consumir a API.

Swagger: Para documentar a API, mostrando o funcionamento de todos os Endpoints.

Entity Framework Core: Ferramenta ORM utilizada para facilitar o trabalho com o DB.

EFCore.Tools (Migration): Foi utilizado o Code First para o desenvolvimento do projeto e por conta disso foi necessário utilizar o Migrations para a estruturação e criação do banco de dados a partir das entidades do projeto.

EFCore.SqlServer: Fazer a configuração da conexão com o DB utilizando SqlServer.

