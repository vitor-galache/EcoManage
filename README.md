# EcoManage
![Logo](https://github.com/user-attachments/assets/3d0442e7-5a17-441d-bbea-3adee8627213)

<b>O EcoManage é um sistema integrado para controle de operações de uma fazenda urbana. </b>

O projeto foi desenvolvido com o objetivo de proporcionar uma solução completa para gestão de fornecedores, produtos,produção e relatórios. 

Este sistema foi concebido como parte de um Projeto Integrado Multidisciplinar para o curso de Análise e Desenvolvimento de Sistemas.

## Principais Funcionalidades

- Controle de Acesso de Funcionário: Implementado sistema de login para que apenas pessoas autorizadas acessem determinadas funcionalidades do sistema.
  
- Gestão de Fornecedores : Cadastro e controle de registros de fornecedores que possuem vinculo com a fazenda urbana.

- Gestão de Produtos: Cadastro dos produtos que são produzidos dentro da fazenda urbana, incluindo edição de produtos e inativação caso necessário.

- Gestão de Produção: Controle completo da produção agrícola da fazenda incluindo data de inicio, tipo de colheita, status de progresso da produção e quantidade do produto que será produzido.

## Arquitetura e Implementação
  ### Domínio (EcoManage.Domain)
  O núcleo do projeto é composto por uma Class Library que encapsula toda a lógica de domínio e modelo de dados. 
  
  Esta classlib serve como base para todos os outros projetos promovendo a reutilização de código e separação de   responsabilidades atráves de interfaces como os Handlers.

- Modelos(Entidades): Contém todas entidades principais como Produto,Fornecedor e Produção.

- Regras de Negócio: Implementa a lógica de negócio, validando e processando as regras de produção e fornecedores, como validar um CNPJ quando um objeto da classe Fornecedor for instanciado por exemplo.

### Persistência de Dados (EcoManage.Persistence)
O projeto EcoManage.Persistence foi criado para isolar a camada de acesso a dados, alinhado às boas práticas de organização de código e separação de responsabilidades. Ele serve como um ponto centralizado para gerenciar interações com o banco de dados, garantindo maior flexibilidade e manutenção.

- O projeto tem referência ao domínio (EcoManage.Domain)
- Segurança: Apenas o projeto de persistência gerencia a conexão direta com o banco de dados, minimizando o risco de acesso não autorizado ou não intencional a dados críticos.
- ORM Entity Framework Core: Utilizado como ferramenta principal para mapear os dados entre as entidades do domínio e o banco de dados relacional, simplificando operações CRUD e garantindo robustez no acesso aos dados.
  
### API (EcoManage.API)

A API foi desenvolvida utilizando ASP.NET Core (Minimal API), sendo ela responsável por expor os dados e serviços da aplicação. Ela possuí referencia ao projeto EcoManage.Domain e ao projeto EcoManage.Persistence para processar e fornecer os dados de forma padronizada.
  
- Arquitetura REST: A API segue princípios RESTful, garantindo fácil integração e consumo dos dados.

- Validação dos Dados: A API garante que apenas dados que estiverem de acordo com as regras de negócio definidas pelo dominio sejam persistidos na base de dados.

- Segurança: A API utiliza autenticação baseada em cookies através do AspNet Identity.

- Apenas o projeto da API interage com a camada de persistência de dados, garantindo assim a segurança de todos dados de produção e de fornecedores.

#### EndPoints

A API expõe diversos endpoints para manipulação de dados relacionados a autenticação, controle de produtos,fornecedores e produção.

**Detalhes dos Endpoints**

Para ver a documentação completa da API com todos os detalhes e exemplos de uso, [clique aqui](https://github.com/vitor-galache/EcoManage/wiki/EcoManage.API).

### Aplicação Web (EcoManage.Web)

A camada de front-end foi implementada utilizando Blazor WebAssembly (WASM). A aplicação Blazor consome a API, sendo responsável pela interação do usuário com os dados.

Vale ressaltar que foi utilizada a biblioteca MudBlazor, que possui suporte a diversos componentes e customização que possibilitaram que a aplicação web ficasse atrativa e agradavel ao olhos. 

https://github.com/user-attachments/assets/95704589-4de2-44ff-a98c-061a457559b6

### Aplicação Mobile (EcoManage.Mobile)
Segue um vídeo do projeto mobile feito com .NET MAUI que consome a API

https://github.com/user-attachments/assets/37306c29-46c4-4df0-85c7-6b4c8260bd5f

### Aplicação Desktop (EcoManage.Desktop)
Segue um vídeo do projeto mobile feito com Windows Forms que também consome a API

https://github.com/user-attachments/assets/8585cbcc-ddfb-4311-bb30-8c3a2431fc5c

