### 📘 **README do Projeto: Gerenciador de Pousada**

---

## 🏨 **Gerenciador de Pousada**

Bem-vindo ao repositório do **Gerenciador de Pousada**! Este projeto foi desenvolvido para otimizar a gestão de uma pousada, incluindo controle de hóspedes, reservas, consumo de produtos, e organização de quartos. A aplicação é robusta, escalável e construída com as melhores práticas em desenvolvimento de software.

---

## 🚀 **Funcionalidades**

- **Gestão de Hóspedes e Acompanhantes**: Cadastro, atualização e consulta de informações dos hóspedes e seus acompanhantes.
- **Controle de Reservas e Quartos**: Organização da disponibilidade dos quartos e reservas associadas.
- **Registro de Consumos**: Controle detalhado de produtos consumidos durante as hospedagens.
- **Calendário Interativo**: Visualização e organização das reservas em um calendário dinâmico.
- **Histórico de Hospedagens**: Listagem das hospedagens passadas e atuais para consulta.

---

## 🛠️ **Tecnologias Utilizadas**

- **Backend**: .NET Core 8.0
- **Banco de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Padrões e Arquitetura**:
  - Clean Architecture
  - CQRS (Command Query Responsibility Segregation)
  - Injeção de Dependências (Dependency Injection)
- **Versionamento**: Git

---

## 📂 **Estrutura do Projeto**

```
📦 GerenciamentoPousada
├── 📁 Application
│   ├── 📁 DTOs
│   ├── 📁 Services
│   ├── 📁 Commands
│   └── 📁 Queries
├── 📁 Domain
│   ├── 📁 Entities
│   └── 📁 Interfaces
├── 📁 Infrastructure
│   ├── 📁 Persistence
│   ├── 📁 Repositories
│   └── 📁 Migrations
├── 📁 API
│   ├── 📁 Controllers
│   └── 📁 Middlewares
└── 📄 README.md
```

---

## 🧑‍💻 **Como Configurar e Rodar o Projeto**

### Pré-requisitos
Certifique-se de que você possui as seguintes ferramentas instaladas:
- [Visual Studio](https://visualstudio.microsoft.com/) (ou IDE de sua preferência)
- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server)

### Passos
1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/PedroVinicioss/WEB_API-Gerenciamento-de-Pousada.git
   cd WEB_API-Gerenciamento-de-Pousada
   ```

2. **Configure o Banco de Dados**:
   - Atualize a string de conexão no arquivo `appsettings.json` em **API** para o seu ambiente SQL Server.
   - Rode as migrações:
     ```bash
     dotnet ef database update
     ```

3. **Inicie a Aplicação**:
   ```bash
   dotnet run --project API
   ```

4. **Acesse no Navegador**:
   - A API estará disponível em: `http://localhost:5000` (ou conforme configuração).

---

## 📅 **Roadmap**

### Versão 1.0:
- [x] Cadastro de hóspedes e acompanhantes
- [x] Gerenciamento de reservas e disponibilidade
- [x] Registro de consumos e fechamento de contas
- [x] Implementação inicial do calendário interativo

### Próximas Funcionalidades:
- [ ] Autenticação e controle de acesso por usuário
- [ ] Relatórios financeiros e estatísticas de hospedagem
- [ ] Notificações automáticas de check-in e check-out
- [ ] Integração com sistemas de pagamento

---

## 🤝 **Contribuições**

Contribuições são sempre bem-vindas! Siga os passos abaixo para colaborar:

1. Faça um fork do repositório.
2. Crie uma nova branch com sua feature ou correção:
   ```bash
   git checkout -b minha-feature
   ```
3. Commit suas alterações:
   ```bash
   git commit -m 'Adicionei minha nova feature'
   ```
4. Faça o push para a branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.

---

## 📄 **Licença**

Este projeto está sob a licença MIT. Sinta-se à vontade para usar, modificar e distribuir. Consulte o arquivo [LICENSE](LICENSE) para mais informações.

---

## ✨ **Contato**

👨‍💻 Desenvolvedor: **Pedro Vinícius**  
📧 Email: [pedrooviniciossantos@gmail.com](mailto:pedrooviniciossantos.dev@gmail.com)  
🔗 LinkedIn: [linkedin.com/in/pedrovinicioss](https://www.linkedin.com/in/pedrovinicioss)  

---

Contribua, aprenda e acompanhe este projeto crescendo. 🚀
