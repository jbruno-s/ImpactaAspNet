create procedure TarefaSelecionar ( 
       @id int = null
	   )
as
  select Id
		,Nome
		,Prioridade
		,Concluida
		,Observacoes
	from Tarefa
   where id = @id or @id is null
   --where id = isnull(@id, id)
   order by 4, 3