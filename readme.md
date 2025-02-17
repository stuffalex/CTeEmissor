- CteEmissor, programa de inicializacao

API:
- CTe - nota fiscal de transportação
	- Dados da CARGA
	- Dados da VIAGEM (ou poderia ser operação, dependendo do contexto(?))
- endpoints:
  - GET - /notasCte (traz todas as notas no banco);
  - GET - /notaCte/{id} - obtém notaCte com o idDaCompra, aqui a nota ta salva com os dados calculados já.
-Compra
	- É o objeto utilizado para gerar a nota CTe. 
	- Conhece os dados da Carga, pois é o produto que irá ser carregado pela empresa, 
	- e da Viagem, pois conhece os enderecos de origem da entrega e o endereco final do recebedor.
 - endpoints:
  - GET - /compras (traz todas as compras no banco);
  - GET - /compra/{id} - obtém compra com o idDaCompra, aqui todas as informações, inclusive calculadas estão salvas no banco. Para obter os dados da NotaCTe deve bater na rota da CTeNota;
  - POST - compra/  - Cria uma compra com os dados informados para poder utilizar na geração da nota cte.
	- E necessario os seguintes dados: nome do comprador para vincular uma compra e consequentemente a compra estará vinculada na nota CTe.
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
