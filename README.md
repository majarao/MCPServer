# MCPServer

Exemplo de como construir um MCP Server com .Net

O projeto possui 3 divisões

### API
Sendo uma API simples para cadastro e listagem de pessoas

### Shared
Projeto do tipo class library, aonde contém modelos compartilhados da comunicação entre a API e o MCP Server, além da configuração das Tools e de um HttpClient que serão utilizados no MCP Server

### MCP Server
Servidor MCP que é aonde o LLM irá buscar as informações

## Definição do MCP 
MCP é Model Context Protocol, é um protocolo que define com uma LLM (IA generativa) irá se comunicar com sua aplicação, muito semelhante a uma interface ou com o REST é para comunicação HTTP.
Partir que uma LLM adota esse protocolo, seu servidor consegue ser consumido sem necessidade de alteração de código.
