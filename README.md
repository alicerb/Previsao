# PrevisaoTempo
Readme
Aplicativo que exibe a previsão do tempo de 5 dias para cidades cadastradas utilizando a api da OpenWeather.

Telas:
Home -> Contém botão para cadastrar nova cidade e a lista de cidades cadastradas para exibir sua previsão;
Cadastro -> Realiza o cadastro de uma cidade na aplicação;
Previsão -> Exibe a temperatura da data atual e faz um forecast de 5 dias com temperatura máxima e mínima.

Projeto e código:
Criei uma arquitetura baseada numa proposta do Eduardo Pires - projeto de DDD (https://www.eduardopires.net.br/) e que foi implementada em um projeto mais novo aqui da empresa, utilizei .NET MVC, EF Code First e AngularJS no front-end que acabei não achando nada muito interessante para exibição e pelo tempo aproveitei uma sugestão de: https://sceendy.com/blog/2017/09-27-weather-widget-tutorial/

Sobre arquitetura:
O projeto tem suas camadas separadas e isoladas, onde a UI só conhece a camada de Application por meio de injeção de dependência (usando simple injector)a camada de application que faz referência a camada de serviço e esta aos objetos de domínio e DAL, que implementa um repositório para acesso a dados via Entity Framework, vale destacar a implemtação do unit of work para coordenar a persistência dos dados.
Fiz uso do AutoMapper para mapear os objetos de domínio em view models e vice-versa de maneira mais ágil.
Dividida em camadas
Injeção de dependência
AutoMapper


Sobre Testes:
Pelo tempo, acabei não criando o projeto de testes muito embora essa arquitetura seja ótima para desenvolver testes

