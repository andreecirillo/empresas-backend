# API REST - CQRS, NHibernate, MongoDB e Fluent Migrator

Este projeto é uma API REST implementada com arquitetura CQRS e princípios de DDD e SOLID. Ele utiliza o NHibernate para operações de comando e o MongoDB para consultas, além de Fluent Migrator para gerenciar migrations.

## Funcionalidades
- **CQRS**: Separação entre Command e Query para maior escalabilidade.
- **NHibernate**: Usado para persistência e mapeamento de dados na camada Command.
- **MongoDB**: Base de dados otimizada para consultas na camada Query.
- **Fluent Migrator**: Gerenciamento de migrações de banco de dados.

# API RESTful com CQRS e Fluent Migrator
Este projeto é uma API desenvolvida em .NET 8, seguindo os princípios de **DDD**, **SOLID**, e **CQRS**. Utiliza **NHibernate** para a camada de comandos e **MongoDB** para consultas. Inclui suporte para migrações de banco de dados utilizando **Fluent Migrator**.

## Estrutura do Projeto
- **Application**: Contém lógica de aplicação e serviços.
- **Domain**: Modelos e regras de negócio seguindo o padrão DDD.
- **Infrastructure**: Implementações de persistência e configurações de banco de dados.
- **API**: Interface RESTful para os serviços.

## Configuração do Ambiente
1. **Pré-requisitos**
   - .NET SDK 8.0+
   - Banco de dados SQL Server (LocalDB ou outra instância configurada)
   - MongoDB configurado e em execução

2. **Clonar o Repositório**
   ```bash
   git clone https://github.com/andreecirillo/empresas-backend.git
   cd empresas-backend
   ```
 
3. **Instalar Dependências** 
   ```
   dotnet restore
   ```

4. **Configurar String de Conexão**	 
   Atualize as strings de conexão nos arquivos appsettings.json do projeto API e no projeto de migração para refletir suas configurações locais ou de produção.

5. **Rodar Migrações de Banco de Dados**
   ```bash
   dotnet run --project Empresas.Infrastructure.Command.Migrator -- "sua-string-de-conexão-do-sql-server"
   ```