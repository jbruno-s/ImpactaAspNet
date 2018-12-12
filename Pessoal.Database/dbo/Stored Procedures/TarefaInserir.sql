CREATE procedure TarefaInserir ( 
       @nome			nvarchar(200),
	   @prioridade		tinyint,
	   @concluida		bit,
	   @observacoes		nvarchar(1000) = null
	   )
as
insert into Tarefa (
	   Nome,
	   Prioridade,
	   Concluida,
	   Observacoes)

output inserted.Id

values (@nome,
       @prioridade,
	   @concluida,
	   @observacoes)