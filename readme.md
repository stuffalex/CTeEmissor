- CteEmissor, programa de inicializacao
- REGRA DE QUAL CEP AINDA NAO CLARA PRA MIM

API:
- CTe - nota fiscal de transporta��o
	- Dados da CARGA
	- Dados da VIAGEM (ou poderia ser opera��o, dependendo do contexto(?))
-Compra
	- � o objeto utilizado para gerar a nota CTe. 
	- Conhece os dados da Carga, pois � o produto que ir� ser carregado pela empresa, 
	- e da Viagem, pois conhece os enderecos de origem da entrega e o endereco final do recebedor.
	- 
- Para gerar informa��es de nota � necessario utilizar o endpoint de POST da Compra = /compra
	- E necessario os seguintes dados, nome do comprador para vincular uma compra e consequentemente a compra estar� vinculada na nota CTe.
		- o corpo padr�o para o envio de dados para cria��o de uma nota � JSON
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