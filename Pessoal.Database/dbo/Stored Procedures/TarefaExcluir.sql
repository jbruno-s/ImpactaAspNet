create procedure TarefaExcluir ( 
       @id int
	   )
as
  delete a
	from Tarefa a
   where a.id = @id