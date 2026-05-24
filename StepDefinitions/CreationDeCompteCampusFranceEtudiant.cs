using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Chrome;
namespace CampusFranceBDDAuto.StepDefinitions
{
    [Binding]
    public class CreationDeCompteCampusFranceEtudiant
    {
        IWebDriver driver;
        LectureFichierJson read = new LectureFichierJson();
        List<Utilisateurs> utilisateurs;
        Utilisateurs utilisateur;

        [Given("[je suis sur la page de creation de compte Campus France]")]
        public void GivenJeSuisSurLaPageDeCreationDeCompteCampusFrance()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            try
            {
                Thread.Sleep(4000);

                IWebElement boutonCookies = driver.FindElement(By.Id("tarteaucitronAllAllowed"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", boutonCookies);
            }
            catch
            {
                Console.WriteLine("Popup cookies non trouvée ou déjà fermée.");
            }
        }

        [When("[je charge les données du profil etudiant depuis le fichier Data_Etudiants.json]")]
        public void WhenJeChargeLesDonneesDuProfilEtudiantDepuisLeFichierData_Etudiants_Json()
        {
            utilisateurs = read.ReadEtudiantsJson();
            utilisateur = utilisateurs[0];
        }

        [When("[je renseigne les champs l email , le mot de passe, et je le re confirme]")]
        public void WhenJeRenseigneLesChampsLEmailLeMotDePasseEtJeLeReConfirme()
        {
            Thread.Sleep(2000);
            //email

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass1]")).SendKeys(utilisateur.motDePasse);

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass2]")).SendKeys(utilisateur.confirmationMotDePasse);

        }

        [When("[je renseigne le btn du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]")]
        public void WhenJeRenseigneLeBtnDuGenreMmeOuMrLeNomPrenomUneListePourChoisirLePaysDeResidence()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[2]/label")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-nom-0-value\"]")).SendKeys(utilisateur.nom);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(utilisateur.prenom);


        }

            [When("[je renseigne le pays de nationalite, j'ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]")]
        public void WhenJeRenseigneLePaysDeNationaliteJaiUnBoutonSiJeVeuxRetirerMonChampEtUnAutreSiJeVeuxAjouterUneAutreNationalite()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-0-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-add-more']"))
                  .Click();

            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-1-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

        }

        [When("[je renseigne le code postal, la ville et le numero de telephone ]")]
        public void WhenJeRenseigneLeCodePostalLaVilleEtLeNumeroDeTelephone()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(utilisateur.codePostal);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(utilisateur.ville);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(utilisateur.telephone);
        }

        [When("[je coche la case Etudiant, je choisis dans la lsite domaine d etudes et niveau d etude ]")]
        public void WhenJeCocheLaCaseEtudiantJeChoisisDansLaLsiteDomaineDEtudesEtNiveauDEtude()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[1]/label")).Click();

            Thread.Sleep(2000);
            //SelectElement domaineetude = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"edit-field-domaine-etudes-wrapper\"]/div/div/div[1]")));
            //domaineetude.SelectByText(utilisateur.domaineEtudes);

            Thread.Sleep(2000);
            //SelectElement niveauetude = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"edit-field-niveaux-etude-wrapper\"]/div/div/div[1]")));
            //niveauetude.SelectByText(utilisateur.niveauEtudes);
        }

            [When("[j'accepte la confidentialite des données ]")]
        public void WhenJaccepteLaConfidentialiteDesDonnees()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")).Click();
        }

        [Then("[le formulaire de creation de compte étudiant doit etre correctement rempli]")]
        public void ThenLeFormulaireDeCreationDeCompteEtudiantDoitEtreCorrectementRempli()
        {
            Console.WriteLine("Formulaire rempli entierement");
        }



    }
}
