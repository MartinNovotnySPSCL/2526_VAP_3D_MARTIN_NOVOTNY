/*select * from 
(select top 1 Predmety.nazev, Osoby.jmeno, 
Osoby.prijmeni, Znamky.znamka, Znamky.vaha 
from 
Predmety join Znamky
on Znamky.id_predmet = Predmety.id
join Osoby
on Osoby.id = Znamky.id_zak where absence = 0
order by znamka asc, vaha desc) as min_znamka

union 

select * from 
(select top 1 Predmety.nazev, Osoby.jmeno, 
Osoby.prijmeni, Znamky.znamka, Znamky.vaha 
from 
Predmety join Znamky
on Znamky.id_predmet = Predmety.id
join Osoby
on Osoby.id = Znamky.id_zak where absence = 0
order by znamka desc, vaha desc) max_znamka*/

select Osoby.jmeno, Osoby.prijmeni,
sum(cast(Znamky.absence as int)) as pocet_absenci
from Osoby join Znamky 
on Znamky.id_zak = Osoby.id 
group by Osoby.id, Osoby.jmeno, Osoby.prijmeni
having sum(cast(Znamky.absence as int)) > 0;