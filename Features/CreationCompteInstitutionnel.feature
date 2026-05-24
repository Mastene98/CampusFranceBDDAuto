Feature: Création de compte Campus France Institutionnel

A short summary of the feature

@tag1
Scenario: [ Remplir le formulaire de création de compte institutionnel ]
	Given [je suis sur la page de creeation de compte Campus France]
	When [je charge les données du profil institutionnel depuis le fichier Data_Institutionnel.json]
    And [je renseignee les champs l email , le mot de passe, et je le re confirme]
    And [je renseignee le btn du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]
    And [je renseigne le pays de nationalité, j ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]
    And [je renseignee le code postal, la ville et le numero de telephone ]
    And [je coche la case Institutionnel, je renseigne la fonction, je choisis le type d organisme dans la liste et je renseigne son nom ]
    And [j acceptee la confidentialite des donnees ]
	Then [le formulaire de creation de compte Institutionnel doit etre correctement rempli]
