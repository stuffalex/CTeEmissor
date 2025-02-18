# 🚛 CTeEmissor  

O **CTeEmissor** é um programa que calcula os valores da nota fiscal de transporte (**CT-e**) com base nas informações recebidas.  
Ele obtém o valor do frete e o valor do ICMS do estado de origem, utilizando a API do **ViaCep** para identificar o estado a partir do CEP informado.  

## 🔧 Funcionalidades  
- 📦 **Cálculo do frete**  
- 💰 **Cálculo do ICMS** baseado no estado de origem  
- 🔗 **Integração com ViaCep**  
- 📜 **Uso de alíquotas estaduais do JSON** [Ref: Tabela de Alíquotas ICMS 2025](https://simtax.com.br/tabela-icms-2025-aliquotas-de-todos-estados-atualizada/)
- 📖 **Documentação da API via Swagger**  
- 🗄️ **Banco SQLite com Entity Framework 9**  

## 📦 Como instalar  
```sh
git clone https://github.com/stuffalex/CTeEmissor.git
cd CTeEmissor
dotnet build
```
## 🚀 Como usar
```sh
dotnet run
```
## 📌 Rodar os Testes Unitários com NUnit ou xUnit

```sh
cd CTeEmissor.Testes
dotnet test
```
