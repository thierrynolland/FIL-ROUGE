
create database villagegreen
go
use villagegreen
create table fournisseur (
	fournisseur_id 		int identity primary key not null,
	fournisseur_nom 	varchar(50) not null
	fournisseur_adresse varchar(100),
	fournisseur_cp varchar(5),
	fournisseur_ville varchar(100)
)
go

create table tva(
	tva_id int identity primary key,
	tva_nom varchar(50) not null,
	tva_taux decimal(12,2) not null
)


create table rubrique(
	rubrique_id 		int identity primary key not null,
	rubrique_nom 		varchar(50)  not null
)

go

create table sous_rubrique(
	ss_rubrique_id 		int identity primary key not null,
	ss_rubrique_nom 	varchar(50) not null,
	rubrique_id int references rubrique(rubrique_id) not null
)
go
create table commercial(
	commercial_id 		int identity primary key not null,
	commercial_nom 		varchar (50) not null,
	commercial_prenom 	varchar(50) 
)
go

create table produit (
	produit_id 			int primary key not null,
	produit_nomcourt 	varchar(10) not null,
	produit_nom 		varchar(100) not null,
	produit_photo 		varchar (25),
	produit_prixachat	decimal(12,2),
	produit_etat 		bit not null,
	produit_prixht 		decimal (12,2),
	produit_validite 	bit not null,
	ss_rubrique_id 		int not null references sous_rubrique(ss_rubrique_id),
	fournisseur_id 		int not null references fournisseur(fournisseur_id),
	tva_id int references tva(tva_id) not null
)
go

create table client(
	client_id 			int primary key not null,
	client_categorie 	int not null,
	client_nom 			varchar(50) not null,
	client_prenom 		varchar(50),
	client_reduc		decimal(12,2),
	client_adresse 		varchar(100),
	client_ville 		varchar(100),
	client_cp 			varchar(5),
	commercial_id 		int references commercial(commercial_id)

)
go


create table commande (
	commande_id int identity primary key not null,
	commande_reduc decimal (12,2),
	commande_etat varchar(20),
	commande_reglt datetime,
	commande_date datetime,
	commande_paye bit,
	livraison_adr varchar(100) not null,
	livraison_ville varchar(100) not null,
	livraison_cp varchar(5) not null,
	client_id int references client(client_id) not null,
	facture_id int not null,
	facture_date datetime not null,
	facture_montant decimal(12,2) ,
	facture_adre varchar(100) not null,
	facture_ville varchar(100) not null,
	facture_cp varchar(5) not null
)

go

create table bon_livraison(
	livraison_id int identity primary key not null,
	livraison_date datetime,
	commande_id int references commande(commande_id) not null
)

go

create table ligne_de_livraison(
	ligneliv_id int identity primary key not null,
	ligneliv_qte	int not null,
	livraison_id int references bon_livraison(livraison_id) not null,
	produit_id int references produit(produit_id) not null
)
go

create table ligne_de_commande (
	lignecom_id int identity primary key not null,
	lignecom_qte int not null,
	prix_fixe decimal(12,2) not null,
	commande_id int references commande(commande_id) not null,
	produit_id int references produit(produit_id) not null

)
go



/* ____________________  */



create index indexclient on client(client_id)
create index indexfournisseur on fournisseur(fournisseur_id)
create index indexcommande on commande(commande_id)
create index indexproduit on produit(produit_id)



go	


/* __LES LOGINS CREES DANS MASTER____  */

use master
go
create login admi with password ='adm', default_database = [villagegreen], check_expiration= off, check_policy=off
go	
create login comm with password ='com', default_database = [villagegreen], check_expiration= off, check_policy=off
go	
create login gest with password ='ges', default_database = [villagegreen], check_expiration= off, check_policy=off
go	
create login client with password ='cli', default_database = [villagegreen], check_expiration= off, check_policy=off
go
create login consu with password ='con', default_database = [villagegreen], check_expiration= off, check_policy=off
go



/* ___LES USERS CREES DANS VILLAGEGREEN_________________  */

use villagegreen
go

create user admi for login admi
go
create user comm for login comm
go
create user gest for login gest
go
create user client for login client
go
create user consu for login consu
go


/* les roles dans villagegreen */
create role rolegestion
	grant update on produit to rolegestion
	grant insert on produit to rolegestion
	grant delete on produit to rolegestion
	grant select on produit to rolegestion

	grant update on rubrique to rolegestion
	grant insert on rubrique to rolegestion
	grant delete on rubrique to rolegestion
	grant select on rubrique to rolegestion

	grant update on sous_rubrique to rolegestion
	grant insert on sous_rubrique to rolegestion
	grant delete on sous_rubrique to rolegestion
	grant select on sous_rubrique to rolegestion


	grant update on fournisseur to rolegestion
	grant insert on fournisseur to rolegestion
	grant select on fournisseur to rolegestion

go

create role roleclient
	
	grant update on client to roleclient
	grant insert on client to roleclient
	grant select on client to roleclient


	grant select on produit to roleclient
	grant select on rubrique to roleclient
	grant select on sous_rubrique to roleclient



	grant update on commande to roleclient
	grant insert on commande to roleclient
	grant select on commande to roleclient

	
	grant update on ligne_de_commande to roleclient
	grant insert on ligne_de_commande to roleclient
	grant delete on ligne_de_commande to roleclient
	grant select on ligne_de_commande to roleclient
go

create role roleconsult
	grant select on produit to roleconsult
	grant select on rubrique to roleconsult
	grant select on sous_rubrique to roleconsult
go

create role rolecommercial
	grant select on produit to rolecommercial
	grant select on rubrique to rolecommercial
	grant select on sous_rubrique to rolecommercial


	grant update on client to rolecommercial
	grant insert on client to rolecommercial
	grant select on client to rolecommercial

	grant update on commande to rolecommercial
	grant insert on commande to rolecommercial
	grant select on commande to rolecommercial

	
	grant update on ligne_de_commande to rolecommercial
	grant insert on ligne_de_commande to rolecommercial
	grant delete on ligne_de_commande to rolecommercial
	grant select on ligne_de_commande to rolecommercial
	
go

grant select on utilisateur to rolecommercial
grant select on utilisateur to rolegestion
grant select on utilisateur to roleclient

grant update on utilisateur to rolecommercial
grant update on utilisateur to roleclient

grant insert on utilisateur to rolecommercial
grant insert on utilisateur to roleclient
go

execute sp_addrolemember 'db_owner','admi'
execute sp_addrolemember 'roleclient','client'
execute sp_addrolemember 'rolegestion','gest'
execute sp_addrolemember 'rolecommercial','comm'
execute sp_addrolemember 'roleconsult','consu'



/* -------------------------------------------------------*/

/* j'ai modifié la table produit directement avec un alter pour rajouter la tva*/
alter table produit
 add tva_id int references tva(tva_id) not null

 /* -------------------------------------------------------*/

/*__________________FOURNISSEUR_______________________________*/
insert into fournisseur (fournisseur_nom) values ('les musicos')
insert into fournisseur (fournisseur_nom) values ('piano and co')
insert into fournisseur (fournisseur_nom) values ('Tout pour la musique')
insert into fournisseur (fournisseur_nom) values ('musique love')
insert into fournisseur (fournisseur_nom) values ('au petit troubadours')
insert into fournisseur (fournisseur_nom) values ('music boulevard')
insert into fournisseur (fournisseur_nom) values ('music stor')
insert into fournisseur (fournisseur_nom) values ('music shop')
insert into fournisseur (fournisseur_nom) values ('La flute de Pan')
insert into fournisseur (fournisseur_nom) values ('gear4Music')

/*___________________TVA______________________________*/

insert into tva(tva_nom,tva_taux) values ('normale',20)
insert into tva(tva_nom,tva_taux) values ('intermédiare',10)
insert into tva(tva_nom,tva_taux) values ('réduite',5.5)
insert into tva(tva_nom,tva_taux) values ('super réduitenormale',2.1)
/*__________________COMMERCIAL_______________________________*/

insert into commercial (commercial_nom,commercial_prenom) values ('DUPONT','paul')
insert into commercial (commercial_nom,commercial_prenom) values ('DUPUIS','pierre')
insert into commercial (commercial_nom,commercial_prenom) values ('BIDOCHON','robert')
insert into commercial (commercial_nom,commercial_prenom) values ('BILOUTE','gustave')
insert into commercial (commercial_nom,commercial_prenom) values ('LENOTRE','robert')
insert into commercial (commercial_nom,commercial_prenom) values ('PICOLO','sam')
insert into commercial (commercial_nom,commercial_prenom) values ('TRINCOT','jean')

/*__________RUBRIQUES_______________________________________*/
insert into rubrique (rubrique_nom) values ('Pianos et claviers')
insert into rubrique (rubrique_nom) values ('Guitares')
insert into rubrique (rubrique_nom) values ('Basse')
insert into rubrique (rubrique_nom) values ('Instruments à vent')
insert into rubrique (rubrique_nom) values ('Batteries')
insert into rubrique (rubrique_nom) values ('Percussions')
insert into rubrique (rubrique_nom) values ('violons et quator')
insert into rubrique (rubrique_nom) values ('Enfant Eveil Musical')
insert into rubrique (rubrique_nom) values ('Accessoires instruments')
insert into rubrique (rubrique_nom) values ('Méthode Partition et tablature')


/*________________SOUS RUBRIQUES_________________________________*/
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Piano acoustique',1) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Piano numérique',1) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Synthétiseur et clavier ',1) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Accordéon électronique ',1) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values (' Accessoire Piano',1) 

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Guitare électrique',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Guitare Folk',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Guitare classique',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Guitare occasion ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Ampli Guitare ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Effet Guitare ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Autres Instruments à corde ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Housse et étui guitare ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values (' Cordes guitare',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Accessoires guitare et basse ',2) 
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Pièces détachées ',2) 

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Basse électrique',3)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Basse électro-acoustique',3)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Basse occasion',3)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Ampli Basse',3)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Effet Basse',3)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Saxophone',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Clarinette',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Haubois',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Flûtes',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Cuivres',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Vent élecctronique',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Harmonica et kazoo',4)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Mélodica',4)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Batterie Acoustique',5)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Batterie Electronique',5)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Cymbale',5)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Peau',5)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Hardware',5)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Accessoires batterie',5)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Cajon',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Conjas',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Bongos',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Djembe et derbouka',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Tambourin',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Shaker Maracas',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Clave Woodblock Triangle',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Cloche',6)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Housses et étuis Percu',6)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Violon',7)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Alto',7)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Violoncelle',7)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Contrebasse',7)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Accessoires violon',7)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Clavier Enfant',8)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Guitare Enfant',8)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Instruments à vent Enfant',8)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Percussion Enfant',8)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Accordeur',9)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Métronome',9)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Pupitre',9)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Goodies',9)

insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Libraireie Piano clavier',10)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Librairie Guitare',10)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Librairie batterie',10)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Librairie violon',10)
insert into sous_rubrique(ss_rubrique_nom,rubrique_id) values ('Librairie vents',10)

/*_________PRODUIT________________________________________
 exemple en booléen
INSERT Boolean(Boolean) VALUES (1);
INSERT Boolean(Boolean) VALUES (0);
INSERT Boolean(Boolean) VALUES ('TRUE');
INSERT Boolean(Boolean) VALUES ('FALSE');
 
SELECT * FROM Boolean
GO
/*    ID Boolean     ModifiedDate
      1     1           2010-10-03
      2     0           2010-10-03
      3     1           2010-10-03
      4     0           2010-10-03 
*/
/* 1-1*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (1,'YAMB1PWH','YAMAHA B1PWH - blanc brillant','1.jpg',2500,1, 3000,'true',1,1,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (2,'YAMB1SG','YAMAHA - B1SG2PE - noir brillant','2.jpg',3000,1, 3500,'true',1,1,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (3,'YAMB1-PEBL','YAMAHA - B1-PE - black','3.jpg',3500,1, 4500,'true',1,2,1)


/* 1-2*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	values (4,'YAMB1PWH','YAMAHA - N3X - laqué noir','4.jpg',14500,1, 18000,'true',2,2,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (5,'ROLGP607','ROLAND GP607 - polished white','5.jpg',3500,1, 5000,'true',2,3,1)




/* 1-6*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (6,'GIB1959','GIBSON Custom Shop Ltd 1959 ','6.jpg',8000,1, 9500,'true',6,4,1)

/* 1-7*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (7,'FENDtrio','FENDER Alkaline Trio Malibu - natural','7.jpg',250,1, 320,'true',7,5,1)

/* 1-17*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (17,'FENDEJAP','FENDER Japan Exclusive Jazz Bass Classic','17.jpg',1000,1, 1250,'true',17,5,1)

/* 1-22*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (22,'LEVSS43','LEVANTE SS4305','22.jpg',450,1, 560,'true',22,5,1)

/* 1-39*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (39,'WAKDJ3335','WAKA DRUMS DJ3335','39.jpg',150,1,179,'true',39,7,1)

insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (45,'HERAS134','HERALD AS134','45.jpg',100,1, 115,'true',45,9,1)

/*nouveaux produits 7 mars 2017*/
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (8,'IB1027PBF','IBANEZ Premium  CBB - cerulean blue burst','8.jpg',1000,1, 1299,'true',6,1,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (9,'IBJS24P','IBANEZ Joe Satriani CA Premium - Candy Apple - candy apple','9.jpg',1050,1,1329,'true',6,1,1)

insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (10,'IBPG80PNT','IBANEZ Paul Gilbert  NT Premium Artist - natural','10.jpg',1025,1,1259,'true',6,1,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (11,'IB1027PBF','IBANEZ Steve Vai  BK Premium - black','11.jpg',1075,1, 1353,'true',6,1,1)


insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (12,'TAY114CE','TAYLOR 114ce-N Walnut ','12.jpg',800,1, 899,'true',8,2,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (13,'TAY214CE','TAYLOR 214CE-N Grand Auditorium - natural gloss top','13.jpg',1075,1, 1353,'true',8,2,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (14,'GOMULSG','GODIN Multiac Nylon Encore - natural semi gloss','14.jpg',1000,1, 1059,'true',8,3,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (15,'IB1027PBF','IBANEZ Steve Vai  BK Premium - black','15.jpg',1105,1, 1199,'true',8,3,1)


insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (16,'SMLCL400','Clarinette Etude SML CL400','16.jpg',200,1, 279,'true',23,4,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (18,'YACL450N','Clarinette Etude YAMAHA YCL-450N 02','18.jpg',625,1, 769,'true',23,4,1)


insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (19,'STAEVN','Violon Electrique STAGG EVN 4/4 MBL','19.jpg',125,1, 181,'true',45,10,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (20,'STAGGVNC34','Violoncelle acoustique STAGG VNC-3/4','20.jpg',300,1, 389,'true',47,10,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (21,'STAGGECL44','Violoncelle electrique STAGG ECL4/4 BK','21.jpg',600,1, 699,'true',47,10,1)
/*_______________________________________________*/

insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (23,'KURKA90','Clavier arrangeur KURZWEIL KA-90','23.jpg',500,1, 599,'true',3,5,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (24,'WALBLOKB','Synthetiseur WALDORF Blofeld Keyboard','24.jpg',560,1, 629,'true',3,6,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (25,'STUSLE20','Synthetiseur STUDIOLOGIC Sledge 2.0','25.jpg',650,1, 753,'true',3,6,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (26,'GEWMONALHW','GEWA OM. MONNICH ALTO HW','26.jpg',175,1, 205,'true',46,6,1)


insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (27,'ROLFR4XRD','Accordeon numerique ROLAND FR-4X-RD','27.jpg',2500,1, 3799,'true',4,5,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (28,'ROLFR8XBK','Accordeon numerique ROLAND FR-8XB BK','28.jpg',3800,1, 5099,'true',4,5,1)

insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (29,'WOPAP1','WOODBRASS Pack accessoires piano','29.jpg',25,1, 39,'true',5,5,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (30,'WOSSKST30','WOODBRASS Support Synthétiseur KST30','30.jpg',18,1, 23,'true',5,5,1)
insert into produit(produit_id,produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id)
	 values (31,'GIBL200','GIBSON Emmylou Harris L-200- Occasion','31.jpg',1000,1, 2100,'true',9,3,1)

/*__________________________________________________*/
























/*___________CLIENT____________________________________*/
insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (1,1,'SKYWALKER','luc',5,'2 rue des etoiles', '80000', 'AMIENS',1)

insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (2,1,'KENOBI','obiwan',0,'5 avenue des constellations','80000', 'AMIENS',1)

insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (3,1,'ORGANA','leia',10,'6 boulevard étoilé', '75000', 'PARIS',2)

insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (4,2,'FETT','boba',0,'67 rue des clones', '76000', 'ROUEN',3)

insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (5,2,'LE HUNT','Jabba',5,'36 rue des affaires', '80000', 'AMIENS',4)

insert into client (client_id,client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id)
	values (6,2,'PALPATINE','Sheev',0,'21 rue des empereurs', '80100', 'ABBEVILLE',5)



/*___________COMMANDE______________________________________*/
insert into commande (client_id,commande_etat, commande_reduc,commande_reglt,commande_date,commande_paye, 
	livraison_adr,livraison_cp,livraison_ville,facture_id,facture_adre,facture_cp,facture_ville, facture_date,facture_montant)
values ( 1, 'saisie', 0, '01/01/2017', '01/01/2017', 'true', '2 rue des etoiles','80000', 'AMIENS',1,'2 rue des etoiles', '80000', 'AMIENS','01/01/2017',10000)

insert into commande (client_id,commande_etat, commande_reduc,commande_reglt,commande_date,commande_paye, 
	livraison_adr,livraison_cp,livraison_ville,facture_id,facture_adre,facture_cp,facture_ville, facture_date,facture_montant)
values ( 2, 'livrée', 0, '11/01/2017', '11/01/2017', 'true', '5 avenue des constellations','80000', 'AMIENS',2,'5 avenue des constellations','80000', 'AMIENS','11/01/2017',20000)


insert into commande (client_id,commande_etat, commande_reduc,commande_reglt,commande_date,commande_paye, 
	livraison_adr,livraison_cp,livraison_ville,facture_id,facture_adre,facture_cp,facture_ville, facture_date,facture_montant)
values ( 3, 'livrée', 0, '16/01/2017', '16/01/2017', 'true', '6 boulevard étoilé', '75000', 'PARIS',3,'6 boulevard étoilé', '75000','PARIS','16/01/2017',30000)



/*____________LIGNE_COMMANDE______________________________*/
insert into ligne_de_commande 	(lignecom_qte,prix_fixe,commande_id,produit_id)
						values 	(1,3000,1,1)
insert into ligne_de_commande 	(lignecom_qte,prix_fixe,commande_id,produit_id)
						values 	(1,9500,2,6)
insert into ligne_de_commande 	(lignecom_qte,prix_fixe,commande_id,produit_id)
						values 	(2,320,2,7)

insert into ligne_de_commande 	(lignecom_qte,prix_fixe,commande_id,produit_id)
						values 	(1,115,3,45)
insert into ligne_de_commande 	(lignecom_qte,prix_fixe,commande_id,produit_id)
						values 	(3,1250,3,17)


												)


/*_____________BON_LIVRAISON____________________________________*/
insert into bon_livraison (livraison_date,commande_id)
	values ('13/01/2017',2)

insert into bon_livraison (livraison_date,commande_id)
	values ('17/01/2017',3)
insert into bon_livraison (livraison_date,commande_id)
	values ('18/01/2017',3)

)

/*______________LIGNE_LIVRAISON___________________________________*/


insert into ligne_de_livraison(ligneliv_qte,livraison_id,produit_id)
	values(1,1,6)

insert into ligne_de_livraison(ligneliv_qte,livraison_id,produit_id)
	values(2,1,7)
insert into ligne_de_livraison(ligneliv_qte,livraison_id,produit_id)
	values(1,2,45)

insert into ligne_de_livraison(ligneliv_qte,livraison_id,produit_id)
	values(3,3,17)




/*__________SAUVEGARDE___*/

exec sp_addumpdevice 'disk','savfilrouge','\\serveur\DL\Thierry\FIL ROUGE\SAUVEGARDEBDD\villagegreen.bak'


backup database villagegreen to savfilrouge

restore database villagegreen from savfilrouge with replace














