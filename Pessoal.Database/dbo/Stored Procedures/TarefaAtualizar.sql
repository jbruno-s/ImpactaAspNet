
create procedure TarefaAtualizar ( 
       @id              int,
       @nome			nvarchar(200),
	   @prioridade		tinyint,
	   @concluida		bit,
	   @observacoes		nvarchar(1000)
	   )
as

update Tarefa
   set nome		   = @nome,
       prioridade  = @prioridade,
	   Concluida   = @concluida,
	   observacoes = @observacoes	   
 where id = @id