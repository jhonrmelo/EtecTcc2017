DROP TABLE IF EXISTS `bd_elaborator`.`DisponibilidadeProfessor` ;

CREATE TABLE IF NOT EXISTS `bd_elaborator`.`DisponibilidadeProfessor` (
  `iddispo` INT NOT NULL AUTO_INCREMENT,
  `iddiasemana` INT NOT NULL,
  `idperiodo` INT NOT NULL,
  `idprof` INT NOT NULL,
  PRIMARY KEY (`iddispo`, `iddiasemana`, `idperiodo`, `idprof`),
  INDEX `iddia_semana_idx` (`iddiasemana` ASC),
  INDEX `idperido_idx` (`idperiodo` ASC),
  INDEX `idprof_idx` (`idprof` ASC),
  CONSTRAINT `iddia_semana`
    FOREIGN KEY (`iddiasemana`)
    REFERENCES `bd_elaborator`.`diasSemana` (`idsemana`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idperido`
    FOREIGN KEY (`idperiodo`)
    REFERENCES `bd_elaborator`.`periodo` (`idperiodo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idprof`
    FOREIGN KEY (`idprof`)
    REFERENCES `bd_elaborator`.`professor` (`idprofessor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

delete from periodo where idperiodo in (1,2,3);
insert into periodo (idperiodo,nome) values (1,'07:00 às 07:50');
insert into periodo (idperiodo,nome) values (2,'07:50 às 08:40');
insert into periodo (idperiodo,nome) values (3,'08:40 às 09:30');
insert into periodo (idperiodo,nome) values (4,'09:50 às 10:40');
insert into periodo (idperiodo,nome) values (5,'10:40 às 11:30');
insert into periodo (idperiodo,nome) values (6,'11:30 às 12:20');
