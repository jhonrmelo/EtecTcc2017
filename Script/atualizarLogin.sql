CREATE PROCEDURE `atualizarLogin`(in p_id  int(2), in p_nome varchar(100), in p_sbnome varchar(100), in p_idade int(2), in p_cargo varchar(100), out p_saida varchar(1000))
BEGIN
declare msg varchar(1000);
set msg = 'O(s) campo(s) ';
if (p_nome != '') then
Update login SET nome = p_nome  Where id = p_id;
set msg = concat(msg, 'nome, ');
end if;
if (p_sbnome != '') then
Update login SET sobrenome = p_sbnome  Where id = p_id;
set msg = concat(msg, 'sobrenome, ');
end if;
if (p_idade != 0) then
Update login SET idade = p_idade Where id = p_id;
set msg = concat(msg, 'idade, ');
end if;
if (p_cargo != '') then
Update login SET cargo = p_cargo Where id = p_id;
set msg = concat(msg, 'cargo, ');
end if;
select CONCAT(msg, 'atualizado(s) com sucesso') into p_saida;
END