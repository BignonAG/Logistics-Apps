1. Importer le projet en local et bosser dessus
	* Ouvrir git bash dans un nouveau puis executer cette commande : git clone ##

2. Une fois projet pour commencer il faut à chaque fois créer une nouvelle branche sur laquelle développer chaque fonctionalié 
	* Commande : git checkout -b <nom-de-la-branche>. 
	* Ex: pour créer une formulaire d'ajout de produit, il faut créer une branche create-product : git checkout -b create-product
	* Une fois le developper demander un pull request dans azure devOops 

3. Installation du projet 
	* Ouvrir le projet dnas visual studio
	* Télécharger node js https://nodejs.org/en/download/
	* lancer node js prompt commande 
	* Se placer dans le dossier clientAp: cd pyvvo/pyvvoo_logistics/clientApp
	* Lancer la commande: npm install
	* Tester que le projet demare correctement
	
4. Installation du framework nebular: npm install -g @angular/cli
	* Configuerer d'abord le format scss:
		=> Rajouter dans le fichier angular.json ou voir https://medium.com/@manivel45/configuring-angular-7-project-with-sass-bootstrap-and-angular-material-design-69b0f033dc04
			"schematics": {
				  "@schematics/angular:component": {
				  "styleext": "scss"
				}
			}
	*Dans ClientApp/src Modifier l'extension du fichier "style.css" en "style.scss"  puis rajouter dans angular.json le style en scss dans "styles"
	*Installer nebular: ng add @nebular/theme
	*Importer les module nebular dnas app.module.ts avant utilisation dans le projet

5. Developpement angular 
	* Pour creer un nouveau component
		=> dans clientApp : ng g c --module=app --skipTests=true <nom-de-component>
	* Pour créer un service 
		=> ng generate service <nom-service> --skipTests=true
	
	


