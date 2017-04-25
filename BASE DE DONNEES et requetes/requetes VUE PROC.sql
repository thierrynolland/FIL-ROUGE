/* FIL ROUGE VILLAGE GREEN*/

/* Requetes de la partie "Développer des composants d’accès aux données "
liste des Interrogations demandées  :
-1 Chiffre d'affaire généré pour l'ensemble et par fournisseur
-2 Liste des produits commandés (ref produit, qte commandé)
-3 Liste des commandes pour un client (date, ref client, montant)
-4 Répartition du chiffre d'affaire par type de client
-5 Lister les commandes en cours de livraison. */

-- 1-- Chiffre d'affaire généré pour l'ensemble et par fournisseur

--pour l'ensemble HT:
select sum(lignecom_qte*prix_fixe) As 'CA HT 'from ligne_de_commande



-- par fournisseur HT
select fournisseur.fournisseur_id, sum(lignecom_qte*prix_fixe) as total
from ligne_de_commande	JOIN	PRODUIT			ON	ligne_de_commande.produit_id = produit.produit_id
						JOIN	FOURNISSEUR		ON	produit.fournisseur_id=fournisseur.fournisseur_id
						group by fournisseur.fournisseur_id

-- par fournisseur avec total d'achat au fournisseur
select fournisseur.fournisseur_id, sum(lignecom_qte*prix_fixe) as 'total vente',sum(produit_prixachat*lignecom_qte) as 'total achat au fournisseur'
from ligne_de_commande	JOIN	PRODUIT			ON	ligne_de_commande.produit_id = produit.produit_id
						JOIN	FOURNISSEUR		ON	produit.fournisseur_id=fournisseur.fournisseur_id
						group by fournisseur.fournisseur_id


--2-Liste des produits commandés (ref produit, qte commandé)
select produit_id,sum(lignecom_qte) as 'quantite' from ligne_de_commande
group by produit_id	
order by produit_id	


--3  Liste des commandes pour un client (date, ref client, montant)

 create proc CommandeClient
 @numclient as int
 as
 select commande.commande_id,client.client_id,commande.commande_date,sum((ligne_de_commande.lignecom_qte*ligne_de_commande.prix_fixe)*(1+(tva.tva_taux/100))) as 'Total TTC', sum(ligne_de_commande.lignecom_qte*ligne_de_commande.prix_fixe) as 'TOTAL HT'
 from ligne_de_commande join commande on ligne_de_commande.commande_id= commande.commande_id
						join client on client.client_id=commande.client_id
						join produit on produit.produit_id=ligne_de_commande.produit_id
						join tva on tva.tva_id= produit.tva_id
						where client.client_id = @numclient
 group by commande.commande_id,client.client_id,commande.commande_date



--puis on accède au client ainsi
 exec CommandeClient 1
 exec CommandeClient 2
 exec CommandeClient 3


---4 Répartition du chiffre d'affaire par type de client

create proc CaParType
@categorie int
as
select client.client_categorie,sum(ligne_de_commande.lignecom_qte*ligne_de_commande.prix_fixe) as 'TOTAL HT'
 from ligne_de_commande join commande on ligne_de_commande.commande_id= commande.commande_id
						join client on client.client_id=commande.client_id
						where client.client_categorie = @categorie
 group by client.client_categorie


--puis on accède au type ainsi (1 client, 2 fournisseur)
 exec CaParType 1
 exec CaParType 2

---5 Lister les commandes en cours de livraison.

create view LivEnCours
as
select produit.produit_id,sum(lignecom_qte) as quantite ,commande.commande_id 
from commande	join ligne_de_commande on commande.commande_id=ligne_de_commande.commande_id 
				join produit on ligne_de_commande.produit_id =produit.produit_id
				group by commande.commande_id,produit.produit_id
union
select produit.produit_id,-sum(ligneliv_qte) as quantite ,bon_livraison.commande_id 
from bon_livraison	join ligne_de_livraison on bon_livraison.livraison_id=ligne_de_livraison.livraison_id
				join produit on ligne_de_livraison.produit_id =produit.produit_id
				group by bon_livraison.commande_id,produit.produit_id



select produit_id, commande_id, sum(quantite) as qte
from LivEnCours
group by produit_id, commande_id
having sum(quantite) > 0



/*PROGRAMMER LES PROCEDURES STOCKEES */
--je reprends la VUE LivEnCours
-- la première ne renvoie que les numero de commande

create proc ComLivEnCours
as
select  distinct commande_id as 'commande' 
from LivEnCours
group by produit_id, commande_id
having sum(quantite) > 0

go
--puis
exec ComLivEnCours

--ou 

--celle-ci renvoie aussi les numero de produit et leur quantite en plus du numero de commande
create proc ComLivEnCoursParProd
as
select  commande_id as 'commande' , produit_id as 'produit', sum(quantite) as 'quantite  restant à livrer'
from LivEnCours
group by produit_id, commande_id
having sum(quantite) > 0

go
--puis
exec ComLivEnCoursParProd





/*MOYENNE DES DELAIS ENTRE DATE DE COMMANDE ET DE FACTURATION */
select avg(datediff(day,commande.commande_date,commande.facture_date)) as 'nb jours'
from commande

-- ça sort le résultat : 2 jours

/* GERER LES VUES */

create view ProduitFournisseur
as
select fournisseur.fournisseur_id as 'num Fournisseur', fournisseur.fournisseur_nom as 'nom fournisseur' , produit_id, produit_nomcourt,produit_nom,  produit_prixachat,produit_prixht,produit_etat,produit_validite, produit_photo
from produit
join fournisseur on produit.fournisseur_id=fournisseur.fournisseur_id

go
--puis

select * from ProduitFournisseur
