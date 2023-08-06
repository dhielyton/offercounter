- O projeto foi desenvolvido em docker, utilizando docker-compose, então para executar a aplicação basta ter o visual studio ou vscode instalado e executar a aplicação,
caso contrario será necessário executar o commando para inicialização das imagens docker atraves do docker compose;

- Melhorias
- Como o tempo do teste e curto, tentei trazer alguns paradigmas e questões de responsabilidade, por exemplo, a paginação deixei apenas na camada da aplicação (API),
por entender que a paginação esta atrelada a forma com que será feita, e componente utilizado na View.
- Sobre a questões de paginação e outros detalhes relacionado a consultas o ideal seria utilizar um CQRS, onde temos uma outra API so para as consultas,
utilizando um outro banco, com um padrão Materialize Views, onde teria tabelas com informações no qual a importancia seria a velocidade de busca e não a estutura das tabelas de acordo com o modelo de dominio, no qual teriamos eventos que utilizariamos para a propagação desses dados,
utilizaria o Kafka, porque muitos dos recursos já estariam prontos e tratados.
- Pontos de gargalo, como mencionei anteriormente, como se trata de um banco só que recebe a requisição de leitura e escrita, teriamos um gargalo em relação ao desempenho, entrando em problemas de concorrencia, em relação a tabelas e o que acarreta o desempenho.
- Então teria outra API, só para a parte de consultas, utilizando o Orm mais simples, como por exemplo, o Dapper, o banco poderia ser um mongodb, ou qualquer outro banco de dados NoSql, disponível no ambiente nuvem Azure, AWS, etc;
- E teria um  Gateway, que seria responsável em realizar as solicitaçõe correspondete;
- Outro ponto importante seria o teste de integração, considerando a instanciação do ambiente e execução dos teste;


