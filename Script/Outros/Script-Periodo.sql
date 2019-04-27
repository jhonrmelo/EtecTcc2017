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
insert into periodo (idperiodo,nome) values (1,'07:00 às 08:00');
insert into periodo (idperiodo,nome) values (2,'08:00 às 09:00');
insert into periodo (idperiodo,nome) values (3,'09:00 às 10:00');
insert into periodo (idperiodo,nome) values (4,'10:00 às 11:00');
insert into periodo (idperiodo,nome) values (5,'11:00 às 12:00');
insert into periodo (idperiodo,nome) values (6,'13 às 14:00');
insert into periodo (idperiodo,nome) values (7,'10:00 às 15:00');
insert into periodo (idperiodo,nome) values (8,'15:00 às 16:00');
insert into periodo (idperiodo,nome) values (9,'16:00 às 17:00');
insert into periodo (idperiodo,nome) values (10,'17:00 às 18:00');
insert into periodo (idperiodo,nome) values (11,'19:00 às 20:');
insert into periodo (idperiodo,nome) values (12,'20:00 às 21:00 ');
insert into periodo (idperiodo,nome) values (13,'21:00 às 22:00');
insert into periodo (idperiodo,nome) values (14,'22:00 às 23:00');

