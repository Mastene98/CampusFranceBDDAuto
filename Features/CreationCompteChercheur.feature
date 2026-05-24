Feature: Création de compte Campus France Chercheur

A short summary of the feature

@tag1
Scenario: [ Remplir le formulaire de création de compte chercheur ]
	Given [je suis sur la pagee de création de compte Campus France]
	When [je charge les données du profil chercheur depuis le fichier Data_Chercheurs.json]
    And [je renseigne les champs lee mail , le mot de passe, et je le re confirme]
    And [je renseigne le bouton du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]
    And [je renseigne le pays de nationalite, j ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]
    And [je renseigne le code postal, la ville et le n telephone ]
    And [je coche la case Chercheur, je choisis dans la lsite domaine d etudes et niveau d etude ]
    And [j accepte la confidentialite des donnee ]
	Then [le formulaire de creation de compte chercheur doit etre correctement rempli]

