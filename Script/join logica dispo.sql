select 
count(*) cadastrou,
numaulas,
round(numAulas * 1 + (30/100*numAulas)) as minimo
from disponibilidadeprofessor d
inner join professor p
on d.idprof = p.idprofessor
where idprof = 2;