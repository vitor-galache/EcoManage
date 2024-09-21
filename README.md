# EcoManage
![Logo](https://github.com/user-attachments/assets/3d0442e7-5a17-441d-bbea-3adee8627213)

<b>O EcoManage é um sistema integrado para controle de operações de uma fazenda urbana </b>

O projeto foi desenvolvido com o objetivo de proporcionar uma solução completa para gestão de fornecedores, produtos,produção e relatórios. 

Este sistema foi concebido como parte de um Projeto Integrado Multidisciplinar para o curso de Análise e Desenvolvimento de Sistemas.

## Principais Funcionalidades

- Controle de Acesso de Funcionário: Implementado sistema de login para que apenas pessoas autorizadas acessem determinadas funcionalidades do sistema.
  
- Gestão de Fornecedores : Cadastro e controle de registros de fornecedores que possuem vinculo com a fazenda urbana.

- Gestão de Produtos: Cadastro dos produtos que são produzidos dentro da fazenda urbana, incluindo edição de produtos e inativação caso necessário.

- Gestão de Produção: Controle completo da produção agrícola da fazenda incluindo data de inicio, tipo de colheita, status de progresso da produção e quantidade do produto que será produzido.

## Arquitetura e Implementação
  ### Class Library (EcoManage.Domain)
  O núcleo do projeto é composto por uma Class Library que encapsula toda a lógica de domínio e modelo de dados. 
  
  Esta classlib serve como base para todos os outros projetos promovendo a reutilização de código e separação de   responsabilidades atráves de interfaces como os Handlers.

- Modelos(Entidades): Contém todas entidades principais como Produto,Fornecedor e Produção.

- Regras de Negócio: Implementa a lógica de negócio, validando e processando as regras de produção e fornecedores, como validar um CNPJ quando um objeto da classe Fornecedor for instanciado por exemplo.

### API (EcoManage.API)

A API foi desenvolvida utilizando ASP.NET Core (Minimal API), sendo ela responsável por expor os dados e serviços da aplicação. Ela possuí referencia ao projeto Class Library para processar e fornecer os dados de forma padronizada.
  
Dentro da API foi utilizado o ORM EntityFramework para o acesso a dados.

- Arquitetura REST: A API segue princípios RESTful, garantindo fácil integração e consumo dos dados.

- Validação dos Dados: A API garante que apenas dados que estiverem de acordo com as regras de negócio definidas pelo dominio sejam persistidos na base de dados.

- Segurança: A API utiliza autenticação baseada em cookies através do AspNet Identity.

- Apenas o projeto da API possui conexão direta com o banco de dados, garantindo assim a segurança de todos dados de produção e de fornecedores.

#### EndPoints

A API expõe diversos endpoints para manipulação de dados relacionados a autenticação, controle de produtos,fornecedores e produção.

**Detalhes dos Endpoints**

Para ver a documentação completa da API com todos os detalhes e exemplos de uso, [clique aqui](https://github.com/vitor-galache/EcoManage/wiki/EcoManage.API).

### Aplicação Web (EcoManage.Web)

A camada de front-end foi implementada utilizando Blazor WebAssembly (WASM). A aplicação Blazor consome a API, sendo responsável pela interação do usuário com os dados.

Vale ressaltar que foi utilizada a biblioteca MudBlazor, que possui suporte a diversos componentes e customização que possibilitaram que a aplicação web ficasse atrativa e agradavel ao olhos. 

**Segue abaixo um video de demonstração da aplicação web em execução:**

https://github.com/user-attachments/assets/b8f3cdfb-541d-48ec-9e1d-ef898af342fa

