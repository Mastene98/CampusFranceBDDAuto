Feature: Création de compte Campus France Etudiant

A short summary of the feature

@tag1
Scenario: [ Remplir le formulaire de création de compte étudiant ]
	Given [je suis sur la page de creation de compte Campus France]
	When [je charge les données du profil etudiant depuis le fichier Data_Etudiants.json]
    And [je renseigne les champs l email , le mot de passe, et je le re confirme]
    And [je renseigne le btn du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]
    And [je renseigne le pays de nationalite, j'ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]
    And [je renseigne le code postal, la ville et le numero de telephone ]
    And [je coche la case Etudiant, je choisis dans la lsite domaine d etudes et niveau d etude ]
    And [j'accepte la confidentialite des données ]
	Then [le formulaire de creation de compte étudiant doit etre correctement rempli]
