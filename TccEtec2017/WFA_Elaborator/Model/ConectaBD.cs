using MySql.Data.MySqlClient;

namespace WFA_tcc.Model
{
    class ConectaBD
    {
        public static MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.bd_elaboratorConnectionString);

        // Verificar se há algum banco de dados existente com o nome bd_elaborator
        public bool verificaBD()
        {
            int cont = 0;

            conexao.Open();
            MySqlCommand cmd = new MySqlCommand("show databases like 'bd_elaborator';", conexao);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cont++;
            }

            if (cont > 0)
            {
                conexao.Dispose();
                return true;

            }
            else
            {
                conexao.Dispose();
                return false;
            }
        }

        // Caso não exista um BD com o nome 'bd_elaborator', este método cria
        public void criaBD()
        {
            #region String para criação do Banco de Dados bd_elaborator
            string strCmd = "CREATE DATABASE IF NOT EXISTS bd_elaborator; USE bd_elaborator; CREATE TABLE IF NOT EXISTS `bd_elaborator`.`professor` (`idprofessor` INT(11) NOT NULL AUTO_INCREMENT,`nomeProf` VARCHAR(45) NOT NULL,`emailProf` VARCHAR(45) NOT NULL,`cpfProf` varchar(15) NOT NULL,`telProf1` varchar(15) NOT NULL,`telProf2` varchar(15) NULL DEFAULT NULL,`enderecoProf` VARCHAR(100) NULL DEFAULT NULL,`dispoProf` VARCHAR(45) NULL DEFAULT NULL,`login` VARCHAR(45) NOT NULL,`senha` VARCHAR(45) NOT NULL,`numAulas` VARCHAR(10),PRIMARY KEY (`idprofessor`),UNIQUE INDEX `cpfProf_UNIQUE` (`cpfProf` ASC),UNIQUE INDEX `emailProf_UNIQUE` (`emailProf` ASC),UNIQUE INDEX `idprofessor_UNIQUE` (`idprofessor` ASC),UNIQUE INDEX `login_UNIQUE` (`login` ASC)); CREATE TABLE IF NOT EXISTS `bd_elaborator`.`diasSemana` (`idsemana` INT(11) NOT NULL AUTO_INCREMENT,`nomeDia` VARCHAR(15) NOT NULL,PRIMARY KEY (`idsemana`)); CREATE TABLE IF NOT EXISTS `bd_elaborator`.`materia` (`idMateria` INT(11) NOT NULL AUTO_INCREMENT,`nome` VARCHAR(30) NOT NULL,PRIMARY KEY (`idMateria`),UNIQUE INDEX `nome_UNIQUE` (`nome` ASC)); CREATE TABLE IF NOT EXISTS `bd_elaborator`.`periodo` (`idperiodo` INT(11) NOT NULL AUTO_INCREMENT,`nome` VARCHAR(45) NOT NULL,PRIMARY KEY (`idperiodo`)); CREATE TABLE IF NOT EXISTS `bd_elaborator`.`DisponibilidadeProfessor` (`iddispo` INT(11) NOT NULL,`iddiasemana` INT(11) NOT NULL,`idperiodo` INT(11) NOT NULL,`idprof` INT(11) NOT NULL,PRIMARY KEY (`iddispo`, `iddiasemana`, `idperiodo`, `idprof`),INDEX `iddia_semana_idx` (`iddiasemana` ASC),INDEX `idperido_idx` (`idperiodo` ASC),INDEX `idprof_idx` (`idprof` ASC),CONSTRAINT `iddia_semana` FOREIGN KEY (`iddiasemana`) REFERENCES `bd_elaborator`.`diasSemana` (`idsemana`) ON DELETE NO ACTION ON UPDATE NO ACTION, CONSTRAINT `idperido` FOREIGN KEY (`idperiodo`)REFERENCES `bd_elaborator`.`periodo` (`idperiodo`) ON DELETE NO ACTION ON UPDATE NO ACTION, CONSTRAINT `idprof` FOREIGN KEY (`idprof`) REFERENCES `bd_elaborator`.`professor` (`idprofessor`) ON DELETE NO ACTION ON UPDATE NO ACTION); CREATE TABLE IF NOT EXISTS `bd_elaborator`.`MateriaProfessor` (`materia_idMateria` INT(11) NOT NULL,`professor_idprofessor` INT(11) NOT NULL,PRIMARY KEY (`materia_idMateria`, `professor_idprofessor`),INDEX `fk_materia_has_professor_professor1_idx` (`professor_idprofessor` ASC),INDEX `fk_materia_has_professor_materia1_idx` (`materia_idMateria` ASC), CONSTRAINT `fk_materia_has_professor_materia1` FOREIGN KEY (`materia_idMateria`) REFERENCES `bd_elaborator`.`materia` (`idMateria`) ON DELETE NO ACTION ON UPDATE NO ACTION, CONSTRAINT `fk_materia_has_professor_professor1` FOREIGN KEY (`professor_idprofessor`) REFERENCES `bd_elaborator`.`professor` (`idprofessor`)ON DELETE NO ACTION ON UPDATE NO ACTION); USE bd_elaborator; insert into professor(nomeProf,emailProf,cpfProf,telProf1,telProf2,enderecoProf,login,senha,numAulas)values ('(admin)','(admin)','(admin)','(admin)','(admin)','(admin)','admin',sha1('123'),0); USE bd_elaborator;insert into professor(nomeProf,emailProf,cpfProf,telProf1,telProf2,enderecoProf,login,senha,numAulas)values ('Claudio Araujo Farias','claudioaf_15@hotmail.com','48529','98190','982759','Rua Érico Verissimo, nº915','claudio',sha1('123'),10);insert into diassemana(nomeDia)values('Segunda');insert into diassemana(nomeDia)values('Terça');insert into diassemana(nomeDia)values('Quarta');insert into diassemana(nomeDia)values('Quinta');insert into diassemana(nomeDia)values('Sexta');insert into diassemana(nomeDia)values('Sábado'); DROP TABLE IF EXISTS `bd_elaborator`.`DisponibilidadeProfessor` ; CREATE TABLE IF NOT EXISTS `bd_elaborator`.`DisponibilidadeProfessor` ( `iddispo` INT NOT NULL AUTO_INCREMENT, `iddiasemana` INT NOT NULL, `idperiodo` INT NOT NULL, `idprof` INT NOT NULL, PRIMARY KEY (`iddispo`, `iddiasemana`, `idperiodo`, `idprof`), INDEX `iddia_semana_idx` (`iddiasemana` ASC), INDEX `idperido_idx` (`idperiodo` ASC), INDEX `idprof_idx` (`idprof` ASC), CONSTRAINT `iddia_semana` FOREIGN KEY (`iddiasemana`) REFERENCES `bd_elaborator`.`diasSemana` (`idsemana`) ON DELETE NO ACTION  ON UPDATE NO ACTION, CONSTRAINT `idperido` FOREIGN KEY (`idperiodo`) REFERENCES `bd_elaborator`.`periodo` (`idperiodo`) ON DELETE NO ACTION ON UPDATE NO ACTION, CONSTRAINT `idprof` FOREIGN KEY (`idprof`) REFERENCES `bd_elaborator`.`professor` (`idprofessor`) ON DELETE NO ACTION ON UPDATE NO ACTION); insert into periodo (idperiodo,nome) values (1,'07:20 às 08:10'); insert into periodo (idperiodo,nome) values (2,'08:10 às 09:00');insert into periodo (idperiodo,nome) values (3,'09:00 às 09:50');insert into periodo (idperiodo,nome) values (4,'10:10 às 11:00');insert into periodo (idperiodo,nome) values (5,'11:00 às 11:50');insert into periodo (idperiodo,nome) values (6,'12:50 às 13:40');insert into periodo (idperiodo,nome) values (7,'13:40 às 14:30');insert into periodo (idperiodo,nome) values (8,'14:30 às 15:20');insert into periodo (idperiodo,nome) values (9,'13:00 às 14:00');insert into periodo (idperiodo,nome) values (10,'14:00 às 15:05');insert into periodo (idperiodo,nome) values (11,'15:20 às 16:20');insert into periodo (idperiodo,nome) values (12,'16:20 às 17:25');insert into periodo (idperiodo,nome) values (13,'19:00 às 19:55');insert into periodo (idperiodo,nome) values (14,'19:55 às 20:50');insert into periodo (idperiodo,nome) values (15,'21:05 às 22:05');insert into periodo (idperiodo,nome) values (16,'22:05 às 23:00'); ALTER TABLE `bd_elaborator`.`professor` DROP COLUMN `dispoProf`; USE bd_elaborator;insert into materia (nome) values ('Artes');insert into materia (nome) values ('Biologia');insert into materia (nome) values ('Educação Física');insert into materia (nome) values ('Filosofia');insert into materia (nome) values ('Física');insert into materia (nome) values ('Geografia');insert into materia (nome) values ('História');insert into materia (nome) values ('Inglês');insert into materia (nome) values ('Matemática');insert into materia (nome) values ('Português');insert into materia (nome) values ('Química');insert into materia (nome) values ('Sociologia');";
            #endregion
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = strCmd;
            cmd.ExecuteNonQuery();
            conexao.Dispose();
        }
    }
}

