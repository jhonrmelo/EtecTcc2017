select p.nomeProf,ds.nomeDia,pr.nome
from disponibilidadeprofessor d
inner join professor p
on d.idprof = p.idprofessor
inner join diassemana ds on
d.iddiasemana = ds.idsemana
inner join periodo pr
on d.idperiodo = pr.idperiodo