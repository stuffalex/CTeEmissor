API:
- CTe - nota fiscal de transportação
	- Dados da CARGA
	- Dados da VIAGEM (ou poderia ser operação, dependendo do contexto(?))

- Para gerar informações de nota é necessario utilizar o endpoint de POST =
	- E necessario os seguintes dados, nome do comprador para vincular uma compra e consequentemente a compra estará vinculada na nota CTe.
		- o corpo padrão para o envio de dados para criação de uma nota é JSON
	- {
	  "nomeComprador": "string",
	  "quantidadeDoProduto": 0,
	  "pesoUnitarioProduto": 0,
	  "volumeTotalDosProdutos": 0,
	  "cepOrigem": "string",
	  "cepDestino": "string",
	  "distanciaOrigemDestino": 0,
	  "despesasAdicionais": 0,
	  "tarifaPorPeso": 0
	}

Banco comandos: 
	Migration inicial: -- dotnet ef migrations add Initial
	Migration updates: -- dotnet ef database update
	Migration add: dotnet ef migrations add NomeDaMigracao