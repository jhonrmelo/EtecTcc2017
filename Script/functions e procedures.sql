-- STORED PROCEDURES
USE `bd_elaborator`;
DROP procedure IF EXISTS `sAlteraDados`;

DELIMITER $$
USE `bd_elaborator`$$
CREATE PROCEDURE `sAlteraDados`(in pNome varchar(45), in pEmail varchar(45), in pCpf varchar(15), in pTel varchar(15), in pCel varchar(15), in pEndereco varchar(100), in pNumaula varchar(50), out pMensagem varchar(100))
BEGIN
Select * from bd_elaborator.professor where cpfProf = pCpf;
UPDATE bd_elaborator.professor
SET nomeProf = pNome, emailProf = pEmail, telProf1 = pTel, telProf2 = pCel, enderecoProf = pEndereco, numAulas = pNumaula
WHERE cpfProf = pCpf;
select 'Alteração realizada com sucesso!!' into pMensagem;
END$$

DELIMITER ;

-- ---------------------------------------------------------

USE `bd_elaborator`;
DROP procedure IF EXISTS `sAlteraSenha`;

DELIMITER $$
USE `bd_elaborator`$$
CREATE  PROCEDURE `sAlteraSenha`(in idProfLog int, in pNovaSenha varchar(45), in pConfSenha varchar(45), out pMensagem varchar(50))
BEGIN

-- select idprofessor from bd_elaborator.professor where emailProf = pEmail into @pId;

if ((pNovaSenha != '') and (pConfSenha != '')) then
	if(pConfSenha = pNovaSenha) then
		update professor set senha = (sha1(pNovaSenha)) where idprofessor = idProfLog;
		select 'Senha alterada com sucesso!' into pMensagem;
	else
		select 'Senhas não coincidem!' into pMensagem;
	end if;
else
	select 'Preencha todos os campos!' into pMensagem;
end if;

END$$

DELIMITER ;

-- ------------------------------------------------------------------------

-- FUNCTIONS
USE `bd_elaborator`;
DROP function IF EXISTS `fCadProf`;

DELIMITER $$
USE `bd_elaborator`$$
CREATE FUNCTION `fCadProf`(pNomeProf varchar(45), pEmailProf varchar(45), pCpfProf varchar(15), pTelProf1 varchar(15), pTelProf2 varchar(15), pEnderecoProf varchar(100), pLogin varchar(45), pSenha varchar(45), pConfSenha varchar(45), pNumaula varchar(10), pIdMateria int(11)) RETURNS varchar(100) CHARSET utf8
BEGIN
	if((pNomeProf != '')  and (pEmailProf != '') and (pCpfProf != '') and (pEnderecoProf != '') and (pLogin != '') and (pSenha != '')) then
		if(pConfSenha = pSenha) then
			Insert into professor (nomeProf, emailProf, cpfProf, telProf1, telProf2, enderecoProf, login, senha,numAulas) 
			values (pNomeProf, pEmailProf, pCpfProf, pTelProf1, pTelProf2, pEnderecoProf, pLogin, sha1(pSenha),pNumaula);
	
			select distinct last_insert_id() into @idProfessor from professor;
		

			insert into materiaprofessor (professor_idprofessor, materia_idMateria) values (@idprofessor, pIdMateria);
		
			RETURN 'Professor cadastrado com sucesso!';
		else
			RETURN 'Professor não cadastrado. Senhas não coincidem!';
		end if;
	else
		RETURN 'Professor não cadastrado. Preencha todos os dados obrigatórios!';
	end if;
END$$

DELIMITER ;

--  -----------------------------------------------------------------

USE `bd_elaborator`;
DROP function IF EXISTS `fCadMaterias`;

DELIMITER $$
USE `bd_elaborator`$$
CREATE  FUNCTION `fCadMaterias`(pNome varchar(60)) RETURNS varchar(50) CHARSET utf8
BEGIN

if (pNome != '') then
	if((SELECT idMateria FROM bd_elaborator.materia where nome = pNome) is null) then
		insert into materia (nome) values (pNome);
		return 'Matéria cadastrada com sucesso!';
	else
		return 'Matéria já existente!';
	end if;
else
	return 'Matéria não cadastrada. Campo vazio!';
end if;
END$$

DELIMITER ;

-- ------------------------------------------------------------------------